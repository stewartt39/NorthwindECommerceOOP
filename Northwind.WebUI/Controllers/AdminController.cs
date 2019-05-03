using Northwind.Entities.Concrete;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.WebUI.Controllers
{

    public class AdminController : Controller
    {
        
        // GET: Admin
        //Data katmanına direkt erişemediğimiz için business katmanına erişmemiz lazım.Business katmanı da Interface ler katmanının serviceleriyle enjekte edilir.
        private IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        //Listeleme aksiyonu getall ile çağrılır.
        
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }
        //Yeni ürün ekleme operasyonunun httpget metodu
        [Authorize]
        public ActionResult Create()
        {
            ViewData["username"] = User.Identity.Name;
            return View(new Product());
        }
        //Eğer model doğru ise product service in add metodu çağrılır ve gönderdiğimiz product kaydedilir.
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
            
        }
        //Güncelleme operasyonunun HttpGet inde productId parametresi verilir.View daki new productId ile binding edilir.
        public ActionResult Edit(int productId)
        {
            //productsertvice in get metodu product nesnesine atanır.
            Product product = _productService.Get(productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ActionResult Delete(int productId)
        {
            Product product = _productService.Get(productId);
            return View(product);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleted(int productId)
        {
            if (ModelState.IsValid)
            {
                _productService.Delete(productId);
                return RedirectToAction("Index");
            }
            else
            {
                return View(productId);
            }
        }
    }
}