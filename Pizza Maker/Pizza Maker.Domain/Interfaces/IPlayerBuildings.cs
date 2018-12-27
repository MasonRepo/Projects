namespace Pizza_Maker.Domain.Models
{
    public interface IPlayerBuildings
    {
        decimal AmountPlayerHas { get; set; }
        string BuildingID { get; set; }
        int PlayerBuildingsID { get; set; }
        string PlayerID { get; set; }
        decimal Price { get; set; }
    }
}