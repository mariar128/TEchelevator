using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetMod1PracticeProblems
{
    public class LoopsArraysExercises
    {
        /*
 Given an array of ints, return true if 6 appears as either the first or last element in the array.
 The array will be length 1 or more.
 FirstLast6([1, 2, 6]) → true
 FirstLast6([6, 1, 2, 3]) → true
 FirstLast6([13, 6, 1, 2, 3]) → false
 */
        public bool FirstLast6(int[] nums)
        {
            return false;
        }

        /*
 Given an array of ints, return true if the array is length 1 or more, and the first element and
 the last element are equal.
 SameFirstLast([1, 2, 3]) → false
 SameFirstLast([1, 2, 3, 1]) → true
 SameFirstLast([1, 2, 1]) → true
 */
        public bool SameFirstLast(int[] nums)
        {
            return false;
        }

        /*
        Given 2 arrays of ints, a and b, return true if they have the same first element or they have
        the same last element. Both arrays will be length 1 or more.
        CommonEnd([1, 2, 3], [7, 3]) → true
        CommonEnd([1, 2, 3], [7, 3, 2]) → false
        CommonEnd([1, 2, 3], [1, 3]) → true
        */
        public bool CommonEnd(int[] a, int[] b)
        {
            return false;
        }

        /*
         Given an array of ints, return the sum of the first 2 elements in the array. If the array length
          is less than 2, just sum up the elements that exist, returning 0 if the array is length 0.
         Sum2([1, 2, 3]) → 3
         Sum2([1, 1]) → 2
         Sum2([1, 1, 1, 1]) → 2
         */
        public int Sum2(int[] nums)
        {
            return 0;
        }

        /*
         Given an array of ints, return true if the array contains a 2 next to a 2 somewhere.
         Has22([1, 2, 2]) → true
         Has22([1, 2, 1, 2]) → false
         Has22([2, 1, 2]) → false
         */
        public bool Has22(int[] nums)
        {
            return false;
        }

        /*
         Given an array of ints, return true if the sum of all the 2's in the array is exactly 8.
         Sum28([2, 3, 2, 2, 4, 2]) → true
         Sum28([2, 3, 2, 2, 4, 2, 2]) → false
         Sum28([1, 2, 3, 4]) → false
         */
        public bool Sum28(int[] nums)
        {
            return false;
        }

    }
}
