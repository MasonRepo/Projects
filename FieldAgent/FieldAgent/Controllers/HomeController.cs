using FieldAgent.Data;
using FieldAgent.Models;
using FieldAgent.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FieldAgent.Controllers
{
    public class HomeController : Controller
    {
        AgentRepo repo = new AgentRepo();
        public ActionResult Index()
        {

            return View( repo.Grab() );
        }

        [HttpGet]
        public ActionResult AddAgent()
        {
            var agent = new Agent();
            var agencies = new Agencies();
            var clear = new SecurityClearance();

            var agents = new AgentVM(agent, agencies.All(), clear.All());

            return View(agents);
        }


        [HttpPost]
        public ActionResult AddAgent(Agent agent)
        {
            var repo = new AgentRepo();


            repo.Add(agent);
            var agencies = new Agencies();
            var clear = new SecurityClearance();

            var agents = new AgentVM(agent, agencies.All(), clear.All());

            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var xd = repo.GrabID(id);

            // this part is where I will be calling upon the repo in services to return a list.
            var assin = new Assignment();
            var agencies = new Agencies();
            var clear = new SecurityClearance();

            var agents = new AssignVM(xd, agencies.All(), clear.All(), assin);

            return View(agents);
        }


        [HttpPost]
        public ActionResult Deletes(int id)
        {
            //var assins = new Assignment();
            //var agents = new AssignVM(agent, assins);
            repo.Delete(id);
            return Redirect("/");
            //return View(agents);
        }

        [HttpGet]
        public ActionResult AddAssignment()
        {

            var agent = new Agent();

            // this part is where I will be calling upon the repo in services to return a list.
            var assin = new Assignment();
            var agencies = new Agencies();
            var clear = new SecurityClearance();

            var agents = new AssignVM(agent, agencies.All(), clear.All(), assin);

            return View(agents);
        }

        
        [HttpPost]
        public ActionResult AddAssignment(Agent agent, Assignment assin)
        {


            AssignmentRepo assign = new AssignmentRepo();
            assign.Add(assin, agent);

            return Redirect("/");
        }


        [HttpGet]
        public ActionResult EditAgent(int id)
        {

            var xd = repo.GrabID(id);

            // this part is where I will be calling upon the repo in services to return a list.
            var assin = new Assignment();
            var agencies = new Agencies();
            var clear = new SecurityClearance();

            var agents = new AssignVM(xd, agencies.All(), clear.All(), assin);

            return View(agents);
        }

        [HttpPost]
        public ActionResult EditAgent(Agent agent)
        {

            repo.Edit(agent.UserID, agent);


            return Redirect("/");
        }

    }
}
