using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektBazyDanych.CodeFirst
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public String CustomerName { get; set; }

        [Column(TypeName = "Money")]
        public decimal CompletePrice { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}