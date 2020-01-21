using CostRegisterMobile.EntityModels;
using System;
using System.Threading.Tasks;

namespace CostRegisterMobile.ViewModels
{
    public class IncomeViewModel : BaseViewModel
    {
        private string _titleOfIncome;
        private int _actualIncome;
        private DateTime _date = DateTime.Today;
        private string _additionalInformations;

        public DateTime Date
        {
            get => _date;
            set
            {
                SetProperty(ref _date, value);
                RefreshCanExecute();
            }
        }

        public int ActualIncome
        {
            get => _actualIncome;
            set
            {
                SetProperty(ref _actualIncome, value);
                RefreshCanExecute();
            }
        }

        public string AdditionalInformations
        {
            get => _additionalInformations;
            set => SetProperty(ref _additionalInformations, value);
        }

        public string TitleOfIncome
        {
            get => _titleOfIncome;
            set
            {
                SetProperty(ref _titleOfIncome, value);
                RefreshCanExecute();
            }
        }

        protected override bool CanExecute()
        {
            var canExecute = _actualIncome > 0 && !string.IsNullOrWhiteSpace(_titleOfIncome);

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
            TitleOfIncome = string.Empty;
            ActualIncome = 0;
            AdditionalInformations = string.Empty;
        }

        protected override async Task ExecuteSaveAsync()
        {
            Busy();

            try 
            { 
                Repo.IncomeRepository.Create(GetInstanceOfIncome());
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

        private Income GetInstanceOfIncome()
        {
            return new Income
            {
                AmountOfIncome = _actualIncome,
                DateOFIncome = _date,
                TypeOfIncome = _titleOfIncome,
                IncomeAdditionalInformation = _additionalInformations
            };
        }
    }
}


