using System;
using System.Collections.Generic;
using System.Security.Claims;
using ClaimServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimTesting
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepository _repo;
        private Claims _content;
        //Object claimOne = new Claims(4, claimTypes.Car, "Accident", 1500, new DateTime(2020, 8, 5).Date, DateTime.Now.Date);

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _content = new Claims(2, claimTypes.Home, "testing", 200000, new DateTime(2020, 8, 5).Date, DateTime.Now.Date);
            _repo.AddContentQueue(_content);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var claim = new Claims(2, claimTypes.Home, "testing", 200000, new DateTime(2020, 8, 5).Date, DateTime.Now.Date);
            //need to test all the methods
            Assert.AreEqual(2, claim.ClaimID);
            Assert.IsTrue(_content.isValid);
            var claimOne = new Claims(4, claimTypes.Car, "Accident", 1500, new DateTime(2020, 1, 1).Date, DateTime.Now.Date);
            Assert.AreEqual(4, claimOne.ClaimID);
            Assert.IsFalse(claimOne.isValid);
        }

        [TestMethod]
        public void GetData_ShowAllData()
        {
            ClaimsRepository repo = new ClaimsRepository();
            Claims claims = new Claims();

            repo.AddContentQueue(claims);

            Queue<Claims> claim = repo.GetClaimsQ();
            bool hasItems = claim.Contains(claims);
            Assert.IsTrue(hasItems);
        }
        [TestMethod]
        [DataRow(1, true)]
        public void DeleteItems(int id, bool expectedResult)
        {

            bool IsDeleted = _repo.RemoveClaimFromList(_content.ClaimID);
            Assert.AreEqual(expectedResult, IsDeleted);
        }

        [TestMethod]
        [DataRow(2)]
        public void GetById(int id)
        {
            Queue<Claims> claims = _repo.GetClaimsQ();

            var yes = _repo.GetByID(id);
            bool hasIt = claims.Contains(yes);
            Assert.IsTrue(hasIt);
        }
        [TestMethod]
        public void GetNextClaim()
        {
            Claims claims = _repo.GetNextClaim();
            Queue<Claims> testing = _repo.GetClaimsQ();

            Assert.IsNotNull(claims);

        }

        [TestMethod]
        [DataRow(4)]
        public void UpdateClaim(int ID)
        {
            var claimOne = new Claims(4, claimTypes.Car, "Accident", 1500, new DateTime(2020, 8, 5).Date, DateTime.Now.Date);

            //_repo.UpdateClaims(claimOne, claimOne.ClaimID);

            _repo.UpdateClaims(claimOne, ID);


        }
    }
}
