namespace Lecture
{
    public partial class LectureProblem
    {
        /*
        10. What code do we need to write so that we can find the highest
             number in the array randomNumbers?
             TOPIC: Looping Through Arrays
        */
        public int FindTheHighestNumber(int[] randomNumbers)
        {
            int highestValue = randomNumbers[0];

            //loop through the array 
            for(int i = 0; i < randomNumbers.Length; i++)
            {
                int currentValue = randomNumbers[i];

                //compare numbers using an if statement
                if(currentValue > highestValue)
                {
                    highestValue = currentValue; //set highestValue if the currentValue is greater than the existing highest value
                }
            }


            return highestValue;
        }
    }
}
