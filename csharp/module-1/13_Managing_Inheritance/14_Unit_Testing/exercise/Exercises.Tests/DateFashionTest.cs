using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {
        [TestMethod()]

        [DataTestMethod()]

        [DataRow(5, 10, 2)]
        [DataRow(5, 2, 0)]
        [DataRow(5, 5, 1)]
        public void GetATable(int you, int date, int expectedResults)
        {
            DateFashion dateFashion = new DateFashion();
            int result = dateFashion.GetATable(you, date);
            Assert.AreEqual(expectedResults, result);
        }
    }
}

