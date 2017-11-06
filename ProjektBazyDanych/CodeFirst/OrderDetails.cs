using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektBazyDanych.CodeFirst
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}