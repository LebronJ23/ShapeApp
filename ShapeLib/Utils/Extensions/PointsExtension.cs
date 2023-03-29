using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShapeLib.Utils.Extensions
{
    public static class PointsExtension
    {
        /// <summary>
        /// Sort points with anticlockwise order around centroid
        /// </summary>
        /// <param name="points">points that define the polygon</param>
        /// <returns>sorted collection of points</returns>
        public static IEnumerable<Point> SortPointsAnticlockwise(this IEnumerable<Point> points)
        {
            var centroid = GetCentroid(points.ToList());
            return points.OrderByDescending(x => Math.Atan2(x.X - centroid.X, x.Y - centroid.Y)).ToList();
        }

        /// <summary>
        /// Sort points with clockwise order around centroid
        /// </summary>
        /// <param name="points">points that define the polygon</param>
        /// <returns>sorted collection of points</returns>
        public static IEnumerable<Point> SortPointsClockwise(this IEnumerable<Point> points)
        {
            var centroid = GetCentroid(points.ToList());
            return points.OrderBy(x => Math.Atan2(x.X - centroid.X, x.Y - centroid.Y)).ToList();
        }

        /// <summary>
        /// Method to compute the centroid of a polygon. This does NOT work for a complex polygon.
        /// </summary>
        /// <param name="poly">points that define the polygon</param>
        /// <returns>centroid point, or Point.Empty if something wrong</returns>
        public static Point GetCentroid(List<Point> poly)
        {
            double accumulatedArea = 0.0f;
            double centerX = 0.0f;
            double centerY = 0.0f;

            for (int i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
            {
                double temp = poly[i].X * poly[j].Y - poly[j].X * poly[i].Y;
                accumulatedArea += temp;
                centerX += (poly[i].X + poly[j].X) * temp;
                centerY += (poly[i].Y + poly[j].Y) * temp;
            }

            if (Math.Abs(accumulatedArea) < 1E-7f)
                return new Point(0, 0);  // Avoid division by zero

            accumulatedArea *= 3f;
            return new Point(centerX / accumulatedArea, centerY / accumulatedArea);
        }
    }
}
