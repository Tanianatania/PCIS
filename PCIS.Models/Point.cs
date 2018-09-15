// <copyright file="Point.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Roman Mulyk</author>

namespace PCIS.Models
{
    /// <summary>
    /// The instance of point
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the x coordinate
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets distance between two points
        /// </summary>
        /// <param name="one">First point</param>
        /// <param name="two">Second point</param>
        /// <returns>The distance</returns>
        public static double Distance(Point one, Point two)
        {
            double distance = System.Math.Sqrt(System.Math.Pow(one.X - two.X, 2) + System.Math.Pow(one.Y - two.Y, 2));
            return distance;
        }
    }
}
