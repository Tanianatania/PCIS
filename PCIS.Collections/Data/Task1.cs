using PCIS.Models;
using PCIS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCIS.Collections.Data
{
    internal class Parser
    {
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

    

    public static class Task1
    {
        static List<IShape> list = new List<IShape>();
        static int count;
        static List<IShape> result = new List<IShape>();
        static List<IShape> totall_result = new List<IShape>();

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

        public static void Run()
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
               string st;
               for (int i=0; i<count; i++)
                {

                }
                                 
            }

            var result =
                from res in list
                where res.IsQuarter3() == true
                select res;


            var totall_result = 
                from u in result
                orderby u.GetPerimeter() descending
                select u;
        }
    }
}
