using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Class1
    {
        public void something(int x)
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
        //void containter(string input)
        //{
        //    while (true)
        //    {

        //        if (whoFirst == 1)
        //        {
        //            // DrawingBoard();
        //            for (int i = 0; i <= (int)BLL.Ships.ShipType.Carrier; i++)
        //            {
        //                Console.WriteLine($"Please enter in the coordinates you would like to place your {(BLL.Ships.ShipType)i} X/Y");
        //                string input = Console.ReadLine();
        //                CreateCord(input);


        //            }

        //        }

        //        {
        //            for (int i = 0; i <= (int)BLL.Ships.ShipType.Carrier; i++)
        //            {
        //                Console.WriteLine($"Please enter in the coordinates you would like to place your {(BLL.Ships.ShipType)i} X/Y");
        //                string input = Console.ReadLine();
        //                CreateCord(input);


        //            }
        //        }

        //    }

        //}
