using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Exercises.LogicalBranching
{
    /*
     * Scamper Shipping Company specializes in small, local deliveries.
     * The problems below ask you to implement the logic to calculate a shipping amount for a package.
     */
    public class ShippingTotal
    {
        // You can use these constants in your solutions.
        private const int MaxWeightPounds = 40;
        private const double UpTo40PoundRate = 0.50;
        private const double Over40PoundRate = 0.75;

        /*
         * Scamper Shipping Company charges $0.50 per pound up to 40 pounds. After that, it's $0.75 for each additional pound.
         * Implement the logic needed to calculate the shipping rate when provided a weight in pounds.
         * calculateShippingTotal(10) ➔ 5.0
         * calculateShippingTotal(25) ➔ 12.5
         * calculateShippingTotal(45) ➔ 23.75
         */
        public double CalculateShippingTotal(int weightInPounds)
        {
            double total;
            if (weightInPounds > MaxWeightPounds)
            {
                total = (MaxWeightPounds * UpTo40PoundRate) + ((weightInPounds - MaxWeightPounds) * Over40PoundRate);
            } 
            else
            {
                total = weightInPounds * UpTo40PoundRate;
            }
            return total;
        }

        /*
         * Scamper Shipping Company now allows customers to provide a discount code to give them 10% off of their order.
         * Implement the logic to calculate the correct shipping rate when provided a weight in pounds and a boolean value
         * for hasDiscount.
         *
         * calculateShippingTotal(10, false) ➔ 5.0
         * calculateShippingTotal(10, true) ➔ 4.5
         * calculateShippingTotal(25, false) ➔ 12.5
         * calculateShippingTotal(25, true) ➔ 11.25
         * calculateShippingTotal(45, false) ➔ 23.75
         * calculateShippingTotal(45, true) ➔ 21.375
         */
        public double CalculateShippingTotal(int weightInPounds, bool hasDiscount)
        {
            double total;
            if (weightInPounds > MaxWeightPounds)
            {
                total = (MaxWeightPounds * UpTo40PoundRate) + ((weightInPounds - MaxWeightPounds) * Over40PoundRate);
            }
            else
            {
                total = weightInPounds * UpTo40PoundRate;
            }

            if (hasDiscount)
            {
                total *= 0.9;
            }

            return total;
        }

        /*
         * As the business grows for Scamper Shipping Company, they now offer discounts in various amounts.
         * Implement the logic to calculate the shipping rate when provided a weight in pounds
         * and a discount percentage(for example, 0.1 = 10% off).
         * 
         * calculateShippingTotal(10, 0) ➔ 5.0
         * calculateShippingTotal(10, 0.1) ➔ 4.5
         * calculateShippingTotal(25, 0.15) ➔ 10.625
         * calculateShippingTotal(45, 0.2) ➔ 19.0
         */
        public double CalculateShippingTotal(int weightInPounds, double discountPercentage)
        {
            double total;
            if (weightInPounds > MaxWeightPounds)
            {
                total = (MaxWeightPounds * UpTo40PoundRate) + ((weightInPounds - MaxWeightPounds) * Over40PoundRate);
            }
            else
            {
                total = weightInPounds * UpTo40PoundRate;
            }

            // Apply discount as needed
            total -= total * discountPercentage;

            return total;
        }

    }
}
