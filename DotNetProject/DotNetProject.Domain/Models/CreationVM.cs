using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetProject.Domain.Models
{
    public class CreationVM
    {
        public OrderModel order { get; set; }
        public ContactModel contact { get; set; }
        public IEnumerable<ContactModel> contacts { get; set; }

    }
}
