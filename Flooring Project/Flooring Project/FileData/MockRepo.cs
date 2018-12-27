using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring_Project.FileData
{
    class MockRepo : IOrderRepo
    {
        public IEnumerable<Orders> GrabDate(DateTime DT)
        {
            throw new NotImplementedException();
        }

        public void RemoveByDateTime(DateTime DT)
        {
            throw new NotImplementedException();
        }

        public void RemoveByDateTime(DateTime DT, int ID)
        {
            throw new NotImplementedException();
        }

        public void Write(DateTime DT, Orders order)
        {
            throw new NotImplementedException();
        }
    }
}
