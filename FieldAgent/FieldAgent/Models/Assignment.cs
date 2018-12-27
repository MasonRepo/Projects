using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FieldAgent.Data
{
    public class Assignment
    {

        //Agent Identifier - Required
        [Required]
        public int Id { get; set; }

        //Country Code - Required, from ISO 3166-1
        [Required]
        public string CountryCode { get; set; }

        //Start Date - Required, must be before Projected and Actual End Date
        [Required]
        public DateTime StartDate { get; set; }

        //Projected End Date - Required, must be after Start Date
        [Required]
        public DateTime ProjectedEndDate { get; set; }
        
        //Actual End Date - Complete on mission completion, must be after Start Date
        [Required]
        public DateTime EndDate { get; set; }

        //Notes
        public string Notes { get; set; }
                
        //TEST LIST
        public static IEnumerable<Assignment> All()
        {
            yield return new Assignment { Id = 004, CountryCode = "Afghanistan" };
            yield return new Assignment { Id = 248, CountryCode = "Åland Islands" };
            yield return new Assignment { Id = 008, CountryCode = "Albania" };
        }


    }
}