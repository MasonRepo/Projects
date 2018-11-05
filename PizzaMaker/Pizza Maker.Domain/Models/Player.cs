using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.Models
{
    public class Player : IPlayer
    {
        public int PlayerID { get; set; }
        public string LoginID { get; set; }
        public decimal PizzaAmount { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
