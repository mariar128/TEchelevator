namespace Lecture
{
    public partial class LectureExample
    {
        /*
        16. Return "Big Even Number" when number is even, larger than 100, and a multiple of 5.
            Return "Big Number" if the number is just larger than 100.
            Return empty string for everything else.
            TOPIC: Complex Expression
        */
        public string ReturnBigEvenNumber(int number)
        {
            if(number % 2 == 0 && number > 100 && number % 5 == 0) // number divided by two has zero remainder if even, and number is over 100, and number divided by five is 
            {
                return "Big Even Number";
            }
            else if(number > 100) // if line 13 fails, check if the number is over 100 specifically
            {
                return "Big Number";
            }
            return "";
        }
    }
}
