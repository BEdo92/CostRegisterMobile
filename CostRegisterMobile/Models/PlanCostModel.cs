using CostRegisterMobile.Repositories;
using System;
using Xamarin.Forms;

namespace CostRegisterMobile.Models
{
    public class PlanCostModel
    {
        private readonly IUnitOfWork _repo = DependencyService.Get<IUnitOfWork>();

        public int CategoryID =>
             _repo.CategoryRepository.GetIdFromCategoryName(CategoryName);

        public int ID { get; set; }
        public string TypeOfCostPlan { get; set; }
        public string CategoryName { get; set; }
        public int CostPlanned { get; set; }
        public DateTime DateOfPlan => DateTime.Today;
        public DateTime DateOfPlanForQueries { get; set; }
        public string PlanAdditionalInformation { get; set; }
    }
}