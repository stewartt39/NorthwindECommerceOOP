using Northwind.BusinessLogicLayer.Concrete;
using Northwind.DataAccessLayer.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WcfServiceLibrary.Concrete
{
    //Yazılımımızı sadece iş katmanından değil servis katmanından da ayağa kaldırmak için ICategoryService interface inden implementasyon yapıyoruz.Daha sonra Category data accessine erişmek için de CategoryManager ı newliyoruz .SOAP kuralları gereği burada constructor kullanamıyoruz
    public class CategoryService : ICategoryService
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        public List<Category> GetAll()
        {
           return _categoryManager.GetAll();
        }
    }
}
