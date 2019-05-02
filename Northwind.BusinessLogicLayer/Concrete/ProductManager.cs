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
    public class ProductManager : IProductService
    {
        //Business Layerın bir üst katmanı olan DataAccess Layer a erişimi olan IProductDal'ın instance ını oluşturduk ki Datalara erişebilelim.Yapıcı metotta contructor ile gelsin ki yarın farklı bir ORM e geçersek burada kod değiştirmek zorunda kalmayalım.
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(productId);
        }

        

        public Product Get(int productId)
        {
            return _productDal.Get(productId);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
