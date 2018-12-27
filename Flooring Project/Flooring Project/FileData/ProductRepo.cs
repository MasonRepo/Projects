using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Flooring_Project.FileData
{
    public class ProductRepo : IProductRepo
    {
        public IEnumerable<ProductData> GrabInfo(string ID)
        {
            var Products = new List<ProductData>();
            var p = new ProductData();

            string path = @"C:\Users\Mason\Desktop\mason-berge-individual-work\Flooring Project\Flooring Project\bin\Debug\Products.txt";
            string[] rows = File.ReadAllLines(path);
            {
                for (int i = 1; i < rows.Length; i++)
                {
                    if (rows[i].Contains($"{ID},"))
                    {

                        string[] columns = rows[i].Split(',');

                        if (columns.Length != 3)
                        {
                            break;
                        }

                        else
                        {

                            Products.Add(new ProductData
                            {
                                ProductType = columns[0],
                                CostSqFeet = decimal.Parse(columns[1]),
                                LaborCost = decimal.Parse(columns[2])

                            });
                        }
                    }
                }
            }

            return Products;

        }
        public IEnumerable<ProductData> DisplayAll()
        {
            var Products = new List<ProductData>();
            var p = new ProductData();

            string path = @"C:\Users\Mason\Desktop\mason-berge-individual-work\Flooring Project\Flooring Project\bin\Debug\Products.txt";
            string[] rows = File.ReadAllLines(path);
            {
                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(',');

                    if (columns.Length != 3)
                    {
                        break;
                    }

                    else
                    {

                        Products.Add(new ProductData
                        {
                            ProductType = columns[0],
                            CostSqFeet = decimal.Parse(columns[1]),
                            LaborCost = decimal.Parse(columns[2])

                        });
                    }
                }
            }

            return Products;

        }
    }
}
