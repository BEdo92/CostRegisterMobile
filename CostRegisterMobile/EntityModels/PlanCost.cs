using CostRegister.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostRegisterMobile.EntityModels
{
    public class PlanCost 
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeOfCostPlan { get; set; }

        public int CategoryID { get; set; }
        
        [Required]
        public int CostPlanned { get; set; }
        
        [Required]
        public DateTime DateOfPlan { get; set; }
        
        [MaxLength(100)]
        public string PlanAdditionalInformation { get; set; }
    }
}
