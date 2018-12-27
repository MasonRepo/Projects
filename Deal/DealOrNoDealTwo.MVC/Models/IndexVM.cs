using DealOrNoDealTwo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealOrNoDealTwo.MVC.Models
{
    public class IndexVM
    {
        public Player Player { get; set; }
        //public Briefcase Briefcase { get; set; }
        public List<Briefcase> Briefcases { get; set; }
        public Round Round { get; set; }
        public GameState GameState { get; set; }
        public decimal? LastClicked { get; set; }
    }
}