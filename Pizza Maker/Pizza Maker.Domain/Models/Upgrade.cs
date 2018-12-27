using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.Models
{
    public class Upgrade : IUpgrade
    {
        public int UpgradeID { get; set; }

        public string UpgradeName { get; set; }
        public decimal PercentIncrease { get; set; }
    }
}