using System;
using EncapsulationLecture.Classes;


namespace EncapsulationLecture
{
    /* ENCAPSULATION: dictionary def. is "the action of enclosing something in or as if in a capsule"
         * -bundling and hiding of fields, properties & methods
         * -packaging similar/like data and functionality into a single component
         * -hiding access to data/functionality using access modifiers
         * -Makes code re-useable, maintainable
         * -Helps make your code loosely coupled
         *      -Classes/Objects do not need to know about other classes/obejcts
    */


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person david = new Person(1989);
            string dogName = "Jerry";

            Dog davidsDog = new Dog(dogName, "Shepard-Mix", false);
            Dog charliesDog = new Dog("Snoopy", "Beagle", false);

            //Dog emptyDog = new Dog();

            davidsDog.SpeakSound = "Ruff!";
            //Calling Speak on davids dog. 
            davidsDog.Speak();

            charliesDog.SpeakSound = "aarf";
            //Calling Speak on charlies dog. 
            charliesDog.Speak();

            charliesDog.Speak("grrrrr");

            string charliesDogGreeting = charliesDog.GetGreeting();

            Console.WriteLine(charliesDogGreeting);
            Console.WriteLine(davidsDog.GetGreeting());

        }
    }
}
