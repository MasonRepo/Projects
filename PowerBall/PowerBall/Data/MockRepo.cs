using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PowerBall.Data
{
    public class MockRepo
    {
        // this class is going to be where the interface is implemented and used for testing. actually not really sure if it needs to be used. pretty confused on everythign.


        //public Powerball Create(Powerball pick)
        //{

        //    //var p = new Powerball();


        //}

        public IEnumerable<Powerball> FindBestMatches(Powerball draw)
        {
            throw new NotImplementedException();
        }

        public Powerball FindById(int identifier)
        {
            throw new NotImplementedException();
        }
    }
}
