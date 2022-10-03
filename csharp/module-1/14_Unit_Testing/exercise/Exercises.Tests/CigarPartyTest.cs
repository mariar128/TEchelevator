using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{ [TestClass]
    public class CigarPartyTest
    {
        [DataTestMethod]
        [DataRow(50, false, true)]
        [DataRow(60, false, true)]
        [DataRow(70, false, false)]
        [DataRow(70, true, true)]

        [TestMethod]

        public void HaveParty(int cigars, bool isWeekend, bool expectedResults)
        {
            CigarParty party = new CigarParty();
            bool result2 = party.HaveParty(cigars, isWeekend);
            Assert.AreEqual(expectedResults, result2);
        }
        

    }
}

