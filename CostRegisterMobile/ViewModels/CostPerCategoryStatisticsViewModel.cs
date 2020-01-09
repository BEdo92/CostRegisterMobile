using CostRegisterMobile.Models;
using System.Collections.Generic;
using System.Linq;

namespace CostRegisterMobile.ViewModels
{
    class CostPerCategoryStatisticsViewModel : StatisticsBaseViewModel<CostStatisticsPerCategory>
    {
        public IEnumerable<CostsStatisticsModel> CostStatisticsList =>
            Repo.CostsRepository
                    .ReadCostsToStatModel()
                    .OrderBy(d => d.DateTime);

        public List<CostStatisticsPerCategory> StatisticsPerCategories
        {
            get
            {
                Busy();

                List<CostStatisticsPerCategory> statsPerCat = new List<CostStatisticsPerCategory>();
                IEnumerable<string> cats = CostStatisticsList
                    .Select(c => c.Category)
                    .Distinct();

                foreach (var cat in cats)
                {
                    int catAllCostTemp = CostStatisticsList
                        .Where(c => c.Category == cat)
                        .Sum(sl => sl.Cost);

                    statsPerCat.Add(new CostStatisticsPerCategory
                    {
                        CategoryName = cat,
                        AllCost = catAllCostTemp,
                        Percentage = (int)(catAllCostTemp / (double)CostStatisticsList.Sum(sl => sl.Cost) * 100)
                    });
                }

                var orderedStats = statsPerCat.OrderByDescending(x => x.AllCost).ToList();

                NotBusy();
                return orderedStats;
            }
        }
    }
}
