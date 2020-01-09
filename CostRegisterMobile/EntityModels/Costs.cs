using CostRegisterMobile.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CostRegisterMobile.EntityModels
{
    public class Costs
    {
        [Key]
        public int CostID { get; set; }
        public int CategoryID { get; set; }
        public int ShopID { get; set; }
        [Required]
        public int AmountOfCost { get; set; }
        [Required]
        public DateTime DateOfCost { get; set; }
        [MaxLength(100)]
        public string AdditionalInformation { get; set; }
    }
}
