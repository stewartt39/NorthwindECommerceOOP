﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime  OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}
