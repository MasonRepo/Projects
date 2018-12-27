using System;
using PowerBall.Data;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PowerBall
{
    public class Services : FileRepo
    {
        // this is going to be methods

        // NO CONSOLE OR FILE IO


        // this can be used for powerball and for quick pick
        public Data.Powerball RandomTicket()
        {
            var random = new Random();

            var powerball = new Data.Powerball();
            var file = new Data.FileRepo();


            for (int i = 0; i < 5; i++)
            {
                bool contain = true;

                while (contain == true)
                {
                    int check = random.Next(1, 69);

                    if (powerball.Nmbers.Contains(check))
                    {
                        check = random.Next(1, 69);
                        contain = true;
                    }
                    else
                    {
                        powerball.Nmbers.Add(check);
                        contain = false;
                    }
                }
            }


            powerball.Powerballnum = random.Next(1, 26);

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

            //if need be write to file.

            // not really sure how I'm going to print off the id, unless I make a method in controller to print it off
            // Console.WriteLine($"This is your ID for the ticket you just created: {powerball.ID}");


            return powerball;


        }
        public bool CheckID()
        {
            var list = new Data.FileRepo();
            var ticket = list.ReadFile();
            var ticketTest = ticket.ToDictionary(c => c.ID);
            foreach (var t in ticketTest)
            {
                if( t.Value.ID == t.Value.ID + 1)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<Powerball> ReturnMatches(Powerball powerBallTicket)
        {
            var file = new Data.FileRepo();
            var x = file.FindBestMatches(powerBallTicket);
            return x;
        }

        public void Write(Powerball ticket)
        {
            var file = new FileRepo();
            file.WriteFile(ticket);
        }

        public Powerball CreatePowerBallTicket()
        {
            var WinningTicket = RandomTicket();
            return WinningTicket;
        }

        public bool Draw(Data.FileRepo power)
        {

            var p = power.ReadFile();
            var WinningTicket = CreatePowerBallTicket();


            //kept saying unreachable code here in the "for" loop for the i++ part
            foreach (var t in p)
            {

                if (t.Nmbers == WinningTicket.Nmbers && t.Powerballnum == WinningTicket.Powerballnum)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            return false;
        }
    }
}
