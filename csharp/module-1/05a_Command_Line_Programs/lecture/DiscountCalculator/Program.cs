using System;

namespace DiscountCalculator
{
    class Program
    {
        /// <summary>
        /// The main method is the start and end of our program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Discount Calculator");
            double discountAmount = 0; // set the discountAmount outside of the loop bubble
          
            Console.Write("Enter the discount amount (w/out percentage): ");
            // use do-while loop to make sure the user is not giving themselves huge discounts
            do {
                // Prompt the user for a discount amount
                // The answer needs to be saved as a double
                string input = Console.ReadLine(); // asking user for input

                 discountAmount = double.Parse(input);
                // the user should not be allowed to put in a discount greater than 100%
                if (discountAmount > 100) // if the discountAmount is greater than 100, we need the user to try again
                {
                    Console.WriteLine("Please only enter amounts less than 100.");
                }
               
               
            
            }
            while (discountAmount > 100); // what is in the do block will run until this condition is false
                 discountAmount = discountAmount / 100.0;

             Console.WriteLine("You entered:" + discountAmount);

          


            // Prompt the user for a series of prices
            Console.Write("Please provide a series of prices (space separated): "); // "2.00 5.00 10.00"
            string prices = Console.ReadLine();

            Console.WriteLine("You entered: " + prices);

            // split the string of prices into seperate values 
            string[] priceArray = prices.Split(' '); // ["2.00", "5.00", "10.00"]
            // placeholders for adding up the totals
            decimal totalOriginalPrice = 0;
            decimal totalSalePrice = 0;

            for (int i = 0; i < priceArray.Length; i++)
            {
                string value = priceArray[i];
                decimal originalPrice = decimal.Parse(value); // turn the value into a decimal
                decimal discountAmountOfItem = originalPrice * (decimal)discountAmount; // figure out the amount of discount for the item $
                decimal salePrice = originalPrice - discountAmountOfItem; // sale price is the original price minus the discount

                Console.WriteLine($"Original price: {originalPrice:C2}, amount of discount: {discountAmountOfItem:C2}, sale price {salePrice:C2}."); // C2 is a currency format its not changing varaible at all its just changing how its displayed
              
                // add to the toal amounts
                totalOriginalPrice += originalPrice; // add the item's origial price to the total original price
                totalSalePrice += salePrice; // add the items sale price to the total sale price
            }
            Console.WriteLine($"Total original price: {totalOriginalPrice:C2}, total sale price: {totalSalePrice:C2}.");
        }
    }
      
