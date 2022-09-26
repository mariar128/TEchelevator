using System;
using System.Collections.Generic;

namespace CollectionsPart2Lecture
{
	public class CollectionsPart2Lecture
	{
		static void Main(string[] args)
		{
			Console.WriteLine("####################");
			Console.WriteLine("       DICTIONARIES");
			Console.WriteLine("####################");
			Console.WriteLine();
			/* DICTIONARY - A collection that stores objects 
			 * IS NOT ORDERED.
			 * Store Data in KEY-VALUE pair.
			 * VALUES are retrieved by using the KEY.
			 * Values can have duplicates(synonym.)
			 * KEYS cannot have duplicates.
			 * Keys all need to be the same Type.
			 * Values all need to be the same Type.
			 * But the key and value dont need to be the same type.
			 */
			// key      value
			Dictionary<string, string> nameToZip = new Dictionary<string, string>();
			// adding an item to a dictionary
			nameToZip["David"] = "44120"; // safest way, insert if they key does not exist.
			nameToZip["David"] = "44555"; // updating if key exists.
										  // {"David", 44120}
			nameToZip["Tori"] = "44102";

			// Retrieving VALUES from a dictionary
			Console.WriteLine("David lives in" + nameToZip["David"]);

			// Retrieving just the keys from Dictionary.
			// Inumerable<type>should match dictionary Key type.
			IEnumerable<string> keys = nameToZip.Keys; // returns a collection of all keys in the dictionary.
			foreach (string keyName in keys)
			{
				Console.WriteLine(keyName + " lives in " + nameToZip[keyName]);
			}

			// checking if a Key is in a dictionary
			if (nameToZip.ContainsKey("David"))
			{
				Console.WriteLine("David Exists.");
			}
			Console.WriteLine();

			//Update Davids Zip to be "12345";
			nameToZip["David"] = "12345";

			foreach (KeyValuePair<string, string> nameZip in nameToZip)
			{
				Console.WriteLine(nameZip.Key + " liveth in " + nameZip.Value);
			}
			nameToZip.Remove("David");
			Console.WriteLine("Removed David.");
			Console.WriteLine();

			foreach (KeyValuePair<string, string> nameZip in nameToZip)
			{
				Console.WriteLine($"Key:{nameZip.Key}, Value:{nameZip.Value}");
			}
			IEnumerable<string> values = nameToZip.Values;
			// initilize a dictionary
			Dictionary<string, string> studentNames = new Dictionary<string, string>()
			{
				{"Tracy", "Barry" },
				{"Colin", "Detwiller"},
				{"Kim","Barry" },
				{"Maria G", "Garcia" },
				{"Amy","Drapac" },
				{"Ben", "Measor"},
				{"Joe", "Gibson" },
				{"Alex", "Hewson"}

			};

            //Debugging



            // List<string> reviews = new List<string>();
            // Caution removing items in a list while you are looping. This will change the indexs.


            //}
        }
	}
}
