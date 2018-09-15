namespace PCIS
{
    using Models;
    using Models.Interfaces;
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes = { new Circle(0, 0, 3), new Square(0, 0, 10, 10), new Triangle(new Point(0, 0), new Point(0, 10), new Point(10, 0)) };

            foreach (var shape in shapes)
            {
                System.Console.WriteLine($"Perimeter: {shape.GetPerimeter()}\tSquare: {shape.GetSquare()}");
            }
        }
    }
}
