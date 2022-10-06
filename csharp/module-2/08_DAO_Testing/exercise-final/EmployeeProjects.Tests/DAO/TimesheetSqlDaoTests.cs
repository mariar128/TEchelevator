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

        private Timesheet testTimesheet;

        [TestInitialize]
        public override void Setup()
        {
            dao = new TimesheetSqlDao(ConnectionString);
            testTimesheet = new Timesheet(99, 2, 1, DateTime.Now.Date, 9.9M, true, "Test Timesheet");
            base.Setup();
        }

        [TestMethod]
        public void GetTimesheet_ReturnsCorrectTimesheetForId()
        {
            Timesheet timesheet = dao.GetTimesheet(1);
            Assert.IsNotNull(timesheet, "GetTimesheet returned null");
            AssertTimesheetsMatch(TIMESHEET_1, timesheet, "GetTimesheet returned wrong or partial data");

            timesheet = dao.GetTimesheet(4);
            Assert.IsNotNull(timesheet, "GetTimesheet returned null");
            AssertTimesheetsMatch(TIMESHEET_4, timesheet, "GetTimesheet returned wrong or partial data");
        }

        [TestMethod]
        public void GetTimesheet_ReturnsNullWhenIdNotFound()
        {
            Timesheet timesheet = dao.GetTimesheet(99);
            Assert.IsNull(timesheet, "GetTimesheet failed to return null for id not in database");
        }

        [TestMethod]
        public void GetTimesheetsByEmployeeId_ReturnsListOfAllTimesheetsForEmployee()
        {
            IList<Timesheet> timesheets = dao.GetTimesheetsByEmployeeId(1);
            Assert.AreEqual(2, timesheets.Count, "GetTimesheetsByEmployeeId returned wrong number of timesheets");
            AssertTimesheetsMatch(TIMESHEET_1, timesheets[0], "GetTimesheetsByEmployeeId returned wrong or partial data");
            AssertTimesheetsMatch(TIMESHEET_2, timesheets[1], "GetTimesheetsByEmployeeId returned wrong or partial data");

            timesheets = dao.GetTimesheetsByEmployeeId(2);
            Assert.AreEqual(2, timesheets.Count, "GetTimesheetsByEmployeeId returned wrong number of timesheets");
            AssertTimesheetsMatch(TIMESHEET_3, timesheets[0], "GetTimesheetsByEmployeeId returned wrong or partial data");
            AssertTimesheetsMatch(TIMESHEET_4, timesheets[1], "GetTimesheetsByEmployeeId returned wrong or partial data");
        }

        [TestMethod]
        public void GetTimesheetsByProjectId_ReturnsListOfAllTimesheetsForProject()
        {
            IList<Timesheet> timesheets = dao.GetTimesheetsByProjectId(1);
            Assert.AreEqual(3, timesheets.Count, "GetTimesheetsByProjectId returned wrong number of timesheets");
            AssertTimesheetsMatch(TIMESHEET_1, timesheets[0], "GetTimesheetsByProjectId returned wrong or partial data");
            AssertTimesheetsMatch(TIMESHEET_2, timesheets[1], "GetTimesheetsByProjectId returned wrong or partial data");
            AssertTimesheetsMatch(TIMESHEET_3, timesheets[2], "GetTimesheetsByProjectId returned wrong or partial data");

            timesheets = dao.GetTimesheetsByProjectId(2);
            Assert.AreEqual(1, timesheets.Count, "GetTimesheetsByProjectId returned wrong number of timesheets");
            AssertTimesheetsMatch(TIMESHEET_4, timesheets[0], "GetTimesheetsByProjectId returned wrong or partial data");
        }

        [TestMethod]
        public void CreateTimesheet_ReturnsTimesheetWithIdAndExpectedValues()
        {
            Timesheet createdTimesheet = dao.CreateTimesheet(testTimesheet);

            Assert.IsNotNull(createdTimesheet, "CreateTimesheet returned null");

            int newId = createdTimesheet.TimesheetId;
            Assert.IsTrue(newId > 0, "CreateTimesheet failed to return a timesheet with an id");

            testTimesheet.TimesheetId = newId;
            AssertTimesheetsMatch(testTimesheet, createdTimesheet, "CreateTimesheet returned timesheet with wrong or partial data");
        }

        [TestMethod]
        public void CreatedTimesheetHasExpectedValuesWhenRetrieved()
        {
            Timesheet createdTimesheet = dao.CreateTimesheet(testTimesheet);

            int newId = createdTimesheet.TimesheetId;
            Timesheet retrievedTimesheet = dao.GetTimesheet(newId);

            AssertTimesheetsMatch(createdTimesheet, retrievedTimesheet, "CreateTimesheet did not save correct data in database");
        }

        [TestMethod]
        public void UpdatedTimesheetHasExpectedValuesWhenRetrieved()
        {
            Timesheet timesheet = dao.GetTimesheet(1);
            timesheet.EmployeeId = 2;
            timesheet.ProjectId = 2;
            timesheet.DateWorked = DateTime.Now.Date;
            timesheet.HoursWorked = 9.9M;
            timesheet.IsBillable = false;
            timesheet.Description = "Test";

            dao.UpdateTimesheet(timesheet);

            Timesheet updatedTimesheet = dao.GetTimesheet(1);
            AssertTimesheetsMatch(timesheet, updatedTimesheet, "UpdateTimesheet failed to update all fields in database");
        }

        [TestMethod]
        public void DeletedTimesheetCantBeRetrieved()
        {
            dao.DeleteTimesheet(1);

            Timesheet timesheet = dao.GetTimesheet(1);
            Assert.IsNull(timesheet, "DeleteTimesheet failed to remove timesheet from database");

            IList<Timesheet> timesheets = dao.GetTimesheetsByEmployeeId(1);
            Assert.AreEqual(1, timesheets.Count, "DeleteTimesheet removed the wrong number of timesheets");
            AssertTimesheetsMatch(TIMESHEET_2, timesheets[0], "DeleteTimesheet deleted wrong timesheet");
        }

        [TestMethod]
        public void GetBillableHours_ReturnsCorrectTotal()
        {
            decimal total = dao.GetBillableHours(1, 1);
            Assert.AreEqual(2.5M, total, "GetBillableHours returned incorrect total for multiple timesheets");

            total = dao.GetBillableHours(2, 1);
            Assert.AreEqual(.25M, total, "GetBillableHours returned incorrect total for single timesheet");

            total = dao.GetBillableHours(2, 2);
            Assert.AreEqual(0M, total, "GetBillableHours failed to return 0 for no matching timesheets");
        }

        //Note that the version of this method provided to students does not have the message parameter.
        private void AssertTimesheetsMatch(Timesheet expected, Timesheet actual, string message)
        {
            Assert.AreEqual(expected.TimesheetId, actual.TimesheetId, message);
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId, message);
            Assert.AreEqual(expected.ProjectId, actual.ProjectId, message);
            Assert.AreEqual(expected.DateWorked, actual.DateWorked, message);
            Assert.AreEqual(expected.HoursWorked, actual.HoursWorked, message);
            Assert.AreEqual(expected.IsBillable, actual.IsBillable, message);
            Assert.AreEqual(expected.Description, actual.Description, message);
        }
    }
}
