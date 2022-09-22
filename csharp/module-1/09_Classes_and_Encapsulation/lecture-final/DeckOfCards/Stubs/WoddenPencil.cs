using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DeckOfCards.Stubs
{
    /// <summary>
    /// NAMESPACE DEFINITION
    ///
    /// Uppercase and aligned with a module or general purpose it provides
    /// Separated by Periods like TechElevator.Classes
    /// </summary>
    /// 




    /// <summary>
	/// CLASS DECLARATION
	/// Naming convention: singular and PascalCase
	/// </summary>
    public class WoddenPencil
    {
		/// <summary>
		/// CLASS VARIABLES AND PROPERTIES
		///
		/// Static modifier, or const (implicit static).
		/// May be public or private.
		/// Often const, but not required to be.
		///
		/// All wooden pencils have a "fixed" set of default values for length,
		///   shape, hardness, and color. External code should be able to ask
		///   WoodenPencil for these defaults.
		///
		/// All wooden pencils have a minimum length below which they are
		///   considered a "stub" and should be discarded.
		///
		/// All wooden pencils have a minimum sharpness below which they are
		///   too dull and need to be sharpened.
		///
		/// Note: These values belong to "ALL" wooden pencils, and thus
		///   belong to the class of WoodenPencil, hence the static modifier,
		///   explicitly written or implied by 'const'..
		/// </summary>

		//public - other classes and methods have access.
		public const double DefaultLength = 8.0;  
		public const int DefaultShape = 2;
		public const string DefaultHardness = "HB";
		public static readonly Color DefaultColor = Color.Yellow;
		public const double DefaultStubLength = 2.0;
		public const double DefaultMaxDullness = 0.3;

		private static double stubLength = DefaultStubLength; //When a pencis is considered a stub, in inches. 

		public double Length { get; set; }
	}
}
