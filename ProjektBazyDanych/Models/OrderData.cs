using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektBazyDanych.Models
{
    public class OrderData
    {
        public String[] catName { get; set; }
        public String[] prodName { get; set; }
        public int[] quantity { get; set; }
    }
    public class DataWrapper
    {
        public String userName { get; set; }
        public String[] catName { get; set; }
        public String[] prodName { get; set; }
        public int[] quantity { get; set; }
    }
}