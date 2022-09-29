using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    class SquareWall : RectangleWall
    {
        public string Name { get; }
        public string Color { get; }
        public int SideLength { get; }

        public SquareWall(string name, string color, int sideLength) : base(name, color, sideLength, sideLength)
        {
            Name = name;
            Color = color;
            SideLength = sideLength;
        }
        public override string ToString()
        {
            return ($"{Name} ({SideLength}x{SideLength}) square");
        }
    }
}

           
       
      

