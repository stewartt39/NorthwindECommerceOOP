using Northwind.DataAccessLayer.Abstract;
using Northwind.Entities.Concrete;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLogicLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
       private ICategoryDal _categorydal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categorydal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categorydal.GetAll();
        }
    }
}
