// <copyright file="Program.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>TORV team</author>

namespace PCIS
{
    using Models;
    using Models.Interfaces;

    /// <summary>
    /// Initial point of app. Variant 1
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starting app
        /// </summary>
        private static void Main()
        {
            IShape[] shapes =
            {
                new Circle(0, 0, 3),
                new Square(0, 5, 5, 0),
                new Triangle(new Point(0, 0), new Point(1, 1), new Point(3, 2))
            };

            foreach (var shape in shapes)
            {
                string name;
                if (shape is Circle)
                {
                    name = "Circle";
                }
                else if (shape is Square)
                {
                    name = "Square";
                }
                else if (shape is Triangle)
                {
                    name = "Triangle";
                }
                else
                {
                    name = "Unknown";
                }

                System.Console.WriteLine($"{name} | Perimeter: {shape.GetPerimeter():00.00}\tSquare: {shape.GetSquare():00.00}");
            }
        }
    }
}
