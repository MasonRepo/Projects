using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Flooring_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = Factory.Create();

            var c = new Controller(services);
            c.Run();
        }
    }
}
