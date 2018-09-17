// <copyright file="Circle.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Roman Mulyk</author>

namespace PCIS.Models
{
    using System;
    using Interfaces;

    /// <summary>
    /// The instance of circle
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Radius of the circle
        /// </summary>
        private double radius;

        /// <summary>
        /// The center of the circle
        /// </summary>
        private Point center;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class
        /// </summary>
        /// <param name="x">X coordinate of center</param>
        /// <param name="y">Y coordinate of center</param>
        /// <param name="radius">Radius of the circle</param>
        public Circle(double x, double y, double radius)
        {
            this.center = new Point(x, y);
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle
        /// </summary>
        public double Radius
        {
            get => this.radius;
            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentException("Radius can`t be less or equal than 0");
                }
            }
        }

        /// <summary>
        /// Gets the center of the circle
        /// </summary>
        public Point Center
        {
            get => center;
        }

        /// <summary>
        /// Calculates perimeter of the shape
        /// </summary>
        /// <returns>The perimeter of the shape</returns>
        public double GetPerimeter()
        {
            double perimeter = 2 * this.Radius * System.Math.PI;
            return perimeter;
        }

        /// <summary>
        /// Calculates square of the shape
        /// </summary>
        /// <returns>The square of the shape</returns>
        public double GetSquare()
        {
            double square = this.Radius * this.Radius * System.Math.PI;
            return square;
        }
    }
}
