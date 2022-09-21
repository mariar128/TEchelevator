using System;
using System.Collections.Generic;

namespace CollectionsPart2Lecture
{
    public class CollectionsPart2Lecture
	{
        static void Main(string[] args)
        {

			List<string> reviews = new List<string>();

			//Caution removing items in a list while you are looping. 
			//This will change the indexs... 


			/* DICTIONARY - A collection that stores objects 
			 *	- IS NOT ORDERED. 
			 *	- Store Data in KEY-VALUE pair.
			 *	- VALUES are retieved by using the KEY.
			 *	- VALUES can have duplicates (synonym).
			 *	- KEYs cannot have duplicates.  
			 *  - KEYS need to be the same Type.
			 *  - Values need to be the same Type.
			 */

			Console.WriteLine("####################");
			Console.WriteLine("       DICTIONARIES");
			Console.WriteLine("####################");
			Console.WriteLine();

			//Declaring a Dictionary.
			Dictionary<string, string> nameToZip = new Dictionary<string, string>();

			//Adding an item to a Dictionary
			//Insert if key does not exist.
			nameToZip["David"] = "44120";
			//Updating if key exists. 
			nameToZip["David"] = "44555";

			nameToZip["Tori"] = "44102";

			nameToZip["Ben"] = "44124";

            //Retrieving VALUES from a dictionary
            Console.WriteLine("David lives in " + nameToZip["David"]);

			// Retrieving just the keys from Dictionary.
			//IEnumerable<Type> should match dictionary Key type.
			IEnumerable<string> keys = nameToZip.Keys; //returns a collection of all keys in the Dictionary. 
			int numberOfNames = nameToZip.Count;

			int sum = 5 + 5;

			foreach(string keyName in nameToZip.Keys)
            {


                Console.WriteLine(keyName + " lives in " + nameToZip[keyName] + "!");
            }


			//Checking if a Key is in a dictionary

			if(nameToZip.ContainsKey("David"))
            {
                Console.WriteLine("David Exists.");
            }
            Console.WriteLine();

			//Update David's Zip to be "12345";

			nameToZip["David"] = "12345";


			//Access Key Value pair from Dictionary.
			foreach(KeyValuePair<string, string> nameZip in nameToZip)
            {
                Console.WriteLine(nameZip.Key + " liveth in " + nameZip.Value);
            }

			nameToZip.Remove("David");
            Console.WriteLine("Removed David.");
            Console.WriteLine();

			foreach(KeyValuePair<string, string> nameZip in nameToZip)
            {
                Console.WriteLine($"Key:{nameZip.Key}, Value:{nameZip.Value}");
            }

            Console.WriteLine(nameToZip);
            Console.WriteLine(nameToZip.Keys);
            Console.WriteLine(reviews);



			//Initilize a dictionary - Using the initilizer. 
			Dictionary<string, string> studentNames = new Dictionary<string, string>()
			{
				{"Tracy", "Barry" },
				{ "Colin", "Detwiller"},
				{ "Kim", "Barry" },
				{ "Maria G", "Garcia" },
				{ "Amy", "Drapac" },
				{ "Ben", "Measor" },
				{ "Joe", "Gibson" },
				{ "Alex", "Hewson" }
			};


			//Debugging 

			if(nameToZip.Count < 2)
            {
                Console.WriteLine("name to zip dictionary is small");
            }
			else
            {
                Console.WriteLine("name to zip dictionary is not small...");
            }

			foreach(KeyValuePair<string,string> student in studentNames)
            {
                Console.WriteLine("Key: " + student.Key);
                Console.WriteLine("Value: " + student.Value);
            }


		}
	}
}
