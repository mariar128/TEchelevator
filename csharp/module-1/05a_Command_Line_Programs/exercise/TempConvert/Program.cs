using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the temp!");
            string userInput = Console.ReadLine();
            Console.WriteLine("Is it in fahrenheit or celsius?");
            string measurmentInput = Console.ReadLine();
            double userInputAsDecimal = double.Parse(userInput);

            double conversionToFahrenheit;
            double conversionToCelsius;
            if (measurmentInput == "fahrenheit")
            {
                conversionToCelsius = (userInputAsDecimal -32)/ 1.8;
                Console.WriteLine($"First measure: {userInputAsDecimal}, convert measurement: {conversionToCelsius}");

            }

            if (measurmentInput == "celsius")
            { //
                conversionToFahrenheit = userInputAsDecimal * 1.8 + 32;
                Console.WriteLine($"Second measure: {userInputAsDecimal}, convert measurement: {conversionToFahrenheit}");
            }
        }
    }
}
        
