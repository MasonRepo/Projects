using System.Collections.Generic;

namespace Vending_Machine.Data
{
    public interface IFileRepo
    {
        Dictionary<string, VendingItem> GrabInfo();
        bool Update(Dictionary<string, VendingItem> file);
    }
}