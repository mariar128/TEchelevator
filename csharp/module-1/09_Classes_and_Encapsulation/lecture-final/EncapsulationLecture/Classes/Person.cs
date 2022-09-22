using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationLecture.Classes
{
    public class Person
    {
        //public  PascalCase
        //private camelCase 

        //name
        public string Name { get; set; }
        //age
        //Based on birthyear compared to the current date. 
        public int Age { 
            //Derived property. - only get = readonly. 
            get
            {
                int currentYear = DateTime.Now.Year;
                return currentYear - birthYear;

            }
        }
        private int birthYear { get; set; }
        //height
        public double Height { get; set; }
             
        //SSN
        private string ssn { get; set; }
        
        
        //Constructor 
        //Once a constructor is defined, the default no-arg (argument) constructor is not avalible.
        public Person(int yearOfBirth)
        {

        }

        public Person()
        {

        }
    }
}
