using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CostRegisterMobile.ViewModels
{
    public class StatisticsBaseViewModel<T> : BaseViewModel where T : class
    {
        private ICommand _deleteCommand;
        private T _selectedRecord;

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
    }
}
