using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Data
{
    public class FileRepo : IFileRepo
    {
        public Dictionary<string, VendingItem> GrabInfo()
        {
            string path = @"C:\Users\Mason\Downloads\VendingItems.TXT";

            VendingItem vend = new VendingItem();

            Dictionary<string, VendingItem> vending = new Dictionary<string, VendingItem>();
            string[] rows = File.ReadAllLines(path);

            for (int i = 0; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                if (columns.Length != 4)
                {
                    continue;
                }

                vending.Add(columns[0], new VendingItem
                {
                    Location = columns[0],
                    Name = columns[1],
                    Price = decimal.Parse(columns[2]),
                    Inventory = int.Parse(columns[3])


                });

            }
            return vending;
        }

        public bool Update(VendingItem item)
        {
            throw new NotImplementedException();
        }




        public bool Update(Dictionary<string, VendingItem> file)
        {
            string filePath = @"C:\Users\Mason\Downloads\VendingItems.TXT";

            var list = file.ToList();

            if (file != null)
            {


                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var r in list)
                    {
                        writer.WriteLine($"{r.Value.Location},{r.Value.Name},{r.Value.Price},{r.Value.Inventory}");
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
