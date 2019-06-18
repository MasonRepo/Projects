using DotNetProject.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DotNetProject.Data.Repo
{
    public class OrdersContext : DbContext
    {
        public OrdersContext() : base("OrdersDatabase")
        {

        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
    }
}
