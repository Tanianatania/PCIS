// <copyright file="Task.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Tania Gutiy/author>


using PCIS.Models;
using PCIS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIS.Collections.Data
{

    /// <summary>
    /// Class for parse to IShape
    /// </summary>
    internal class Parser
    { 

        /// <summary>
        /// Parse string to IShape
        /// </summary>
        /// <param name="str"></param>
        /// <returns> IShape element </returns>
        public IShape Parse(string str)
        {
            string[] fields = str.Split(' ');
            string name = fields[0];
            switch (name)
            {
                case "circle":
                    double x = double.Parse(fields[1]);
                    double y = double.Parse(fields[2]);
                    double r = double.Parse(fields[3]);
                    return new Circle(x, y, r);


                case "square":
                    double left_x = double.Parse(fields[1]);
                    double left_y = double.Parse(fields[2]);
                    double right_x = double.Parse(fields[3]);
                    double right_y = double.Parse(fields[4]);
                    return new Square(left_x, left_y, right_x, right_y);

                case "triangle":
                    double first_x = double.Parse(fields[1]);
                    double first_y = double.Parse(fields[2]);
                    Point first_point = new Point(first_x, first_y);
                    double second_x = double.Parse(fields[3]);
                    double second_y = double.Parse(fields[4]);
                    Point second_point = new Point(second_x, second_y);
                    double third_x = double.Parse(fields[5]);
                    double third_y = double.Parse(fields[6]);
                    Point third_point = new Point(third_x, third_y);
                    return new Triangle(first_point, second_point, third_point);

                default:
                    return null;
            }
        }
    }
    

    /// <summary>
    /// Class to complete the tasks
    /// </summary>
    public static class Task
    {

        /// <summary>
        /// Count of Ishape elements
        /// </summary>
        static int count=0;


        /// <summary>
        /// List of elements in 3 quarter
        /// </summary>
        static List<IShape> result = new List<IShape>();


        /// <summary>
        /// Sort List of elements in quarter 
        /// </summary>
        static List<IShape> totall_result = new List<IShape>();


        /// <summary>
        /// Initial list of IShape elements
        /// </summary>
        static List<IShape> list = new List<IShape>();


        /// <summary>
        /// Sort IShape elements for growth
        /// </summary>
        public static void sort()
        {
            IShape temp;

            for (int i=0; i<count-1; i++)
            {
                for (int j=i+1; j<count; j++)
                {
                    if (list[i].GetSquare() > list[j].GetSquare())
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }


        /// <summary>
        /// Reading  from Data.txt, sort list, writing result in File1.txt
        /// </summary>
        public static void RunTask1()
        {

            using (var fm = new BasicFileManager(@"C:\Users\Hp\Desktop\PCIS\PCIS.Collections\Data\Data.txt", BasicFileManager.IOType.Reader))
            {
                Parser p = new Parser();
                count = int.Parse(fm.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    string data = fm.ReadLine();
                    Console.WriteLine(data);
                    list.Add(p.Parse(data));
                }
            }

            sort();

            using (var fw = new BasicFileManager(@"C:\Users\Hp\Desktop\PCIS\PCIS.Collections\Data\File1.txt", BasicFileManager.IOType.Writer))
            {
               for (int i=0; i<count; i++)
                {
                    if (list[i] is Circle)
                    {
                        Circle c = list[i] as Circle;
                        fw.WriteLine($"Circle: ({c.Center.X} {c.Center.Y}), radius: {c.Radius}");
                    }
                    else if (list[i] is Square)
                    {
                        Square c = list[i] as Square;
                        fw.WriteLine($"Square: ({c.LeftTopPoint.X} {c.LeftTopPoint.Y}), ({c.RightDownPoint.X} {c.RightDownPoint.Y})");
                    }
                    else if (list[i] is Triangle)
                    {
                        Triangle c = list[i] as Triangle;
                        fw.WriteLine($"Trianle: ({c.FirstPoint.X} {c.FirstPoint.Y}), ({c.SecondPoint.X} {c.SecondPoint.Y}), ({c.ThirdPoint.X} {c.ThirdPoint.Y})");
                    }
                }
                                 
            }

        }


        /// <summary>
        /// Select elements that is in 3 quarter and sot them by degeneration
        /// </summary>
        public static void RunTask2()
        {
            var result =
                from res in list
                where res.IsQuarter3() == true
                select res;


            List<IShape> totall_result =
                (from u in result
                orderby u.GetPerimeter() descending
                select u).ToList();


            using (var fw = new BasicFileManager(@"C:\Users\Hp\Desktop\PCIS\PCIS.Collections\Data\File2.txt", BasicFileManager.IOType.Writer))
            {
                for (int i = 0; i < totall_result.Count; i++)
                {
                    if (totall_result[i] is Circle)
                    {
                        Circle c = totall_result[i] as Circle;
                        fw.WriteLine($"Circle: ({c.Center.X} {c.Center.Y}), radius: {c.Radius}");
                        fw.WriteLine($"Perimeter: {c.GetPerimeter()}");
                    }
                    else if (totall_result[i] is Square)
                    {
                        Square c = totall_result[i] as Square;
                        fw.WriteLine($"Square: ({c.LeftTopPoint.X} {c.LeftTopPoint.Y}), ({c.RightDownPoint.X} {c.RightDownPoint.Y})");
                        fw.WriteLine($"Perimeter: {c.GetPerimeter()}");
                    }
                    else if (totall_result[i] is Triangle)
                    {
                        Triangle c = totall_result[i] as Triangle;
                        fw.WriteLine($"Trianle: ({c.FirstPoint.X} {c.FirstPoint.Y}), ({c.SecondPoint.X} {c.SecondPoint.Y}), ({c.ThirdPoint.X} {c.ThirdPoint.Y})");
                        fw.WriteLine($"Perimeter: {c.GetPerimeter()}");
                    }
                }

            }
        }
    }
}

