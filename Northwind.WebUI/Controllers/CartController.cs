using Northwind.Entities;
using Northwind.Entities.Concrete;
using Northwind.Interfaces;
using Northwind.WcfServiceLibrary.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        //Product database ini kullanacağımız için burada service implementasyonunu yapıyoruz
        IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        //Sepete ekleme aksiyonunu yazıyoruz ,hangi ürünü eklediğimizi bilmesi için de productId parametresini kullanacağız
        public RedirectToRouteResult AddToCart(Cart cart,int productId)
        {
            //Önceden yazdığımız get metoduyla ilk önce ürünü buluyoruz.
            //product nesnesine gönderdiğimiz prouductId parametresini atadık ve veritabanındaki karşılığını bulmak için kod yazdık
            Product product = _productService.Get(productId);
            
            //Sessiona ekle bu sana gönderdiğim parametreyi ve quantity olarak da 1 ekle
            cart.AddToCart(product, 1);
            //İşlem bitiminde Index e yönlendir.
            return RedirectToAction("Index", cart);

        }
        //Sepetin görüntülenmesi
        public ViewResult Index(Cart cart)
        {
            
            return View(cart);
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId)
        {
            //Parametre olarak gönderilen productid ile veritabanındakini eşleştir ve bana eşleşen ilk kyadı getir
            Product product = _productService.Get(productId);
            //cart nesnesini Sessionda bulunan Cart nesnesine değişken atadık
           


            //RemoveFromCart metodunu zaten Cart entitisinde tanımlamıştık.Burada sadece metodu çağırdık ve sileceği parametreyi gönderdik.
            cart.RemoveFromCart(product);

            return RedirectToAction("Index", cart);
        }
        public ActionResult Order()
        {
            //Sipariş vermeden önce kullanıcıdan gelen adres,telefon numarası,sipariş adı vs gibi bilgilerin 
            //olduğu ekranın yaratılması
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Order(ShippingDetails model)
        {
            if (ModelState.IsValid)
            {
                //Database e kaydet
                return RedirectToAction("OrderCompleted");
            }
            else
            {
                return View(model);
            }

        }
        public ActionResult OrderCompleted()
        {
            return View();
        }
        //Sepeti partialview yaptık çünkü bazı yerlerde göstermeyebiliriz.
        public PartialViewResult CartSummary(Cart cart)
        {
           
            return PartialView(cart);
        }
    }
}