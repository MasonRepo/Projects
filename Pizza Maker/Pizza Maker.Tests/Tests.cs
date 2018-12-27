using NUnit.Framework;
using Pizza_Maker.Data.Repo;
using Pizza_Maker.Domain.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Tests
{
    [TestFixture]
    class Tests
    {
        BuildRepoTest BuildingRepo = new BuildRepoTest();
        UpgradesRepoTest UpgradeRepo = new UpgradesRepoTest();
        PlayerRepoTest PlayerRepo = new PlayerRepoTest();

        // not sure how to use auto fac with tests...
        // all passed BEFORE i added autofac, gonna have to look up howto set it considering
        // i did the same thing as i did in the controlLer

        LogicServices Services;
        public Tests(LogicServices services)
        {
            this.Services = services;
        }
        int TestingID = 117;

        [Test]
        public void CheckCreate()
        {
            var result = PlayerRepo.AllLoggedIn(TestingID.ToString());
            if (result.Count() == 0)
            {
                Services.CreateNewGame(TestingID.ToString());
            }
            var PlayerResult = PlayerRepo.AllLoggedIn(TestingID.ToString());
            var BuildingResult = BuildingRepo.All();
            var UpgradeResult = UpgradeRepo.All();
            Assert.AreEqual(1, PlayerResult.Count());
            Assert.AreEqual(5, BuildingResult.Count());
            Assert.AreEqual(5, UpgradeResult.Count());
        }


        [Test]
        public void BuildingPurchase()
        {
            var vm = Services.LoadGame(1.ToString());
            var build = vm.TotalBuildings.ToList();
            var oldAmount = 0M;
            var newAmount = 0M;
            for (int i = 0; i < vm.TotalBuildings.Count(); i++)
            {
                if (build[i].BuildingID == 2.ToString())
                {
                    oldAmount = build[i].AmountPlayerHas;
                    build[i].AmountPlayerHas++;
                    newAmount = build[i].AmountPlayerHas;
                    //has to be last
                    build[i].Price = build[i].Price * 1.25M;
                    vm.TotalBuildings = build;
                    vm.PPS = Services.CurrentPPS(vm);
                    break;
                }
            }
            Assert.AreEqual(newAmount, oldAmount + 1);
        }



        [Test]
        public void CheckSave()
        {
            var vm = Services.LoadGame(1.ToString());
            var build = vm.TotalBuildings.ToList();
            var oldAmount = 0M;
            var newAmount = 0M;
            for (int i = 0; i < vm.TotalBuildings.Count(); i++)
            {
                if (build[i].BuildingID == 2.ToString())
                {
                    oldAmount = build[i].AmountPlayerHas;
                    build[i].AmountPlayerHas++;
                    newAmount = build[i].AmountPlayerHas;
                    //has to be last
                    build[i].Price = build[i].Price * 1.25M;
                    vm.TotalBuildings = build;
                    vm.PPS = Services.CurrentPPS(vm);
                    break;
                }
            }
            var result = Services.SaveGame(vm);
            Assert.AreEqual(true, result);



        }

        [Test]
        public void CheckLoad()
        {
            var PlayerResult = PlayerRepo.AllLoggedIn(TestingID.ToString());
            var BuildingResult = BuildingRepo.AllLoggedIn(1.ToString());
            var UpgradeResult = UpgradeRepo.All();
            Assert.AreEqual(1, PlayerResult.Count());
            Assert.AreEqual(5, BuildingResult.Count());
            Assert.AreEqual(5, UpgradeResult.Count());
        }

        [Test]
        public void UpgradePurchase()
        {
            var vm = Services.LoadGame(1.ToString());
            var upgrades = vm.AllUpgrades.ToList();

            foreach (var u in upgrades)
            {
                // this will buy the upgrade "Super Meats"
                if (u.UpgradeID == 3.ToString())
                {
                    u.IsPurchased = true;

                    break;
                }
            }
            vm.AllUpgrades = upgrades;
            vm.PPS = Services.CurrentPPS(vm);

            // point to 2 because lists start at 0 even though the ID is 3.
            Assert.AreEqual(true, upgrades[2].IsPurchased);

        }

        [Test]
        public void CalculateUpgrades()
        {
            var vm = Services.LoadGame(1.ToString());
            var upgrades = vm.AllUpgrades.ToList();

            foreach (var u in upgrades)
            {
                // this will buy the upgrade "Super Meats"
                if (u.UpgradeID == 3.ToString())
                {
                    u.IsPurchased = true;

                    break;
                }
            }
            vm.AllUpgrades = upgrades;
            vm.PPS = Services.CurrentPPS(vm);

            // this is going to be 10.5, due to the 5% from the upgrade
            // and the 10 from the current building.
            Assert.AreEqual(10.5M,vm.PPS);

        }


    }
}
