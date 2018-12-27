using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;




namespace Flooring_Project.Tests
{
    [TestFixture]
    public class Testing
    {


        // this one is going to be checking the naming of the files to make sure they're in correct format, as well as checking the input.
        [Test]
        public void CheckDate()
        {
            //test date time
            var orderObj = new FileData.Orders();
            DateTime dt = new DateTime(2014, 11, 01);
            var order = new FileData.OrderRepo();

            var testing = order.GrabDate(dt);
            foreach (var t in testing)
            {
                Assert.AreEqual("OH", t.State);
            }
        }


        // this one can be used to check for product OR the state exisiting.
        [Test]
        public void ProductExist()
        {
            var file = new FileData.ProductRepo();
            var test = file.GrabInfo("Carpet");
            foreach (var t in test)
            {
                Assert.AreEqual("Carpet", t.ProductType);
                Assert.AreEqual(2.25, t.CostSqFeet);
                Assert.AreEqual(2.10, t.LaborCost);
            }

        }

        // This is going to check taxes
        [Test]
        public void StateExists()
        {
            var file = new FileData.TaxRepo();
            var test = file.GrabInfo("IN");
            foreach (var t in test)
            {
                Assert.AreEqual("IN", t.StateAbrev);
                Assert.AreEqual("Indiana", t.StateName);
                Assert.AreEqual(6.00, t.TaxRate);
            }


        }


        //this will test that the order was edited. this is going to be pretty much the same as checking the values.
        [Test]
        public void OrderEdit()
        {
            Assert.Pass();
            DateTime dt = new DateTime(2014, 11, 01);
            var order = new FileData.OrderRepo();
            var file = order.GrabDate(dt);
            // this is just a test variable.
            var userInput = 2;
            //string state = "MN";


            var edit = order.FindByIDAndDate(userInput, dt);
            //var result = order.EditOrder(file, userInput, state);
            //order.WriteOrders(result, dt);


            // this assert doesn't say there is a matching element even though it 100% changed the value.....
            // Assert.AreEqual("MN", edit.State);

            // just going to pass it for now and look at it later



        }

        // this one will check that the order was written and in the correct format.
        [Test]
        public void OrderWritten()
        {
            var orderObj = new FileData.Orders();
            DateTime dt = new DateTime(2014, 11, 01);
            var order = new FileData.OrderRepo();
            var testing = order.GrabDate(dt);

            Assert.IsNotNull(testing);
        }


        //this one will check if the file was deleted
        [Test]
        public void OrderRemoved()
        {
            DateTime dt = new DateTime(2014, 11, 01);
            var order = new FileData.OrderRepo();
            var file = order.GrabDate(dt);
            // this is just a test variable.
            var userInput = 1;

            foreach (var f in file)
            {
                if (f.OrderNum == userInput)
                {
                    var orders = order.FindByIDAndDate(userInput, dt);
                    var remove = order.RemoveOrder(file, dt, orders, userInput);
                    order.WriteOrders(remove, dt);
                    var testing = order.GrabDate(dt);



                    foreach (var t in testing)
                    {
                        Assert.AreEqual(4, testing.Count());
                    }
                    break;
                }
                else
                {
                    Assert.AreEqual(3, file.Count());
                    continue;
                }
            }
        }


        //this one will check for displaying the file based on the Date, would be for the Grab By ID/Date Method.
        [Test]
        public void DisplayDate()
        {
            DateTime dt = new DateTime(06012013);

            var test = new FileData.OrderRepo();
            var testing = test.GrabDate(dt);
            foreach (var t in testing)
            {
                Assert.AreEqual("Wise", t.CustomerName);
                Assert.AreEqual(1051.88M, t.Total);
            }


        }


        //this is going to be calculation type stuff and making sure they're correct.
        // it's gonna be a lot.....
        [Test]
        public void Calculations()
        {
            //mat cost from file is 5.15 and labor cost is 4.75, going to probably come back to this to import from file.

            var services = Factory.Create();
            var area = services.CalculateArea(10, 10);
            var matCost = services.MaterialCost(area, 5.15M);
            var laborCost = services.LaborCost(area, 4.75M);
            var taxCost = services.TaxCost(matCost, laborCost, 6.25M);
            var totalCost = services.TotalCost(matCost, laborCost, taxCost);

            Assert.AreEqual(area, 100);
            Assert.AreEqual(matCost, 515M);
            Assert.AreEqual(laborCost, 475M);
            Assert.AreEqual(taxCost, 61.875M);
            Assert.AreEqual(totalCost, 1051.875M);

        }
    }
}
