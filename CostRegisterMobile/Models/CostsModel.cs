using CostRegisterMobile.Repositories;
using System;
using Xamarin.Forms;

namespace CostRegisterMobile.Models
{
    public class CostsModel
    {
        private string _shopName;
        private string _categoryName;

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                CategoryID = Repo.CategoryRepository.GetIdFromCategoryName(CategoryName);
            }
        }

        public int CategoryID { get; private set; }
        public string ShopName
        {
            get => _shopName;
            set
            {
                _shopName = value;
                ShopID = Repo.ShopRepository.GetIdFromShopName(ShopName);
            }
        }

        public int ShopID { get; private set; }
        public int AmountOfCost { get; set; }
        public DateTime DateOfCost { get; set; }
        public string AdditionalInformation { get; set; }

        public IUnitOfWork Repo { get; } = DependencyService.Get<IUnitOfWork>();
    }
}
