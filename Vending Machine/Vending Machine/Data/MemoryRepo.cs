using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Data
{
    class MemoryRepo : IFileRepo
    {
        public Dictionary<string, VendingItem> GrabInfo()
        {
            VendingItem vend = new VendingItem();

            vend.Location = "A1";
            vend.Name = "Oreo's";
            vend.Inventory = 5;
            vend.Price = 2.5M;

            Dictionary<string, VendingItem> vending = new Dictionary<string, VendingItem>();
            vending.Add(vend.Location, new VendingItem
            {
                Location = "A1",
                Name = "Oreo's",
                Price = 2.5M,
                Inventory = 5


            });
            return vending;

            //throw new NotImplementedException();
        }

        public bool Update(Dictionary<string, VendingItem> file)
        {
            throw new NotImplementedException();
        }
    }
}
