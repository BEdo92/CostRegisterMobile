using CostRegisterMobile.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostRegisterMobile.ViewModels
{
    class CostStatisticsViewModel : StatisticsBaseViewModel<CostsStatisticsModel>
    {
        private IEnumerable<CostsStatisticsModel> _costStatisticsList;

        public IEnumerable<string> Categories
           => Repo.CategoryRepository.ReadCategory();

        public IEnumerable<CostsStatisticsModel> CostStatisticsList
        {
            get => _costStatisticsList; 

            set
            {
                SetProperty(ref _costStatisticsList, value);
                RefreshCanDelete();
            }
        }

        protected override void RefreshList()
        {
            CostStatisticsList = Repo.CostsRepository
                        .ReadCostsToStatModel()
                        .Where(c =>
                        {
                            if (!string.IsNullOrWhiteSpace(SelectedListItem))
                            {
                                return c.Category.Equals(SelectedListItem);
                            }

                            return true;
                        })
                        .OrderByDescending(d => d.DateTime);

            Notifications = CostStatisticsList.Any() ? string.Empty : AppResources.NotificationsNoStatData;
        }

        protected override async Task ExecuteDeleteAsync()
        {
            Busy();
            if (await DialogService.ShowConfirmation(AppResources.TextConfirmDeleteData, AppResources.TitleWarning, AppResources.ButtonCancel))
            {
                Repo.CostsRepository.Delete(SelectedRecord.ID);
                await Repo.CommitAsync();

                SelectedRecord = null;
                SelectedListItem = null;
                CostStatisticsList = Repo.CostsRepository.ReadCostsToStatModel();
            }
            NotBusy();
        }
    }
}