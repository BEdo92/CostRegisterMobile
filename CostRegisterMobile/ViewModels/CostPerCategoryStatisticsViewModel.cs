using CostRegisterMobile.Models;
using System.Collections.Generic;
using System.Linq;

namespace CostRegisterMobile.ViewModels
{
    class CostPerCategoryStatisticsViewModel : StatisticsBaseViewModel<CostStatisticsPerCategory>
    {
        private List<CostStatisticsPerCategory> _statisticsPerCategories;

        public IEnumerable<CostsStatisticsModel> CostStatisticsList =>
            Repo.CostsRepository
                    .ReadCostsToStatModel()
                    .OrderBy(d => d.DateTime);

        public List<CostStatisticsPerCategory> StatisticsPerCategories
        {
            get => _statisticsPerCategories;
            set => SetProperty(ref _statisticsPerCategories, value);
        }

        protected override void RefreshList()
        {
            StatisticsPerCategories = SumCostsPerCategories();
        }

        private List<CostStatisticsPerCategory> SumCostsPerCategories()
        {
            Busy();

            List<CostStatisticsPerCategory> statsPerCategories = new List<CostStatisticsPerCategory>();

            // first get the categories that already have costs saved
            IEnumerable<string> categoriesWithSavedData = CostStatisticsList
                .Select(c => c.Category)
                .Distinct();

            foreach (var currentCategory in categoriesWithSavedData)
            {
                // get the total costs for each category
                var allCostPerCurrentCategory = CostStatisticsList
                    .Where(c => c.Category == currentCategory)
                    .Sum(costStat => costStat.Cost);

                statsPerCategories.Add(new CostStatisticsPerCategory
                {
                    CategoryName = currentCategory,
                    AllCost = allCostPerCurrentCategory,
                    Percentage = (int)(allCostPerCurrentCategory / (double)CostStatisticsList.Sum(s => s.Cost) * 100)
                });
            }

            var orderedStats = statsPerCategories.OrderByDescending(x => x.AllCost).ToList();

            NotBusy();
            Notifications = orderedStats.Any() ? string.Empty : AppResources.NotificationsNoStatData;
            return orderedStats;
        }
    }
}
