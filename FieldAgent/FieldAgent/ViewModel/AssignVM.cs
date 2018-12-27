using FieldAgent.Data;
using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldAgent.ViewModel
{
    public class AssignVM
    {

        public Agent Agent { get; set; }
        public IEnumerable<Agent> Agents { get; set; }
        public IEnumerable<Agencies> Agency { get; set; }
        public IEnumerable<SecurityClearance> SecurityClearances { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }
        public Assignment Assin { get; set; }

        public AssignVM() { }

        public AssignVM(Agent agent, IEnumerable<Agencies> agen, IEnumerable<SecurityClearance> clear, Assignment assin)
        {
            AgentRepo agents = new AgentRepo();
            Agents = agents.Grab();
            Agent = agent;
            Assin = assin;
            Assignments = Assignment.All().ToList();
            Agency = agen;
            SecurityClearances = clear;
        }
    }
}