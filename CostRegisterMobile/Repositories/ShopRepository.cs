using CostRegisterMobile.EntityModels;
using System.Collections.Generic;
using System.Linq;

namespace CostRegisterMobile.Repositories
{
    public class ShopRepository : CostPlansRepositoryBase<Shops>
    {
        public ShopRepository(CostPlansContext costPlansContext) : base(costPlansContext)
        {
        }

        public ShopRepository() : base()
        {
        }

        public IEnumerable<string> ReadShops()
        {
            var list = _context.Shops
                .Select(name => name.ShopName.ToString())
                .ToList();

            return list;
        }

        public int GetIdFromShopName(string shopName)
        {
            var shop = _context.Shops.FirstOrDefault(sn => sn.ShopName == shopName);
            var shopID = shop.ShopID;

            return shopID;
        }

        public Shops GetShopByName(string shopName)
        {
            var shop = _context.Shops.FirstOrDefault(sn => sn.ShopName == shopName);

            return shop;
        }
    }
}
