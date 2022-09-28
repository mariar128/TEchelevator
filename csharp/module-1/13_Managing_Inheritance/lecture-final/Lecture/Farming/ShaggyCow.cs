using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class ShaggyCow : Cow
    {
        public ShaggyCow() : base()
        {
        }

        public override string Sound
        {
            get
            {
                return "shaggy moo"; 
            }
        }
    }
}
