using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring_Project.FileData
{
    public class TaxRepo : ITaxRepo
    {
        public IEnumerable<TaxData> GrabInfo(string ID)
        {
            var Taxes = new List<TaxData>();
            var t = new TaxData();

            string path = @"C:\Users\Mason\Desktop\mason-berge-individual-work\Flooring Project\Flooring Project\bin\Debug\Taxes.txt";
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

                            Taxes.Add(new TaxData
                            {
                                StateAbrev = columns[0],
                                StateName = columns[1],
                                TaxRate = decimal.Parse(columns[2])

                            });
                        }
                    }
                }
            }

            return Taxes;

        }
        public IEnumerable<TaxData> DisplayAll()
        {
            var Taxes = new List<TaxData>();
            var t = new TaxData();

            string path = @"C:\Users\Mason\Desktop\mason-berge-individual-work\Flooring Project\Flooring Project\bin\Debug\Taxes.txt";
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

                        Taxes.Add(new TaxData
                        {
                            StateAbrev = columns[0],
                            StateName = columns[1],
                            TaxRate = decimal.Parse(columns[2])

                        });
                    }
                }
            }

            return Taxes;

        }


    }
}
