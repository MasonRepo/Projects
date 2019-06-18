namespace DotNetProject.Data.Migrations
{
    using DotNetProject.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetProject.Data.Repo.OrdersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DotNetProject.Data.Repo.OrdersContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Random rand = new Random();

            var contacts = new List<ContactModel>
            {
                new ContactModel{  FirstName = "John", LastName = "Smith" },
                new ContactModel{  FirstName = "Jane", LastName = "Doe" },
                new ContactModel{  FirstName = "Alec", LastName = "Baldwin" },
                new ContactModel{  FirstName = "Gary", LastName = "Busey" },
                new ContactModel{  FirstName = "Brad", LastName = "Pitt" }

            };
            contacts.ForEach(c => context.Contacts.AddOrUpdate(c));
            // So I'm not really sure if I want to set the ID or have the DB auto increment it, seems like something
            // that would be talked about with the company but I have no idea so I'm gonna let it auto set it
            var orders = new List<OrderModel>
            {
                new OrderModel{ OrderNumber = rand.Next(0,100000), OrderDate = DateTime.Parse("02-18-2013"), ContactID = 1, OrderDescription = "Tuna Garnished With Lemon", OrderAmount = 10.99M},
                new OrderModel{ OrderNumber = rand.Next(0,100000), OrderDate = DateTime.Parse("01-08-2018"), ContactID = 2, OrderDescription = "Tuna Garnished With Lime", OrderAmount = 12.99M},
                new OrderModel{ OrderNumber = rand.Next(0,100000), OrderDate = DateTime.Parse("11-02-2002"), ContactID = 3, OrderDescription = "Salmon Garnished With Lemon", OrderAmount = 14.99M},
                new OrderModel{ OrderNumber = rand.Next(0,100000), OrderDate = DateTime.Parse("07-13-2014"), ContactID = 4, OrderDescription = "Salmon Garnished With Lime", OrderAmount = 15.99M},
                new OrderModel{ OrderNumber = rand.Next(0,100000), OrderDate = DateTime.Parse("04-04-2006"), ContactID = 5, OrderDescription = "Cod Garnished With Lemon", OrderAmount = 21.99M},
                new OrderModel{ OrderNumber = rand.Next(0,100000), OrderDate = DateTime.Parse("07-13-2001"), ContactID = 2, OrderDescription = "Cod Garnished With Lime", OrderAmount = 42.99M},
                new OrderModel{ OrderNumber = rand.Next(0,100000), OrderDate = DateTime.Parse("02-16-2012"), ContactID = 3, OrderDescription = "Tuna Garnished With Lemon", OrderAmount = 41.99M},
                new OrderModel{ OrderNumber = rand.Next(0,100000), OrderDate = DateTime.Parse("12-18-2015"), ContactID = 1, OrderDescription = "YellowFin Garnished With Lime", OrderAmount = 17.95M}
            };
            orders.ForEach(o => context.Orders.AddOrUpdate(o));
            context.SaveChanges();

        }
    }
}
