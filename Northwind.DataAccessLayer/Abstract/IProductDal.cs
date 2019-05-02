using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();
        Product Get(int productId);
        void Delete(int productId);
        void Add(Product product);
        void Update(Product product);

    }
}
