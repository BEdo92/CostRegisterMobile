using System.ComponentModel.DataAnnotations;

namespace CostRegisterMobile.EntityModels
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
