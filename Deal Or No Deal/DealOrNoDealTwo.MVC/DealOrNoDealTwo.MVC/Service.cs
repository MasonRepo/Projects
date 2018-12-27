//using DealOrNoDealTwo.Data;
//using DealOrNoDealTwo.Domain.Models;
//using DealOrNoDealTwo.MVC.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace DealOrNoDealTwo.MVC
//{
//    public class Service
//    {
//        private IBriefcaseRepo repo;
//        public void SetRepo(IBriefcaseRepo repo)
//        {
//            this.repo = repo;
//        }

//        // this one shall take care of setting the round number and how many cases have been and can be picked.
//        public void ManageRounds(GameState state)
//        {
//            // this will indicate a fresh game
//            if (state.RoundNumber == 0)
//            {
//                state.RoundNumber = 1;
//                state.AmountChosen = 0;
//            }
//            if (state.AmountChosen == 6 && state.RoundNumber == 1)
//            {
//                state.RoundNumber++;
//                state.AmountChosen = 0;
//            }
//            if (state.AmountChosen == 5 && state.RoundNumber == 2)
//            {
//                state.RoundNumber++;
//                state.AmountChosen = 0;
//            }
//            if (state.AmountChosen == 4 && state.RoundNumber == 3)
//            {
//                state.RoundNumber++;
//                state.AmountChosen = 0;
//            }
//            if (state.AmountChosen == 3 && state.RoundNumber == 4)
//            {
//                state.RoundNumber++;
//                state.AmountChosen = 0;
//            }
//            if (state.AmountChosen == 2 && state.RoundNumber == 5)
//            {
//                state.RoundNumber++;
//                state.AmountChosen = 0;
//            }

//            throw new NotImplementedException();
//        }


//        public void CheckWin(IndexVM vm)
//        {
//            BriefcaseRepo repo = new BriefcaseRepo();
//            var count = vm.Briefcases.Count();
//            // if it's 1 that mean they're on the last one and that's what they get.
//            if (count == 1)
//            {
//                foreach (var sum in vm.Briefcases)
//                {
//                    vm.Player.EndingSum = sum.Amount;
//                }
//            }
//        }

//    }
//}
