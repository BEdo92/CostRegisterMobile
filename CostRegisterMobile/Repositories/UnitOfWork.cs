using CostRegisterMobile.EntityModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CostRegisterMobile.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CostPlansContext _context;
        private CategoryRepository _categoryRepository;
        private ShopRepository _shopRepository;
        private CostsRepository _costsRepository;
        private IncomeRepository _incomeRepository;
        private PlanCostsRepository _plansRepository;
        private SettingsRepository _settingsRepository;

        public UnitOfWork(CostPlansContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {
            _context = DependencyService.Get<CostPlansContext>();
        }

        public CategoryRepository CategoryRepository  =>
            _categoryRepository ??= new CategoryRepository(_context);

        public ShopRepository ShopRepository => 
            _shopRepository ??= new ShopRepository(_context);

        public CostsRepository CostsRepository =>
            _costsRepository ??= new CostsRepository(_context); 

        public PlanCostsRepository PlansRepository =>
            _plansRepository ??= new PlanCostsRepository(_context); 

        public IncomeRepository IncomeRepository =>
            _incomeRepository ??= new IncomeRepository(_context);

        public SettingsRepository SettingsRepository =>
            _settingsRepository ??= new SettingsRepository(_context); 

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
