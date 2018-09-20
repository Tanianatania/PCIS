// <copyright file="IShape.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Roman Mulyk</author>

namespace PCIS.Models.Interfaces
{
    /// <summary>
    /// Interface which allows to figure out square and perimeter of shapes
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Calculates perimeter of the shape
        /// </summary>
        /// <returns>The perimeter of the shape</returns>
        double GetPerimeter();

        /// <summary>
        /// Calculates square of the shape
        /// </summary>
        /// <returns>The square of the shape</returns>
        double GetSquare();
    }
}