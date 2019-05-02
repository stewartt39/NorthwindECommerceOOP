using Northwind.DataAccessLayer.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        NorthwindContext _context = new NorthwindContext();
        public List<Category> GetAll()
        {
           return _context.Categories.ToList();
        }
    }
}
