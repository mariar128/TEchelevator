namespace Lecture
{
    public partial class LectureProblem
    {
        /*
        6. How can we write a for loop that sums up the values in this array?
           TOPIC: For Loops
        */
        public int ReturnSumArray()
        {
            int[] arrayToLoopThrough = { 3, 4, 2, 9 };

            int sum = 0; // scope sum starts out life as 0
            for(int i = 0; i < arrayToLoopThrough.Length; i++)
            {
                sum = sum + arrayToLoopThrough[i]; // changes the value of sum by adding the current value of sum + what is at the specified array index
            }
            // sum is now 18 after the loop cycled all the way through the arrayToLoopThrough array
            return 0;
        }
    }
}
