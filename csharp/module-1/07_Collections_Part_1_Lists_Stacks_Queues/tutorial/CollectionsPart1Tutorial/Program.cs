using System;
using System.Collections.Generic;

namespace CollectionsPart1Tutorial
{
    public class CollectionsPart1Tutorial
    {
        static void Main(string[] args)
        {

            // Step One: Declare a List
            List<string> theList = new List<string>();



            // Step Two: Add values to a List
            theList.Add("10");
            theList.Add("15");
            theList.Add("20");



            // Step Three: Looping through a List in a for loop
            int counter = 0;
            for (int i = 0; i < theList.Count; i++)
            {
                counter++;
            }


            // Step Four: Remove an item
            theList.RemoveAt(0);
            theList.Remove("10");


            // Step Five: Looping through List in a foreach loop
            foreach(string Scene in theList)
            {
                Console.WriteLine(Scene);
            }



        }
    }
}
