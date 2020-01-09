using System.Threading.Tasks;

namespace CostRegisterMobile.Repositories
{
    public interface IUnitOfWork
    {
        CategoryRepository CategoryRepository { get; }
        ShopRepository ShopRepository { get; }
        CostsRepository CostsRepository { get; }
        PlanCostsRepository PlansRepository { get; }
        IncomeRepository IncomeRepository { get; }
        SettingsRepository SettingsRepository { get; }
       Task CommitAsync();
    }
}
