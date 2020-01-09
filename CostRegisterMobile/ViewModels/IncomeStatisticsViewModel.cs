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

        public override void RefreshPage()
        {
            IncomeStatisticsList = Repo.IncomeRepository
                        .GetAll()
                        .OrderByDescending(d => d.DateOFIncome);
        }

        protected override async Task ExecuteDeleteAsync()
        {
            Busy();

            if (await MessageBoxService.ShowConfirmation(AppResources.TextConfirmFormDelete))
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
