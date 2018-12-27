using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldAgent.ViewModel
{
    public class AgentVM
    {
        
        public Agent Agent { get; set; }
        public IEnumerable<Agencies> Agency { get; set; } = new List<Agencies>();
        public IEnumerable<SecurityClearance> Security_Clearances { get; set; } = new List<SecurityClearance>();

        public AgentVM() { }

        public AgentVM(Agent agent, IEnumerable<Agencies> agen, IEnumerable<SecurityClearance> clear)
        {
            Agent = agent;
            Agency = agen;
            Security_Clearances = clear;
        }
    }
}