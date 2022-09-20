namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return true if it ends in "ly".
        EndsLy("oddly") → true
        EndsLy("y") → false
        EndsLy("oddy") → false
        */
        public bool EndsLy(string str)
        {
            int length = str.Length;

            if (length < 2)
            {
                return false;
            }
           
                return (str.Substring(length - 2).Equals("ly"));
            }
        }
    }

