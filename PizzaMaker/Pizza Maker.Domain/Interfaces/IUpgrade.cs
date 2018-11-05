namespace Pizza_Maker.Domain.Models
{
    public interface IUpgrade
    {
        decimal PercentIncrease { get; set; }
        int UpgradeID { get; set; }
        string UpgradeName { get; set; }
    }
}