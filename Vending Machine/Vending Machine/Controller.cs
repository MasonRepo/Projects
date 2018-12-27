using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine.Data;

namespace Vending_Machine
{
    public class Controller
    {
        private const string filePath = @"C:\Users\Mason\Downloads\VendingItems.TXT";

        FileRepo f = new FileRepo();

        public void run()
        {
            decimal currentFunding = 0;



            bool quit = false;
            while (quit == false)
            {
                Selection();
                SelectFromMenu(currentFunding);



            }



        }

        int SelectFromMenu(decimal currentFunding)
        {
            Console.WriteLine("1. List Items");
            Console.WriteLine("2. Add Funds");
            if (currentFunding > 0)
            {
                Console.WriteLine("3. Purchase Item");
                Console.WriteLine("4. Return Change");
            }
            Console.WriteLine("5. Exit");
            return ReadIntInRange("Please select between 1-5:", 1, 5);
        }
        public void Selection()
        {
            int quit = 0;
            int selection = 0;
            decimal currentFunding = 0;
            do
            {
                selection = SelectFromMenu(currentFunding);
                switch (selection)

                {
                    case 1:
                        ListItems();
                        break;
                    case 2:
                        currentFunding = +AddFunds(currentFunding);
                        Console.WriteLine($"You now have {currentFunding} waiting to be used.");
                        break;
                    case 3:
                        ListItems();
                        Purchase(currentFunding, ReadString("Please enter in what selection you would like to make:"));
                        break;
                    case 4:
                        ReturnCurrency(currentFunding);
                        currentFunding = 0;
                        break;
                    case 5:
                        quit = 1;
                        break;

                }
            } while (selection > 0 && selection < 5 || quit == 1);
            Console.WriteLine("Done");



        }


        public void ListItems()
        {
            FileRepo f = new FileRepo();

            var vending = f.GrabInfo();

            foreach (var data in vending)
            {
                if (data.Value.Inventory > 0)
                {
                    Console.WriteLine($"{data.Value.Location} {data.Value.Name} {data.Value.Price} ({data.Value.Inventory})");
                }
            }

        }
        public decimal AddFunds(decimal currentfunding)
        {
            currentfunding += ReadIntInRange("Please enter in how much you would like to add to the machine: ", 0, 100);
            return currentfunding;
        }

        public void Purchase(decimal currentFunds, string vendingChoice)
        {

            var vendinglist = f.GrabInfo();
            var list = vendinglist.ToList();

            foreach (var v in list)
            {
                if (v.Value.Location == vendingChoice)
                {
                    if (currentFunds >= v.Value.Price)
                    {

                        Console.WriteLine($"You have purchased {v.Value.Name}");

                        Console.ReadKey();
                        v.Value.Inventory--;
                        var result = f.Update(vendinglist);
                        if (result == true)
                            Console.WriteLine("The item inventory has successfully be updated.");
                        else
                        {
                            Console.WriteLine("The file has not been updated......");
                        }
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough funds, please enter more!");
                        Console.ReadKey();
                    }
                }
            }
        }
        public void ReturnCurrency(decimal currentFunds)
        {
            decimal nickles = 0;
            decimal Quarters = 0;
            decimal dimes = 0;
            decimal pennies = 0;



            if (currentFunds == 0)
            {
                Console.WriteLine("You have no change to return!");
            }
            while (currentFunds != 0)
            {

                if (currentFunds / 0.25M != 0)
                {
                    Quarters++;
                    if (currentFunds % 0.10M != 0)
                    {
                        dimes++;
                        if (currentFunds % 0.05M != 0)
                        {
                            nickles++;
                            if (currentFunds % 0.01M != 0)
                                pennies++;
                        }
                    }

                }
            }
            Console.WriteLine($"You got back {Quarters},{dimes},{nickles},{pennies}.");

        }



        //Helpers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        int ReadIntInRange(string prompt, int min, int max)
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
