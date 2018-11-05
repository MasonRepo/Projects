using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Pizza_Maker.Data.Repo;
using Pizza_Maker.Domain;
using Pizza_Maker.Domain.Models;
using Pizza_Maker.Domain.Services;
using Pizza_Maker.Domain.ViewModels;
using Pizza_Maker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;

namespace Pizza_Maker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private LogicServices service;


        public HomeController()
        {
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                var apptest = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                return apptest;
            }
            private set
            {
                _userManager = value;
            }
        }


        public ApplicationSignInManager SignInManager
        {
            get
            {
                var some = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                return some;
            }
            private set
            {
                _signInManager = value;
            }
        }

        public HomeController(LogicServices services)
        {
            this.service = services;
        }





        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var model = new LogInVM();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("StartGame", "Home");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

                var result = await UserManager.CreateAsync(user, model.Password);

                var newUser = UserManager.FindByEmail(user.Email);

                UserManager.AddToRole(newUser.Id, "User");

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    

                    return RedirectToAction("Login", "Home");
                }
                AddErrors(result);
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        // this is going to return everything I THINK
        // or it just might save the increments??
        [Route("Test/{BuildingID}/{PlayerID}")]
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public ActionResult Purchase(int BuildingID, int playerID)
        {
            var vm = service.LoadGame(playerID.ToString());
            var build = vm.TotalBuildings.ToList();

            for (int i = 0; i < vm.TotalBuildings.Count(); i++)
            {
                if (build[i].BuildingID == BuildingID.ToString())
                {
                    build[i].AmountPlayerHas++;
                    //has to be last
                    build[i].Price = build[i].Price * 1.25M;
                    vm.TotalBuildings = build;
                    vm.PPS = service.CurrentPPS(vm);
                    break;
                }
            }
            // lets hope this works!
            service.SaveGame(vm);

            return Json(vm, JsonRequestBehavior.AllowGet);
            // return Json(new { x = 10M, name = "bob", BuildingID }, JsonRequestBehavior.AllowGet);

        }


        // I believe this one wil just be setting how many pizzas the player has
        // as the post above it will already be saving just how many buildings there are
        [Route("Save/{PlayerID}/{TotalAmount}")]
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult Save(int PlayerID, int TotalAmount)
        {
            

            var vm = service.LoadGame(PlayerID.ToString());
            vm.Player.PizzaAmount = TotalAmount;
            service.SaveGame(vm);

            return Json(vm);
        }

        [Route("PurchaseUpgrade/{PlayerID}/{UpgradeID}")]
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult PurchaseUpgrade(int PlayerID, int UpgradeID)
        {
            var vm = service.LoadGame(PlayerID.ToString());
            var upgrades = vm.AllUpgrades.ToList();

            foreach (var u in upgrades)
            {
                if (u.UpgradeID == UpgradeID.ToString())
                {
                    u.IsPurchased = true;

                    break;
                }
            }
            vm.AllUpgrades = upgrades;
            vm.PPS = service.CurrentPPS(vm);

            // lets hope this works!
            service.SaveGame(vm);

            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult StartGame()
        {
            var vm = new EverythingVM();
            PlayerRepo pRepo = new PlayerRepo();
            var used = HttpContext.User;
            var user = UserManager.FindById(used.Identity.GetUserId());
            var games = pRepo.AllLoggedIn(user.Id);


            return View(games);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult StartGame(EverythingVM vm, int PlayerID)
        {

            if (PlayerID == 0)
            {

                var used = HttpContext.User;
                var user = UserManager.FindById(used.Identity.GetUserId());

                vm = service.CreateNewGame(user.Id);

                return RedirectToAction("Game", "Home", new { id = vm.Player.PlayerID });
            }

            return RedirectToAction("Game", "Home", new { id = PlayerID });
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult Game(int id)
        {

            var vm = service.LoadGame(id.ToString());
            return View(vm);

        }



        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}