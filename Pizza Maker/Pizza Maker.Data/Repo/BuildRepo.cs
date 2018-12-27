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
    public class BuildRepo : IBuildRepo
    {

        private const string CONN_STRING_KEY = "PizzaMaker";

        public IEnumerable<PlayerBuildings> All()
        {
            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                return conn.Query<PlayerBuildings>("SELECT PlayerID, BuildingID, Price, AmountPlayerHas FROM PlayerBuildings;");
            }
        }
        public IEnumerable<PlayerBuildings> AllLoggedIn(string UserID)
        {
            var result = new List<PlayerBuildings>();

            foreach (var c in All())
            {
                if (c.PlayerID == UserID)
                {
                    result.Add(c);
                }
            }
            return result;
        }

        public IEnumerable<PlayerBuildings> StartBuildings(string ID)
        {
            const string sql = "INSERT INTO PlayerBuildings(PlayerID, BuildingID, Price, AmountPlayerHas) "
       + "VALUES (@PlayerID, 1, 10, 0)," +
       "(@PlayerID, 2, 600, 0)," +
       "(@PlayerID, 3, 2100, 0)," +
       "(@PlayerID, 4, 4356, 0)," +
       "(@PlayerID, 5, 6300, 0)," +
       "(@PlayerID, 6, 12000,0); "
       + "SELECT SCOPE_IDENTITY()";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                conn.Execute(sql, new { PlayerID = ID });
            }
            return AllLoggedIn(ID);
        }

        public IEnumerable<TotalBuildings> GrabBuildings(string ID)
        {
            const string sql = "Select * " +
                "FROM Buildings, PlayerBuildings " +
                "WHERE Buildings.BuildingID = PlayerBuildings.BuildingID and PlayerBuildings.PlayerID = @PlayerID";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                return conn.Query<TotalBuildings>(sql, new { PlayerID = ID });
            }
        }

        public void Update(EverythingVM vm)
        {

            const string sql = "UPDATE PlayerBuildings SET "
                + "AmountPlayerHas = @AmountHas, Price = @NewPrice "
                + "WHERE PlayerBuildings.BuildingID = @BuildingChoice and PlayerBuildings.PlayerID = @PlayerID";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                foreach (var r in vm.TotalBuildings)
                {
                    conn.Execute(sql, new { AmountHas = r.AmountPlayerHas, BuildingChoice = r.BuildingID, PlayerID = r.PlayerID, NewPrice = r.Price });                  

                    
                }
            }
        }

    }
}
