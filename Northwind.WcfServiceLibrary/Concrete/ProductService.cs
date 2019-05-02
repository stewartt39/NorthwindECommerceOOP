using Northwind.BusinessLogicLayer.Concrete;
using Northwind.DataAccessLayer.Concrete.EntityFramework;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WcfServiceLibrary.Concrete
{
    public class ProductService : IProductService
    {
        private ProductManager _productManager = new ProductManager(new EfProductDal());

        public void Add(Northwind.Entities.Concrete.Product product)
        {
            _productManager.Add(product);
        }

        public void Delete(int productId)
        {
            _productManager.Delete(productId);
        }

        public Northwind.Entities.Concrete.Product Get(int productId)
        {
           return _productManager.Get(productId);
        }

        public List<Northwind.Entities.Concrete.Product> GetAll()
        {
            return _productManager.GetAll();
        }

        public void Update(Northwind.Entities.Concrete.Product product)
        {
            _productManager.Update(product);
        }
    }
}
