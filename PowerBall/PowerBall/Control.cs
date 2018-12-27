using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBall
{
    class Control
    {
        // THIS CAN USE CONSOLE BUT NOT FILE IO

        public void Run()
        {
            var c = new Data.FileRepo();
            var p = new Data.Powerball();


            Selection(p, c);
            SelectFromMenu();



        }






        public void ListInfo(Data.FileRepo power)
        {
            var service = new Services();
            var p = power.ReadFile();
            Console.Clear();
            var id = ReadIntInRange("Please enter in the ID of the ticket you would like to see: ", 1, 99999999);
            var ticket = service.FindById(id);

            Console.WriteLine($"ID: {ticket.ID} \t Numbers: {ticket.Nmbers[0]} {ticket.Nmbers[1]} {ticket.Nmbers[2]}" +
                $" {ticket.Nmbers[3]} {ticket.Nmbers[4]}  PowerBall:  {ticket.Powerballnum}");



            Console.ReadKey();

        }


        public void Drawing(Data.FileRepo power)
        {
            var service = new Services();
            var result = service.Draw(power);
            var p = new Data.Powerball();

            var PowerBallTicket = service.CreatePowerBallTicket();

            var list = service.FindBestMatches(PowerBallTicket);

            var orderedList = list.OrderBy(c => c.Match);

            if (result == true)
            {
                Console.Clear();
                Console.WriteLine("Wow, you actually won the PowerBall, are you cheating????");
            }
            else
            {
                Console.Clear();
                foreach (var h in list)
                {
                    Console.WriteLine($"ID: {h.ID} \t Numbers: {h.Nmbers[0]} {h.Nmbers[1]} {h.Nmbers[2]}" +
                    $" {h.Nmbers[3]} {h.Nmbers[4]}  PowerBall:  {h.Powerballnum}    Matches:  {h.Match}");
                }
                Console.WriteLine("You didn't win the PowerBall, please try again!");
                Console.WriteLine("The file will now clear.");
            }
            power.ClearFile(p);
            Console.ReadKey();
        }


        int SelectFromMenu()
        {
            var c = new Data.FileRepo();

            Console.Clear();

            Console.WriteLine("1. Add a Pick!");
            Console.WriteLine("2. Do a Quick Pick!");
            //if (count > 0)
            //{
            Console.WriteLine("3. List Picks");
            Console.WriteLine("4. Draw!");
            //}
            Console.WriteLine("5. Exit");
            return ReadIntInRange("Please select between 1-5:", 1, 5);

        }


        public void QuickDraw()
        {

            Console.Clear();
            var service = new Services();
            var dictionary = service.RandomTicket();

            service.Write(dictionary);
            Console.WriteLine($"This is the ID for the random ticket you created: {dictionary.ID}");
            Console.ReadKey();
        }




        public Data.Powerball AddPick()
        {
            var powerball = new Data.Powerball();
            var file = new Data.FileRepo();


            for (int i = 0; i < 5; i++)
            {
                bool contain = true;
                while (contain == true)
                {
                    int input = ReadIntInRange($"Please enter in a number between 1-69 for Set {i + 1}: ", 1, 69);

                    if (powerball.Nmbers.Contains(input))
                    {
                        Console.WriteLine("Please enter in a unique number!");
                        contain = true;
                    }
                    else
                    {
                        powerball.Nmbers.Add(input);
                        contain = false;
                    }
                }
            }


            int powerInput = ReadIntInRange($"Please enter in a number between 1-26 for your Powerball Number: ", 1, 26);

            powerball.Powerballnum = powerInput;

            // this part is going to set the id, which means grabbing the file and finding the max of all ids.

            var max = file.ReadFile();



            int count = max.Count();
            if (count == 0)
            {
                powerball.ID = 1;
            }
            else if (count > 0)
            {

                var maxID = max.Max(m => m.ID);
                powerball.ID = maxID + 1;

            }
            //now this will write the file

            file.WriteFile(powerball);

            Console.WriteLine($"This is your ID for the ticket you just created: {powerball.ID}");
            Console.ReadKey();

            return powerball;

        }

        public void Selection(Data.Powerball powerball, Data.FileRepo c)
        {
            int selection = 0;
            do
            {
                selection = SelectFromMenu();
                switch (selection)

                {
                    case 1:
                        AddPick();
                        break;
                    case 2:
                        QuickDraw();
                        break;
                    case 3:
                        ListInfo(c);
                        break;
                    case 4:
                        Drawing(c);
                        break;
                    case 5:
                        continue;

                }
            } while (selection > 0 && selection < 5);
            Console.WriteLine("Done");



        }

        // HELPERS

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
