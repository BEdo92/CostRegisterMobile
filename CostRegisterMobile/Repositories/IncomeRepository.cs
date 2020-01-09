using CostRegisterMobile.EntityModels;
using System.Collections.Generic;
using System.Linq;

namespace CostRegisterMobile.Repositories
{
    public class IncomeRepository : CostPlansRepositoryBase<Income>
    {
        public IncomeRepository(CostPlansContext costPlansContext) : base(costPlansContext)
        {
        }

        public IEnumerable<int> ReadAllIncomeMoney()
        {
            return _context.Income
            .Select(i => i.AmountOfIncome)
            .ToList();
        }
    }
}