using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjektBazyDanych.CodeFirst
{
    public class DBInitrializer : DropCreateDatabaseIfModelChanges<ProdContext>
    {
        public DBInitrializer()
        {
        }

        protected override void Seed(ProdContext context)
        {
            var categories = new List<Category>
            {
                new Category{Name = "Napoje"},
                new Category{Name = "Alkohole", Description = "Wina, wódki, piwa"},
                new Category{Name = "Mięsa", Description = "Wołowina i wieprzowina"},
                new Category{Name = "Chemia", Description = "Mydła, proszki do prania i inne"}
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var query = from item in context.Categories
                        select item;

            var products = new List<Product>
            {
                new Product{ Name = "Coca cola", UnitPrice = 5, UnitsInStock = 6, CategoryId =  query.Where(n => n.Name == "Napoje").Select(i => i.CategoryID).ToList().FirstOrDefault() },
                new Product{ Name = "Jack Daniels", UnitPrice = 100, UnitsInStock = 10, CategoryId =  query.Where(n => n.Name == "Alkohole").Select(i => i.CategoryID).ToList().FirstOrDefault() },
                new Product{ Name = "Finlandia", UnitPrice = 50, UnitsInStock = 40, CategoryId =  query.Where(n => n.Name == "Alkohole").Select(i => i.CategoryID).ToList().FirstOrDefault() },
                new Product{ Name = "Podwawelska", UnitPrice = 34, UnitsInStock = 10, CategoryId =  query.Where(n => n.Name == "Mięsa").Select(i => i.CategoryID).ToList().FirstOrDefault() },
                new Product{ Name = "Toruńska", UnitPrice = 22, UnitsInStock = 56, CategoryId =  query.Where(n => n.Name == "Mięsa").Select(i => i.CategoryID).ToList().FirstOrDefault() },
                new Product{ Name = "Polędwica", UnitPrice = 30, UnitsInStock = 56, CategoryId =  query.Where(n => n.Name == "Mięsa").Select(i => i.CategoryID).ToList().FirstOrDefault() },
                new Product{ Name = "Visir", UnitPrice = 18, UnitsInStock = 35, CategoryId =  query.Where(n => n.Name == "Chemia").Select(i => i.CategoryID).ToList().FirstOrDefault() },
                new Product{ Name = "Lenor", UnitPrice = 15, UnitsInStock = 27, CategoryId =  query.Where(n => n.Name == "Chemia").Select(i => i.CategoryID).ToList().FirstOrDefault() },
                new Product{ Name = "Fairy", UnitPrice = 7, UnitsInStock = 97, CategoryId =  query.Where(n => n.Name == "Chemia").Select(i => i.CategoryID).ToList().FirstOrDefault() },
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}