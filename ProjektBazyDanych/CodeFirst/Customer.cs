using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektBazyDanych.CodeFirst
{
    public class Customer
    {
        [Key]
        public String CompanyName { get; set; }
        public String Description { get; set; }

        public ICollection<Order> Orders{ get; set; }

    }
}