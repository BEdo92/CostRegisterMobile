using CostRegisterMobile.EntityModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostRegisterMobile.ViewModels
{
    class IncomeStatisticsViewModel : StatisticsBaseViewModel<Income>
    {
        private IEnumerable<Income> _incomeStatisticsList;

        public IEnumerable<Income> IncomeStatisticsList
        {
            get => _incomeStatisticsList;
            set
            {
                SetProperty(ref _incomeStatisticsList, value);
                RefreshCanDelete();
            }
        }

        protected override void RefreshList()
        {
            IncomeStatisticsList = Repo.IncomeRepository
                          .GetAll()
                          .Where(c =>
                          {
                              if (!string.IsNullOrWhiteSpace(TextToFilterBy))
                              {
                                  return c.TypeOfIncome.Contains(TextToFilterBy);
                              }

                              return true;
                          })
                          .OrderByDescending(d => d.DateOFIncome);

            Notifications = IncomeStatisticsList.Any() ? string.Empty : AppResources.NotificationsNoStatData;
        }

        protected override async Task ExecuteDeleteAsync()
        {
            Busy();

            if (await DialogService.ShowConfirmation(AppResources.TextConfirmFormDelete, AppResources.TitleWarning, AppResources.ButtonCancel))
            {
                Repo.IncomeRepository.Delete(SelectedRecord.IncomeID);
                await Repo.CommitAsync();

                SelectedRecord = null;
                IncomeStatisticsList = Repo.IncomeRepository.GetAll();
            }

            NotBusy();
        }
    }
}
