using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    class TriangleWall : Wall
    { 
            public int Length { get; }
            public int Height { get; }
            public string Name { get; }
            public string Color { get; }
        
        public int @Base { get; }
        

            public TriangleWall(string name, string color, int @base, int height) : base(name, color)
            {
                Base = @base;
                Height = height;
                Name = name;
                Color = color;
            }
            public override int GetArea()
            {
            return (Base * Height) / 2;
            }

            public override string ToString()
            {
                return ($"{Name} ({Base}x{Height}) triangle");
            }
        }
    }






