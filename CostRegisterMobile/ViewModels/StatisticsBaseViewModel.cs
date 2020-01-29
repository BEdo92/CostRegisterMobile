using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CostRegisterMobile.ViewModels
{
    public class StatisticsBaseViewModel<T> : BaseViewModel where T : class
    {
        private ICommand _showAllCommand;
        private ICommand _showSpecificCommand;
        private ICommand _deleteCommand;
        private T _selectedRecord;
        private string _selectedListItem;
        private string _notifications = null;

        public new ICommand DeleteCommand =>
            _deleteCommand ??= new Command(async () => await ExecuteDeleteAsync(), CanDeleteBeEnabled);

        public T SelectedRecord
        {
            get => _selectedRecord;
            set
            {
                SetProperty(ref _selectedRecord, value);
                RefreshCanDelete();
            }
        }

        public ICommand ShowAllCommand =>
            _showAllCommand ??= new Command(ShowCosts);

        public ICommand ShowSpecificCommand =>
            _showSpecificCommand ??= new Command(ShowSpecificCosts);

        public string SelectedListItem
        {
            get => _selectedListItem; 
            set => SetProperty(ref _selectedListItem, value); 
        }
        public string Notifications 
        { 
            get => _notifications; 
            set => SetProperty(ref _notifications, value); 
        }

        protected bool CanDeleteBeEnabled()
        {
            return SelectedRecord != null;
        }

        protected void RefreshCanDelete()
        {
            (DeleteCommand as Command)?.ChangeCanExecute();
        }

        protected override Task ExecuteDeleteAsync()
        {
            throw new NotImplementedException();
        }

        protected override Task ExecuteSaveAsync()
        {
            throw new NotImplementedException();
        }

        public override void RefreshPage()
        {
            RefreshList();
        }

        protected virtual void RefreshList() { }

        protected virtual void ShowSpecificCosts()
        {
            RefreshList();
        }

        protected virtual void ShowCosts()
        {
            SelectedListItem = null;
            RefreshList();
        }
    }
}
