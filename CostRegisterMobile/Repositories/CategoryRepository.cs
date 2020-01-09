using CostRegisterMobile.EntityModels;
using System.Collections.Generic;
using System.Linq;

namespace CostRegisterMobile.Repositories
{
    public class CategoryRepository : CostPlansRepositoryBase<Category>
    {
        public CategoryRepository(CostPlansContext costPlansContext) : base(costPlansContext) { }

        public CategoryRepository() : base()
        {
        }

        public int GetIdFromCategoryName(string categoryName)
        {
            return _context.Category.Single(cn => cn.CategoryName == categoryName).CategoryID;
        }

        public IEnumerable<string> ReadCategory()
        {
            return _context.Category
                .ToList()
                .Select(name => name.CategoryName.ToString())
                .ToList();
        }

        public void Delete(string categoryName) 
        {
           // TODO: fix it, because it throws exception
           // _context.Category.RemoveRange(_context.Category.Find(categoryName));
        }

    }
}
