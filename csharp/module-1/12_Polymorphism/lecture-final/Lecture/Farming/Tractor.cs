using System;

namespace Lecture.Farming
{
    public class Tractor : ISingable, IDriveable
    {
        public string Name { get; }
        public string Sound { get; }

        public Tractor()
        {
            Name = "Tractor";
            Sound = "vroom";
        }

        public void Drive()
        {
            Console.WriteLine("Fire up the International Harvester and take off to the field to the tune of Kenny Chesney's 'She Thinks My Tractor's Sexy'..."); 
        }
    }
}
