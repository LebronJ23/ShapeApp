using ShapeLib.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeLib.Shapes
{
    /// <summary>
    /// Polygon class
    /// </summary>
    public class Polygon : Shape
    {
        /// <summary>
        /// Collection of points
        /// </summary>
        public IEnumerable<Point> Points { get; set; }
        public Polygon(params Point[] points)
        {
            Points = points.ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var point in Points)
            {
                sb.AppendLine($"X: {point.X}, Y: {point.Y}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sort Points collection
        /// </summary>
        public void SortAntiClockWise()
        {
            Points = Points.SortPointsAnticlockwise();
        }

        /// <summary>
        /// Sort Points collection
        /// </summary>
        public void SortClockWise()
        {
            Points = Points.SortPointsClockwise();
        }

        /// <summary>
        /// Area calculation
        /// </summary>
        /// <returns>Area</returns>
        public override double GetArea()
        {
            // Для подсчетов используется Формула площади Гаусса(алгоритм шнурования), которая позволяет
            // вычислить площадь простого многоугольника по его точкам
            // Точки сортируются против часовой стрелки, чтобы формула не требовала дополнительного вызова Math.Abs
            SortAntiClockWise();

            double result = default;
            double curValuePos = default;
            double curValueNeg = default;
            var pointsCount = Points.Count();
            var points = Points.ToList();

            for (int i = 0; i < pointsCount; i++)
            {
                Point curPoint = points[i];
                Point nextPoint = points[(i + 1) % pointsCount];
                curValuePos = curPoint.X * nextPoint.Y;
                curValueNeg = nextPoint.X * curPoint.Y;
                result += curValuePos - curValueNeg;
            }

            result = Math.Abs(result) * 0.5;
            return result;
        }
    }
}
