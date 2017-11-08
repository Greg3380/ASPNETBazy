using ProjektBazyDanych.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektBazyDanych.Models
{
    public class OrderService
    {
        private OrderData orderData;
        private String customerName;

        public OrderService(DataWrapper dataWrapper)
        {
            this.orderData = new OrderData
            {
                catName = dataWrapper.catName,
                prodName = dataWrapper.prodName,
                quantity = dataWrapper.quantity
            };

            customerName = dataWrapper.userName;
        }

        public bool Save()
        {
            try
            {
                ProdContext prodContext = new ProdContext();

                Customer customer = prodContext.Customers.FirstOrDefault(n => n.CompanyName == customerName);

                if (customer == null)
                    return false;

                List<OrderTranferObject> orderDTO = new List<OrderTranferObject>();
                for (int i = 0; i < orderData.catName.Length; i++)
                {
                    var catTmp = orderData.catName[i];
                    var prodTmp = orderData.prodName[i];
                    orderDTO.Add(new OrderTranferObject
                    {
                        Category = prodContext.Categories.FirstOrDefault(c => c.Name == catTmp),
                        Product = prodContext.Products.FirstOrDefault(c => c.Name == prodTmp),
                        Quantity = orderData.quantity[i]
                    });

                }
                decimal price = 0;
                orderDTO.ForEach(n => price += n.Product.UnitPrice * n.Quantity);

                List<OrderDetails> details = new List<OrderDetails>();

                Order order = new Order {
                    CompletePrice = price,
                    Customer = customer
                };

                foreach(var item in orderDTO)
                {
                    OrderDetails detail = new OrderDetails();
                    detail.Order = order;
                    detail.Product = item.Product;
                    detail.Quantity = item.Quantity;
                    detail.UnitPrice = item.Product.UnitPrice;
                    details.Add(detail);
                }

                order.OrderDetails = details;

                prodContext.Orders.Add(order);
                details.ForEach(d => prodContext.OrderDetails.Add(d));
                prodContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }


            return true;
        }

    }

    public class OrderTranferObject
    {
        public Category Category { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}