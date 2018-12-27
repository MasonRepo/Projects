using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring_Project.FileData;

namespace Flooring_Project
{
    public class Services
    {
        public IOrderRepo orderRepo;
        public ITaxRepo taxRepo;
        public IProductRepo productRepo;

        // i still don't understand this too much.
        //kinda

        public Services(IOrderRepo orderRepo, ITaxRepo taxRepo, IProductRepo productRepo)
        {

            this.orderRepo = orderRepo;
            this.taxRepo = taxRepo;
            this.productRepo = productRepo;
        }


        public void RemovingOrder(DateTime dt, int ID)
        {
            var order = new FileData.OrderRepo();
            var file = order.GrabDate(dt);



            foreach (var f in file)
            {
                if (f.OrderNum == ID)
                {
                    var orders = order.FindByIDAndDate(ID, dt);
                    var remove = order.RemoveOrder(file, dt, orders, ID);
                    order.WriteOrders(remove, dt);
                    var testing = order.GrabDate(dt);
                }
            }
        }




        public List<Orders> EditOrder(int ID, DateTime dt, string editChoice, int varToChange)
        {
            if (editChoice == null)
            {
                return null;
            }
            else
            {
                var order = new FileData.OrderRepo();
                var file = order.GrabDate(dt);

                var edit = order.FindByIDAndDate(ID, dt);
                var result = order.EditOrder(file, ID, editChoice, varToChange);

                if (result == null)
                {
                    return null;
                }
                else
                {

                    var calc = CalculateNewValues(result, editChoice, ID);

                    order.WriteOrders(calc, dt);

                    return result;
                }
            }

        }

        public Orders CreateOrder(string productChoice, string taxChoice, DateTime DT, string name, string height, string length)
        {
            // adding appropriate file class info into the order class
            //creating variables
            var products = new ProductRepo();
            var productInfo = products.GrabInfo(productChoice);
            var taxes = new TaxRepo();
            var taxInfo = taxes.GrabInfo(taxChoice);
            var orderInfo = new Orders();
            var ordersFile = new OrderRepo();


            var orderCount = ordersFile.GrabDate(DT);
            int count;
            if (orderCount.Count() == 0)
            {
                count = 0;
            }
            else
            {

                count = orderCount.Max(c => c.OrderNum);
            }


            foreach (var t in taxInfo)
            {
                if (t.StateAbrev == taxChoice)
                {
                    orderInfo.TaxRate = t.TaxRate;
                    orderInfo.State = t.StateAbrev;
                }
            }
            foreach (var p in productInfo)
            {
                if (p.ProductType == productChoice)
                {
                    orderInfo.ProductType = p.ProductType;
                    orderInfo.LaborCostPerSquareFoot = p.LaborCost;
                    orderInfo.CostPerSquareFoot = p.CostSqFeet;
                }
            }

            orderInfo.OrderNum = count + 1;
            orderInfo.CustomerName = name;
            orderInfo.Area = CalculateArea(decimal.Parse(height), decimal.Parse(length));
            orderInfo.MaterialsCost = MaterialCost(orderInfo.Area, orderInfo.CostPerSquareFoot);
            orderInfo.LaborCost = LaborCost(orderInfo.Area, orderInfo.LaborCostPerSquareFoot);
            orderInfo.Tax = TaxCost(orderInfo.MaterialsCost, orderInfo.LaborCost, orderInfo.TaxRate);
            orderInfo.Total = TotalCost(orderInfo.MaterialsCost, orderInfo.LaborCost, orderInfo.Tax);


            //var writeOrders = new OrderRepo();
            ordersFile.Write(DT, orderInfo);
            return orderInfo;

        }

        public List<Orders> CalculateNewValues(IEnumerable<Orders> orders, string userChoice, int ID)
        {
            var products = new ProductRepo();
            var productInfo = products.GrabInfo(userChoice);
            var taxes = new TaxRepo();
            var taxInfo = taxes.GrabInfo(userChoice);
            var orderList = orders.ToList();

            foreach (var order in orderList)
            {
                if (order.OrderNum == ID)
                {

                    foreach (var t in taxInfo)
                    {
                        if (t.StateAbrev == userChoice)
                        {
                            order.TaxRate = t.TaxRate;
                            order.State = t.StateAbrev;
                        }
                    }

                    foreach (var p in productInfo)
                    {
                        if (p.ProductType == userChoice)
                        {
                            order.ProductType = p.ProductType;
                            order.LaborCostPerSquareFoot = p.LaborCost;
                            order.CostPerSquareFoot = p.CostSqFeet;
                        }
                    }
                    order.MaterialsCost = MaterialCost(order.Area, order.CostPerSquareFoot);
                    order.LaborCost = LaborCost(order.Area, order.LaborCostPerSquareFoot);
                    order.Tax = TaxCost(order.MaterialsCost, order.LaborCost, order.TaxRate);
                    order.Total = TotalCost(order.MaterialsCost, order.LaborCost, order.Tax);

                }

            }
            return orderList;
        }

        public decimal CalculateArea(decimal height, decimal length)
        {

            return height * length;
        }

        //  MaterialCost = (Area* CostPerSquareFoot)
        //  LaborCost = (Area * LaborCostPerSquareFoot)
        //  Tax = ((MaterialCost + LaborCost) * (TaxRate/100))
        //  Tax rates are stored as whole numbers
        //  Total = (MaterialCost + LaborCost + Tax)
        public decimal MaterialCost(decimal area, decimal matCost)//reduction can refer to labercost or tax
        {
            return area * matCost;
        }

        public decimal LaborCost(decimal area, decimal labCost)
        {
            return area * labCost;
        }

        public decimal TaxCost(decimal MaterialCost, decimal LaberCost, decimal Tax)
        {
            return (MaterialCost + LaberCost) * (Tax / 100);
        }

        public decimal TotalCost(decimal MaterialCost, decimal LaberCost, decimal TaxCost)
        {
            return MaterialCost + LaberCost + TaxCost;

        }

        public bool CheckProduct(string productType)
        {
            var prod = new FileData.ProductRepo();

            var products = prod.DisplayAll();

            string productChoice = productType;
            foreach (var p in products)
            {
                if (productChoice == p.ProductType)
                {
                    return true;
                }
            }
            return false;

        }
        public bool CheckTaxes(string taxChoice)
        {
            var tax = new FileData.TaxRepo();

            var taxes = tax.DisplayAll();

            foreach (var t in taxes)
            {
                if (taxChoice == t.StateAbrev)
                {
                    return true;
                }

            }
            return false;
        }
        public bool CheckNumbers(string length, string width)
        {
            if (decimal.TryParse(length, out decimal testNum) == false || decimal.TryParse(width, out decimal otherTestNum) == false)
            {
                return false;
            }
            return true;
        }
    }
}

