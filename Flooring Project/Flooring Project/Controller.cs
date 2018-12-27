using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring_Project
{
    class Controller
    {
        private Services service;

        public Controller(Services service)
        {
            this.service = service;
        }

        public void Run()
        {

            Selection();


        }


        // Validation complete. Done.

        public DateTime Display()
        {
            var order = new FileData.OrderRepo();
            string date = ReadString("Please enter in the date of your order (any format): ");
            DateTime.TryParse(date, out DateTime dt);

            if (dt == null)
            {
                Console.WriteLine("Please enter in a valid input");
            }
            else
            {
                if (DateTime.Now > dt)
                {
                    Console.WriteLine("Please enter in a valid date in the FUTURE");
                }
                else
                {
                    var orders = order.GrabDate(dt);
                    if (orders == null)
                    {
                        Console.WriteLine("Could NOT find the file with the date you have entered.");
                    }
                    else
                    {
                        foreach (var o in orders)
                        {
                            Console.WriteLine($"{o.OrderNum}  {o.CustomerName}  {o.State}  {o.TaxRate}  {o.ProductType}  {o.Area}  {o.CostPerSquareFoot}  {o.LaborCostPerSquareFoot}  {o.MaterialsCost}  {o.LaborCost}  {o.Tax}  {o.Total}");
                        }
                    }
                }
            }
            return dt;

        }


        // Validation I believe is complete. Hopefully done.
        public void AddOrder()
        {
            //this will have a service method that will be adding both both the product and taxes together, as well as user input.

            var prod = new FileData.ProductRepo();

            var products = prod.DisplayAll();
            var tax = new FileData.TaxRepo();
            var taxes = tax.DisplayAll();
            bool complete = false;
            string productChoice = "";
            string taxChoice = "";
            string length = "";
            string width = "";


            string name = ReadString("Please Enter In Your Name: ");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductType}\t{p.CostSqFeet}\t{p.LaborCost}");
            }

            while (complete == false)
            {
                productChoice = ReadString("Please Enter In the Product You Wish To Use: ");
                {
                    var result = service.CheckProduct(productChoice);
                    if (result == false)
                    {
                        Console.WriteLine("Please enter in a valid product.");
                    }
                    else if (result == true)
                    {
                        break;
                    }

                }
            }
            while (complete == false)
            {
                taxChoice = ReadString("Please Enter In What State You Live In: ");
                var result = service.CheckTaxes(taxChoice);
                {
                    if (result == false)
                    {
                        Console.WriteLine("Please enter in a valid State!");
                    }
                    else if (result == true)
                    {
                        break;
                    }
                }
            }
            while (complete != true)
            {
                length = ReadString("What Is The Length of the room (FT): ");
                width = ReadString("What Is The Width Of The Room (FT): ");

                var result = service.CheckNumbers(length, width);
                if (result == false)
                {
                    Console.WriteLine("Please enter in a number.");
                }
                else if (result == true)
                {
                    break;
                }

            }
            while (complete == false)
            {
                string date = ReadString("Please Enter In The Date You Would Like The Order To Be Filled: ");
                DateTime.TryParse(date, out DateTime dt);


                if (dt == null)
                {
                    Console.WriteLine("Please enter in a valid input");
                }
                else
                {
                    if (DateTime.Now > dt)
                    {
                        Console.WriteLine("Please enter in a valid date in the FUTURE");
                    }
                    else
                    {
                        var order = service.CreateOrder(productChoice, taxChoice, dt, name, length, width);
                        break;
                    }
                }
            }
        }




        // NEEDS VALIDATION STILL
        public void EditOrder()
        {

            var dt = Display();

            int ID = ReadIntInRange("Please enter in the ID you would like to edit: ", 1, 999999999);
            var file = new FileData.OrderRepo();

            var list = file.FindByIDAndDate(ID, dt);

            if (list == null)
            {
                Console.WriteLine("Please enter in a valid ID.");
                Console.ReadKey();
            }
            else
            {

                Console.WriteLine($" 1) Name: {list.CustomerName} \n 2) State: {list.State} \n 3) ProductType: {list.ProductType} \n 4) Area/Dimensions: {list.Area}");

                int varToChange = ReadIntInRange($"Please enter in the ID of the variable you would like to change: ", 1, 4);
                string userChoice = ReadString("Please enter in what the new property you would like to be (if blank it will not change): ");


                var editedOrder = service.EditOrder(ID, dt, userChoice, varToChange);
                list = file.FindByIDAndDate(ID, dt);
                if (editedOrder == null)
                {
                    Console.WriteLine("You have chosen to not update any value or what you inputed as a new value was not valid.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Your updated order values are now as follows:\n Name: {list.CustomerName} \n State: {list.State} \n ProductType: {list.ProductType} \n Area/Dimensions: {list.Area}");
                    Console.ReadKey();
                }
            }
        }

        //Does NOT require any more validation I think, done.

        public void RemoveOrder()
        {
            var file = new FileData.OrderRepo();


            var dt = Display();
            int id = ReadIntInRange("Please enter in the ID of the date you would like to remove: ", 1, 99999999);
            var o = file.FindByIDAndDate(id, dt);
            if (o != null)
            {

                bool correct = false;
                while (correct == false)
                {
                    Console.Clear();
                    Console.WriteLine($"{o.OrderNum}  {o.CustomerName}  {o.State}  {o.TaxRate}  {o.ProductType}  {o.Area}  {o.CostPerSquareFoot}  {o.LaborCostPerSquareFoot}  {o.MaterialsCost}  {o.LaborCost}  {o.Tax}  {o.Total}");
                    string removeYesorNo = ReadString("Are you sure this is the the ID you would like to remove? (Y/N)");
                    if (removeYesorNo == "Yes" || removeYesorNo == "Y")
                    {
                        Console.WriteLine("You have choosen to delete this entry.");
                        service.RemovingOrder(dt, id);
                        correct = true;
                    }
                    else if (removeYesorNo == "No" || removeYesorNo == "N")
                    {
                        Console.WriteLine("You have choosen to not delete this entry.");
                        correct = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter in a valid input.");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("That id or file does not exist.");
            }
            Console.ReadKey();

        }








        // HELPERS

        int SelectFromMenu()
        {
            Console.Clear();

            Console.WriteLine("1. Add An Order");
            Console.WriteLine("2. Find Order By ID");
            Console.WriteLine("3. Edit An Order By ID");
            Console.WriteLine("4. Remove An Order By ID");
            Console.WriteLine("5. Exit");
            return ReadIntInRange("Please select between 1-5:", 1, 5);

        }




        public void Selection()
        {

            int selection = 0;
            do
            {
                selection = SelectFromMenu();
                switch (selection)

                {
                    case 1:
                        AddOrder();
                        break;
                    case 2:
                        Display();
                        Console.ReadKey();
                        break;
                    case 3:
                        EditOrder();
                        break;
                    case 4:
                        RemoveOrder();
                        break;
                    case 5:
                        continue;


                }
            } while (selection > 0 && selection < 5);
            Console.WriteLine("Done");
            //return quit = false;


        }


        string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }


        public int ReadIntInRange(string prompt, int min, int max)
        {
            int result = 0;
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                int.TryParse(input, out result);
                if (result < min || result > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                }
            } while (result < min || result > max);

            return result;

        }

    }
}
