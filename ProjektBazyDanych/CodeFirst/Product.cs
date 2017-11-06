using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektBazyDanych.CodeFirst
{
    public class Product
    {
        public int ProductID { get; set; }
        public String Name { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }

        [Column(TypeName = "Money")]
        public decimal UnitPrice { get; set; }


    }
}