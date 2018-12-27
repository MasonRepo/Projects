using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDealTwo.Domain.Models
{
    public class Briefcase
    {
        public int BriefCaseId { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }
    }
}
