using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationLecture
{
 public class Dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        private bool isSpade { get; set; }

        public string speakSound;
        public string SpeakSound
        {
            set
            {
                this.speakSound = value;
            }
        }
        public Dog()
        {
            Console.WriteLine("inside Dog constructor);
        }
        public Dog(string name, string breed, bool isSpade)
        {
            // THIS- this is usally optional but allows you to specify the object you are working in
            this.Name = name;
            Breed = breed;
            this.isSpade = isSpade;
        }
        // Behaviors - things the Dog can do.
        // This method will cause the dog to bark.

        // Method OVERLOADING.
        // Multiple versions of the same method
        //To Overload must have different Number or Types of parameters.
        public void Speak()
        {
            Console.WriteLine($"{this.Name} says {this.speakSound}");
        }
        public void Speak(string sound)
        {
            Console.WriteLine($"{this.Name} says {sound}");
        }
    }
    }
    
