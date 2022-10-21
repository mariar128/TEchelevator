using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using USCitiesAndParks.DAO;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.Tests
{
    [TestClass]
    public class CitySqlDaoTests : BaseDaoTests
    {
        private static readonly City CITY_1 = new City(1, "City 1", "AA", 11,111);
        private static readonly City CITY_2 = new City(2, "City 2", "BB", 22,222);
        private static readonly City CITY_4 = new City(4, "City 4", "AA", 44,444);

        private City testCity;

        private CitySqlDao dao;

        [TestInitialize]
        public override void Setup()
        {
            dao = new CitySqlDao(ConnectionString);
            testCity = new City(0, "Test City", "CC", 99, 999);
            base.Setup();
        }

        [TestMethod]
        public void GetCity_ReturnsCorrectCityForId()
        {
            City city = dao.GetCity(1);
            AssertCitiesMatch(CITY_1, city);

            city = dao.GetCity(2);
            AssertCitiesMatch(CITY_2, city);
        }

        [TestMethod]
        public void GetCity_ReturnsNullWhenIdNotFound()
        {
            City city = dao.GetCity(99);
            Assert.IsNull(city);
        }

        [TestMethod]
        public void GetCitiesByState_ReturnsAllCitiesForState()
        {
            IList<City> cities = dao.GetCitiesByState("AA");
            Assert.AreEqual(2, cities.Count);
            AssertCitiesMatch(CITY_1, cities[0]);
            AssertCitiesMatch(CITY_4, cities[1]);

            cities = dao.GetCitiesByState("BB");
            Assert.AreEqual(1, cities.Count);
            AssertCitiesMatch(CITY_2, cities[0]);
        }

        [TestMethod]
        public void GetCitiesByState_ReturnsEmptyListForAbbreviationNotInDb()
        {
            IList<City> cities = dao.GetCitiesByState("XX");
            Assert.AreEqual(0, cities.Count);
        }

        [TestMethod]
        public void CreateCity_ReturnsCityWithIdAndExpectedValues()
        {
            City createdCity = dao.CreateCity(testCity);

            int newId = createdCity.CityId;
            Assert.IsTrue(newId > 0);

            testCity.CityId = newId;
            AssertCitiesMatch(testCity, createdCity);
        }

        [TestMethod]
        public void CreatedCityHasExpectedValuesWhenRetrieved()
        {
            City createdCity = dao.CreateCity(testCity);

            int newId = createdCity.CityId;
            City retrievedCity = dao.GetCity(newId);

            AssertCitiesMatch(createdCity, retrievedCity);
        }

        [TestMethod]
        public void UpdatedCityHasExpectedValuesWhenRetrieved()
        {
            City cityToUpdate = dao.GetCity(1);

            cityToUpdate.CityName = "Updated";
            cityToUpdate.StateAbbreviation = "CC";
            cityToUpdate.Population = 99;
            cityToUpdate.Area = 999;

            dao.UpdateCity(cityToUpdate);

            City retrievedCity = dao.GetCity(1);
            AssertCitiesMatch(cityToUpdate, retrievedCity);
        }

        [TestMethod]
        public void DeletedCityCantBeRetrieved()
        {
            dao.DeleteCity(4);

            City retrievedCity = dao.GetCity(4);
            Assert.IsNull(retrievedCity);

            IList<City> cities = dao.GetCitiesByState("AA");
            Assert.AreEqual(1, cities.Count);
            AssertCitiesMatch(CITY_1, cities[0]);
        }

        private void AssertCitiesMatch(City expected, City actual)
        {
            Assert.AreEqual(expected.CityId, actual.CityId);
            Assert.AreEqual(expected.CityName, actual.CityName);
            Assert.AreEqual(expected.StateAbbreviation, actual.StateAbbreviation);
            Assert.AreEqual(expected.Population, actual.Population);
            Assert.AreEqual(expected.Area, actual.Area);
        }
    }
}
