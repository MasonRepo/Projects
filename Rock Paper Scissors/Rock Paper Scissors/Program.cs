using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {

            string userInput;
            int choice;
            int userRounds;
            int tie = 0;
            int win = 0;
            int lose = 0;
            int tryagain = 1;
            int yesorno;
            int autoquit = 1;

            while (tryagain == 1)
            {
                Console.WriteLine("Hello and welcome to Rock Paper Scissors!!");
                Console.Write("First I would like to know how many rounds you would like to play (1-10): ");

                string rounds = Console.ReadLine();

                if (int.TryParse(rounds, out userRounds))
                {
                    if (userRounds > 10 || userRounds <= 0)
                    {
                        Console.WriteLine("You have entered an invalid input, the game will now quit!");
                        tryagain--;
                        autoquit--;

                    }
                    else
                    {
                        Console.WriteLine($"You have choosen to play {userRounds} times, good luck!");
                    }
                    int i = 0;
                    if (tryagain == 1)
                    {
                        while (i != userRounds)
                        {
                            Random computerRandom = new Random();
                            int random = computerRandom.Next(1, 3);
                            Console.WriteLine("Now please choose either \n 1 = Rock \n 2 = Paper \n 3 = Scissors");
                            userInput = Console.ReadLine();
                            int.TryParse(userInput, out choice);

                            if (choice < 1 || choice > 3)
                            {
                                Console.WriteLine("You have entered in a invalid input!");
                                Console.ReadKey();
                            }

                            else if (choice == random)
                            {
                                Console.WriteLine("You have tied with the computer!");
                                tie++;
                                i++;
                            }
                            else if (choice == 1 && random == 2)
                            {
                                Console.WriteLine("The computer picked Paper, you lost!");
                                lose++;
                                i++;

                            }
                            else if (choice == 3 && random == 1)
                            {
                                Console.WriteLine("The computer picked Rock, you lost!");
                                lose++;
                                i++;
                            }
                            else if (choice == 1 && random == 3)
                            {
                                Console.WriteLine("The computer picked Scissors, you won!");
                                win++;
                                i++;
                            }
                            else if (choice == 2 && random == 1)
                            {
                                Console.WriteLine("The computer picked Rock, you won!");
                                win++;
                                i++;
                            }
                            else if (choice == 2 && random == 3)
                            {
                                Console.WriteLine("The computer picked Scissors, you lost!");
                                lose++;
                                i++;
                            }
                            else if (choice == 3 && random == 2)
                            {
                                Console.WriteLine("The computer picked Paper, you won!");
                                win++;
                                i++;
                            }
                        }
                        Console.WriteLine($"\nYou have played {userRounds} round(s) resulting in you winning {win} times, losing {lose} times, and tying {tie} times.");
                        if (win > lose)
                        {
                            Console.Write($"Overall you won more times than the computer!");
                        }
                        else
                        {
                            Console.WriteLine("You lost to the computer more!");
                        }
                    }
                }

                if (autoquit == 1)
                {
                    int howmanyint = 1;
                    while (howmanyint == 1)
                    {
                        Console.WriteLine("\nWould you like to keep playing? \n 1 = Yes  \n 2 = No");
                        string again = Console.ReadLine();
                        if (int.TryParse(again, out yesorno))
                            if (yesorno < 1 || yesorno > 2)
                            {
                                Console.WriteLine("Please enter in a valid input!");
                            }

                            else if (yesorno == 1)
                            {
                                Console.WriteLine("You have chosen to play again, thank you! \n");
                                howmanyint--;
                            }
                            else if (yesorno == 2)
                            {
                                tryagain--;
                                howmanyint--;
                            }
                    }

                }

            }
            Console.WriteLine("That is the end of the Rock Paper Scissors Game, thank you for playing!");
            Console.ReadKey();





        }




    }



}























