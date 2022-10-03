using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Exercises.Tests
{
    [TestClass]
  public class Lucky13Testcs
    {
        [DataTestMethod]
        [DataRow (new int[] { 0, 2, 4 }, true)]
        [DataRow (new int[] { 1, 2, 3 }, false)]
        [DataRow (new int[] { 1, 2, 4 }, false)]

        public void GetLuckyTest(int []nums, bool expectedResult)
        {
            Lucky13 lucky = new Lucky13();
            bool result = lucky.GetLucky(nums);
            Assert.AreEqual(expectedResult, result);

        }
           
    }
}
