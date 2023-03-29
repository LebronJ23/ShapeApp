using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeLib.Shapes
{
    // Наследуется от полигона, так как это частный случай
    public class Triangle : Polygon
    {
        private const int PointsCount = 3;

        public double[] Sides { get; set; }

        public Triangle(Point point1, Point point2, Point point3) : base(point1, point2, point3)
        {
            SortClockWise();
            Sides = new double[PointsCount];
            SetSides();
        }

        public Triangle(double a, double b, double c)
        {
            // Проверка треугольника на существование
            if (a < b + c && b < a + c && c < a + b)
            {
                Sides = new double[] { a, b, c };
            }
            else
            {
                Sides = new double[] { 1, 1, 1 };
            }
            Sides = Sides.OrderBy(x => x).ToArray();
        }

        // При задании треугольника через точки, а не через стороны, можно вычислять площадь
        // с помощью базового метода в классе Polygon
        public override double GetArea()
        {
            if (Points.Any())
            {
                return base.GetArea();
            }
            else
            {
                return GetAreaWithSides();
            }
        }

        // проверка, является ли треугольник прямоугольным
        public bool IsRightAngled()
        {
            var maxSidePowered = Math.Pow(Sides.LastOrDefault(), 2);
            var minSidesPowered = Sides.Take(2).Select(x => x * x).Sum();

            return maxSidePowered == minSidesPowered;
        }

        // Вычисление площади треугольника по его сторонам
        private double GetAreaWithSides()
        {
            double result = 0;
            double p = Sides.Sum() * 0.5;

            result = Math.Sqrt(p * Sides.Select(x => p - x).Aggregate((a, b) => a * b));

            return result;
        }

        // Вычисление сторон треугольника при инстансе треугольника через точки
        private void SetSides()
        {
            var trinaglePoints = Points.Take(PointsCount).ToList();
            for (int i = 0; i < PointsCount; i++)
            {
                var curPoint = trinaglePoints[i];
                var nextPoint = trinaglePoints[(i + 1) % PointsCount];
                Sides[i] = Math.Sqrt(Math.Pow(nextPoint.X - curPoint.X, 2) + Math.Pow(nextPoint.Y - curPoint.Y, 2));
            }
            Sides = Sides.OrderBy(x => x).ToArray();
        }
    }
}
