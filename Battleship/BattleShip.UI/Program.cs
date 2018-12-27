using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public class Program
    {
         static void Main(string[] args)
        {

            BattleshipController c = new BattleshipController();
            c.Run();
        }
    }
   
}




