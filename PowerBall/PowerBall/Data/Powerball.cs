using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBall.Data
{
    public class Powerball
    {
        public int ID { get; set; }
        public int Powerballnum { get; set; }
        public List<int> Nmbers { get; set; } = new List<int>();
        public int Match { get; set; }




    }
}
