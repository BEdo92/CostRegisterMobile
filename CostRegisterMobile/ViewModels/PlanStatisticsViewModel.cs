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

        public override void RefreshPage()
        {
            RefreshList();
        }

        protected override void RefreshList()
        {
            if (SelectedListItem != null)
            {
                PlanStatisticsList = Repo.PlansRepository
                           .ReadAllPlanCost()
                           .Where(c => c.CategoryName == SelectedListItem)
                           .OrderByDescending(d => d.DateOfPlan);
            }
            else
            {
                PlanStatisticsList = Repo.PlansRepository
                             .ReadAllPlanCost()
                             .OrderByDescending(d => d.DateOfPlan);
            }
        }

        protected override async Task ExecuteDeleteAsync()
        {
            Busy();

            if (await MessageBoxService.ShowConfirmation(AppResources.TextConfirmDeleteData, AppResources.TitleWarning, AppResources.ButtonCancel)
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
