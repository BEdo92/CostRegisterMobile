using System;

namespace CostRegisterMobile.Models
{
    public class CostsStatisticsModel
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Category { get; set; }
        public string Shop { get; set; }
        public int Cost { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
