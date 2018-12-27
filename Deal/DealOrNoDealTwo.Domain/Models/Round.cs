using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDealTwo.Domain.Models
{
    public class Round
    {
        public int RoundId { get; set; }
        //we're going to sum the available amounts then divide by percentage
        public decimal BankerPercentage { get; set; }

        public virtual ICollection<Briefcase> Briefcases { get; set; }

    }
}
