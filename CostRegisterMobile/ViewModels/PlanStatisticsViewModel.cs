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

        public override void RefreshPage()
        {
            PlanStatisticsList = Repo.PlansRepository
                        .ReadAllPlanCost()
                        .OrderByDescending(d => d.DateOfPlan);
        }

        protected override async Task ExecuteDeleteAsync()
        {
            Busy();

            if (await MessageBoxService.ShowConfirmation("Valóban törölni kívánja az adatokat?", "Figyelmeztetés!")
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
