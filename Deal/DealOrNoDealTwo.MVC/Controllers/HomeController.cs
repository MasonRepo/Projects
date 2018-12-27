using DealOrNoDealTwo.Data;
using DealOrNoDealTwo.Domain.Models;
using DealOrNoDealTwo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealOrNoDealTwo.MVC.Controllers
{
    public class HomeController : Controller
    {
        public void Start()
        {
            //Choice player1Choice;
            //GameManager gm = DIContainer.Container.Resolve<GameManager>();
        }
            BriefcaseRepo repo = new BriefcaseRepo();
        IndexVM vm = new IndexVM();
        GameState gameState = new GameState();
        
        [HttpGet]
        public ActionResult Index()
        {
            
            using (var context = new ShowContext("GameShow"))
            {
                var result = context;
                //context.SaveChanges();
            }
            IndexVM vm = new IndexVM();
            vm.GameState = gameState;
            vm.Briefcases = repo.All().ToList();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            
            IndexVM vm = new IndexVM();
            var num = repo.FindBriefCaseById(id);
            vm.LastClicked = num.Amount;
            repo.DeleteById(id);
            vm.Briefcases = repo.All().ToList();
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}