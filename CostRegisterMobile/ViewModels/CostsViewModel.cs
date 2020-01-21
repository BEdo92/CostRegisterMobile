using CostRegisterMobile.Helpers;
using CostRegisterMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CostRegisterMobile.ViewModels
{
    public class CostsViewModel : BaseViewModel
    {
        private string _selectedCategory;
        private string _selectedShop;
        private int _actualCost;
        private DateTime _date = DateTime.Today;
        private string _additionalInformations;

        public IEnumerable<string> Categories
            => Repo.CategoryRepository.ReadCategory();

        public IEnumerable<string> Shops 
            => Repo.ShopRepository.ReadShops();

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
            base.RefreshPage();
        }

        protected override async Task ExecuteSaveAsync()
        {
            Busy();

            try
            {
                Repo.CostsRepository.Create(GetCostModelObject().Map());
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
    }
}