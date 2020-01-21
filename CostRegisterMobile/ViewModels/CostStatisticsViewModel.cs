using CostRegisterMobile.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostRegisterMobile.ViewModels
{
    class CostStatisticsViewModel : StatisticsBaseViewModel<CostsStatisticsModel>
    {
        private IEnumerable<CostsStatisticsModel> _costStatisticsList;

        public IEnumerable<CostsStatisticsModel> CostStatisticsList
        {
            get => _costStatisticsList; 

            set
            {
                SetProperty(ref _costStatisticsList, value);
                RefreshCanDelete();
            }
        }

        public override void RefreshPage()
        {
            CostStatisticsList = Repo.CostsRepository
                    .ReadCostsToStatModel()
                    .OrderByDescending(d => d.DateTime);
        }

        protected override async Task ExecuteDeleteAsync()
        {
            Busy();
            if (await MessageBoxService.ShowConfirmation(AppResources.TextConfirmDeleteData, AppResources.TitleWarning, AppResources.ButtonCancel))
            {
                Repo.CostsRepository.Delete(SelectedRecord.ID);
                await Repo.CommitAsync();

                SelectedRecord = null;
                CostStatisticsList = Repo.CostsRepository.ReadCostsToStatModel();
            }
            NotBusy();
        }
    }
}