using DotnetMod1PracticeProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Exercises
{
    [TestClass]
    public class ExerciseTests
    {
        CollectionsExercises exercises = new CollectionsExercises();

        /*
         Given a list of Strings, return an array containing the same Strings in the same order
         List2Array( ["Apple", "Orange", "Banana"] )  ->  {"Apple", "Orange", "Banana"}
         List2Array( ["Red", "Orange", "Yellow"] )  ->  {"Red", "Orange", "Yellow"}
         List2Array( ["Left", "Right", "Forward", "Back"] )  ->  {"Left", "Right", "Forward", "Back"}
         */
        [TestMethod]
        public void Exercise02_List2Array()
        {
            CollectionAssert.AreEqual(new string[] { "Apple", "Orange", "Banana" }, exercises.List2Array(new List<string> { "Apple", "Orange", "Banana" }));
            CollectionAssert.AreEqual(new string[] { "Red", "Orange", "Yellow" }, exercises.List2Array(new List<string> { "Red", "Orange", "Yellow" }));
            CollectionAssert.AreEqual(new string[] { "Left", "Right", "Forward", "Back" }, exercises.List2Array(new List<string> { "Left", "Right", "Forward", "Back" }));
        }

        /*
         Given an array of Strings, return a List containing the same Strings in the same order
         except for any words that contain exactly 4 characters.
         No4LetterWords( {"Train", "Boat", "Car"} )  ->  ["Train", "Car"]
         No4LetterWords( {"Red", "White", "Blue"} )  ->  ["Red", "White"]
         No4LetterWords( {"Jack", "Jill", "Jane", "John", "Jim"} )  ->  ["Jim"]
         */
        [TestMethod]
        public void Exercise03_No4LetterWords()
        {
            CollectionAssert.AreEqual(new List<string>() { "Train", "Car" }, exercises.No4LetterWords(new string[] { "Train", "Boat", "Car" }));
            CollectionAssert.AreEqual(new List<string>() { "Red", "White" }, exercises.No4LetterWords(new string[] { "Red", "White", "Blue" }));
            CollectionAssert.AreEqual(new List<string>() { "Jim" }, exercises.No4LetterWords(new string[] { "Jack", "Jill", "Jane", "John", "Jim" }));
        }


        /*
         Given a List of Integers, return the largest value.
         FindLargest( [11, 200, 43, 84, 9917, 4321, 1, 33333, 8997] ) -> 33333
         FindLargest( [987, 1234, 9381, 731, 43718, 8932] ) -> 43718
         FindLargest( [34070, 1380, 81238, 7782, 234, 64362, 627] ) -> 81238
         */
        [TestMethod]
        public void Exercise05_FindLargest()
        {
            Assert.AreEqual(33333, exercises.FindLargest(new List<int>() { 11, 200, 43, 84, 9917, 4321, 1, 33333, 8997 }));
            Assert.AreEqual(43718, exercises.FindLargest(new List<int>() { 987, 1234, 9381, 731, 43718, 8932 }));
            Assert.AreEqual(81238, exercises.FindLargest(new List<int>() { 34070, 1380, 81238, 7782, 234, 64362, 627 }));
        }

        /*
         Given an array of Integers, return a List of Integers containing just the odd values.
         OddOnly( {112, 201, 774, 92, 9, 83, 41872} ) -> [201, 9, 83]
         OddOnly( {1143, 555, 7, 1772, 9953, 643} ) -> [1143, 555, 7, 9953, 643]
         OddOnly( {734, 233, 782, 811, 3, 9999} ) -> [233, 811, 3, 9999]
         */
        [TestMethod]
        public void Exercise06_OddOnly()
        {
            CollectionAssert.AreEqual(new List<int>() { 201, 9, 83 }, exercises.OddOnly(new int[] { 112, 201, 774, 92, 9, 83, 41872 }));
            CollectionAssert.AreEqual(new List<int>() { 1143, 555, 7, 9953, 643 }, exercises.OddOnly(new int[] { 1143, 555, 7, 1772, 9953, 643 }));
            CollectionAssert.AreEqual(new List<int>() { 233, 811, 3, 9999 }, exercises.OddOnly(new int[] { 734, 233, 782, 811, 3, 9999 }));
        }

        /*
         Given an array of Integers, return a List that contains strings.  except any multiple of 3
         should be replaced by the String "Fizz", any multiple of 5 should be replaced by the String "Buzz",
         and any multiple of both 3 and 5 should be replaced by the String "FizzBuzz"
         FizzBuzzList( {1, 2, 3} )  ->  ["1", "2", "Fizz"]
         FizzBuzzList( {4, 5, 6} )  ->  ["4", "Buzz", "Fizz"]
         FizzBuzzList( {7, 8, 9, 10, 11, 12, 13, 14, 15} )  ->  ["7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]
         */
        [TestMethod]
        public void Exercise08_FizzBuzzList()
        {
            CollectionAssert.AreEqual(new List<string>() { "1", "2", "Fizz" }, exercises.FizzBuzzList(new int[] { 1, 2, 3 }));
            CollectionAssert.AreEqual(new List<string>() { "4", "Buzz", "Fizz" }, exercises.FizzBuzzList(new int[] { 4, 5, 6 }));
            CollectionAssert.AreEqual(new List<string>() { "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" }, exercises.FizzBuzzList(new int[] { 7, 8, 9, 10, 11, 12, 13, 14, 15 }));
        }

        [TestMethod]
        public void Exercise05_BeginningAndEnding()
        {
            Dictionary<string, string> expected = new Dictionary<string, string>()
            {
                { "b", "g" },
                { "c", "e" }
            };
            Dictionary<string, string> actual = exercises.BeginningAndEnding(new string[] { "code", "bug" });
            CollectionAssert.AreEqual(expected, actual);

            expected = new Dictionary<string, string>()
            {
                { "m", "n" },
            };
            actual = exercises.BeginningAndEnding(new string[] { "man", "moon", "main" });
            CollectionAssert.AreEqual(expected, actual);


            expected = new Dictionary<string, string>()
            {
                { "g","d" },
                { "m", "t" },
                { "n", "t" }
            };
            actual = exercises.BeginningAndEnding(new string[] { "muddy", "good", "moat", "good", "night" });
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
