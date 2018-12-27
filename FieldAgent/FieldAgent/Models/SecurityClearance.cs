using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldAgent.Models
{
    public class SecurityClearance
    {
        public int Id { get; set; }
        public string Clearance { get; set; }
        
        public  IEnumerable<SecurityClearance> All()
        {
            yield return new SecurityClearance { Id = 1, Clearance = "Confidential" };
            yield return new SecurityClearance { Id = 2, Clearance = "Secret" };
            yield return new SecurityClearance { Id = 3, Clearance = "Top Secret" };
            yield return new SecurityClearance { Id = 4, Clearance = "Dark Matter" };

        }
    }
}