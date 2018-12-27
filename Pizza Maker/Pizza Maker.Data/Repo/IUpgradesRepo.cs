using System.Collections.Generic;
using Pizza_Maker.Domain.Models;
using Pizza_Maker.Domain.ViewModels;

namespace Pizza_Maker.Data.Repo
{
    public interface IUpgradesRepo
    {
        IEnumerable<PlayerUpgrades> All();
        IEnumerable<PlayerUpgrades> AllLoggedIn(string UserID);
        IEnumerable<AllUpgrades> GrabUpgrades(string ID);
        IEnumerable<PlayerUpgrades> StartUpgrades(string ID);
        void Update(EverythingVM vm);
    }
}