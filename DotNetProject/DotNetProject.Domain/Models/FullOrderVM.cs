using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetProject.Domain.Models
{
    public class FullOrderVM
    {
        public IEnumerable<ContactModel> contact { get; set; }
        public IEnumerable<OrderModel> order { get; set; }

    }
}
