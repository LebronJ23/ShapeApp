using ShapeLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLib.Shapes
{
    public abstract class Shape : IAreaCalculatable
    {
        public abstract double GetArea();
    }
}
