using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;
using System;
using BattleShip.BLL.GameLogic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class BattleshipController
    {
        public void Run()
        {
            Player one = new Player();
            Player two = new Player();
            Board playerOne = new Board();
            Board playerTwo = new Board();
            one.board = playerOne;
            two.board = playerTwo;
            Random r = new Random();
            int whoFirst = 1; // r.Next(1, 3);


            int playagain = 0;


            // 1. Welcome

            while (playagain == 0)
            {
                Console.WriteLine("Hello and welcome to the BATTLESHIP GAME!");
                Console.Write("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                drawBoard(10);


                // 2. Creates Players with names

                //playerOne = CreatePlayer("Player #1");
                //two = CreatePlayer("Player #2");
                Console.WriteLine($"Player {whoFirst} will be going first!");
                Console.ReadKey();
                Console.Clear();

                // 3. Places Ships
                if (whoFirst == 1)
                {
                    PlaceShip(one, ShipType.Battleship);
                    PlaceShip(one, ShipType.Carrier);
                    PlaceShip(one, ShipType.Cruiser);
                    PlaceShip(one, ShipType.Destroyer);
                    PlaceShip(one, ShipType.Submarine);
                }

                
                    Console.Clear();
                    PlaceShip(two, ShipType.Battleship);
                    PlaceShip(two, ShipType.Carrier);
                    PlaceShip(two, ShipType.Cruiser);
                    PlaceShip(two, ShipType.Destroyer);
                    PlaceShip(two, ShipType.Submarine);
                //if (whoFirst > 1)
                //Console.Clear();
                //PlaceShip(one, ShipType.Battleship);
                //PlaceShip(one, ShipType.Carrier);
                //PlaceShip(one, ShipType.Cruiser);
                //PlaceShip(one, ShipType.Destroyer);
                //PlaceShip(one, ShipType.Submarine);



                // 4. Fire and register shots, ends with victory!
                //while (ShotStatus.Victory)
                if (whoFirst == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Now you shall take turns firing shots and at each other.");
                    Console.Write("Please enter in the coordinate you would like to fire at (X,Y): ");
                    string userInput = Console.ReadLine();
                    Coordinate cord = CreateCord(userInput);
                    playerOne.FireShot(cord);
                    FireShotResponse p1shotrespone = playerOne.FireShot(cord);
                    if (p1shotrespone.ShotStatus == ShotStatus.Hit)
                    { 
                        Console.WriteLine("You hit them at" + cord);
                        Console.ReadKey();
                    }
                    Console.ReadKey();
                    whoFirst = 2;
                }
                    if (whoFirst == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Now you shall take turns firing shots and at each other.");
                    Console.Write("Please enter in the coordinate you would like to fire at (X,Y): ");
                    string userInput = Console.ReadLine();
                    Coordinate cord = CreateCord(userInput);
                    playerTwo.FireShot(cord);
                    Console.ReadKey();
                    whoFirst = 1;
                    //if(ShotStatus == ShotStatus.Victory)
                }
                // Play again or not
            }

        }

        public Coordinate CreateCord(string input)
        {
            string yCord = input.Substring(input.Length - 2, 2);
            string xCord = input.Substring(0, 1);

            int x;
            int y;
            int.TryParse(yCord, out y);
            int.TryParse(xCord, out x);
            if (x > 0 || x < 11 && y > 0 || y < 11)
            {
                Coordinate coordinate = new Coordinate(x, y);
                Console.WriteLine($"{x},{y}");
                //Console.WriteLine(coordinate.XCoordinate + coordinate.YCoordinate);
                return coordinate;
            }
            else
                Console.WriteLine("Please enter in a valid input.");
                return null;
        }



        public void PlaceShip(Player player, ShipType shiptype)
        {
            Console.Write($"{player.Name}, Please enter in the coordinates you would like to place your {shiptype} (X,Y) : ");
            string userInput = Console.ReadLine();
            ShipPlacement result;
            do
            {
                PlaceShipRequest request = new PlaceShipRequest();
                request.ShipType = shiptype;
                request.Coordinate = CreateCord(userInput);
                request.Direction = ReadDirection();

                result = player.PlayerBoard.PlaceShip(request);
                if (result == ShipPlacement.NotEnoughSpace)
                {
                    Console.WriteLine("There is not enough space for your placement, please try again");
                }
                else if (result == ShipPlacement.Overlap)
                {
                    Console.WriteLine("You have overlapped with another ship, please choose a different spot.");
                }
            }
            while (result != ShipPlacement.Ok);
            {
                Console.WriteLine("Success!");
            }
        }

        private void TakeTurns(int Player)
        {
            if ( Player == 1 )
            {
                Console.Write("Please enter in the coordinate you would like to fire at (X,Y): ");
                string userInput = Console.ReadLine();
                Coordinate nate = new Coordinate(5, 5);
                Board board = new Board();

                Coordinate coordinate = new Coordinate(1, 3);
                var response = board.FireShot(nate);
            }
            if (Player == 2)
            {

            }

        }


        private ShipDirection ReadDirection()
        {
            Console.WriteLine("Enter the Direction:");
            string input = Console.ReadLine();

            switch (input)
            {
                case "up":
                    return ShipDirection.Up;
                case "down":
                    return ShipDirection.Down;
                case "left":
                    return ShipDirection.Up;
                case "right":
                    return ShipDirection.Right;
                default:
                    return ShipDirection.Down;
            }
        }

        //public Player CreatePlayer(string prompt)
        //{

        //    Player p = new Player();
        //    Console.Write($"{prompt} Please put in your name:");
        //    string name = Console.ReadLine();
        //    p.Name = name;
        //    return p;

        //}
        public void drawBoard(int x)
        {
            Console.Clear();
            for (int row = 0; row < x; row++)
            {
                for (int col = 0; col < x; col++)
                {
                    Console.Write("|_");

                }
                Console.WriteLine();
            }
        }
    }
}