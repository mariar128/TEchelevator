using DotnetMod1PracticeProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class ValidationTests
    {
        private Conditionals exercises = new Conditionals();

        /*
	     SleepIn(false, false) → true
	     SleepIn(true, false) → false
	     SleepIn(false, true) → true
	    */
        [DataTestMethod]
        [DataRow(true, true, true)]
        [DataRow(true, false, false)]
        [DataRow(false, true, true)]
        [DataRow(false, false, true)]
        public void SleepIn(bool input1, bool input2, bool output)
        {
            Assert.AreEqual(output, exercises.SleepIn(input1, input2), $"Input: SleepIn ({input1.ToString()}, {input2.ToString()})");
        }

        /*
         SumDouble(1, 2) → 3
         SumDouble(3, 2) → 5
         SumDouble(2, 2) → 8
         */
        [DataTestMethod]
        [DataRow(77, 173, 250)]
        [DataRow(-38, -37, -75)]
        [DataRow(194, 130, 324)]
        [DataRow(-173, 188, 15)]
        [DataRow(-232, -196, -428)]
        [DataRow(-134, -75, -209)]
        [DataRow(231, 231, 924)]
        [DataRow(111, -238, -127)]
        [DataRow(56, 78, 134)]
        [DataRow(157, -246, -89)]
        [DataRow(211, -152, 59)]
        [DataRow(59, 59, 236)]
        [DataRow(-6, -6, -24)]
        [DataRow(7, 7, 28)]
        [DataRow(154, 154, 616)]
        [DataRow(163, 163, 652)]
        [DataRow(-32, -32, -128)]
        [DataRow(176, -184, -8)]
        [DataRow(225, -117, 108)]
        [DataRow(121, 121, 484)]
        [DataRow(-251, -222, -473)]
        [DataRow(-179, -203, -382)]
        [DataRow(195, -252, -57)]
        [DataRow(-150, -150, -600)]
        [DataRow(-188, -188, -752)]
        [DataRow(49, 49, 196)]
        [DataRow(-130, -61, -191)]
        [DataRow(-11, 216, 205)]
        [DataRow(-34, 65, 31)]
        [DataRow(-173, -71, -244)]
        [DataRow(163, 163, 652)]
        [DataRow(118, -111, 7)]
        public void SumDouble(int input1, int input2, int output) => Assert.AreEqual(output, exercises.SumDouble(input1, input2), $"Input: SumDouble ({input1.ToString()}, {input2.ToString()})");
        /*
         IcyHot(120, -1) → true
         IcyHot(-1, 120) → true
         IcyHot(2, 120) → false
         */
        [DataTestMethod]
        [DataRow(120, -1, true)]
        [DataRow(-1, 120, true)]
        [DataRow(2, 120, false)]
        [DataRow(20, -30, false)]
        [DataRow(128, -7, true)]
        [DataRow(10, 27, false)]
        [DataRow(146, 78, false)]
        [DataRow(-37, 68, false)]
        [DataRow(-35, -49, false)]
        [DataRow(51, 49, false)]
        [DataRow(-33, 66, false)]
        [DataRow(-9, 26, false)]
        [DataRow(137, 30, false)]
        [DataRow(51, 98, false)]
        [DataRow(52, 136, false)]
        [DataRow(-14, 8, false)]
        [DataRow(95, 44, false)]
        [DataRow(140, -6, true)]
        [DataRow(19, 75, false)]
        [DataRow(41, 84, false)]
        [DataRow(27, -49, false)]
        [DataRow(-3, 4, false)]
        [DataRow(144, -29, true)]
        [DataRow(134, 98, false)]
        [DataRow(14, 89, false)]
        [DataRow(129, 120, false)]
        [DataRow(73, -23, false)]
        [DataRow(86, -35, false)]
        [DataRow(-29, 118, true)]
        [DataRow(5, -29, false)]
        [DataRow(123, 4, false)]
        [DataRow(134, 122, false)]
        [DataRow(124, 35, false)]
        [DataRow(36, 29, false)]
        [DataRow(-33, 107, true)]
        [DataRow(141, 90, false)]
        [DataRow(-18, 41, false)]
        [DataRow(14, 96, false)]
        [DataRow(16, 99, false)]
        [DataRow(144, -23, true)]
        [DataRow(84, 87, false)]
        [DataRow(7, 41, false)]
        [DataRow(42, -23, false)]
        [DataRow(31, 95, false)]
        [DataRow(57, 77, false)]
        [DataRow(81, 40, false)]
        [DataRow(55, 1, false)]
        [DataRow(94, -31, false)]
        [DataRow(43, 3, false)]
        [DataRow(-45, 79, false)]
        [DataRow(-17, 135, true)]
        [DataRow(-47, -11, false)]
        [DataRow(127, 50, false)]
        [DataRow(-3, 125, true)]
        [DataRow(36, 84, false)]
        [DataRow(-27, 136, true)]
        [DataRow(0, -47, false)]
        [DataRow(0, -15, false)]
        [DataRow(0, 136, false)]
        [DataRow(0, 94, false)]
        [DataRow(0, 112, false)]
        [DataRow(132, 0, false)]
        [DataRow(139, 0, false)]
        [DataRow(61, 0, false)]
        [DataRow(18, 0, false)]
        [DataRow(13, 0, false)]
        [DataRow(100, 118, false)]
        [DataRow(100, 25, false)]
        [DataRow(100, 110, false)]
        [DataRow(100, 107, false)]
        [DataRow(100, 119, false)]
        [DataRow(-11, 100, false)]
        [DataRow(91, 100, false)]
        [DataRow(44, 100, false)]
        [DataRow(63, 100, false)]
        [DataRow(-15, 100, false)]
        public void IcyHot(int input1, int input2, bool output)
        {
            Assert.AreEqual(output, exercises.IcyHot(input1, input2), $"Input: IcyHot ({input1}, {input2})");
        }

        /*
         CigarParty(30, false) → false
         CigarParty(50, false) → true
         CigarParty(70, true) → true
         */
        [DataTestMethod]
        [DataRow(0, true, false)]
        [DataRow(10, true, false)]
        [DataRow(20, true, false)]
        [DataRow(30, true, false)]
        [DataRow(39, true, false)]
        [DataRow(40, true, true)]
        [DataRow(41, true, true)]
        [DataRow(42, true, true)]
        [DataRow(45, true, true)]
        [DataRow(48, true, true)]
        [DataRow(49, true, true)]
        [DataRow(50, true, true)]
        [DataRow(51, true, true)]
        [DataRow(55, true, true)]
        [DataRow(60, true, true)]
        [DataRow(70, true, true)]
        [DataRow(80, true, true)]
        [DataRow(90, true, true)]
        [DataRow(100, true, true)]
        [DataRow(1000, true, true)]
        [DataRow(10000, true, true)]
        [DataRow(0, false, false)]
        [DataRow(10, false, false)]
        [DataRow(20, false, false)]
        [DataRow(30, false, false)]
        [DataRow(39, false, false)]
        [DataRow(40, false, true)]
        [DataRow(41, false, true)]
        [DataRow(42, false, true)]
        [DataRow(45, false, true)]
        [DataRow(48, false, true)]
        [DataRow(49, false, true)]
        [DataRow(50, false, true)]
        [DataRow(51, false, true)]
        [DataRow(55, false, true)]
        [DataRow(60, false, true)]
        [DataRow(70, false, false)]
        [DataRow(80, false, false)]
        [DataRow(90, false, false)]
        [DataRow(100, false, false)]
        [DataRow(1000, false, false)]
        [DataRow(10000, false, false)]
        public void CigarParty(int i1, bool i2, bool op)
        {
            Assert.AreEqual(op, exercises.CigarParty(i1, i2), $"Input: CigarParty ({i1}, {i2})");
        }

        /*
         AnswerCell(false, false, false) → true
         AnswerCell(false, false, true) → false
         AnswerCell(true, false, false) → false
         */
        [DataTestMethod]
        [DataRow(true, true, true, false)]
        [DataRow(true, true, false, true)]
        [DataRow(true, false, true, false)]
        [DataRow(true, false, false, false)]
        [DataRow(false, true, true, false)]
        [DataRow(false, true, false, true)]
        [DataRow(false, false, true, false)]
        [DataRow(false, false, false, true)]
        public void AnswerCell(bool ip1, bool ip2, bool ip3, bool op) => Assert.AreEqual(op, exercises.AnswerCell(ip1, ip2, ip3), $"Input: AnswerCell ({ip1}, {ip2}, {ip3})");

        /*
         TeaParty(6, 8) → 1
         TeaParty(3, 8) → 0
         TeaParty(20, 6) → 2
         */
        [DataTestMethod]
        [DataRow(6, 8, 1)]
        [DataRow(3, 8, 0)]
        [DataRow(20, 6, 2)]
        [DataRow(8, 6, 1)]
        [DataRow(8, 3, 0)]
        [DataRow(6, 20, 2)]
        [DataRow(0, 1, 0)]
        [DataRow(4, 3, 0)]
        [DataRow(1, 3, 0)]
        [DataRow(2, 4, 0)]
        [DataRow(1, 0, 0)]
        [DataRow(3, 4, 0)]
        [DataRow(3, 1, 0)]
        [DataRow(4, 2, 0)]
        [DataRow(4, 4, 0)]
        [DataRow(5, 5, 1)]
        [DataRow(10, 10, 1)]
        [DataRow(8, 15, 1)]
        [DataRow(8, 16, 2)]
        [DataRow(8, 17, 2)]
        [DataRow(10, 19, 1)]
        [DataRow(10, 20, 2)]
        [DataRow(10, 21, 2)]
        [DataRow(15, 8, 1)]
        [DataRow(16, 8, 2)]
        [DataRow(17, 8, 2)]
        [DataRow(19, 10, 1)]
        [DataRow(20, 10, 2)]
        [DataRow(21, 10, 2)]
        public void TeaParty(int ip1, int ip2, int op)
        {
            Assert.AreEqual(op, exercises.TeaParty(ip1, ip2), $"Input: TeaParty ({ip1}, {ip2})");

        }

    }
}