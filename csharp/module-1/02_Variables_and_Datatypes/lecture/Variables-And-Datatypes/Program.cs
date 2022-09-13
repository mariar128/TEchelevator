using System;

namespace Variables_And_Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		    */

            int numberOfExercises = 26;
            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half = 0.5;
            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name = "TechElevator";
            Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            byte seasonsOfFirefly = 1;
            Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";
            Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */
            double pi = 3.1416;
            Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            string myName = "Maria";
            Console.WriteLine(myName);
            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int mouseButtons = 4;
            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            int percentageOfBatteryLeft = 50;
            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int difference = 121 - 27;
            Console.WriteLine(difference);
            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            //double sum = 12.3 + 32.1;
            decimal sum = (decimal)12.3 + (decimal)32.1;
            Console.WriteLine(sum);
            /*
            12. Create a string that holds your full name.
            */
            string myFullName = "Maria Rivera";
            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string newString = "Hello, " + myFullName;
            Console.WriteLine(newString);
            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            myFullName = "Maria Rivera Esquire";
            Console.WriteLine(myFullName);

            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            myFullName += " PhD";
            Console.WriteLine(myFullName);
            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            string saw = "Saw";
            saw += 2; //implicit conversion the complier thinks we want concatenation, so it turns 2 into a string for us
            Console.WriteLine(saw);
            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */
            saw += 0;
            Console.WriteLine(saw);
            /*
            18. What is 4.4 divided by 2.2?
            */
            double result = 4.4 / 2.2;
            Console.WriteLine(result);
            /*
            19. What is 5.4 divided by 2?
            */
            Console.WriteLine(5.4 / 2);
            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            double fiveByTwo = 5 / 2;
            Console.WriteLine(fiveByTwo);
            /*
            21. What is 5.0 divided by 2?
            */
            fiveByTwo = (float)5 / 2;
            Console.WriteLine(fiveByTwo);
            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */
            decimal bankBalance = 1234.56M;
            Console.WriteLine(bankBalance);
            Console.WriteLine("Double balance:" + bankBalance * 2);
            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            int remainder = 5 % 2;
            Console.WriteLine("5 % 2 = " + remainder);
            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together.
                What is the result?
            */
            int three = 3;
            int billion = 1_000_000_000; // underscores as placeholders, brilliant
                                         // Console.WriteLine(three * billion); this results in an overflow of integer space
            long threeBillion = three * (long)billion; //a long should hold three billion 
            Console.WriteLine(threeBillion);
            /*
            25. Create a variable that holds a boolean called isDoneWithExercises and
            set it to false.
            */
            bool isDoneWithExercises = false;
            /*
            26. Now set isDoneWithExercise to true.
            */
            isDoneWithExercises = true;
            Console.WriteLine("Are we done with exercises? " + isDoneWithExercises);
            Console.ReadLine();
        }
    }
}
