using Pizza_Maker.Data.Repo;
using Pizza_Maker.Domain.Models;
using Pizza_Maker.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.Services
{
    public class LogicServices
    {
        //PPS STANDS FOR PIZZAS PER SECOND.

        private IPlayerRepo playerrepo;
        private IBuildRepo buildrepo;
        public IUpgradesRepo upgraderepo;

        public LogicServices(IPlayerRepo playerRepo, IBuildRepo buildRepo, IUpgradesRepo upgradeRepo)
        {
            this.playerrepo = playerRepo;
            this.buildrepo = buildRepo;
            this.upgraderepo = upgradeRepo;
        }


        public decimal CurrentPPS(EverythingVM vm)
        {

            var total = 0M;
            var actualtotal = 0M;

            // this is used for dividing the modifier because they're set like so = 1.25, and by adding it would be 2.50, divided would be 1.5
            var count = 0;
            var Modifier = 0M;

            var build = vm.TotalBuildings.ToList();
            foreach (var p in build)
            {
                total = +p.AmountPlayerHas * p.PizzaIncrease;

                // yeah this one is a bit weird because my IQ is less then 8
                actualtotal = total + actualtotal;
            }

            var upgrades = vm.AllUpgrades.ToList();
            foreach (var u in upgrades)
            {
                if (u.IsPurchased == true)
                {
                    Modifier = Modifier + u.PercentIncrease;
                    count++;
                }
            }
            if (count != 0)
            {
                // this is because the Modifier now is a whole number not a percent
                //so need to divide by 100 to get the percentage such as 15%
                Modifier = Modifier / 100;

                //multiply the actual total to get how much to add to it.
                // if it's at 100 and I have an increase of 10%
                // then I will be wanting to add 10 to the end total.
                var AmountAdded = actualtotal * Modifier;
                actualtotal = actualtotal + AmountAdded;

                // this is to help display in the webpage.
            }
            vm.Modifier = Modifier + 1;

            // i don't even think this is needed
            vm.PPS = actualtotal;

            return actualtotal;
        }

        public EverythingVM CreateNewGame(string LoginID)
        {
            var vm = new EverythingVM();

            var player = new Player();
            player.PizzaAmount = 0;
            player.LoginID = LoginID;
            player.DateCreated = DateTime.Now;

            var id = playerrepo.Save(player);

            //player.PlayerID = playerrepo.All().Max(m => m.PlayerID);

            buildrepo.StartBuildings(id.PlayerID.ToString());
            upgraderepo.StartUpgrades(id.PlayerID.ToString());
            var startingUpgrades = upgraderepo.GrabUpgrades(id.PlayerID.ToString());
            var startingbuildings = buildrepo.GrabBuildings(id.PlayerID.ToString());

            vm.Player = player;
            vm.TotalBuildings = startingbuildings;
            vm.AllUpgrades = startingUpgrades;

            //vm = CurrentPPS(vm);
            vm.PPS = 0;
            return vm;

        }


        // WORK IN PROGRESS AHHHHHHHHH
        public EverythingVM LoadGame(string playerID)
        {
            var vm = new EverythingVM();

            vm.Player = playerrepo.FindById(playerID);
            vm.TotalBuildings = buildrepo.GrabBuildings(vm.Player.PlayerID.ToString());
            vm.AllUpgrades = upgraderepo.GrabUpgrades(vm.Player.PlayerID.ToString());
            vm.PPS = CurrentPPS(vm);

            return vm;
        }


        public bool SaveGame(EverythingVM vm)
        {
            if (vm != null)
            {
                playerrepo.Save(vm.Player);
                buildrepo.Update(vm);
                upgraderepo.Update(vm);
                return true;
            }
            return false;
        }
    }
}
