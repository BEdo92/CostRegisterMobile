using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using CostRegisterMobile.Repositories;
using CostRegisterMobile.Services;
using System.Threading.Tasks;
using CostRegisterMobile.Models;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace CostRegisterMobile.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private ICommand _saveCommand;
        private ICommand _deleteCommand;

        private string _balance;
        private bool _isBusy = false;
        private string _guiInformation;

        public ICommand DeleteCommand =>
            _deleteCommand ??= new Command(async () => await ExecuteDeleteAsync());

        public ICommand SaveCommand =>
            _saveCommand ??= new Command(async () => await ExecuteSaveAsync(), CanExecute);

        public IDialogService DialogService =>
            DependencyService.Get<IDialogService>();

        public BalanceModel BalanceModel =>
            DependencyService.Get<BalanceModel>();

        public IUnitOfWork Repo =>
            DependencyService.Get<IUnitOfWork>();

        public string Balance
        {
            get => _balance;
            set => SetProperty(ref _balance, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public string GuiInformation
        { 
            get => _guiInformation; 
            set => SetProperty(ref _guiInformation, value); 
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);

            return true;
        }

        public virtual void RefreshPage()
        {
            UpdateBalance();
        }

        protected void UpdateBalance()
        {
            Balance = BalanceModel.BalanceString;
        }

        public virtual void HidePage()
        {
        }

        protected virtual void Busy()
        {
            IsBusy = true;
        }

        protected virtual void NotBusy()
        {
            IsBusy = false;
        }

        protected abstract Task ExecuteDeleteAsync();

        protected virtual void RefreshCanExecute()
        {
            (SaveCommand as Command)?.ChangeCanExecute();
        }

        protected abstract Task ExecuteSaveAsync();

        protected virtual bool CanExecute()
        {
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}