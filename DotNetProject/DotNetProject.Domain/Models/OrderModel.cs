using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetProject.Domain.Models
{
    public class OrderModel
    {
        public int ID { get; set; }

        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }

        [Column(TypeName = "DateTime2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Name")]
        public int ContactID { get; set; }

        [Display(Name = "Order Description")]
        public string OrderDescription { get; set; }
        [Display(Name = "Order Amount")]
        public decimal OrderAmount { get; set; }
    }
}
