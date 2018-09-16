using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCIS
{
    interface iShape
    {
        double getSqaure();
        double getPerimetr();
    }
    class Circle:iShape
    {
        public int x { get; set; }
        public int y { get; set; }
        public int radius { get; set; }

        public double getSqaure()
        {
            double res = Math.PI * radius * radius;
            return res;
        }
        
        public double getPerimetr()
        {
            double res = 2 * Math.PI * radius;
            return res;
        }
    }
    class Square:iShape
    {
        public double left_upper_angle { get; set; }
        public double right_bottom_angle { get; set; }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
