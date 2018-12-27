using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring_Project.FileData
{
    public interface IOrderRepo
    {
        IEnumerable<Orders> GrabDate(DateTime DT);
        void RemoveByDateTime(DateTime DT);
        void Write(DateTime DT, Orders order);
        void RemoveByDateTime(DateTime DT, int ID);
    }
}
