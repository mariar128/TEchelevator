using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EmployeeProjects.DAO;
using EmployeeProjects.Models;
using System.Data.SqlClient;

namespace EmployeeProjects.Tests.DAO
{
    [TestClass]
    public class TimesheetSqlDaoTests : BaseDaoTests
    {
        private static readonly Timesheet TIMESHEET_1 = new Timesheet(1, 1, 1, DateTime.Parse("2021-01-01"), 1.0M, true, "Timesheet 1");
        private static readonly Timesheet TIMESHEET_2 = new Timesheet(2, 1, 1, DateTime.Parse("2021-01-02"), 1.5M, true, "Timesheet 2");
        private static readonly Timesheet TIMESHEET_3 = new Timesheet(3, 2, 1, DateTime.Parse("2021-01-01"), 0.25M, true, "Timesheet 3");
        private static readonly Timesheet TIMESHEET_4 = new Timesheet(4, 2, 2, DateTime.Parse("2021-02-01"), 2.0M, false, "Timesheet 4");

        private TimesheetSqlDao dao;


        [TestInitialize]
        public override void Setup()
        {
            dao = new TimesheetSqlDao(ConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void GetTimesheet_ReturnsCorrectTimesheetForId()
        {
            Timesheet timesheet = dao.GetTimesheet(1); //go interact with the mock database (UnitedStatesTesting)
            AssertTimesheetsMatch(TIMESHEET_1, timesheet);


        }
            

                
            

        [TestMethod]
        public void GetTimesheet_ReturnsNullWhenIdNotFound()
        {
            Timesheet timesheet = dao.GetTimesheet(99); //go find the city in the test db with id 99 (it doesn't exist)
            Assert.IsNull(timesheet);
        }

        [TestMethod]
        public void GetTimesheetsByEmployeeId_ReturnsListOfAllTimesheetsForEmployee()
        {

            IList<Timesheet> timesheet = dao.GetTimesheetsByEmployeeId(2);
            Assert.AreEqual(2, timesheet.Count);
            AssertTimesheetsMatch(TIMESHEET_3, timesheet[2]);
            AssertTimesheetsMatch(TIMESHEET_4, timesheet[3]);

            
        }

        [TestMethod]
        public void GetTimesheetsByProjectId_ReturnsListOfAllTimesheetsForProject()
        {
            IList<Timesheet> timesheet = dao.GetTimesheetsByEmployeeId(1);
            Assert.AreEqual(2, timesheet.Count);
            AssertTimesheetsMatch(TIMESHEET_1, timesheet[0]);
            AssertTimesheetsMatch(TIMESHEET_2, timesheet[1]);

        }

        [TestMethod]
        public void CreateTimesheet_ReturnsTimesheetWithIdAndExpectedValues()
        {
            IList<Timesheet> timesheet = dao.GetTimesheetsByEmployeeId(1);
            Assert.AreEqual(2, timesheet.Count);
            AssertTimesheetsMatch(TIMESHEET_1, timesheet[0]);
            AssertTimesheetsMatch(TIMESHEET_2, timesheet[1]);
        }

        [TestMethod]
        public void CreatedTimesheetHasExpectedValuesWhenRetrieved()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void UpdatedTimesheetHasExpectedValuesWhenRetrieved()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void DeletedTimesheetCantBeRetrieved()
        {
            dao.DeleteTimesheet(1);

            Timesheet retrievedTimesheet = dao.GetTimesheet(1);
            Assert.IsNull(retrievedTimesheet);
        }

        [TestMethod]
        public void GetBillableHours_ReturnsCorrectTotal()
        {
            Assert.Fail();
        }

        private void AssertTimesheetsMatch(Timesheet expected, Timesheet actual)
        {
            Assert.AreEqual(expected.TimesheetId, actual.TimesheetId);
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId);
            Assert.AreEqual(expected.ProjectId, actual.ProjectId);
            Assert.AreEqual(expected.DateWorked, actual.DateWorked);
            Assert.AreEqual(expected.HoursWorked, actual.HoursWorked);
            Assert.AreEqual(expected.IsBillable, actual.IsBillable);
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }
}
