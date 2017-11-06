using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektBazyDanych.CodeFirst
{
    public class Category
    {
        public int CategoryID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public List<Product> Products { get; set; }
    }
}