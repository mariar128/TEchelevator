using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
	public sealed class Exercise04_HotelReservationTests : TestBase
    {
        [TestMethod]
        public void ShouldCalculateCorrectTotal1_Simple()
        {
            // Arrange
            HotelReservation hotel = new HotelReservation();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(99.99, hotel.CalculateStayTotal(1), CentsDelta, "A 1 night stay should cost $99.99");
            Assert.AreEqual(199.98, hotel.CalculateStayTotal(2), CentsDelta, "A 2 night stay should cost $199.98");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3), CentsDelta, "A 3 night stay should get the discount rate and cost $269.97");
            Assert.AreEqual(359.96, hotel.CalculateStayTotal(4), CentsDelta, "A 4 night stay should get the discount rate and cost $359.96");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10), CentsDelta, "A 10 night stay should get the discount rate and cost $899.90");
        }

        [TestMethod]
        public void ShouldCalculateCorrectTotal2_WithWeekends()
        {
            // Arrange
            HotelReservation hotel = new HotelReservation();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(99.99, hotel.CalculateStayTotal(1, 0), CentsDelta, "A 1 night stay on a weekday should cost $99.99 at the normal rate");
            Assert.AreEqual(99.99, hotel.CalculateStayTotal(1, 1), CentsDelta, "A 1 night stay on a weekend should cost $99.99 at the normal rate");
            Assert.AreEqual(199.98, hotel.CalculateStayTotal(2, 0), CentsDelta, "A 2 night stay with 0 weekend nights should cost $199.98 at the normal rate");
            Assert.AreEqual(199.98, hotel.CalculateStayTotal(2, 1), CentsDelta, "A 2 night stay with 1 weekend night should cost $199.98 at the normal rate");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3, 0), CentsDelta, "A 3 night stay with 0 weekend nights should cost $269.97 at the discount rate");
            Assert.AreEqual(279.97, hotel.CalculateStayTotal(3, 1), CentsDelta, "A 3 night stay with 1 weekend night should cost $279.97 at the discount and weekend rates");
            Assert.AreEqual(289.97, hotel.CalculateStayTotal(3, 2), CentsDelta, "A 3 night stay with 2 weekend nights should cost $289.97 at the discount and weekend rates");
            Assert.AreEqual(359.96, hotel.CalculateStayTotal(4, 0), CentsDelta, "A 4 night stay with 0 weekend nights should cost $359.96 at the discount rate");
            Assert.AreEqual(369.96, hotel.CalculateStayTotal(4, 1), CentsDelta, "A 4 night stay with 1 weekend night should cost $369.96 at the discount and weekend rates");
            Assert.AreEqual(379.96, hotel.CalculateStayTotal(4, 2), CentsDelta, "A 4 night stay with 2 weekend nights should cost $379.96 at the discount and weekend rates");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10, 0), CentsDelta, "A 10 night stay with 0 weekend nights should cost $899.90 at the discount rate");
            Assert.AreEqual(909.90, hotel.CalculateStayTotal(10, 1), CentsDelta, "A 10 night stay with 1 weekend night should cost $909.90 at the discount and weekend rates");
            Assert.AreEqual(919.90, hotel.CalculateStayTotal(10, 2), CentsDelta, "A 10 night stay with 2 weekend nights should cost $919.90 at the discount and weekend rates");
            Assert.AreEqual(929.90, hotel.CalculateStayTotal(10, 3), CentsDelta, "A 10 night stay with 3 weekend nights should cost $929.90 at the discount and weekend rates");
            Assert.AreEqual(939.90, hotel.CalculateStayTotal(10, 4), CentsDelta, "A 10 night stay with 3 weekend nights should cost $939.90 at the discount and weekend rates");
        }

        [TestMethod]
        public void ShouldCalculateCorrectTotal3_Rewards()
        {
            // Arrange
            HotelReservation hotel = new HotelReservation();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(89.99, hotel.CalculateStayTotal(1, 0, true), CentsDelta, "A 1 night stay on a weekday for a rewards member should cost $89.99 at the discount rate");
            Assert.AreEqual(89.99, hotel.CalculateStayTotal(1, 1, true), CentsDelta, "A 1 night stay on a weekend for a rewards member should cost $89.99 at the discount rate");
            Assert.AreEqual(179.98, hotel.CalculateStayTotal(2, 0, true), CentsDelta, "A 2 night stay with 0 weekend nights for a rewards member should cost $179.98 at the discount rate");
            Assert.AreEqual(179.98, hotel.CalculateStayTotal(2, 1, true), CentsDelta, "A 2 night stay with 1 weekend night for a rewards member should cost $179.98 at the discount rate");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3, 0, true), CentsDelta, "A 3 night stay with 0 weekend nights for a rewards member should cost $269.97 at the discount rate");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3, 1, true), CentsDelta, "A 3 night stay with 1 weekend night for a rewards member should cost $269.97 at the discount rate");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3, 2, true), CentsDelta, "A 3 night stay with 2 weekend nights for a rewards member should cost $269.97 at the discount rate");
            Assert.AreEqual(359.96, hotel.CalculateStayTotal(4, 0, true), CentsDelta, "A 4 night stay with 0 weekend nights for a rewards member should cost $359.96 at the discount rate");
            Assert.AreEqual(359.96, hotel.CalculateStayTotal(4, 1, true), CentsDelta, "A 4 night stay with 1 weekend night for a rewards member should cost $359.96 at the discount rate");
            Assert.AreEqual(359.96, hotel.CalculateStayTotal(4, 2, true), CentsDelta, "A 4 night stay with 2 weekend nights for a rewards member should cost $359.96 at the discount rate");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10, 0, true), CentsDelta, "A 10 night stay with 0 weekend nights for a rewards member should cost $899.90 at the discount rate");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10, 1, true), CentsDelta, "A 10 night stay with 1 weekend night for a rewards member should cost $899.90 at the discount rate");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10, 2, true), CentsDelta, "A 10 night stay with 2 weekend nights for a rewards member should cost $899.90 at the discount rate");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10, 3, true), CentsDelta, "A 10 night stay with 3 weekend nights for a rewards member should cost $899.90 at the discount rate");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10, 4, true), CentsDelta, "A 10 night stay with 4 weekend nights for a rewards member should cost $899.90 at the discount rate");

            Assert.AreEqual(99.99, hotel.CalculateStayTotal(1, 0, false), CentsDelta, "A 1 night stay on a weekday for a non-rewards member should cost $99.99 at the normal rate");
            Assert.AreEqual(99.99, hotel.CalculateStayTotal(1, 1, false), CentsDelta, "A 1 night stay on a weekend for a non-rewards member should cost $99.99 at the normal rate");
            Assert.AreEqual(199.98, hotel.CalculateStayTotal(2, 0, false), CentsDelta, "A 2 night stay with 0 weekend nights for a non-rewards member should cost $199.98 at the normal rate");
            Assert.AreEqual(199.98, hotel.CalculateStayTotal(2, 1, false), CentsDelta, "A 2 night stay with 1 weekend night for a non-rewards member should cost $199.98 at the normal rate");
            Assert.AreEqual(269.97, hotel.CalculateStayTotal(3, 0, false), CentsDelta, "A 3 night stay with 0 weekend nights for a non-rewards member should cost $269.97 at the discount rate");
            Assert.AreEqual(279.97, hotel.CalculateStayTotal(3, 1, false), CentsDelta, "A 3 night stay with 1 weekend night for a non-rewards member should cost $279.97 at the discount and weekend rates");
            Assert.AreEqual(289.97, hotel.CalculateStayTotal(3, 2, false), CentsDelta, "A 3 night stay with 2 weekend nights for a non-rewards member should cost $289.97 at the discount and weekend rates");
            Assert.AreEqual(359.96, hotel.CalculateStayTotal(4, 0, false), CentsDelta, "A 4 night stay with 0 weekend nights for a non-rewards member should cost $359.96 at the discount rate");
            Assert.AreEqual(369.96, hotel.CalculateStayTotal(4, 1, false), CentsDelta, "A 4 night stay with 1 weekend night for a non-rewards member should cost $369.96 at the discount and weekend rates");
            Assert.AreEqual(379.96, hotel.CalculateStayTotal(4, 2, false), CentsDelta, "A 4 night stay with 2 weekend nights for a non-rewards member should cost $379.96 at the discount and weekend rates");
            Assert.AreEqual(899.90, hotel.CalculateStayTotal(10, 0, false), CentsDelta, "A 10 night stay with 0 weekend nights for a non-rewards member should cost $899.90 at the discount rate");
            Assert.AreEqual(909.90, hotel.CalculateStayTotal(10, 1, false), CentsDelta, "A 10 night stay with 1 weekend night for a non-rewards member should cost $909.90 at the discount and weekend rates");
            Assert.AreEqual(919.90, hotel.CalculateStayTotal(10, 2, false), CentsDelta, "A 10 night stay with 2 weekend nights for a non-rewards member should cost $919.90 at the discount and weekend rates");
            Assert.AreEqual(929.90, hotel.CalculateStayTotal(10, 3, false), CentsDelta, "A 10 night stay with 3 weekend nights for a non-rewards member should cost $929.90 at the discount and weekend rates");
            Assert.AreEqual(939.90, hotel.CalculateStayTotal(10, 4, false), CentsDelta, "A 10 night stay with 3 weekend nights for a non-rewards member should cost $939.90 at the discount and weekend rates");
        }
    }
}
