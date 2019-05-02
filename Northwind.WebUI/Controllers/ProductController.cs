using Northwind.BusinessLogicLayer.Concrete;
using Northwind.DataAccessLayer.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using Northwind.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Northwind.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //Service katmanı ile Business katmanının ortak inherit edildiği katman Interfaces katmanı olduğu için
        //burada bulunan IProductService ten türetiriz.Eğer servis gönderirsek servisi ,manager gönderirsek de managerı
        //constructorda oluşturarak bize gerekli enjeksiyonu sağlar
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        
        public ActionResult Index(int? categoryid)
        {
            //Değişkene atama işleminde Product bir liste şeklinde döndürüleceği için ilk olarak List <Product> dedik ve getall metodunu kullandık.GetAllu da gelen categoryid parametresine göre listelemesini söyledik.
            //Zaten Categorylerde de Route helperıyla tıkladığımız kategoriler ürünün categoryid sini çağıracak ve bu parametre 
            //bu actiona bind olacak bağlanacak.Seçtiğimiz kategoriye göre liste dönecek.
            List<Product> products = _productService.GetAll().Where(x=>x.CategoryID==categoryid ||categoryid==null ).ToList();

            return View(products);

        }
    }
}