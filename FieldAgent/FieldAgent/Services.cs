using FieldAgent.Data;
using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldAgent
{
    public class Services
    {
        // this is going to be where I have to inject the repo so I don't have to use file repo through out the file
        AgentRepo repo = new AgentRepo();

        public bool add(Agent agent)
        {

            repo.Add(agent);
            return true;
        }






    }
}