using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationLecture.Classes
{
  public class Person
    {
        // name
    public string Name { get; set; }
        // age
        // Based on birthyear compared to the current date
         public int Age
        { // Derived property. - only get = readonly. two things you put together (ex first name & last name = full name)
            get
            {
                int currentYear = DateTime.Now.Year;
                return currentYear - birthYear;
            }
        }
        private int birthYear { get; set; }
        // height
        public Person (int birthYear)
            {
            this.birthYear = birthYear;
        }
        public double Height { get; set; }
       
        // SSN
        private string ssn { get; set; }
        // Constructor
        // Once a constructor is defined, the default no-argument constructor is not available.
        // public Person(int yearOFBirth)
    }
}
