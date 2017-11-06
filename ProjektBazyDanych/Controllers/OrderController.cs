using ProjektBazyDanych.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjektBazyDanych.Controllers
{
    public class Data
    {
        public String ctr { get; set; }
        public String prod { get; set; }
    }

    public class OrderController : Controller
    {
        private ProdContext db = new ProdContext();
        // GET: Order
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }


        public ActionResult ShowProducts(String categoryName)
        {
            
            ProdContext prodContext = new ProdContext();

            var category = prodContext.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (category == null)
                return Json(null);

            var allProducts = prodContext.Products.Where(p => category.CategoryID == p.CategoryId).ToList();
            return Json(allProducts);
        }

        public ActionResult SaveForm(Data[] data)
        {
            return View();
        }
    }
}