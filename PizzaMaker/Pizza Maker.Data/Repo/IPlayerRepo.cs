using System.Collections.Generic;
using Pizza_Maker.Domain.Models;

namespace Pizza_Maker.Data.Repo
{
    public interface IPlayerRepo
    {
        IEnumerable<Player> All();
        IEnumerable<Player> AllLoggedIn(string UserID);
        bool Delete(int id);
        Player FindById(string id);
        Player Save(Player player);
    }
}