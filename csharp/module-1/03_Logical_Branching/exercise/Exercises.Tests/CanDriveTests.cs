using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
	public sealed class Exercise02_CanDriveTests : TestBase
    {
        [TestMethod]
        public void ShouldReturnCorrectValues1_GivenPermitAndPassenger()
        {
            // Arrange
            AllowDriving driving = new AllowDriving();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsTrue(driving.CanDrive(true, true), "You should be able to drive if you have a permit and are accompanied by a passenger with a permit");
            Assert.IsFalse(driving.CanDrive(true, false), "You should NOT be able to drive without a permit");
            Assert.IsFalse(driving.CanDrive(false, false), "You should NOT be able to drive if your passenger doesn't have a permit");
            Assert.IsFalse(driving.CanDrive(true, false), "You should NOT be able to drive if your passenger doesn't have a permit - even if you do");
        }        

        [TestMethod]        
        public void ShouldReturnCorrectValues2_GivenPermitAndPassengerAge()
        {
            // Arrange
            AllowDriving driving = new AllowDriving();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsTrue(driving.CanDrive(true, true, 42), "A 42 year old should be able to drive with permit and passenger with permit");
            Assert.IsTrue(driving.CanDrive(true, true, 21), "A 21 year old should be able to drive with permit and passenger with permit");
            Assert.IsFalse(driving.CanDrive(true, true, 20), "A 20 year old should NOT be able to drive");
            Assert.IsFalse(driving.CanDrive(true, false, 42), "A 42 year old should NOT be able to drive unless their passenger also has a permit");
            Assert.IsFalse(driving.CanDrive(false, false, 42), "A driver should NOT be able to drive without a permit");
            Assert.IsFalse(driving.CanDrive(false, true, 42), "A driver should NOT be able to drive without a permit - even if the passenger has one");
        }  

        [TestMethod]        
        public void ShouldReturnCorrectValues3_GivenPermitAndPassengerGuardian()
        {
            // Arrange
            AllowDriving driving = new AllowDriving();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsTrue(driving.CanDrive(true, true, 42, true), "A 42 year old should be able to drive with permit, and a guardian passenger with a permit");
            Assert.IsTrue(driving.CanDrive(true, true, 18, true), "An 18 year old should be able to drive with permit, and a guardian passenger with a permit");
            Assert.IsFalse(driving.CanDrive(true, true, 20, false), "A 20 year old should NOT be able to drive with permit, and a non-guardian passenger with a permit");
            Assert.IsFalse(driving.CanDrive(true, false, 42, true), "A 42 year old should NOT be able to drive with permit and a passenger without a permit");
            Assert.IsFalse(driving.CanDrive(false, false, 42, true), "A driver should NOT be able to drive without a permit");
            Assert.IsFalse(driving.CanDrive(false, true, 42, true), "A driver should NOT be able to drive without a permit - even if the passenger has a permit and is a guardian");            
        }
    }
}
