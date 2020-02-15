using CostRegisterMobile.Services;
using CostRegisterMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CostRegisterMobile.ViewModels
{
    public class CostsViewModel : BaseViewModel
    {
        private string _selectedCategory;
        private string _selectedShop;
        private int _actualCost;
        private DateTime _date = DateTime.Today;
        private string _additionalInformations;
        private bool _isPreviouslyPlannedToggled = false;
        private List<PlanCostModel> _listOfPlans;
        private string _selectedPlan;
        private List<string> _listOfPlanNames;
        private PlanCostModel _selectedPlanRecord;

        public IEnumerable<string> Categories
            => Repo.CategoryRepository.ReadCategory();

        public IEnumerable<string> Shops 
            => Repo.ShopRepository.ReadShops();

        public PlanCostModel SelectedPlanRecord
        {
            get => _selectedPlanRecord;
            set => SetProperty(ref _selectedPlanRecord, value);
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                SetProperty(ref _selectedCategory, value);
                if (value == AppResources.Others || value == AppResources.Overhead || value == AppResources.Rental)
                {
                    SelectedShop = AppResources.CostNotInShop;
                }
                RefreshCanExecute();
            }
        }

        public string SelectedShop
        {
            get => _selectedShop;
            set
            {
                SetProperty(ref _selectedShop, value);
                RefreshCanExecute();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                SetProperty(ref _date, value);
                RefreshCanExecute();
            }
        }

        public int ActualCost
        {
            get => _actualCost;
            set
            {
                SetProperty(ref _actualCost, value);
                RefreshCanExecute();
            }
        }

        public string AdditionalInformations
        {
            get => _additionalInformations;
            set => SetProperty(ref _additionalInformations, value);
        }

        public bool IsPreviouslyPlannedToggled
        {
            get => _isPreviouslyPlannedToggled;
            set
            {
                SetProperty(ref _isPreviouslyPlannedToggled, value);

                if (_isPreviouslyPlannedToggled)
                {
                    FillPreviousPlans();
                }
                else
                {
                    ResetSettingsOfPreviousPlans();
                }
            }
        }


        public List<PlanCostModel> ListOfPlans
        { 
            get => _listOfPlans; 
            set => SetProperty(ref _listOfPlans, value); 
        }

        public List<string> ListOfPlanNames 
        { 
            get => _listOfPlanNames; 
            set => SetProperty(ref _listOfPlanNames, value); 
        }

        public string SelectedPlan
        {
            get => _selectedPlan;
            set
            {
                SetProperty(ref _selectedPlan, value);

                if (_selectedPlan != null)
                {
                    SelectedPlanRecord = ListOfPlans.FirstOrDefault(pl => pl.TypeOfCostPlan.Equals(SelectedPlan));
                    RefreshForm();
                }
            }
        }

        protected override bool CanExecute()
        {
            var canExecute = _actualCost > 0
                && _selectedCategory != null
                && _selectedShop != null;

            return canExecute;
        }

        protected override async Task ExecuteDeleteAsync()
        {
            bool whetherDelete = await MessageBoxService.ShowConfirmation(AppResources.TextConfirmFormDelete, AppResources.TitleWarning, AppResources.ButtonCancel);

            if (whetherDelete)
            {
                DeleteForm();
            }
        }

        private void DeleteForm()
        {
            ActualCost = 0;
            SelectedCategory = null;
            SelectedShop = null;
            AdditionalInformations = string.Empty;
        }

        public override void RefreshPage()
        {
            GuiInformation = AppResources.UiInformationAboutNewShop;
            FillPreviousPlans();
            base.RefreshPage();
        }

        protected override async Task ExecuteSaveAsync()
        {
            Busy();

            try
            {
                Repo.CostsRepository.Create(GetCostModelObject().Map());

                if (SelectedPlanRecord != null)
                {
                    var confirmDelete = await MessageBoxService.ShowConfirmation(
                        $"{AppResources.DialogConfirmDeletePlan}{Environment.NewLine}{SelectedPlanRecord.TypeOfCostPlan}{Environment.NewLine}{SelectedPlanRecord.CategoryName}",
                        AppResources.TitleWarning,
                        AppResources.ButtonCancel);

                    if (confirmDelete)
                    {
                        Repo.PlansRepository.Delete(SelectedPlanRecord.ID);
                    }
                }

                await Repo.CommitAsync();
            }
            catch (Exception)
            {
                await MessageBoxService.ShowMessage(AppResources.TextError, AppResources.TitleError);

                NotBusy();
                return;
            }

            await MessageBoxService.ShowMessage(AppResources.TextSaveSuccess, AppResources.TitleSuccess);

            DeleteForm();
            UpdateBalance();
            FillPreviousPlans();
            SelectedPlanRecord = null;
            NotBusy();
        }

        private CostsModel GetCostModelObject()
        {
            var cmodel = new CostsModel
            {
                ShopName = _selectedShop,
                CategoryName = _selectedCategory,
                AmountOfCost = _actualCost,
                DateOfCost = _date,
                AdditionalInformation = _additionalInformations
            };

            return cmodel;
        }

        private void FillPreviousPlans()
        {
            ListOfPlans = Repo.PlansRepository.ReadAllPlanCost().ToList();
            ListOfPlanNames = ListOfPlans.Select(names => names.TypeOfCostPlan).ToList();
        }

        private void RefreshForm()
        {
            SelectedCategory = SelectedPlanRecord.CategoryName;
            AdditionalInformations = SelectedPlanRecord.PlanAdditionalInformation;
            ActualCost = SelectedPlanRecord.CostPlanned;
        }

        private void ResetSettingsOfPreviousPlans()
        {
            SelectedPlanRecord = null;
            SelectedPlan = null;

            DeleteForm();
        }
    }
}