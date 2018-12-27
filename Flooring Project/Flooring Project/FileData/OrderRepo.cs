using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Flooring_Project.FileData
{
    public class OrderRepo : IOrderRepo
    {


        public void Write(DateTime DT, Orders order)
        {
            var fixedDT = DT.ToString("MMddyyyy");
            string txt = ".txt";
            string hope = $@"C:\Users\Mason\Desktop\mason-berge-individual-work\Flooring Project\Flooring Project\bin\Debug\Orders\Orders_{fixedDT}{txt}";
            string header = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";

            if (!File.Exists(hope))
            {
                using (StreamWriter writer = File.AppendText(hope))
                {
                    writer.WriteLine(header);

                }
            }

            using (StreamWriter writer = File.AppendText(hope))
            {

                writer.WriteLine($"{order.OrderNum},{order.CustomerName},{order.State},{order.TaxRate},{order.ProductType},{order.Area},{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot},{order.MaterialsCost},{order.LaborCost},{order.Tax},{order.Total}");
            }
        }

        public IEnumerable<Orders> GrabDate(DateTime DT)
        {
            var orders = new Dictionary<string, Orders>();
            var o = new Orders();
            var fixedDT = DT.ToString("MMddyyyy");
            string file = @"C:\Users\Mason\Desktop\mason-berge-individual-work\Flooring Project\Flooring Project\bin\Debug\Orders\Orders_";
            string hope = $@"{file}{fixedDT}.txt";


            if (File.Exists(hope))
            {
                string[] rows = File.ReadAllLines(hope);
                {
                    for (int i = 1; i < rows.Length; i++)
                    {


                        string[] columns = rows[i].Split(',');

                        if (columns.Length != 12)
                        {
                            break;
                        }

                        else
                        {
                            orders.Add(columns[0], new Orders
                            {
                                OrderNum = int.Parse(columns[0]),
                                CustomerName = columns[1],
                                State = columns[2],
                                TaxRate = decimal.Parse(columns[3]),
                                ProductType = columns[4],
                                Area = decimal.Parse(columns[5]),
                                CostPerSquareFoot = decimal.Parse(columns[6]),
                                LaborCostPerSquareFoot = decimal.Parse(columns[7]),
                                MaterialsCost = decimal.Parse(columns[8]),
                                LaborCost = decimal.Parse(columns[9]),
                                Tax = decimal.Parse(columns[10]),
                                Total = decimal.Parse(columns[11])
                            });
                        }

                    }
                }
            }
            return orders.Values;
        }

        public List<Orders> RemoveOrder(IEnumerable<Orders> orders, DateTime DT, Orders order, int ID)
        {

            var remove = orders.ToList();
            remove.RemoveAll(o => o.OrderNum == ID);

            return remove;
        }

        public List<Orders> EditOrder(IEnumerable<Orders> orders, int ID, string userInput, int varToChange)
        {
            var edit = orders.ToList();


            foreach (var e in edit)
            {
                if (e.OrderNum == ID)
                {
                    if (userInput != null)
                    {
                        if (varToChange == 1)
                        {
                            e.CustomerName = userInput;
                        }
                        else if (varToChange == 2)
                        {
                            if (e.State != userInput)
                            {
                                return edit = null;
                            }
                            else
                            {
                                e.State = userInput;
                            }
                        }
                        else if (varToChange == 3)
                        {
                            if (e.ProductType != userInput)
                            {
                                return edit = null;
                            }
                            else
                            {
                                e.ProductType = userInput;
                            }
                        }
                        else if (varToChange == 4)
                        {
                            if (decimal.TryParse(userInput, out decimal result) == false)
                            {
                                return edit = null;
                            }
                            else
                            {
                                e.Area = decimal.Parse(userInput);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return edit;
        }


        public Orders FindByIDAndDate(int ID, DateTime DT)
        {


            return GrabDate(DT).ToList()
              .First(o => o.OrderNum == ID);


        }

        public void WriteOrders(IEnumerable<Orders> orders, DateTime DT)
        {
            string header = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";

            var fixedDT = DT.ToString("MMddyyyy");
            string txt = ".txt";
            string hope = $@"C:\Users\Mason\Desktop\mason-berge-individual-work\Flooring Project\Flooring Project\bin\Debug\Orders\Orders_{fixedDT}{txt}";


            //this one is funny because essentially I'm clearing it with file to add the header, and to keep the header I appened the file.

            using (StreamWriter writer = new StreamWriter(hope))
            {
                writer.WriteLine(header);

            }

            using (StreamWriter writer = File.AppendText(hope))
            {
                foreach (var r in orders)
                {

                    writer.WriteLine($"{r.OrderNum},{r.CustomerName},{r.State},{r.TaxRate},{r.ProductType},{r.Area},{r.CostPerSquareFoot},{r.LaborCostPerSquareFoot},{r.MaterialsCost},{r.LaborCost},{r.Tax},{r.Total}");


                }
            }


        }
        //ignore these for now
        public void RemoveByDateTime(DateTime DT, int ID)
        {
            throw new NotImplementedException();
        }

        public void RemoveByDateTime(DateTime DT)
        {
            throw new NotImplementedException();
        }
    }
}
