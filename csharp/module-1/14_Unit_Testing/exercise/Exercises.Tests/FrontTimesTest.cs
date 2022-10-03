using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {
        [DataTestMethod]
        [DataRow("Chocolate", 2, "ChoCho")]
        [DataRow("Chocolate", 3, "ChoChoCho")]
        [DataRow("Abc", 3, "AbcAbcAbc")]


        [TestMethod]

        public void GenerateStringTest(string str, int n, string expectedResult)
        {
            FrontTimes frontTimes = new FrontTimes();
            string result = frontTimes.GenerateString(str, n);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
