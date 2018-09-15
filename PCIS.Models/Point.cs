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
        /// The x coordinate
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The y coordinate
        /// </summary>
        public double Y { get; set; }
    }
}
