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
            OrderService service = new OrderService(data);
            if (service.Save())
            {
                return View("SubmitSuccesful");
            }
            return View("SubmitFailure");
        }

        public ActionResult GetCustomerName()
        {
            
            return View("GetCustomerName");
        }

        public ActionResult CheckUserName(UserNameWrapper user)
        {
            Customer customer = db.Customers.FirstOrDefault(n => n.CompanyName == user.userName);

            if (customer == null)
            {
                ViewBag.Error = "Nie ma takiego użytkownika w bazie danych";
                return View("GetCustomerName");
            }

            var orders = (from item in db.Orders
                         where item.CustomerName == customer.CompanyName
                         select item).ToList();

            return View("ShowAllOrders", orders);
        }

        public ActionResult ShowDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var orderdetails = db.OrderDetails.JWhere(o => o.OrderId == id).ToList();
            var orderdetails = (from item in db.OrderDetails
                                join prod in db.Products
                                on item.ProductId equals prod.ProductID
                                where item.OrderId == id
                                select new {
                                    prod = prod,
                                    unitPrice = item.UnitPrice,
                                    quantity = item.Quantity
                                }).ToList();
            if (orderdetails == null)
            {
                return HttpNotFound();
            }
            return Json(orderdetails, JsonRequestBehavior.AllowGet);
        }
    }
    public class UserNameWrapper
    {
        public String userName { get; set; }
    }

    
}