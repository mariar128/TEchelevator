using DotnetMod1PracticeProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass()]
    public class LoopsArraysExercisesTests
    {
        LoopsArraysExercises exercises = new LoopsArraysExercises();

        [TestMethod()]
        public void FirstLast6Test()
        {
            Assert.AreEqual(true, exercises.FirstLast6(new int[] { 1, 2, 6 }), "Test 1: Input was [1, 2, 6]");
            Assert.AreEqual(true, exercises.FirstLast6(new int[] { 6, 1, 2, 3 }), "Test 2: Input was [6, 1, 2, 3]");
            Assert.AreEqual(false, exercises.FirstLast6(new int[] { 13, 6, 1, 2, 3 }), "Test 3: Input was [13, 6, 1, 2, 3]");
        }

        [TestMethod()]
        public void SameFirstLastTest()
        {
            Assert.AreEqual(false, exercises.SameFirstLast(new int[] { 1, 2, 3 }), "Test 1: Input was [1, 2, 3]");
            Assert.AreEqual(true, exercises.SameFirstLast(new int[] { 1, 2, 3, 1 }), "Test 2: Input was [1, 2, 3, 1]");
            Assert.AreEqual(true, exercises.SameFirstLast(new int[] { 1, 2, 1 }), "Test 3: Input was [1, 2, 1]");
        }

        [TestMethod()]
        public void CommonEndTest()
        {
            Assert.AreEqual(true, exercises.CommonEnd(new int[] { 1, 2, 3 }, new int[] { 1, 5, 3 }), "Test 1: Input was [1, 2, 3] and [1, 5, 3]. It should return true.");
            Assert.AreEqual(false, exercises.CommonEnd(new int[] { 1, 2, 3 }, new int[] { 7, 3, 2 }), "Test 2: Input was [1, 2, 3] and [7, 3, 2]. It should return false.");
            Assert.AreEqual(true, exercises.CommonEnd(new int[] { 1, 2, 3 }, new int[] { 7, 3 }), "Test 3: Input was [1, 2, 3] and [7, 3]. Did you notice the arrays were different sizes?");
            Assert.AreEqual(true, exercises.CommonEnd(new int[] { 1, 2, 3 }, new int[] { 1, 3 }), "Test 4: Input was [1, 2, 3] and [1, 3]. Did you notice the arrays were different sizes?");
        }

        [TestMethod()]
        public void Sum2Test()
        {
            Assert.AreEqual(3, exercises.Sum2(new int[] { 1, 2, 3 }), "Test 1: Input was [1, 2, 3]");
            Assert.AreEqual(2, exercises.Sum2(new int[] { 1, 1 }), "Test 2: Input was [1, 1]");
            Assert.AreEqual(2, exercises.Sum2(new int[] { 1, 1, 1, 1 }), "Test 3: Input was [1, 1, 1, 1]");
            Assert.AreEqual(5, exercises.Sum2(new int[] { 5 }), "Test 4: Input was [5]");
            Assert.AreEqual(0, exercises.Sum2(new int[] { }), "Test 5: Input was []");
        }

        [TestMethod()]
        public void Has22Test()
        {
            Assert.AreEqual(true, exercises.Has22(new int[] { 1, 2, 2, 3 }), "Test 1: Input was [1, 2, 2, 3] and should return true.");
            Assert.AreEqual(true, exercises.Has22(new int[] { 2, 2, 3 }), "Test 2: Input was [2, 2, 3] and should return true.");

            Assert.AreEqual(true, exercises.Has22(new int[] { 1, 2, 2 }), "Test 3: Input was [1, 2, 2] and should also return true.");
            Assert.AreEqual(false, exercises.Has22(new int[] { 1, 2, 1, 2 }), "Test 4: Input was [1, 2, 1, 2] and should return false.");
            Assert.AreEqual(false, exercises.Has22(new int[] { 2, 1, 2 }), "Test 5: Input was [2, 1, 2] and should return false.");

            Assert.AreEqual(true, exercises.Has22(new int[] { 2, 2, 2 }), "Test 6: Input was [2, 2, 2] and should also return true.");
            Assert.AreEqual(false, exercises.Has22(new int[] { 1, 2, 3, 4 }), "Test 7: Input was [1, 2, 3, 4] and should return false.");
            Assert.AreEqual(false, exercises.Has22(new int[] { 3, 4, 5 }), "Test 8: Input was [3, 4, 5] and should return false.");
        }

        [TestMethod()]
        public void Sum28Test()
        {
            Assert.AreEqual(true, exercises.Sum28(new int[] { 2, 3, 2, 2, 4, 2 }), "Test 1: Input was [2, 3, 2, 2, 4, 2]");
            Assert.AreEqual(false, exercises.Sum28(new int[] { 2, 3, 2, 2, 4, 2, 2 }), "Test 2: Input was [2, 3, 2, 2, 4, 2, 2]");
            Assert.AreEqual(false, exercises.Sum28(new int[] { 1, 2, 3, 4 }), "Test 3: Input was [1, 2, 3, 4]");
        }
    }
}