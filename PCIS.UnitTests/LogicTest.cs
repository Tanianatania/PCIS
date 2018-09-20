using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCIS.Models;

namespace PCIS.UnitTests
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void TestCirclePerimeter()
        {
            var circle = new Circle(0, 0, 2);
            var perimeter = 2 * 2 * Math.PI;
            Assert.AreEqual(circle.GetPerimeter(), perimeter);
        }

        [TestMethod]
        public void TestCircleSquare()
        {
            var circle = new Circle(0, 0, 2);
            var square = 2 * 2 * Math.PI;
            Assert.AreEqual(circle.GetSquare(), square);
        }

        [TestMethod]
        public void TestPointDistance()
        {
            var firstPoint = new Point(2, 3);
            var secondPoint = new Point(4, 5);
            double distance = System.Math.Sqrt(System.Math.Pow(2 - 4, 2) + System.Math.Pow(3 - 5, 2));
            Assert.AreEqual(distance, Point.Distance(firstPoint, secondPoint));
        }

        [TestMethod]
        public void TestSquarePerimeter()
        {
            var square = new Square(0, 4, 4, 0);
            Assert.AreEqual(square.GetPerimeter(), 16);
        }

        [TestMethod]
        public void TestSquareSquare()
        {
            var square = new Square(0, 4, 4, 0);
            Assert.AreEqual(square.GetSquare(), 16);
        }

        [TestMethod]
        public void TestTrianglePerimeter()
        {
            var triangle = new Triangle(
                    new Point(0,0), 
                    new Point(0,4), 
                    new Point(4,0)
                );
            var testPerimeter = Math.Sqrt(16 + 16) + 4 + 4;
            Assert.AreEqual(testPerimeter, triangle.GetPerimeter());
        }

        [TestMethod]
        public void TestTriangle()
        {
            var triangle = new Triangle(
                new Point(0, 0),
                new Point(0, 4),
                new Point(4, 0)
            );
            var square = (int)((4 * 4) / 2)-1;
            Assert.AreEqual((int)triangle.GetSquare(), square);
        }
    }
}