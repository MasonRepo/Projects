using DealOrNoDealTwo.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

namespace DealOrNoDealTwo.Data
{
    public class ShowContext : DbContext
    {
        static ShowContext()
        {
            System.Data.Entity.Database.SetInitializer<ShowContext>(null);
        }
        public ShowContext() : base("Gameshow") { }
        public ShowContext(string connectionName) : base(connectionName) { }

        public DbSet<Briefcase> Briefcases { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Rounds { get; set; }

    }
}
