﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class Exercise02_BoardingGate
    {
        /*
        Local Jetways is a regional airline operating at local airports.
        They use a basic passenger manifest to represent seat occupancy on their plane.
            Each passenger seat is represented as an element in a boolean array.
            A value of TRUE indicates that seat is currently available.
            A value of FALSE indicates the seat is not available.
        */

        /*
        A nearby airport has an incoming flight from Local Jetways. As the passengers disembark, the gate
        attendant's first responsibility is to generate a new seating chart with each seat initially available.

        Implement the logic to generate a seating chart using the required number of seats. Make sure to indicate
        that each seat is initially available (TRUE).

        Note: The number of seats is guaranteed not to be negative.

        Examples:
        GenerateSeatingChart(7) → [true, true, true, true, true, true, true]
        GenerateSeatingChart(5) → [true, true, true, true, true]
        GenerateSeatingChart(2) → [true, true]
        */
        public bool[] GenerateSeatingChart(int numberOfSeats)
        {
            return new bool[] { };
        }

        /*
        Once passengers begin boarding the plane, gate attendants need a way to determine how many available
        seats there are on the plane.

        Using the array provided, implement the logic to count the number of available seats in the seating chart.
        A seat is available if the value is TRUE.

        Examples:
        GetAvailableSeatCount([true, false, false, false]) → 1
        GetAvailableSeatCount([false, false, false, false, false, false]) → 0
        GetAvailableSeatCount([true, true, true, false]) → 3
        GetAvailableSeatCount([]) → 0
        */
        public int GetAvailableSeatCount(bool[] seatingChart)
        {
            return 0;
        }

        /*
        The crew determined that it would be nice to know how many rows on the plane are at full occupancy.
        Each row has three seats and a row is at full occupancy if all three seats have someone sitting in them.

        Using the boolean array, implement the logic to count the number of full rows on the plane.
        Note: A new row starts at every third element. For example, row one begins with index 0, row two begins with index 3, and so on.

        Examples:
        GetNumberOfFullRows([false, false, false, false, false, false]) → 2
        GetNumberOfFullRows([false, false, false, true, true, true]) → 1
        GetNumberOfFullRows([true, true, true, true, true, true]) → 0    
        */

        public int GetNumberOfFullRows(bool[] seatingChart)
        {
            return 0;
        }
    }
}
