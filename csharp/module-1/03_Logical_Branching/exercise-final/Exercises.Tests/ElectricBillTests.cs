using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
	public sealed class Exercise06_ElectricBillTests : TestBase
    {
        [TestMethod]
        public void ShouldAcceptOrRejectPackage1_Weight()
        {
            // Arrange
            ElectricBill bill = new ElectricBill();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(2, bill.CalculateElectricBill(10), CentsDelta, "10 units should result in a bill of $2.00 (calculated at base rate)");
            Assert.AreEqual(10.44, bill.CalculateElectricBill(52.2), CentsDelta, "52.2 units should result in a bill of $10.44 (calculated at base rate)");
            Assert.AreEqual(15.22, bill.CalculateElectricBill(76.1), CentsDelta, "76.1 units should result in a bill of $15.22 (calculated at base rate)");
            Assert.AreEqual(20, bill.CalculateElectricBill(100), CentsDelta, "100 units should result in a bill of $20.00 (calculated at base rate)");
            Assert.AreEqual(20.025, bill.CalculateElectricBill(100.1), CentsDelta, "100.1 units should result in a bill of $20.025 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(20.25, bill.CalculateElectricBill(101), CentsDelta, "101 units should result in a bill of $20.25 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(27.1, bill.CalculateElectricBill(128.4), CentsDelta, "128.4 units should result in a bill of $27.10 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(29.25, bill.CalculateElectricBill(137), CentsDelta, "137 units should result in a bill of $29.25 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(45, bill.CalculateElectricBill(200), CentsDelta, "200 units should result in a bill of $45.00 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
        }

        [TestMethod]
        public void ShouldAcceptOrRejectPackage2_Renewable()
        {
            // Arrange
            ElectricBill bill = new ElectricBill();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(2, bill.CalculateElectricBill(10, false), CentsDelta, "10 units without renewable energy should result in a bill of $2.00 (calculated at base rate)");
            Assert.AreEqual(1.9, bill.CalculateElectricBill(10, true), CentsDelta, "10 units with renewable energy should result in a bill of $1.90 (calculated at base rate with 5% discount)");
            Assert.AreEqual(10.44, bill.CalculateElectricBill(52.2, false), CentsDelta, "52.2 units without renewable energy should result in a bill of $10.44 (calculated at base rate)");
            Assert.AreEqual(9.918, bill.CalculateElectricBill(52.2, true), CentsDelta, "52.2 units with renewable energy should result in a bill of $9.918 (calculated at base rate with 5% discount)");
            Assert.AreEqual(15.22, bill.CalculateElectricBill(76.1, false), CentsDelta, "76.1 units without renewable energy should result in a bill of $15.22 (calculated at base rate)");
            Assert.AreEqual(14.459, bill.CalculateElectricBill(76.1, true), CentsDelta, "76.1 units with renewable energy should result in a bill of $14.459 (calculated at base rate with 5% discount)");
            Assert.AreEqual(20, bill.CalculateElectricBill(100, false), CentsDelta, "100 units without renewable energy should result in a bill of $20.00 (calculated at base rate)");
            Assert.AreEqual(19, bill.CalculateElectricBill(100, true), CentsDelta, "100 units with renewable energy should result in a bill of $19.00 (calculated at base rate with 5% discount)");
            Assert.AreEqual(20.025, bill.CalculateElectricBill(100.1, false), CentsDelta, "100.1 units without renewable energy should result in a bill of $20.025 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(19.02375, bill.CalculateElectricBill(100.1, true), CentsDelta, "100.1 units with renewable energy should result in a bill of $19.02375 (calculated at base rate X max excess units plus the excess rate for the remaining units with 5% discount)");
            Assert.AreEqual(20.25, bill.CalculateElectricBill(101, false), CentsDelta, "101 units without renewable energy should result in a bill of $20.25 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(19.2375, bill.CalculateElectricBill(101, true), CentsDelta, "101 units with renewable energy should result in a bill of $19.2375 (calculated at base rate X max excess units plus the excess rate for the remaining units with 5% discount)");
            Assert.AreEqual(27.1, bill.CalculateElectricBill(128.4, false), CentsDelta, "128.4 units without renewable energy should result in a bill of $27.1 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(25.745, bill.CalculateElectricBill(128.4, true), CentsDelta, "128.4 units with renewable energy should result in a bill of $25.745 (calculated at base rate X max excess units plus the excess rate for the remaining units with 5% discount)");
            Assert.AreEqual(29.25, bill.CalculateElectricBill(137, false), CentsDelta, "137 units without renewable energy should result in a bill of $29.25 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(27.7875, bill.CalculateElectricBill(137, true), CentsDelta, "137 units with renewable energy should result in a bill of $27.7875 (calculated at base rate X max excess units plus the excess rate for the remaining units with 5% discount)");
            Assert.AreEqual(45, bill.CalculateElectricBill(200, false), CentsDelta, "200 units without renewable energy should result in a bill of $45.00 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(42.75, bill.CalculateElectricBill(200, true), CentsDelta, "200 units with renewable energy should result in a bill of $42.75 (calculated at base rate X max excess units plus the excess rate for the remaining units with 5% discount)");
       }

        [TestMethod]
        public void ShouldAcceptOrRejectPackage3_UnitsReturned()
        {
            // Arrange
            ElectricBill bill = new ElectricBill();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.AreEqual(2, bill.CalculateElectricBill(10, 0), CentsDelta, "10 units used without renewable energy should result in a bill of $2.00 (calculated at base rate)");
            Assert.AreEqual(1.71, bill.CalculateElectricBill(10, 1), CentsDelta, "10 units used with 1 unit returned should result in a bill of $1.71 (calculated at base rate with 5% discount)");
            Assert.AreEqual(-0.2, bill.CalculateElectricBill(10, 11), CentsDelta, "10 units used with 11 units returned should result in a credit of $0.20 (calculated at base rate without discount)");
            Assert.AreEqual(10.44, bill.CalculateElectricBill(52.2, 0), CentsDelta, "52.2 units used without renewable energy should result in a bill of $10.44 (calculated at base rate)");
            Assert.AreEqual(8.018, bill.CalculateElectricBill(52.2, 10), CentsDelta, "52.2 units used with 10 units returned should result in a bill of $8.018 (calculated at base rate with 5% discount)");
            Assert.AreEqual(-9.56, bill.CalculateElectricBill(52.2, 100), CentsDelta, "52.2 units used with 100 units returned should result in a credit of $9.56 (calculated at base rate without discount)");
            Assert.AreEqual(15.22, bill.CalculateElectricBill(76.1, 0), CentsDelta, "76.1 units used without renewable energy should result in a bill of $15.22 (calculated at base rate)");
            Assert.AreEqual(10.07, bill.CalculateElectricBill(76.1, 23.1), CentsDelta, "76.1 units used with 23.1 units returned should result in a bill of $10.07 (calculated at base rate with 5% discount)");
            Assert.AreEqual(-9.38, bill.CalculateElectricBill(76.1, 123), CentsDelta, "76.1 units used with 123 units returned should result in a credit of $9.38 (calculated at base rate without discount)");
            Assert.AreEqual(20, bill.CalculateElectricBill(100, 0), CentsDelta, "100 units used without renewable energy should result in a bill of $20 (calculated at base rate)");
            Assert.AreEqual(11.97, bill.CalculateElectricBill(100, 37), CentsDelta, "100 units used with 37 units returned should result in a bill of $11.97 (calculated at base rate with 5% discount)");
            Assert.AreEqual(-7.446, bill.CalculateElectricBill(100, 137.23), CentsDelta, "100 units used with 137.23 units returned should result in a credit of $7.446 (calculated at base rate without discount)");
            Assert.AreEqual(0, bill.CalculateElectricBill(100, 100), CentsDelta, "100 units used with 100 units returned should result in no bill ($0.00 returned)");
            Assert.AreEqual(20.025, bill.CalculateElectricBill(100.1, 0), CentsDelta, "100.1 units used without renewable energy should result in a bill of $20.025 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(18.601, bill.CalculateElectricBill(100.1, 2.2), CentsDelta, "100.1 units used with 2.2 units returned should result in a bill of $18.601 (calculated at base rate X max excess units plus the excess rate for the remaining units with a 5% discount)");
            Assert.AreEqual(20.25, bill.CalculateElectricBill(101, 0), CentsDelta, "101 units used without renewable energy should result in a bill of $20.25 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(19, bill.CalculateElectricBill(101, 1), CentsDelta, "101 units used with 1 unit returned should result in a bill of $19.00 (calculated at base rate X max excess units plus the excess rate for the remaining units with a 5% discount)");
            Assert.AreEqual(-10.2, bill.CalculateElectricBill(101, 152), CentsDelta, "101 units used with 152 units returned should result in a credit of $10.20 (calculated at base rate without discount)");
            Assert.AreEqual(29.25, bill.CalculateElectricBill(137, 0), CentsDelta, "137 units used without renewable energy should result in a bill of $29.25 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(23.465, bill.CalculateElectricBill(137, 18.2), CentsDelta, "137 units used with 18.2 units returned should result in a bill of $23.465 (calculated at base rate X max excess units plus the excess rate for the remaining units with a 5% discount)");
            Assert.AreEqual(18.43, bill.CalculateElectricBill(137, 40), CentsDelta, "137 units used with 40 units returned should result in a bill of $18.43 (calculated at base rate X max excess units plus the excess rate for the remaining units with a 5% discount)");
            Assert.AreEqual(45, bill.CalculateElectricBill(200, 0), CentsDelta, "200 units used without renewable energy should result in a bill of $45.00 (calculated at base rate X max excess units plus the excess rate for the remaining units)");
            Assert.AreEqual(30.875, bill.CalculateElectricBill(200, 50), CentsDelta, "200 units used with 50 units returned should result in a bill of $30.875 (calculated at base rate X max excess units plus the excess rate for the remaining units with a 5% discount)");
            Assert.AreEqual(9.5, bill.CalculateElectricBill(200, 150), CentsDelta, "200 units used with 150 units returned should result in a bill of $9.50 (calculated at base rate X max excess units plus the excess rate for the remaining units with a 5% discount)");
            Assert.AreEqual(-60, bill.CalculateElectricBill(200, 500), CentsDelta, "200 units used with 500 units returned should result in a credit of $60.00 (calculated at base rate without discount)");
        }
    }
}
