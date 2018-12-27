//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using DealOrNoDealTwo.Domain.Models;
//using System.Threading.Tasks;
//using DealOrNoDealTwo.Data;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Data;
//using Dapper;

//namespace DealOrNoDealTwo.Data
//{
//    public class BriefcaseRepo : IBriefcaseRepo
//    {
//        private const string CONNECTION_NAME = "GameShow";

//        // gonna be real with you cheif I don't know what we are adding but I DO know that we are going to be getting rid of BREIFCASES

//        //public IEnumerable<Briefcase> All()
//        //{
//        //    using (var context = new ShowContext(CONNECTION_NAME))
//        //    {
//        //        return context.Briefcases.ToList();
//        //    }
//        //}

//        public IEnumerable<Briefcase> All()
//        {
//            using (var cn = new SqlConnection())
//            {
//                cn.ConnectionString = ConfigurationManager
//                    .ConnectionStrings[CONNECTION_NAME]
//                    .ConnectionString;
//                // this is a stored procedure, making note to change later....
//                return cn.Query<Briefcase>("MovieSelectAll",
//                    commandType: CommandType.StoredProcedure);
//            }
//        }

//        //public void DeleteAllBriefCases()
//        //{
//        //    var briefcases = All();
//        //    using (var context = new ShowContext(CONNECTION_NAME))
//        //    {
//        //        context.Briefcases.RemoveRange(context.Briefcases);
//        //        context.SaveChanges();

//        //    }
//        //}


//        public void DeleteAllBriefCases()
//        {
//            using (var cn = new SqlConnection())
//            {
//                cn.ConnectionString = ConfigurationManager
//                    .ConnectionStrings[CONNECTION_NAME]
//                    .ConnectionString;
//                // this is a stored procedure, making note to change later....
//                return cn.Query<Briefcase>("DeleteAll",
//                    commandType: CommandType.StoredProcedure);
//            }
//        }

//        public void AddBriefcases()
//        {

//            Briefcase briefcase = new Briefcase();

//            using (var cn = new SqlConnection())
//            {
//                cn.ConnectionString = ConfigurationManager
//                    .ConnectionStrings[CONNECTION_NAME]
//                    .ConnectionString;
//                // this is a stored procedure, making note to change later....
//                return cn.Query<Briefcase>("AddBriefcases",
//                    commandType: CommandType.StoredProcedure);
//            }


//            //using (var context = new ShowContext(CONNECTION_NAME))
//            //{
//            //    briefcase.Amount = 0.01M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 1M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 5M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 10M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 25M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 50M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 75M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 100M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 200M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 300M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 400M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 500M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 750M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 1000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 5000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 10000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 25000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 50000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 75000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 100000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 200000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 300000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 400000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 500000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();

//            //    briefcase.Amount = 750000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();
//            //    briefcase.Amount = 1000000M;
//            //    context.Briefcases.Add(briefcase);
//            //    context.SaveChanges();
//            //}
//        }

//        public IEnumerable<Player> AllPlayers()
//        {
//            using (var context = new ShowContext(CONNECTION_NAME))
//            {
//                return context.Players.ToList();
//            }
//        }

//        public bool DeleteById(int id)
//        {
//            using (var context = new ShowContext(CONNECTION_NAME))
//            {
//                var existing = context.Briefcases.FirstOrDefault(a => a.BriefCaseId == id);
//                if (existing == null)
//                {
//                    return false;
//                }

//                context.Briefcases.Remove(existing);
//                return context.SaveChanges() > 0;
//            }
//        }

//        public void FindBriefCaseById(int id)
//        {

//            using (var cn = new SqlConnection())
//            {
//                cn.ConnectionString = ConfigurationManager
//                    .ConnectionStrings[CONNECTION_NAME]
//                    .ConnectionString;
//                // this is a stored procedure, making note to change later....
//                return cn.Query<Briefcase>("FindByID",
//                    commandType: CommandType.StoredProcedure);
//            }

//            //using (var context = new ShowContext(CONNECTION_NAME))
//            //{
//            //    return context.Briefcases.FirstOrDefault(a => a.BriefCaseId == id);
//            //}


//        }

//        public Round FindRoundById(int id)
//        {

//            using (var cn = new SqlConnection())
//            {
//                cn.ConnectionString = ConfigurationManager
//                    .ConnectionStrings[CONNECTION_NAME]
//                    .ConnectionString;
//                // this is a stored procedure, making note to change later....
//                return cn.Query<Briefcase>("FindByID",
//                    commandType: CommandType.StoredProcedure);
//            }


//        //    using (var context = new ShowContext(CONNECTION_NAME))
//        //    {
//        //        return context.Rounds.FirstOrDefault(a => a.RoundId == id);
//        //    }
//        }

//        public Round ChangeBankerPercentage(Round round)
//        {



//            using (var cn = new SqlConnection())
//            {
//                cn.ConnectionString = ConfigurationManager
//                    .ConnectionStrings[CONNECTION_NAME]
//                    .ConnectionString;
//                // this is a stored procedure, making note to change later....
//                return cn.Query<Briefcase>("FindByID",
//                    commandType: CommandType.StoredProcedure);
//            }





//            //using (var context = new ShowContext(CONNECTION_NAME))
//            //{
//            //    if (round.RoundId > 0)
//            //    {
//            //        context.Rounds.Attach(round);
//            //        context.Entry(round).State = System.Data.Entity.EntityState.Modified;
//            //    }
//            //    else
//            //    {
//            //        context.Rounds.Add(round);
//            //    }

//            //    if (context.SaveChanges() > 0)
//            //    {
//            //        return round;
//            //    }
//            //}
//            //return null;
//        }

//        public Player FindPlayerById(int id)
//        {


//            using (var cn = new SqlConnection())
//            {
//                cn.ConnectionString = ConfigurationManager
//                    .ConnectionStrings[CONNECTION_NAME]
//                    .ConnectionString;
//                // this is a stored procedure, making note to change later....
//                return cn.Query<Briefcase>("FindByID",
//                    commandType: CommandType.StoredProcedure);
//            }


//            //using (var context = new ShowContext(CONNECTION_NAME))
//            //{
//            //    return context.Players.FirstOrDefault(a => a.PlayerId == id);
//            //}
//        }

//        public Player Save(Player player)
//        {


//            using (var cn = new SqlConnection())
//            {
//                cn.ConnectionString = ConfigurationManager
//                    .ConnectionStrings[CONNECTION_NAME]
//                    .ConnectionString;
//                // this is a stored procedure, making note to change later....
//                return cn.Query<Briefcase>("FindByID",
//                    commandType: CommandType.StoredProcedure);
//            }




//            //using (var context = new ShowContext(CONNECTION_NAME))
//            //{
//            //    if (player.PlayerId > 0)
//            //    {
//            //        context.Players.Attach(player);
//            //        context.Entry(player).State = System.Data.Entity.EntityState.Modified;
//            //    }
//            //    else
//            //    {
//            //        context.Players.Add(player);
//            //    }

//            //    if (context.SaveChanges() > 0)
//            //    {
//            //        return player;
//            //    }
//            //}

//            //return null;
//        }

//    }
//}
