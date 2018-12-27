namespace Pizza_Maker.Domain.Models
{
    public interface IBuilding
    {
        decimal BaseCost { get; set; }
        int BuildingID { get; set; }
        string BuildingName { get; set; }
        decimal PizzaIncrease { get; set; }
    }
}