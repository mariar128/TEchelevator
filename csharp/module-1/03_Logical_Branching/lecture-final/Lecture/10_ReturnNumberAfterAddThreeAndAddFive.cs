namespace Lecture
{
    public partial class LectureExample
    {
        /*
        10.This method will take a number and do the following things to it:
            If addThree is true, we'll add three to that number
            If addFive is true, we'll add five to that number
            We'll then return the result
            TOPIC: Stacking Conditional Logic
        */
        public int ReturnNumberAfterAddThreeAndAddFive(int number, bool addThree, bool addFive)
        {
            if (addThree == true)
            {
                number = number + 3;
            }
         
            // Why can't we use an else here?
            // Because the two conditions aren't mutually exclusive (addFive doesn't become true just because addThree is false)

            if (addFive == true)
            {
                number += 5; //same as: number = number + 5
            }

            return number;
        }
    }
}
