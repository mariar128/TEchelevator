using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
  //06_ReturnSumArray 

            int[] arrayToLoopThrough = { 3, 4, 2, 9 };

            int sum = 0; //scope
                         //sum starts out life as 0 

            Console.WriteLine(sum);

            for (int i = 0; i < arrayToLoopThrough.Length; i++)
            {
                sum = sum + arrayToLoopThrough[i]; //changes the value of sum by adding the current value of sum + what is at the specified array index
            }

            //sum is now 18 after the loop cycled all the way through the arrayToLoopThrough array
            Console.WriteLine(sum);

            for (int i = 0; i < arrayToLoopThrough.Length; i++)
            {
                sum = sum - arrayToLoopThrough[i];
            }

            //sum is 0 again
            Console.WriteLine(sum);


        }
    }
}
