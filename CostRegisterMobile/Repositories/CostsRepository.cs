using CostRegisterMobile.EntityModels;
using CostRegisterMobile.Models;
using System.Collections.Generic;
using System.Linq;

namespace CostRegisterMobile.Repositories
{
    public class CostsRepository : CostPlansRepositoryBase<Costs>
    {
        public CostsRepository(CostPlansContext costPlansContext) : base(costPlansContext)
        {
        }

        public IEnumerable<PlanCost> PreviousCosts => 
            _context.PlanCosts.ToList();

        public IEnumerable<int> ReadAllCostMoney()
        {
            return _context.Costs
           .Select(c => c.AmountOfCost)
           .ToList();
        }

        public IEnumerable<CostsStatisticsModel> ReadCostsToStatModel()
        {
            return (from co in _context.Costs
                    join ca in _context.Category
                    on co.CategoryID equals ca.CategoryID
                    join sh in _context.Shops
                    on co.ShopID equals sh.ShopID
                    select GetCostStatisticsModel(co, ca, sh)).ToList();
        }

        private static CostsStatisticsModel GetCostStatisticsModel(Costs co, Category ca, Shops sh)
        {
            return new CostsStatisticsModel
            {
                ID = co.CostID,
                DateTime = co.DateOfCost.Date,
                Category = ca.CategoryName,
                Shop = sh.ShopName,
                Cost = co.AmountOfCost,
                AdditionalInformation = co.AdditionalInformation
            };
        }
    }
}