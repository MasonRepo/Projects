using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldAgent.Models
{
    public class Agencies
    {
        public int Id { get; set; }
        public string Agency { get; set; }

        public  IEnumerable<Agencies> All()
        {
            yield return new Agencies { Id = 1, Agency = "CIA" };
            yield return new Agencies { Id = 2, Agency = "FBI" };
            yield return new Agencies { Id = 3, Agency = "NSA" };
            yield return new Agencies { Id = 4, Agency = "Homeland Security" };
            yield return new Agencies { Id = 5, Agency = "Defense Intelligence Agency" };
            yield return new Agencies { Id = 6, Agency = "Southern Reach" };
            yield return new Agencies { Id = 7, Agency = "CONTROL" };
            yield return new Agencies { Id = 8, Agency = "ODIN" };
            yield return new Agencies { Id = 9, Agency = "Special Forces" };
        }
    }
}