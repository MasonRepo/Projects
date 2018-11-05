using Pizza_Maker.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Maker.Data.Repo
{
    public class PlayerRepoTest
    {
        private const string CONN_STRING_KEY = "PizzaMakerTest";

        public IEnumerable<Player> All()
        {
            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                return conn.Query<Player>("SELECT PlayerID, PlayerName FROM Player;");
            }
        }

        public IEnumerable<Player> AllLoggedIn(string UserID)
        {

            const string sql = "SELECT PlayerID, PizzaAmount, DateCreated FROM Player WHERE Player.LoginID = @LoginID;";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                return conn.Query<Player>(sql, new { LoginID = UserID });
            }
        }


        public bool Delete(int id)
        {
            const string sql = "DELETE FROM Player WHERE PlayerId = @PlayerID";
            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                return conn.Execute(sql, new { PlayerId = id }) > 0;
            }
        }

        public Player FindById(string id)
        {
            const string sql = "SELECT PlayerID, PizzaAmount, DateCreated "
                   + "FROM Player "
                   + "WHERE PlayerID = @PlayerID;";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                return conn.Query<Player>(sql, new { PlayerId = id })
                    .FirstOrDefault();
            }
        }

        public Player Save(Player player)
        {
            if (player.PlayerID > 0)
            {
                return Update(player);
            }
            return Insert(player);
        }

        private Player Insert(Player player)
        {
            const string sql = "INSERT INTO Player (LoginID, PizzaAmount, DateCreated) "
                   + "VALUES (@LoginID, @PizzaAmount, @DateCreated); "
                   + "SELECT SCOPE_IDENTITY()";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                player.PlayerID = conn.Query<int>(sql, player).First();
            }
            return player;
        }

        private Player Update(Player player)
        {
            const string sql = "UPDATE Player SET "
                + "PizzaAmount = @PizzaAmount "
                + "WHERE PlayerID = @PlayerID;";

            using (var conn = Database.GetOpenConnection(CONN_STRING_KEY))
            {
                conn.Execute(sql, player);
            }
            return null;
        }

    }
}
