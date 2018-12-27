using DealOrNoDealTwo.Data;
using DealOrNoDealTwo.Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDealTwo.Tests
{
    [TestFixture]
    public class PlayerRepositoryTests
    {
        [Test]
        public void CanSave()
        {
            var repo = new BriefcaseRepo();
            Player player = new Player
            {
                Name = "Will Ferrel",
                BackStory = "Commedian, spiked, hit his peak."
            };
            var actual = repo.Save(player);
            Assert.IsTrue(actual != null && actual.PlayerId > 0);
        }
        [Test]
        public void CanUpdate()
        {
            var repo = new BriefcaseRepo();
            var player = repo.FindPlayerById(1);
            player.EndingSum = 10M;

            var actual = repo.Save(player);
            Assert.AreEqual(actual.EndingSum, 10M);
        }
    
    }
}
