using System;

namespace Pizza_Maker.Domain.Models
{
    public interface IPlayer
    {
        DateTime DateCreated { get; set; }
        decimal PizzaAmount { get; set; }
    }
}