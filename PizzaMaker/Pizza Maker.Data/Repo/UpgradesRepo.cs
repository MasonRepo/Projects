using Dapper;
using Pizza_Maker.Domain.Models;
using Pizza_Maker.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Data.Repo
{
    public class UpgradesRepo : IUpgradesRepo
    {

        private const string CONN_STRING_KEY = "PizzaMaker";

        public IEnumerable<PlayerUpgrades> All()
        {
            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                return conn.Query<PlayerUpgrades>("SELECT PlayerID, UpgradeID, Price, IsPurchased FROM PlayerUpgrades;");
            }
        }



        public IEnumerable<PlayerUpgrades> AllLoggedIn(string UserID)
        {
            var result = new List<PlayerUpgrades>();

            foreach (var c in All())
            {
                if (c.PlayerID == UserID)
                {
                    result.Add(c);
                }
            }
            return result;
        }









        // WORK IN PROGRESS





        public IEnumerable<PlayerUpgrades> StartUpgrades(string ID)
        {
            const string sql = "INSERT INTO PlayerUpgrades(PlayerID, UpgradeID, Price, IsPurchased) "
       + "VALUES (@PlayerID, 1, 600, 0)," +
       "(@PlayerID, 2, 1200, 0)," +
       "(@PlayerID, 3, 3400, 0)," +
       "(@PlayerID, 4, 6000, 0)," +
       "(@PlayerID, 5, 12000, 0); "
       + "SELECT SCOPE_IDENTITY()";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                conn.Execute(sql, new { PlayerID = ID });
            }
            return AllLoggedIn(ID);
        }

        public IEnumerable<AllUpgrades> GrabUpgrades(string ID)
        {
            const string sql = "Select * " +
                "FROM Upgrades, PlayerUpgrades " +
                "WHERE Upgrades.UpgradesID = PlayerUpgrades.UpgradeID and PlayerUpgrades.PlayerID = @PlayerID";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                return conn.Query<AllUpgrades>(sql, new { PlayerID = ID });
            }
        }

        public void Update(EverythingVM vm)
        {
            const string sql = "UPDATE PlayerUpgrades SET "
                + "IsPurchased = @IsPurchased "
                + "WHERE PlayerUpgrades.UpgradeID = @UpgradeChoice and PlayerUpgrades.PlayerID = @PlayerID";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                foreach (var r in vm.AllUpgrades)
                {
                    conn.Execute(sql, new { UpgradeChoice =  r.UpgradeID , IsPurchased = r.IsPurchased, PlayerID = r.PlayerID});
                }
            }
        }



    }
}
