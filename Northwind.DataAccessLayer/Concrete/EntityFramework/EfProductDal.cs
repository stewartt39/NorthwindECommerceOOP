using Northwind.DataAccessLayer.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private NorthwindContext _context = new NorthwindContext(); 

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(x => x.ProductID == productId));
            _context.SaveChanges();
        }

        public Product Get(int productId)
        {
          return  _context.Products.FirstOrDefault(x => x.ProductID == productId);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
            
        }

        public void Update(Product product)
        {
            Product productToupdate= _context.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            productToupdate.ProductName = product.ProductName;
            productToupdate.UnitPrice = product.UnitPrice;
            productToupdate.UnitsInStock = product.UnitsInStock;
            productToupdate.CategoryID = product.CategoryID;
            _context.SaveChanges();
        }
    }
}
