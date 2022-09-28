using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
  public interface Isellable
    {
        string Name { get; }
        decimal Price { get; }
    }
}
