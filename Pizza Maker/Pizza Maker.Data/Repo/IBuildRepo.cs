using System.Collections.Generic;
using Pizza_Maker.Domain.Models;
using Pizza_Maker.Domain.ViewModels;

namespace Pizza_Maker.Data.Repo
{
    public interface IBuildRepo
    {
        IEnumerable<PlayerBuildings> All();
        IEnumerable<PlayerBuildings> AllLoggedIn(string UserID);
        IEnumerable<TotalBuildings> GrabBuildings(string ID);
        IEnumerable<PlayerBuildings> StartBuildings(string ID);
        void Update(EverythingVM vm);
    }
}