using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.Tests
{
    [TestClass]
    public class ParkSqlDaoTests : BaseDaoTests
    {
        private static readonly Park PARK_1 = new Park(1, "Park 1", DateTime.Parse("1800-01-02"), 100, true);
        private static readonly Park PARK_2 = new Park(2, "Park 2", DateTime.Parse("1900-12-31"), 200, false);
        private static readonly Park PARK_3 = new Park(3, "Park 3", DateTime.Parse("2000-06-15"), 300, false);

        private ParkSqlDao dao;

        [TestInitialize]
        public override void Setup()
        {
            dao = new ParkSqlDao(ConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void GetPark_ReturnsCorrectParkForId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetPark_ReturnsNullWhenIdNotFound()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetParksByState_ReturnsAllParksForState()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetParksByState_ReturnsEmptyListForAbbreviationNotInDb()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CreatePark_ReturnsParkWithIdAndExpectedValues()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CreatedParkHasExpectedValuesWhenRetrieved()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void UpdatedParkHasExpectedValuesWhenRetrieved()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeletedParkCantBeRetrieved()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ParkAddedToStateIsInListOfParksByState()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ParkRemovedFromStateIsNotInListOfParksByState()
        {
            Assert.Fail();
        }

        private void AssertParksMatch(Park expected, Park actual)
        {
            Assert.AreEqual(expected.ParkId, actual.ParkId);
            Assert.AreEqual(expected.ParkName, actual.ParkName);
            Assert.AreEqual(expected.DateEstablished.Date, actual.DateEstablished.Date);
            Assert.AreEqual(expected.Area, actual.Area);
            Assert.AreEqual(expected.HasCamping, actual.HasCamping);
        }
    }
}
