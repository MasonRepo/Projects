namespace Pizza_Maker.Domain.Models
{
    public interface IPlayerUpgrades
    {
        bool IsPurchased { get; set; }
        string PlayerID { get; set; }
        int PlayerUpgradesID { get; set; }
        decimal Price { get; set; }
        string UpgradeID { get; set; }
    }
}