using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace DeckOfCards.Stubs
{
    // NAMESPACE DEF
    // Uppercase and aligned with a module or general purpose it provides. Seperated by periods like TechElevator.Classes

    // CLASS DECLARATION
    // Naming convention: singular and PascalCase
    public class WoodenPencil
    {
        // public - other classes and methods have access. 
        public const double DefaultLength = 8.0;
        public const int DefaultShape = 2;
        public const string DefaultHardness = "HB";
    //    public const Color DefaultColor = Color.Yellow;
        public const double DefaultStubLength = 2.0;
        public const double DefaultMaxDullness = 0.3;


        private static double stubLength = DefaultStubLength; // When a pencil is considered a stub, in inches.

        public double Length { get; set; }

    }
}
