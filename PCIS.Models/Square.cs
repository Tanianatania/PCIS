// <copyright file="Square.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Roman Mulyk</author>

namespace PCIS.Models
{
    using Interfaces;

    /// <summary>
    /// The instance of circle
    /// </summary>
    public class Square : IShape
    {
        /// <summary>
        /// Left top point
        /// </summary>
        private Point leftTopPoint;

        /// <summary>
        /// Right down point
        /// </summary>
        private Point rightDownPoint;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class
        /// </summary>
        /// <param name="ltx">Left top X coordinate</param>
        /// <param name="lty">Left top Y coordinate</param>
        /// <param name="rdx">Right down X coordinate</param>
        /// <param name="rdy">Right down Y coordinate</param>
        public Square(double ltx, double lty, double rdx, double rdy)
        {
            this.leftTopPoint = new Point(ltx, lty);
            this.rightDownPoint = new Point(rdx, rdy);
        }

        /// <summary>
        /// Gets left top point
        /// </summary>
        public Point LeftTopPoint { get => this.leftTopPoint; }

        /// <summary>
        /// Gets right down point
        /// </summary>
        public Point RightDownPoint { get => this.rightDownPoint; }

        /// <summary>
        /// Calculates perimeter of the shape
        /// </summary>
        /// <returns>The perimeter of the shape</returns>
        public double GetPerimeter()
        {
            double width = System.Math.Abs(this.RightDownPoint.X - this.LeftTopPoint.X);
            double height = System.Math.Abs(this.LeftTopPoint.Y - this.RightDownPoint.Y);
            double perimeter = 2 * (width + height);
            return perimeter;
        }

        /// <summary>
        /// Calculates square of the shape
        /// </summary>
        /// <returns>The square of the shape</returns>
        public double GetSquare()
        {
            double width = System.Math.Abs(this.RightDownPoint.X - this.LeftTopPoint.X);
            double height = System.Math.Abs(this.LeftTopPoint.Y - this.RightDownPoint.Y);
            double square = width * height;
            return square;
        }
    }
}