using ProjektBazyDanych.CodeFirst;
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


        public ActionResult ShowProducts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdContext prodContext = new ProdContext();

            var allProducts = (from item in prodContext.Products
                               where item.CategoryId == id
                               select item).ToList();


            return View(allProducts);
        }

        public ActionResult PlaceAnOrder()
        {
            return View();
        }
    }
}