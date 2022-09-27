using System;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal, ISellable
    {
        public decimal Price { get; }
        public Chicken() : base("Chicken", "cluck")
        {
            Price = 10;
        }

        public void LayEgg()
        {
            Console.WriteLine("Chicken laid an egg!");
        }
    }
}
