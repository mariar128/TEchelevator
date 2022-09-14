namespace Lecture
{
    public partial class LectureExample
    {
        /*
11. Write an if statement that returns "Fizz"
    if the parameter is 3 and returns an empty string for anything else.
    TOPIC: Conditional Logic
*/

        /*
        12. Now write the above using the Ternary operator ?:
        */
        public string ReturnFizzIfThreeUsingTernary(int number)
        {
            return (number == 3) ? "Fizz" : "";
        }

        //Write the code that makes sense to you -- if you need to solve with if/else, use that, if you like ternaries, use those
    }
}
