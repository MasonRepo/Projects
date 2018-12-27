using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FieldAgent.Models
{
    public class Agent
    {

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PictureUrl { get; set; }

        //Birth Date - Between 1/1/1900 and ten years from the current day.
        [Required]
        public DateTime BirthDate { get; set; }

        //Height in inches - Required, between 36 and 96
        [Range(36,96)]
        public decimal HeightIN { get; set; }

        //Identifier - User-entered, Required, must be globally unique
        [Required]
        public int UserID { get; set; }

        //Agency - Required, See Below
        [Required]
        public string Agency { get; set; }

        //Activation Date - Required
        [Required]
        public DateTime ActivationDate { get; set; }

        //Security Clearance - Required, See Below
        [Required]
        public string SecurityClearance { get; set; }

        //Is Active
        [Required]
        public bool IsActive { get; set; }

        //Aliases - Zero-to-many names
        public IEnumerable<string> Aliases { get; set; }
    }
}