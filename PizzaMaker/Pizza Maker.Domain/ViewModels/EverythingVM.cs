using Pizza_Maker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.ViewModels
{
    public class EverythingVM
    {
        public Player Player { get; set; }
        // public Building Building { get; set; }
        // public PlayerBuildings PlayerBuildings { get; set; }
        public IEnumerable<AllUpgrades> AllUpgrades { get; set; }
        public IEnumerable<TotalBuildings> TotalBuildings { get; set; }
       // public PlayerUpgrades PlayerUpgrades { get; set; }
      //  public Upgrade Upgrade { get; set; }
        public decimal PPS { get; set; }
        public decimal Modifier { get; set; }
    }
}
