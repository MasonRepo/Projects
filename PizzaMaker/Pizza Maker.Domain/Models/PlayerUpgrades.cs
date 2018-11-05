using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.Models
{
    public class PlayerUpgrades : IPlayerUpgrades
    {
        public int PlayerUpgradesID { get; set; }

        public string PlayerID { get; set; }
        public string UpgradeID { get; set; }
        
        public decimal Price { get; set; }
        public bool IsPurchased{ get; set; }

    }
}
