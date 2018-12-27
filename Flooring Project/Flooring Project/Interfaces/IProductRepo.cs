using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring_Project.FileData
{
     public interface IProductRepo
    {
        IEnumerable<ProductData> GrabInfo(string ID);

    }
}
