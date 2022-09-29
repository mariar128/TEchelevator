using Lecture.Farming;
using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // OLD MACDONALD
            //
            Cow sirloin = new Cow();
            Chicken frederick = new Chicken();
            Pig bacon = new Pig();
            Cat philco = new Cat();
            Tractor internationalHarvester = new Tractor();

            philco.Sleep(true); // phil is down for a nap
            bacon.Sleep(true); // night-night Bacon

            FarmAnimal animal = new Cow(); // a cow is a farm animal, so we can fit a cow object into a farm animal shaped bucket
            Cow farmCowTwo = new Cow();
            FarmAnimal[] farmAnimals = new FarmAnimal[] { sirloin, frederick, bacon };

            Console.WriteLine(philco.Eat());
            Console.WriteLine(frederick.Eat());

            ShaggyCow shaggyCow = new ShaggyCow();
            Console.WriteLine(shaggyCow.Sound);

            ISellable[] sellables = new ISellable[]
           {
                // new Cow(), new Chicken(), new Pig(), new Tractor()
             //   new Cow(), new Chicken(), new Pig(), new Tractor()
            };

            foreach(ISingable singable in singables)
            {
                Console.WriteLine("Old MacDonald had a farm, ee ay ee ay oh!");
                Console.WriteLine("And on his farm he had a " + singable.Name + ", ee ay ee ay oh!");
                Console.WriteLine("With a " + singable.Sound + " " + singable.Sound + " here");
                Console.WriteLine("And a " + singable.Sound + " " + singable.Sound + " there");
                Console.WriteLine("Here a " + singable.Sound + " there a " + singable.Sound + " everywhere a " + singable.Sound + " " + singable.Sound);
                Console.WriteLine();
            }

           
            {
                new Cow(), new Pig(), new Egg();
            };

            foreach(ISellable sellable in sellables)
            {
                Console.WriteLine("Step right up and get your " + sellable.Name);
                Console.WriteLine("Only $" + sellable.Price);
            }
        }
    }
}