using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Vending_Machine.Data;

namespace VendingTest.Test
{
    [TestFixture]
    public class Testing
    {
        [Test]
        public void CheckInv()
        {
            var f = new FileRepo();
            var vendinglist = f.GrabInfo();

            foreach (var v in vendinglist)
            {
                Assert.LessOrEqual(0, v.Value.Inventory);
            }
        }
        [Test]
        public void Funds()
        {
            int currentfunding = 30;
            var f = new FileRepo();
            var vendinglist = f.GrabInfo();
            foreach (var v in vendinglist)
            {
                // this passed till it hit a vaule that was above the amount that was inputed aka the funds in the machine
                Assert.LessOrEqual(v.Value.Price, currentfunding);
            }
        }
        [Test]
        public void Inventory()
        {
            var f = new FileRepo();
            var vendinglist = f.GrabInfo();

            foreach (var v in vendinglist)
            {
                // this is pretty much the same thing I had in the controller, would write to the file after doing v.value.Inventory - 1;
                Assert.AreNotEqual(v.Value.Inventory, v.Value.Inventory - 1);
            }
        }

        // not really sure how to go about this one, could just loop through the count of items in in the file and point to the keys with "i" and asserting they exist
        // could also assert is not null because that would mean an empty entry, meaning that the grab info method worked.

        [Test]
        public void CHeckFile()
        {
            var f = new FileRepo();
            var vendinglist = f.GrabInfo();
            foreach (var v in vendinglist)
            {
                Assert.IsNotNull(v.Value.Location);
            }
        }
    }

}
