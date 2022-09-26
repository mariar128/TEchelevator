using System;
using EncapsulationLecture.Classes;
namespace EncapsulationLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person david = new Person(1989);
            string dogName = "Jerry,";
            Dog davidsDog = new Dog("Jerry", "Shepard-Mix", true);
            Dog charliesDog = new Dog("Snoopy", "Beagle", false);

            davidsDog.SpeakSound = "Ruff!";
            // Calling Speak on davids dog.
            davidsDog.Speak();

            charliesDog.SpeakSound = "aarf";
            //Callimg speak on charlies dog
            charliesDog.Speak();

            charliesDog.Speak("grrrrrr");
           
            
        }
    }
}
