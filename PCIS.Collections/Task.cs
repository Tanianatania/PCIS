// <copyright file="Task.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Tania Gutiy/author>

namespace PCIS.Collections.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PCIS.Models;
    using PCIS.Models.Interfaces;

    /// <summary>
    /// Class to complete the tasks
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Count of Ishape elements
        /// </summary>
        int count = 0;

        /// <summary>
        /// List of elements in 3 quarter
        /// </summary>
        List<IShape> result = new List<IShape>();

        /// <summary>
        /// Sort List of elements in quarter 
        /// </summary>
        List<IShape> totallResult = new List<IShape>();

        /// <summary>
        /// Initial list of IShape elements
        /// </summary>
        List<IShape> list = new List<IShape>();

        /// <summary>
        /// Reading  from Data.txt, sort list, writing result in File1.txt
        /// </summary>
        public void RunTask1(string path1, string path2)
        {
            using (var fm = new BasicFileManager(path1, BasicFileManager.IOType.Reader))
            {
                Parser p = new Parser();
                this.count = int.Parse(fm.ReadLine());
                for (int i = 0; i < this.count; i++)
                {
                    string data = fm.ReadLine();
                    Console.WriteLine(data);
                    this.list.Add(p.Parse(data));
                }
            }

           this.list = this.list.OrderBy(o => o.GetArea()).ToList();

            using (var fw = new BasicFileManager(path2, BasicFileManager.IOType.Writer))
            {
                for (int i = 0; i < this.count; i++)
                {
                    if (this.list[i] is Circle)
                    {
                        Circle c = this.list[i] as Circle;
                        fw.WriteLine($"Circle: ({c.Center.X} {c.Center.Y}), radius: {c.Radius}");
                        fw.WriteLine($"Square: {c.GetArea()}");
                    }
                    else if (this.list[i] is Rectangle)
                    {
                        Rectangle c = this.list[i] as Rectangle;
                        fw.WriteLine($"Square: ({c.LeftTopPoint.X} {c.LeftTopPoint.Y}), ({c.RightDownPoint.X} {c.RightDownPoint.Y})");
                        fw.WriteLine($"Square: {c.GetArea()}");
                    }
                    else if (this.list[i] is Triangle)
                    {
                        Triangle c = this.list[i] as Triangle;
                        fw.WriteLine($"Trianle: ({c.FirstPoint.X} {c.FirstPoint.Y}), ({c.SecondPoint.X} {c.SecondPoint.Y}), ({c.ThirdPoint.X} {c.ThirdPoint.Y})");
                        fw.WriteLine($"Square: {c.GetArea()}");
                    }
                }                  
            }
        }

        /// <summary>
        /// Select elements that is in 3 quarter and sot them by degeneration
        /// </summary>
        public void RunTask2(string path3)
        {
            var result =
                from res in this.list
                where res.IsQuarter3() == true
                select res;

            List<IShape> totallResult =
                (from u in result
                orderby u.GetPerimeter() descending
                select u).ToList();

            using (var fw = new BasicFileManager(path3, BasicFileManager.IOType.Writer))
            {
                for (int i = 0; i < totallResult.Count; i++)
                {
                    if (totallResult[i] is Circle)
                    {
                        Circle c = totallResult[i] as Circle;
                        fw.WriteLine($"Circle: ({c.Center.X} {c.Center.Y}), radius: {c.Radius}");
                        fw.WriteLine($"Perimeter: {c.GetPerimeter()}");
                    }
                    else if (totallResult[i] is Rectangle)
                    {
                        Rectangle c = totallResult[i] as Rectangle;
                        fw.WriteLine($"Square: ({c.LeftTopPoint.X} {c.LeftTopPoint.Y}), ({c.RightDownPoint.X} {c.RightDownPoint.Y})");
                        fw.WriteLine($"Perimeter: {c.GetPerimeter()}");
                    }
                    else if (totallResult[i] is Triangle)
                    {
                        Triangle c = totallResult[i] as Triangle;
                        fw.WriteLine($"Trianle: ({c.FirstPoint.X} {c.FirstPoint.Y}), ({c.SecondPoint.X} {c.SecondPoint.Y}), ({c.ThirdPoint.X} {c.ThirdPoint.Y})");
                        fw.WriteLine($"Perimeter: {c.GetPerimeter()}");
                    }
                }
            }
        }
    }

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

                case "rectangle":
                    double left_x = double.Parse(fields[1]);
                    double left_y = double.Parse(fields[2]);
                    double right_x = double.Parse(fields[3]);
                    double right_y = double.Parse(fields[4]);
                    return new Rectangle(left_x, left_y, right_x, right_y);

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
}
