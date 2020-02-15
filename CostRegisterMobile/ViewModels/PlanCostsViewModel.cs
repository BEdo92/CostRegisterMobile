using CostRegisterMobile.Services;
using CostRegisterMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CostRegisterMobile.ViewModels
{
    public class PlanCostsViewModel : BaseViewModel
    {
        private string _selectedCategory = null;
        private int _plannedCost;
        private string _additionalInformations;
        private string _titleOfPlannedCost;

        public IEnumerable<string> Categories =>
            Repo.CategoryRepository.ReadCategory();

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                SetProperty(ref _selectedCategory, value);
                RefreshCanExecute();
            }
        }

        public int PlannedCost
        {
            get => _plannedCost;
            set
            {
                SetProperty(ref _plannedCost, value);
                RefreshCanExecute();
            }
        }

        public string AdditionalInformations
        {
            get => _additionalInformations;
            set => SetProperty(ref _additionalInformations, value);
        }

        public string TitleOfPlannedCost
        {
            get => _titleOfPlannedCost;
            set
            {
                SetProperty(ref _titleOfPlannedCost, value);
                RefreshCanExecute();
            }
        }

        protected override bool CanExecute()
        {
            var canExecute = !string.IsNullOrWhiteSpace(_titleOfPlannedCost)
                && _plannedCost > 0
                && _selectedCategory != null;

            return canExecute;
        }

        protected override async Task ExecuteDeleteAsync()
        {
            bool whetherDelete = await DialogService.ShowConfirmation(AppResources.TextConfirmFormDelete, AppResources.TitleWarning, AppResources.ButtonCancel);

            if (whetherDelete)
            {
                DeleteForm();
            }
        }

        private void DeleteForm()
        {
            PlannedCost = 0;
            SelectedCategory = null;
            TitleOfPlannedCost = string.Empty;
            AdditionalInformations = string.Empty;
        }

        protected override async Task ExecuteSaveAsync()
        {
            Busy();

            try
            { 
                Repo.PlansRepository.Create(GetCostPlansModel().Map());
                await Repo.CommitAsync();
            }
            catch (Exception)
            {
                await DialogService.ShowMessage(AppResources.TextError, AppResources.TitleError);

                NotBusy();
                return;
            }

            await DialogService.ShowMessage(AppResources.TextSaveSuccess, AppResources.TitleSuccess);

            UpdateBalance();
            DeleteForm();
            NotBusy();
        }

        private PlanCostModel GetCostPlansModel()
        {
            var cpmodel = new PlanCostModel
            {
                CategoryName = _selectedCategory,
                CostPlanned = _plannedCost,
                TypeOfCostPlan = _titleOfPlannedCost,
                PlanAdditionalInformation = _additionalInformations
            };

            return cpmodel;
        }
    }
}