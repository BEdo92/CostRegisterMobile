using CostRegisterMobile.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostRegisterMobile.ViewModels
{
    class PlanStatisticsViewModel : StatisticsBaseViewModel<PlanCostModel>
    {
        private IEnumerable<PlanCostModel> _planStatisticsList;

        public IEnumerable<PlanCostModel> PlanStatisticsList
        {
            get => _planStatisticsList;
            set
            {
                SetProperty(ref _planStatisticsList, value);
                RefreshCanDelete();
            }
        }

        public IEnumerable<string> Categories
          => Repo.CategoryRepository.ReadCategory();

        protected override void RefreshList()
        {            
                PlanStatisticsList = Repo.PlansRepository
                           .ReadAllPlanCost()
                           .Where(c => 
                           {
                               if (!string.IsNullOrWhiteSpace(SelectedListItem) && !string.IsNullOrWhiteSpace(TextToFilterBy))
                               {
                                   return c.CategoryName.Equals(SelectedListItem) && c.TypeOfCostPlan.Contains(TextToFilterBy);
                               }
                               else if (!string.IsNullOrWhiteSpace(SelectedListItem))
                               {
                                   return c.CategoryName.Equals(SelectedListItem);
                               }
                               else if (!string.IsNullOrWhiteSpace(TextToFilterBy))
                               {
                                   return c.TypeOfCostPlan.Contains(TextToFilterBy);
                               }

                               return true;
                           })
                           .OrderByDescending(d => d.DateOfPlan);

            Notifications = PlanStatisticsList.Any() ? string.Empty : AppResources.NotificationsNoStatData;           
        }

        protected override async Task ExecuteDeleteAsync()
        {
            Busy();

            if (await DialogService.ShowConfirmation(AppResources.TextConfirmDeleteData, AppResources.TitleWarning, AppResources.ButtonCancel)
                && SelectedRecord != null)
            {
                Repo.PlansRepository.Delete(SelectedRecord.ID);
                await Repo.CommitAsync();

                SelectedRecord = null;
                PlanStatisticsList = Repo.PlansRepository.ReadAllPlanCost();
            }

            NotBusy();
        }

    }
}