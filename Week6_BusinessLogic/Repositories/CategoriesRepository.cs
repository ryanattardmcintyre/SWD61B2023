using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_BusinessLogic.Models;

namespace Week6_BusinessLogic.Repositories
{
    public class CategoriesRepository
    {
        public SWD61B_OOPEntities Context { get; set; }
        public CategoriesRepository(SWD61B_OOPEntities _context)
        {
            Context = _context;
        }

        public IQueryable<Category> GetCategories()
        {
            return Context.Categories;

            //return (from c in Context.Categories select c);
        }
    }
}
