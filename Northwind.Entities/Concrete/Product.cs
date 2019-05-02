using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.Entities.Concrete
{
  public  class Product
    {
        //Hiddeninput attribute u gelecek
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        
        public Int32? CategoryID { get; set; }
    }
}
