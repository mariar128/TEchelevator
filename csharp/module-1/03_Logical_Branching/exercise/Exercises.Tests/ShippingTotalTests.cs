using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{

    [TestClass]
    public sealed class Exercise03_ShippingTotalTests : TestBase
	{
		[TestMethod]
		public void ShouldCalculateCorrectShipping1_Simple()
		{
			// Arrange
			ShippingTotal shipping = new ShippingTotal();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(10, shipping.CalculateShippingTotal(20), CentsDelta, "A package weighing 20 lbs should result in a charge of $10.00 at the up to 40 lbs rate");
			Assert.AreEqual(19.5, shipping.CalculateShippingTotal(39), CentsDelta, "A package weighing 39 lbs should result in a charge of $19.50 at the up to 40 lbs rate");
			Assert.AreEqual(20, shipping.CalculateShippingTotal(40), CentsDelta, "A package weighing 40 lbs should result in a charge of $20.00 at the up to 40 lbs rate");
			Assert.AreEqual(20.75, shipping.CalculateShippingTotal(41), CentsDelta, "A package weighing 41 lbs should result in a charge of $20.75 at the up to 40 lbs rate X 40 lbs plus 1 lb times the excess rate");
			Assert.AreEqual(27.50, shipping.CalculateShippingTotal(50), CentsDelta, "A package weighing 50 lbs should result in a charge of $27.50 at the up to 40 lbs rate X 40 lbs plus 10 lbs times the excess rate");
		}

		[TestMethod]
		public void ShouldCalculateCorrectShipping2_SimpleDiscount()
		{
			// Arrange
			ShippingTotal shipping = new ShippingTotal();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(10, shipping.CalculateShippingTotal(20, false), CentsDelta, "An undiscounted package weighing 20 lbs should result in a charge of $10.00 at the up to 40 lbs rate");
			Assert.AreEqual(19.5, shipping.CalculateShippingTotal(39, false), CentsDelta, "An undiscounted package weighing 39 lbs should result in a charge of $19.50 at the up to 40 lbs rate");
			Assert.AreEqual(20, shipping.CalculateShippingTotal(40, false), CentsDelta, "An undiscounted package weighing 40 lbs should result in a charge of $20.00 at the up to 40 lbs rate");
			Assert.AreEqual(20.75, shipping.CalculateShippingTotal(41, false), CentsDelta, "An undiscounted package weighing 41 lbs should result in a charge of $20.75 at the up to 40 lbs rate X 40 lbs plus 1 lb times the excess rate");
			Assert.AreEqual(27.50, shipping.CalculateShippingTotal(50, false), CentsDelta, "An undiscounted package weighing 50 lbs should result in a charge of $27.50 at the up to 40 lbs rate X 40 lbs plus 10 lbs times the excess rate");
			Assert.AreEqual(9, shipping.CalculateShippingTotal(20, true), CentsDelta, "A discounted package weighing 20 lbs should result in a charge of $9.00 at the up to 40 lbs rate");
			Assert.AreEqual(17.55, shipping.CalculateShippingTotal(39, true), CentsDelta, "A discounted package weighing 39 lbs should result in a charge of $17.55 at the up to 40 lbs rate");
			Assert.AreEqual(18, shipping.CalculateShippingTotal(40, true), CentsDelta, "A discounted package weighing 40 lbs should result in a charge of $18.00 at the up to 40 lbs rate");
			Assert.AreEqual(18.675, shipping.CalculateShippingTotal(41, true), CentsDelta, "A discounted package weighing 41 lbs should result in a charge of $18.675 at the up to 40 lbs rate X 40 lbs plus 1 lb times the excess rate");
			Assert.AreEqual(24.75, shipping.CalculateShippingTotal(50, true), CentsDelta, "A discounted package weighing 50 lbs should result in a charge of $24.75 at the up to 40 lbs rate X 40 lbs plus 10 lbs times the excess rate");
		}

		[TestMethod]
		public void ShouldCalculateCorrectShipping3_NumericDiscount()
		{
			// Arrange
			ShippingTotal shipping = new ShippingTotal();

			// Act / Assert - Note: Normally each of these would be a separate test
			// We include multiple assertions here for ease of student experience / to reduce confusion
			Assert.AreEqual(10, shipping.CalculateShippingTotal(20, 0), CentsDelta, "An undiscounted package weighing 20 lbs should result in a charge of $10.00 at the up to 40 lbs rate");
			Assert.AreEqual(19.5, shipping.CalculateShippingTotal(39, 0), CentsDelta, "An undiscounted package weighing 39 lbs should result in a charge of $19.50 at the up to 40 lbs rate");
			Assert.AreEqual(20, shipping.CalculateShippingTotal(40, 0), CentsDelta, "An undiscounted package weighing 40 lbs should result in a charge of $20.00 at the up to 40 lbs rate");
			Assert.AreEqual(20.75, shipping.CalculateShippingTotal(41, 0), CentsDelta, "An undiscounted package weighing 41 lbs should result in a charge of $20.75 at the up to 40 lbs rate X 40 lbs plus 1 lb times the excess rate");
			Assert.AreEqual(27.50, shipping.CalculateShippingTotal(50, 0), CentsDelta, "An undiscounted package weighing 50 lbs should result in a charge of $27.50 at the up to 40 lbs rate X 40 lbs plus 10 lbs times the excess rate");
			Assert.AreEqual(5, shipping.CalculateShippingTotal(20, 0.5), CentsDelta, "A 50% discounted package weighing 20 lbs should result in a charge of $5.00 at the up to 40 lbs rate with discount applied");
			Assert.AreEqual(13.65, shipping.CalculateShippingTotal(39, 0.3), CentsDelta, "A 30% discounted package weighing 39 lbs should result in a charge of $13.65 at the up to 40 lbs rate with discount applied");
			Assert.AreEqual(19, shipping.CalculateShippingTotal(40, 0.05), CentsDelta, "A 5% discounted package weighing 40 lbs should result in a charge of $19.00 at the up to 40 lbs rate with discount applied");
			Assert.AreEqual(18.675, shipping.CalculateShippingTotal(41, 0.1), CentsDelta, "A 10% discounted package weighing 41 lbs should result in a charge of $18.675 at the up to 40 lbs rate X 40 lbs plus 1 lb times the excess rate with discount applied");
			Assert.AreEqual(21.175, shipping.CalculateShippingTotal(50, 0.23), CentsDelta, "A 23% discounted package weighing 50 lbs should result in a charge of $21.175 at the up to 40 lbs rate X 40 lbs plus 10 lbs times the excess rate with discount applied");
		}
	}
}
