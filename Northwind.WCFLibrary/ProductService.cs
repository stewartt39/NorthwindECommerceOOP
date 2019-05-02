using Northwind.BusinessLogicLayer.Concrete;

using Northwind.Entities.Concrete;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccessLayer.Concrete.EntityFramework;

namespace Northwind.WCFLibrary
{
    public class ProductService : IProductService
    {
        //Servicelerde SOAP lara göre ctor kullanılamadığı için burada hangi teknolojiyi kullanacağımızı seçiyoruz.
        private ProductManager _productManager = new ProductManager(new EfProductDal());

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public Product Get(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
