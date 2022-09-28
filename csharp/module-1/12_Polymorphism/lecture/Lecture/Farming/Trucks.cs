using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
   public class Trucks : Idriveable
    {
        public string Name { get; }
        public string Sound { get; }

        public Trucks()
        {
            Name = "Truck";
            Sound = "brrrr";
        }

        public void Drive()
        {
            Console.WriteLine("Crank up the radio and play Tim Mcgraw's 'Truck Yeah!'");
        }
    }

}
