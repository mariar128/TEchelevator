namespace Lecture
{
    public partial class LectureProblem
    {
        /*
        1a. This method expects an array of integers to be returned.
            Create an array and return it.

            TOPIC: Array Creation
        */
        public int[] ReturnNewArray()
        {
            int[] firstArray = new int[73];
            return firstArray;
        }


        /*
        1b. This method expects an array of integers size 100 to be returned.
            Create an array of size 100 and return it.

            TOPIC: Array Creation
        */
        public int[] ReturnArrayOfKnownSize()
        {
            int[] secondArray = new int[100];
            return secondArray;
        }

        /*
        1c. This method expects an array of strings size n to be returned.
            As long as the array size is set to an integer, its ok to not know the value when we create it.

            TOPIC: Array Creation
        */
        public string[] ReturnArrayOfUnknownSize(int n)
        {
            string[] thirdArray = new string[n];
            return thirdArray;
        }


    }
}
