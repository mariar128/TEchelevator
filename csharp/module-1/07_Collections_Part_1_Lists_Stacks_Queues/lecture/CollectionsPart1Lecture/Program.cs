using System;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
	public class CollectionsPart1Lecture
	{

				static void Main(string[] args)
				{
					Console.WriteLine("####################");
					Console.WriteLine("       LISTS");
					Console.WriteLine("####################");


					double[] averageScores = new double[20];
					averageScores[0] = 3.0;
					// Lists live in System.Collections.Generic
					{

						string[] teStaff = new string[6];
						teStaff[0] = "David";
						teStaff[1] = "Tori";
						teStaff[2] = "John";
						teStaff[3] = "Ben";
						teStaff[4] = "Kaitlin";
						teStaff[5] = "Chelsea";

						List<string> names = new List<string>(); // call constructor for list -> ()
																 // T - stand in for 'Type' You can put a type in <>.
						names.Add("Frodo");
						names.Add("Sam");
						names.Add("Pippin");
						names.Add("Merry");
						names.Add("Gandalf");
						names.Add("Aragorn");
						names.Add("Boromir");
						names.Add("Gimli");
						names.Add("Legolas");

						for (int i = 0; i < names.Count; i++) // Arrays have .Length Lists have .Count
						{
							Console.WriteLine(names[i]);
						}


						Console.WriteLine("####################");
					Console.WriteLine("Lists are ordered");
					Console.WriteLine("####################");


                    for (int i = 0; i < names.Count; i++)
                    {
						Console.WriteLine(names[i]);
                    }

					Console.WriteLine("####################");
					Console.WriteLine("Lists allow duplicates");
					Console.WriteLine("####################");
				names.Add("Sam");
                for (int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine(names[i]);
                }

					Console.WriteLine("####################");
					Console.WriteLine("Lists allow elements to be inserted in the middle");
					Console.WriteLine("####################");


				names.Insert(2, "David");
				for(int i = 0; i < names.Count; i++)
                {
					Console.WriteLine(names[i]);
                }

					Console.WriteLine("####################");
					Console.WriteLine("Lists allow elements to be removed by index");
					Console.WriteLine("####################");

				names.Remove("David"); // OR names.RemoveAt(2);
				for(int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine(names[i]);
                }

					Console.WriteLine("####################");
					Console.WriteLine("Find out if something is already in the List");
					Console.WriteLine("####################");

				bool isItemInList = names.Contains("Gandalf");
				Console.WriteLine("Is Gandalf in the names list?" + isItemInList); // concatnated boolean to string


					Console.WriteLine("####################");
					Console.WriteLine("Find index of item in List");
					Console.WriteLine("####################");
				int gandalfIndex = -1;
				/*
				for(int i = 0; i < names.Count; i++)
                {
					if(names[i] == "Gandalf")
                    {
						gandalfIndex = i;
                    }
                }
				*/
				// when item is not present youll get -1
				gandalfIndex = names.IndexOf("Tori");

				Console.WriteLine("Gandalf is located at index" + gandalfIndex);
				

					Console.WriteLine("####################");
					Console.WriteLine("Lists can be turned into an array");
					Console.WriteLine("####################");

				string[] namesArray = names.ToArray();
				for(int i = 0; i < namesArray.Length; i++)
                {
					Console.WriteLine(namesArray[i]);
                }

					Console.WriteLine("####################");
					Console.WriteLine("Lists can be sorted");
					Console.WriteLine("####################");

				names.Sort(); // void means it gives us back nothing. return type is void. Sort changes the list. 
				for(int i = 0; i < names.Count; i++)
                {
					Console.WriteLine(names[i]);
                }




					Console.WriteLine("####################");
					Console.WriteLine("Lists can be reversed too");
					Console.WriteLine("####################");

				names.Reverse(); // changing the original list, no undo or copy.

				for(int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine(names[i]);
                }

					Console.WriteLine("####################");
					Console.WriteLine("       FOREACH");
					Console.WriteLine("####################");
					Console.WriteLine();
				foreach (string name in names)
				{
					Console.WriteLine(name);
				}

				List<bool> isWeekend = new List<bool>();
				//Tuesday
				isWeekend.Add(false);
				//Wed
				isWeekend.Add(false);
				// Thurs
				isWeekend.Add(false);
				//Fri
				isWeekend.Add(false);
				//Sat
				isWeekend.Add(true);
				//Mon
				isWeekend.Add(false);
				
				foreach(bool dayOfWeek in isWeekend)

                {
                    Console.WriteLine(dayOfWeek);
                }










				// for each works on arrays too
				// loop through names,
				// run the code block (stuff inside of curly braces) on every time in the collection.
				// Explanation: foreach(type(string) variableName(name) in Collection(names))
				
				// Queue<Dog> dogQueue = new Queue<Dog>();
				}
			}
		}
	}


