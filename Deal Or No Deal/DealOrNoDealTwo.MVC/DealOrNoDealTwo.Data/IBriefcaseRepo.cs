using System.Collections.Generic;
using DealOrNoDealTwo.Domain.Models;

namespace DealOrNoDealTwo.Data
{
    public interface IBriefcaseRepo
    {
        void AddBriefcases();
        IEnumerable<Briefcase> All();
        IEnumerable<Player> AllPlayers();
        Round ChangeBankerPercentage(Round round);
        void DeleteAllBriefCases();
        bool DeleteById(int id);
        Briefcase FindBriefCaseById(int id);
        Player FindPlayerById(int id);
        Round FindRoundById(int id);
        Player Save(Player player);
    }
}