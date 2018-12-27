using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring_Project.FileData
{
    public class Orders
    {
        public int OrderNum { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal Tax { get; set; }
        public string ProductType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal Area { get; set; }
        public decimal MaterialsCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Total { get; set; }



    }
}
