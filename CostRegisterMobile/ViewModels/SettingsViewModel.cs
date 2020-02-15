using CostRegisterMobile.EntityModels;
using CostRegisterMobile.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CostRegisterMobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private string _nameOfNewShop;
        private string _selectedCategory = null;
        private string _newCategory;
        private bool _involvePlans = true;
        private IEnumerable<string> _categories;

        private ICommand _deleteDatabaseCommand;

        public IEnumerable<string> Categories
        {
            get => _categories ??= Repo.CategoryRepository.ReadCategory();
            set => SetProperty(ref _categories, value);
        }

        public string NewCategory
        {
            get => _newCategory;
            set => SetProperty(ref _newCategory, value);
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public string NameOfNewShop
        {
            get => _nameOfNewShop;
            set => SetProperty(ref _nameOfNewShop, value);
        }

        public bool InvolvePlans
        {
            get => _involvePlans;
            set => SetProperty(ref _involvePlans, value);
        }
        public ICommand DeleteDatabaseCommand => _deleteDatabaseCommand ??= new Command(async () => await DeleteUserDatasFromDatabase());
        
        protected override bool CanExecute()
        {
            return true;
        }

        protected override async Task ExecuteSaveAsync()
        {
            Busy();

            var whetherSave = await DialogService.ShowConfirmation(AppResources.TextConfirmChangeSettings, AppResources.TitleWarning, AppResources.ButtonCancel);

            if (whetherSave)
            {
                await SaveChangesOfSettingsAsync();
            }

          NotBusy();
        }

        private async Task SaveChangesOfSettingsAsync()
        {
            bool isAnythingSaved;
            try
            {
                isAnythingSaved = await AddingShopAsync()
                                  || await AddingCategoryAsync()
                                  || DeletingCategory()
                                  || SettingInvolvePlans();

                if (!isAnythingSaved)
                {
                    await DialogService.ShowMessage(AppResources.TextSettingsAlreadyMatch, AppResources.TitleMessage);
                    return;
                }

                await Repo.CommitAsync();
            }
            catch (Exception)
            {
                await DialogService.ShowMessage(AppResources.TextError, AppResources.TitleError);
                return;
            }

            await DialogService.ShowMessage(AppResources.TextSaveSuccess, AppResources.TitleSuccess);

            Categories = Repo.CategoryRepository.ReadCategory();
            UpdateBalance();
        }

        private async Task<bool> AddingShopAsync()
        {
            if (string.IsNullOrWhiteSpace(_nameOfNewShop))
            {
                return false;
            }
            var shop = Repo.ShopRepository.GetShopByName(_nameOfNewShop);

            if (shop is null)
            {
                Repo.ShopRepository.Create(new Shops
                {
                    ShopName = _nameOfNewShop
                });
            }
            else
            {
                await DialogService.ShowMessage(AppResources.TextShopAlreadyExists, AppResources.TitleWarning);
                return false;
            }
            return true;
        }

        private async Task<bool> AddingCategoryAsync()
        {
            if (string.IsNullOrWhiteSpace(_newCategory))
            {
                return false;
            }

            if (!Categories.Contains(_newCategory))
            {
                Repo.CategoryRepository.Create(new Category
                {
                    CategoryName = _newCategory
                });
            }
            else
            {
                await DialogService.ShowMessage(AppResources.TextCategoryAlreadyExists, AppResources.TitleWarning);
                return false;
            }
            return true;
        }

        private bool DeletingCategory()
        {
            if (!string.IsNullOrWhiteSpace(_selectedCategory))
            {
                Repo.CategoryRepository
                    .Delete(Repo.CategoryRepository
                    .GetIdFromCategoryName(_selectedCategory));

                return true;
            }
            return false;
        }

        private bool SettingInvolvePlans()
        {
            bool formerlyInvolvedPlans = Repo.SettingsRepository.GetById(1).SettingMode == (int)BalanceSettingsModeEnum.WithPlans;
            if (InvolvePlans && !formerlyInvolvedPlans)
            {
                Repo.SettingsRepository.Update(1, (int)BalanceSettingsModeEnum.WithPlans);
                return true;
            }
            else if ((InvolvePlans && formerlyInvolvedPlans) || (!InvolvePlans && !formerlyInvolvedPlans))
            {
                return false;
            }
            else
            {
                Repo.SettingsRepository.Update(1, (int)BalanceSettingsModeEnum.WithoutPlans);
                return true;
            }          
        }

        protected override void RefreshCanExecute()
        {
            (DeleteCommand as Command)?.ChangeCanExecute();
        }

        protected override async Task ExecuteDeleteAsync()
        {
            bool whetherDelete = await DialogService.ShowConfirmation(AppResources.TextConfirmFormDelete,AppResources.TitleWarning, AppResources.ButtonCancel);

            if (whetherDelete)
            {
                NameOfNewShop = string.Empty;
                NewCategory = string.Empty;
                SelectedCategory = null;
            }
        }

        private async Task DeleteUserDatasFromDatabase()
        {
            bool whetherDelete = await DialogService.ShowConfirmation(AppResources.TextConfirmDeleteDatabase, AppResources.TitleWarning, AppResources.ButtonCancel);

            if (whetherDelete)
            {
                Repo.IncomeRepository.DeleteAllUserDatas();
                Repo.CostsRepository.DeleteAllUserDatas();
                Repo.PlansRepository.DeleteAllUserDatas();

                await Repo.CommitAsync();
            }
        }

    }
}