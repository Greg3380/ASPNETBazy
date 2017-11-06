using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjektBazyDanych.CodeFirst
{
    public class ProdContext : DbContext
    {
        public ProdContext() : base("ProdContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasRequired<Order>(o => o.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(s => s.OrderId);

            modelBuilder.Entity<OrderDetails>()
                .HasRequired<Product>(p => p.Product)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Order>()
                .HasRequired<Customer>(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(s => s.CustomerName);

            base.OnModelCreating(modelBuilder);
        }

    }
}