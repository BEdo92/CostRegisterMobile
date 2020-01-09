using System.ComponentModel.DataAnnotations;

namespace CostRegisterMobile.EntityModels
{
    public class Shops
    {
        [Key]
        public int ShopID { get; set; }
        [Required]
        public string ShopName { get; set; }
    }
}
