using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetMod1PracticeProblems
{
    public class CollectionsExercises
    {
        /*
      Given an array of Strings, return a List containing the same Strings in the same order
      except for any words that contain exactly 4 characters.
      No4LetterWords( {"Train", "Boat", "Car"} )  ->  ["Train", "Car"]
      No4LetterWords( {"Red", "White", "Blue"} )  ->  ["Red", "White"]
      No4LetterWords( {"Jack", "Jill", "Jane", "John", "Jim"} )  ->  ["Jim"]
      */
        public List<string> No4LetterWords(string[] stringArray)
        {
            return new List<string>();
        }

        /*
      Given a List of integers, return the largest value.
      FindLargest( [11, 200, 43, 84, 9917, 4321, 1, 33333, 8997] ) -> 33333
      FindLargest( [987, 1234, 9381, 731, 43718, 8932] ) -> 43718
      FindLargest( [34070, 1380, 81238, 7782, 234, 64362, 627] ) -> 81238
      */
        public int FindLargest(List<int> integerList)
        {
            return 0;
        }

        /*
        Given an array of Integers, return a List of Integers containing just the odd values.
        OddOnly( {112, 201, 774, 92, 9, 83, 41872} ) -> [201, 9, 83]
        OddOnly( {1143, 555, 7, 1772, 9953, 643} ) -> [1143, 555, 7, 9953, 643]
        OddOnly( {734, 233, 782, 811, 3, 9999} ) -> [233, 811, 3, 9999]
        */
        public List<int> OddOnly(int[] integerArray)
        {
            return new List<int>();
        }

        /*
       Given an array of integers, return a List that contains the same integers (as strings). Except any multiple of 3
       must be replaced by the string "Fizz", any multiple of 5 must be replaced by the string "Buzz",
       and any multiple of both 3 and 5 must be replaced by the string "FizzBuzz."
       ** INTERVIEW QUESTION **

       FizzBuzzList( {1, 2, 3} )  ->  ["1", "2", "Fizz"]
       FizzBuzzList( {4, 5, 6} )  ->  ["4", "Buzz", "Fizz"]
       FizzBuzzList( {7, 8, 9, 10, 11, 12, 13, 14, 15} )  ->  ["7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"]

       HINT: To convert an integer x to a string, you can use x.ToString() in your code. For example, if x = 1 then x.ToString() equals "1."
       */
        public List<string> FizzBuzzList(int[] integerArray)
        {
            return new List<string>();
        }

        /*
         * Given an array of non-empty strings, return a Dictionary<string, string> where for every different string in the array,
         * there is a key of its first character with the value of its last character.
         *
         * BeginningAndEnding(["code", "bug"]) → {"b": "g", "c": "e"}
         * BeginningAndEnding(["man", "moon", "main"]) → {"m": "n"}
         * BeginningAndEnding(["muddy", "good", "moat", "good", "night"]) → {"g": "d", "m": "t", "n": "t"}
         */
        public Dictionary<string, string> BeginningAndEnding(string[] words)
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
            foreach (string word in words)
            {
                output[word.Substring(0, 1)] = word.Substring(word.Length - 1);
            }

            return output;
        }


    }
}
