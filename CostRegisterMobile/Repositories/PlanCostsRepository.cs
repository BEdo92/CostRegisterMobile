using System.Collections.Generic;
using System.Linq;
using CostRegisterMobile.EntityModels;
using CostRegisterMobile.Models;

namespace CostRegisterMobile.Repositories
{
    public class PlanCostsRepository : CostPlansRepositoryBase<PlanCost>
    {
        public PlanCostsRepository(CostPlansContext _context) : base(_context)
        {
        }

        public IEnumerable<int> ReadCostPlansMoney()
        {
            return _context.PlanCosts
                .Select(pc => pc.CostPlanned)
                .ToList();
        }

        public IEnumerable<PlanCostModel> ReadAllPlanCost()
        {
            return (from co in _context.PlanCosts
                    join ca in _context.Category
                    on co.CategoryID equals ca.CategoryID
                    select GetPlanCostModel(co, ca)).ToList();
        }

        private static PlanCostModel GetPlanCostModel(PlanCost co, Category ca)
        {
            var pcmodel = new PlanCostModel
            {
                ID = co.ID,
                DateOfPlanForQueries = co.DateOfPlan,
                TypeOfCostPlan = co.TypeOfCostPlan,
                CategoryName = ca.CategoryName,
                CostPlanned = co.CostPlanned,
                PlanAdditionalInformation = co.PlanAdditionalInformation
            };

            return pcmodel;
        }
    }
}