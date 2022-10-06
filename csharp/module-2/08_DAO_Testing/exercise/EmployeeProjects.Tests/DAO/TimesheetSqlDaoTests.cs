using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EmployeeProjects.DAO;
using EmployeeProjects.Models;

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
            Assert.Fail();
        }

        [TestMethod]
        public void GetTimesheet_ReturnsNullWhenIdNotFound()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetTimesheetsByEmployeeId_ReturnsListOfAllTimesheetsForEmployee()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetTimesheetsByProjectId_ReturnsListOfAllTimesheetsForProject()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CreateTimesheet_ReturnsTimesheetWithIdAndExpectedValues()
        {
            Assert.Fail();
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
            Assert.Fail();
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
