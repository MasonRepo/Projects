using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDealTwo.Domain.Models
{
    public class GameState
    {
        public Player Player { get; set; }
        public Round Round { get; set; }
        public decimal RoundNumber { get; set; }
        public decimal AmountChosen { get; set; }
    }
}
