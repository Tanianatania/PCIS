// <copyright file="IShapeExtention.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Tania Gutiy/author>

using PCIS.Models.Interfaces;
using PCIS.Models;

namespace PCIS.Collections
{

    /// <summary>
    /// IShape extension
    /// </summary>
    public static class IShapeExtension
    {

        /// <summary>
        /// check whether the item belongs 3 quarter
        /// </summary>
        /// <param name="shape"></param>
        /// <returns>yes or no</returns>
        public static bool IsQuarter3(this IShape shape)
        {
            if (shape is Circle)
            {
                Circle c = shape as Circle;
                if (c.Center.X + c.Radius <= 0 && c.Center.Y + c.Radius <= 0)
                {
                    return true;
                }
                return false;
            }
            else if (shape is Rectangle)
            {
                Rectangle c = shape as Rectangle;
                if (c.LeftTopPoint.Y < 0 && c.RightDownPoint.X <= 0 && c.RightDownPoint.Y < 0)
                {
                    return true;
                }
                return false;
            }
            else if (shape is Triangle)
            {
                Triangle c = shape as Triangle;
                if (c.FirstPoint.X <= 0 && c.FirstPoint.Y <= 0 && c.SecondPoint.X <= 0 && c.SecondPoint.Y <= 0 && c.ThirdPoint.X <= 0 && c.ThirdPoint.Y <= 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
