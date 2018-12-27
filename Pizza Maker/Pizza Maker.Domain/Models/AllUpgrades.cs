using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.Models
{
    public class AllUpgrades : IAllUpgrades
    {
        public string UpgradeID { get; set; }
        public string UpgradesName { get; set; }
        public decimal PercentIncrease { get; set; }
        public string PlayerID { get; set; }
        public decimal Price { get; set; }
        public bool IsPurchased { get; set; }
    }
}
