using System;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
	{
        static void Main(string[] args)
        {
			/*
			 * ARRAYS
			 * 
			 */

			double[] averageScores = new double[20];
			averageScores[0] = 3.0;

			// Lists lives in System.Collections.Generic;


			string[] teStaff = new string[6];
			teStaff[0] = "David";
			teStaff[1] = "Tori";
			teStaff[2] = "John";
			teStaff[3] = "Ben";
			teStaff[4] = "Kaitlin";
			teStaff[5] = "Chelsea";


			Console.WriteLine("####################");
			Console.WriteLine("       LISTS");
			Console.WriteLine("####################");

			List<string> names = new List<string>(); //call constructor for list -> ();
			names.Add("Frodo");
			names.Add("Sam");
			names.Add("Pippin");
			names.Add("Merry");
			names.Add("Gandalf");
			names.Add("Aragorn");
			names.Add("Boromir");
			names.Add("Gimli");
			names.Add("Legolas");



			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");

			//names.Reverse();

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

			names.RemoveAt(2);
			
			for(int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }


			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");

			bool isItemInList = names.Contains("Gandalf");

            Console.WriteLine("Is Gandalf in the names list? " + isItemInList);

			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");

			
			/*
			for(int i = 0; i < names.Count; i++)
            {
				if(names[i] == "Gandalf")
                {
					gandalfIndex = i;
                }
            }
			*/

			//When Item is not present 
		    int toriIndex = names.IndexOf("Tori");

            Console.WriteLine("Tori is located at index " + toriIndex);

			int gandalfIndex = names.IndexOf("Gandalf");

            Console.WriteLine("Gandalf is located at index " + gandalfIndex);

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");

			string[] namesArray = names.ToArray();
			// forloop with namesArray and write to console. 
			for (int i = 0; i < namesArray.Length; i++)
            {
                Console.WriteLine(namesArray[i]);
            }

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");


			names.Sort(); //CHANGES THE LIST ORDER
			for(int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");

			names.Reverse(); //CHANGES THE LIST ORDER

			for(int i = 0; i <names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();

			//Loop throught names, 
			//run the code block on every item in the collection. 
			//Explanation: foreach(Type variableName in Collection) 
			foreach(string lordOfTheRingsCharacter in names)
            {
                Console.WriteLine(lordOfTheRingsCharacter);
            }

            Console.WriteLine("####### FOREACH WORKS ON ARRAYS TOO ######");

			string myWord = "TechElevator";

			foreach( char letter in myWord)
            {
                Console.WriteLine(letter);
            }
			

            Console.WriteLine("############### Collectoins with Classes ###########");

			List<Dog> dogs = new List<Dog>();

			Dog davidsDog = new Dog();
			davidsDog.Name = "Jerry";
			davidsDog.Age = 6;
			davidsDog.Breed = "Shepard-Mix";

			Dog zachDog = new Dog();
			zachDog.Name = "Rosy";
			zachDog.Age = 5;
			zachDog.Breed = "PitBull";

			dogs.Add(zachDog);
			dogs.Add(davidsDog);

            Console.WriteLine("WRITE THE WHOLE DOG!!!!");
			//      Type variableName in Collection
			foreach(Dog currentDog in dogs)
            {

                Console.WriteLine(currentDog.Name + " is a " + currentDog.Breed + " who is " + currentDog.Age + " years old.");
                Console.WriteLine(currentDog.Name);
                Console.WriteLine(currentDog.Breed);
                Console.WriteLine(currentDog.Age);
            }

			List<bool> isWeekend = new List<bool>();

			//Tuesday
			isWeekend.Add(false);
			//Wednesday
			isWeekend.Add(false);
			isWeekend.Add(false);
			isWeekend.Add(false);
			//Saturday
			isWeekend.Add(true);
			//Sunday
			isWeekend.Add(true);
			//Monday
			isWeekend.Add(false);

			foreach(bool dayOfWeek in isWeekend)
            {
                Console.WriteLine(dayOfWeek);
            }


            //Console.WriteLine(zachDog.Name);

            Console.WriteLine("############## Other Collections - Bonus ###########");
			//QUEUE https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-6.0
			Queue<Dog> dogQueue = new Queue<Dog>();
			dogQueue.Enqueue(zachDog);
			dogQueue.Enqueue(davidsDog);

			dogQueue.Dequeue();

			//STACK https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-6.0

			Stack<Dog> dogStack = new Stack<Dog>();
			dogStack.Push(zachDog);
			dogStack.Push(davidsDog);

			Dog Jerry = dogStack.Pop();


			//LINKEDLIST https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0

		}
	}
}

