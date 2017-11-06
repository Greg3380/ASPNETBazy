namespace ProjektBazyDanych.Migrations
{
    using ProjektBazyDanych.CodeFirst;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjektBazyDanych.CodeFirst.ProdContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProjektBazyDanych.CodeFirst.ProdContext";
        }

        protected override void Seed(ProjektBazyDanych.CodeFirst.ProdContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
        }
    }
}
