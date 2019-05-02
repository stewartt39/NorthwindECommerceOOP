using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //İlk listelerken categoryid 0 olsun ki tüm ürünleri listelesin
        //Partialview yapmamızın sebebi bazı sayfalarda kullanmayabiliriz
        public PartialViewResult List(int categoryid=0)
        {
            //seçilen kategorinin üzerini farklı bir renge boyamak için ilk olarak gelen kategoriyi viewbag ile
            //tutarız.Buradan da view a aktarıcaz
            ViewBag.CurrentCategory = categoryid;
            //Categorilerin hepsini getir metodunu kullanıcaz.
            return PartialView(_categoryService.GetAll());
        }
    }
}