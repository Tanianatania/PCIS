// <copyright file="Triangle.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Roman Mulyk</author>

namespace PCIS.Models
{
    using System;
    using Interfaces;

    /// <summary>
    /// The instance of triangle
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// First point
        /// </summary>
        private Point first;

        /// <summary>
        /// Second point
        /// </summary>
        private Point second;

        /// <summary>
        /// Third point
        /// </summary>
        private Point third;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class
        /// </summary>
        /// <param name="first">The first point</param>
        /// <param name="second">The second point</param>
        /// <param name="third">The third point</param>
        public Triangle(Point first, Point second, Point third)
        {
            if (Point.OnOneLine(first, second, third))
            {
                throw new ArgumentException("This point located in one line");
            }

            this.first = first;
            this.second = second;
            this.third = third;
        }

        /// <summary>
        /// The first point
        /// </summary>
        public Point FirstPoint => this.first;

        /// <summary>
        /// The second point
        /// </summary>
        public Point SecondPoint => this.second;

        /// <summary>
        /// The third point
        /// </summary>
        public Point ThirdPoint => this.third;

        /// <summary>
        /// Calculates perimeter of the shape
        /// </summary>
        /// <returns>The perimeter of the shape</returns>
        public double GetPerimeter()
        {
            double dist1 = Point.Distance(this.first, this.second);
            double dist2 = Point.Distance(this.second, this.third);
            double dist3 = Point.Distance(this.first, this.third);

            double perimeter = dist1 + dist2 + dist3;
            return perimeter;
        }

        /// <summary>
        /// Calculates square of the shape
        /// </summary>
        /// <returns>The square of the shape</returns>
        public double GetSquare()
        {
            double perimeter = this.GetPerimeter();
            double halfPerimeter = perimeter / 2;

            double dist1 = Point.Distance(this.first, this.second);
            double dist2 = Point.Distance(this.second, this.third);
            double dist3 = Point.Distance(this.first, this.third);
            
            double square = System.Math.Sqrt(halfPerimeter * (halfPerimeter - dist1) * (halfPerimeter - dist2) * (halfPerimeter - dist3));
            return square;
        }

        /// <summary>
        /// Checks or figure belongs to 3 quarters
        /// </summary>
        /// <returns>Is it true</returns>
        public bool IsQuarter3()
        {
            if (this.first.X<=0 && this.first.Y<=0 && this.second.X<= 0 && this.second.y <= 0 && this.third.X<=0 && this.third.Y<=0)
            {
                return true;
            }
            return false;
        }
    }
}
