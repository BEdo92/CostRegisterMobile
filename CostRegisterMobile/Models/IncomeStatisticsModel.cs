using System;

namespace CostRegister.Models
{
    public class IncomeStatisticsModel 
    {
        public string TypeOfIncome { get; set; }
        public int AmountOfIncome { get; set; }
        public DateTime DateOFIncome { get; set; }
        public string IncomeAdditionalInformation { get; set; }
    
    }
}
