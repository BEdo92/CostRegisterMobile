using System;
using System.ComponentModel.DataAnnotations;

namespace CostRegisterMobile.EntityModels
{
    public class Income
    {
        [Key]
        public int IncomeID { get; set; }
        [Required]
        [MaxLength(100)]
        public string TypeOfIncome { get; set; }
        [Required]
        public int AmountOfIncome { get; set; }
        [Required]
        public DateTime DateOFIncome { get; set; }
        [MaxLength(100)]
        public string IncomeAdditionalInformation { get; set; }
    }
}
