using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Domain.ViewModels
{
    public class LogInVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        // i don't really wanna use this but just keeping in for now cause I kinda wanna see how it works..
        public bool RememberMe { get; set; }

    }
}
