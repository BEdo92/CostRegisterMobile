using System.ComponentModel.DataAnnotations;

namespace CostRegisterMobile.EntityModels
{
    public class Settings
    {
        [Key]
        public int ID { get; set; }
        public string SettingType { get; set; }
        public int SettingMode { get; set; }
    }
}
