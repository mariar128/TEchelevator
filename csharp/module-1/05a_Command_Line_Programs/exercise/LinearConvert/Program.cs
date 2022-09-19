using System;

namespace LinearConvert
{
    class Program
    {
        // m = f* 0.3048
        //    f = m* 3.2808399

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the length!");
            string userInput = Console.ReadLine();
            Console.WriteLine("Is it in meters or feet?");
            string measurmentInput = Console.ReadLine();
            double userInputAsDecimal = double.Parse(userInput);

            double conversionToFeet;
            double conversionToMeters;
            if (measurmentInput == "meters")
            {
                conversionToFeet = userInputAsDecimal * 3.2808399;
                Console.WriteLine($"Firstmeasure: {userInputAsDecimal}, convertmeasurement: {conversionToFeet}");

            }
            
                    if (measurmentInput == "feet")
                    {
                        conversionToMeters = userInputAsDecimal * 0.3048;
                        Console.WriteLine($"Secondmeasure: {userInputAsDecimal}, convertmeasurement: {conversionToMeters}");
                    }
                }
            }
        }
    








            