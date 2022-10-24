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

        private ParkSqlDao dao; // declared up here 

        [TestInitialize]
        public override void Setup()
        {
            dao = new ParkSqlDao(ConnectionString); // getting a new DAO and new connection before every test
            base.Setup(); // open a transaction before every test so that it rolls back at the end 
        }

        [TestMethod]
        public void GetPark_ReturnsCorrectParkForId()
        {
            //let's test getting part 2 from the test db 
            Park park = dao.GetPark(2); // this should get the park with id 2 from the test db 
            AssertParksMatch(PARK_2, park); // compare and assert match to PARK_2
        }

        [TestMethod]
        public void GetPark_ReturnsNullWhenIdNotFound()
        {
            Park park = dao.GetPark(6000);
            Assert.IsNull(park);
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
            Park testPark = new Park(0, "Test Park", DateTime.Now, 900, true);

            Park newParkFromDB = dao.CreatePark(testPark); // try to create testPark in the DB
            // I should have got a park_id that wasn't 0 when I did the insert into the DB, so let's test that
            Assert.IsTrue(newParkFromDB.ParkId > 0);
            // check the rest of the values from the park the came out of the DB to see if they match Testpark
            Assert.AreEqual(testPark.ParkName, newParkFromDB.ParkName); // could do a bunch of these

            testPark.ParkId = newParkFromDB.ParkId; // set the id of the test park to the new id 
            AssertParksMatch(testPark, newParkFromDB); // and we could do this instead
        }

        [TestMethod]
        public void CreatedParkHasExpectedValuesWhenRetrieved()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void UpdatedParkHasExpectedValuesWhenRetrieved()
        {
            Park parkToUpdate = dao.GetPark(2); // the least amount of code I can write to get a park 
            parkToUpdate.HasCamping = true; // make the world a better place
            dao.UpdatePark(parkToUpdate); // update the park
            Park retrievedPark = dao.GetPark(2); // get the park again 
            AssertParksMatch(parkToUpdate, retrievedPark); // matchy matchy
        }

        [TestMethod]
        public void DeletedParkCantBeRetrieved()
        {
            dao.DeletePark(3); // byeeee

            Park retrievedPark = dao.GetPark(3); // shouldn't work 
            Assert.IsNull(retrievedPark);
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
