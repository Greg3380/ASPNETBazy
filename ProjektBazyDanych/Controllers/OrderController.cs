using ProjektBazyDanych.CodeFirst;
using ProjektBazyDanych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjektBazyDanych.Controllers
{
    

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

        public ActionResult SaveForm(DataWrapper data)
        {
            //OrderService service = new OrderService(data);
            //if (service.Save())
            //{
            //    return View("SubmitSuccesful");
            //}
            return View("SubmitFailure");
        }
    }

    public class DataWrapper
    {
        public String userName;
        public String[] catName { get; set; }
        public String[] prodName { get; set; }
        public int[] quantity { get; set; }
    }
}