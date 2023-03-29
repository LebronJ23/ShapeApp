using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeLib.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; private set; }
        
        public Circle(double rad)
        {
            Radius = Math.Abs(rad);
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
