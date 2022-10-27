using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
   public class Less20Test
    {
        [DataTestMethod]
        [DataRow (18,true)]
        [DataRow(19, true)]
        [DataRow(20,false )]
       
        public void IsLessThanMultipleOf20Test(int n, bool expectedResult)
        {
            Less20 less20 = new Less20();
            bool result = less20.IsLessThanMultipleOf20(n);
            Assert.AreEqual(expectedResult, result);




        }


    }
}
