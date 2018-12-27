namespace Pizza_Maker.Domain.Models
{
    public interface IAllUpgrades
    {
        bool IsPurchased { get; set; }
        decimal PercentIncrease { get; set; }
        string PlayerID { get; set; }
        decimal Price { get; set; }
        string UpgradeID { get; set; }
        string UpgradesName { get; set; }
    }
}