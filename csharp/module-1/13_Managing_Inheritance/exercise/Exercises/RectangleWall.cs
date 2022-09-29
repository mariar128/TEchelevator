using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    class RectangleWall : Wall
    {
    
       
        public int Length { get;  }
        public int Height { get;  }
        public string Name { get; }
        public string Color { get; }

        public RectangleWall(string name, string color, int length, int height) : base( name, color)
        {
            Length = length;
            Height = height;
            Name = name;
            Color = color;
        }
        public override int GetArea()
        {
            return Length * Height;
        }
        
        public override string ToString()
        {
            return ($"{Name} ({Length}x{Height}) rectangle");
        }
    }
}


