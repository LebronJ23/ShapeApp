﻿using ShapeLib;
using ShapeLib.Interfaces;
using ShapeLib.Shapes;
using ShapeLib.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tri = new Triangle(17, 13, 15);
            var tri1 = new Triangle(
                    new Point(1, 1),
                    new Point(1, 4),
                    new Point(5, 1)
                );
            var circle = new Circle(15);

            // заполнение списка форм
            var shapes = new List<IAreaCalculatable>
            {   circle,
                tri,
                tri1,
                new Polygon(
                    new Point(1, 1),
                    new Point(1, 4),
                    new Point(5, 1)
                    ),
                new Triangle(3,4,5),
                new Polygon(
                    new Point(3, 4),
                    new Point(5, 11),
                    new Point(12, 8),
                    new Point(9, 5),
                    new Point(5, 6)
                    )
            };
            Console.WriteLine($"Shapes areas: ");
            shapes.ForEach(x => Console.WriteLine(x.GetArea()));

        }
    }
}
