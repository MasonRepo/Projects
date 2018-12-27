using DealOrNoDealTwo.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDealTwo.Tests
{
    [TestFixture]
    public class BriefcaseRepositoryTests
    {
        [Test]
        public void AllTest()
        {
            var repo = new BriefcaseRepo();
            var actual = repo.All();
            Assert.IsTrue(actual != null && actual.Any());
        }


        [Test]
        public void CanDelete()
        {
            var repo = new BriefcaseRepo();
            var actual = repo.DeleteById(1);
            Assert.AreEqual(actual, true);
        }

        [Test]
        public void CanFind()
        {
            var repo = new BriefcaseRepo();
            var actual = repo.FindBriefCaseById(2);
            Assert.AreEqual(actual.BriefCaseId, 2);
        }

        [Test]
        public void CanFindRound()
        {
            var repo = new BriefcaseRepo();
            var actual = repo.FindRoundById(1);
            Assert.AreEqual(actual.RoundId, 1);
        }

        [Test]
        public void CanUpdateBankerPercentage()
        {
            var repo = new BriefcaseRepo();
            var round = repo.FindRoundById(1);
            var updatedRound = round.BankerPercentage = 0.2M;
            var actual = repo.ChangeBankerPercentage(round);
            
            

            Assert.AreEqual(actual.BankerPercentage, 0.2M);
        }

        [Test]
        public void CanGenerateBriefcases()
        {
            var repo = new BriefcaseRepo();
            repo.AddBriefcases();
            var actual = repo.All();

            Assert.AreEqual(actual.ToList().Count, 26);

        }
        
        [Test]
        public void DeleteAllBriefcases()
        {
            var repo = new BriefcaseRepo();
            repo.DeleteAllBriefCases();
            var actual = repo.All();

            Assert.AreEqual(actual.ToList().Count, 0);
        }
    }
}
