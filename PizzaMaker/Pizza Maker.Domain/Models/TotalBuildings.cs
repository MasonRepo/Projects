using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.Models
{
    public class TotalBuildings : ITotalBuildings
    {
        public string BuildingID { get; set; }
        public string BuildingName { get; set; }
        public decimal PizzaIncrease { get; set; }
        public decimal BaseCost { get; set; }

        public string PlayerID { get; set; }
        public decimal Price { get; set; }
        public decimal AmountPlayerHas { get; set; }

    }
}
