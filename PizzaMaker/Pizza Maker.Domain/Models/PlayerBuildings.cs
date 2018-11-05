using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.Models
{
    public class PlayerBuildings : IPlayerBuildings
    {
        public int PlayerBuildingsID { get; set; }

        public string PlayerID { get; set; }
        public string BuildingID { get; set; }

        // Price will be equal to base cost * amount player has * 1.25 >>> which is a custom value I wanna set as.
        public decimal Price { get; set; }
        public decimal AmountPlayerHas { get; set; }



    }
}
