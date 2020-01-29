using CostRegisterMobile.EntityModels;
using CostRegisterMobile.Models;

namespace CostRegisterMobile.Services
{
    public static class Mappers
    {
        public static Costs Map(this CostsModel costsModel)
        {
            var costs = new Costs
            {
                ShopID = costsModel.ShopID,
                CategoryID = costsModel.CategoryID,
                AmountOfCost = costsModel.AmountOfCost,
                DateOfCost =  costsModel.DateOfCost,
                AdditionalInformation = costsModel.AdditionalInformation
            };

            return costs;
        }

        public static PlanCost Map(this PlanCostModel planCostModel)
        {
            var planCosts = new PlanCost
            {
                TypeOfCostPlan = planCostModel.TypeOfCostPlan,
                CategoryID = planCostModel.CategoryID,
                CostPlanned = planCostModel.CostPlanned,
                DateOfPlan = planCostModel.DateOfPlan,
                PlanAdditionalInformation = planCostModel.PlanAdditionalInformation
            };

            return planCosts;
        }
    }
}