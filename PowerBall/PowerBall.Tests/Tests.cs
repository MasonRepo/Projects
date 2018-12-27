using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBall;
using NUnit.Framework;
using PowerBall.Data;

namespace PowerBall.Tests
{
    [TestFixture]
    public class Testing
    {


        public IEnumerable<Powerball> CreateTicket()
        {


            var p = new Powerball();
            var ticket = new Data.FileRepo();
            var r = ticket.ReadFile();

            //p.ID = 1;
            //for (int i = 1; i <= 5; i++)
            //{
            //    p.Nmbers.Add(i);
            //}
            //p.Powerballnum = 12;

            return r;

        }

        [Test]
        public void TestPick()
        {
            // Making sure that the numbers are all within range and it's a valid ticket.
            // might be adding too much testing as I could spilt the range and validitiy 

            var test = CreateTicket();
            foreach (var h in test)
            {
                Assert.Greater(69, h.Nmbers[0]);
                Assert.Greater(69, h.Nmbers[1]);
                Assert.Greater(69, h.Nmbers[2]);
                Assert.Greater(69, h.Nmbers[3]);
                Assert.Greater(69, h.Nmbers[4]);
                Assert.Less(0, h.Nmbers[0]);
                Assert.Less(0, h.Nmbers[1]);
                Assert.Less(0, h.Nmbers[2]);
                Assert.Less(0, h.Nmbers[3]);
                Assert.Less(0, h.Nmbers[4]);
                Assert.Greater(26, h.Powerballnum);
                Assert.Less(0, h.Powerballnum);
            }

            //Assert.Greater(69, test.Nmbers[1]);
        }
        [Test]
        public void TestUnique()
        {
            var service = new Services();
            var result = service.CheckID();
            if (result == true)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestNoReoccuring()
        {
            var test = CreateTicket();


            // actually not really sure how I would go about writing the code to make sure it's for each and everyone
            // because this one will just quickly loop and check the one before it
            // if I could find the code we did were we looped it twice that might help but at the moment want to work
            // on checking the winning pick.

            foreach (var t in test)
            {
                for (int i = 1; i <= 5; i++)

                    if (t.Nmbers[i - 1] != t.Nmbers[i])
                    {
                        Assert.Pass();
                    }

                //Assert.Contains(t.Value.Nmbers[i],test);
            }
        }

        [Test]
        public void WinningPick()
        {

            // the most recent entry in my file for powerball numbers is "36,22,52,53,26,22"
            // going to write it so it will show two, if it passes and if it fails.

            var test = CreateTicket();

            var WinningTicket = new Powerball();

            WinningTicket.Nmbers.Add(3);
            WinningTicket.Nmbers.Add(4);
            WinningTicket.Nmbers.Add(5);
            WinningTicket.Nmbers.Add(6);
            WinningTicket.Nmbers.Add(7);
            WinningTicket.Powerballnum = 22;




            foreach (var t in test)
            {

                Assert.Contains(t.Nmbers, WinningTicket.Nmbers);

            }



        }

    }
}
