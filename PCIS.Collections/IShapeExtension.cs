using PCIS.Models.Interfaces;
using PCIS.Models;

namespace PCIS.Collections
{
    public static class IShapeExtension
    {
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
            else if (shape is Square)
            {
                Square c = shape as Square;
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
