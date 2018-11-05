namespace Pizza_Maker.Domain.Models
{
    public interface ITotalBuildings
    {
        decimal AmountPlayerHas { get; set; }
        decimal BaseCost { get; set; }
        string BuildingID { get; set; }
        string BuildingName { get; set; }
        decimal PizzaIncrease { get; set; }
        string PlayerID { get; set; }
        decimal Price { get; set; }
    }
}