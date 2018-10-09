namespace PCIS.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PCIS.Models;

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
            Assert.AreEqual(circle.GetArea(), square);
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
            var square = new Rectangle(0, 4, 4, 0);
            Assert.AreEqual(square.GetPerimeter(), 16);
        }

        [TestMethod]
        public void TestSquareSquare()
        {
            var square = new Rectangle(0, 4, 4, 0);
            Assert.AreEqual(square.GetArea(), 16);
        }

        [TestMethod]
        public void TestTrianglePerimeter()
        {
            var triangle = new Triangle(
                    new Point(0, 0),
                    new Point(0, 4),
                    new Point(4, 0));
            var testPerimeter = Math.Sqrt(16 + 16) + 4 + 4;
            Assert.AreEqual(testPerimeter, triangle.GetPerimeter());
        }

        [TestMethod]
        public void TestTriangle()
        {
            var triangle = new Triangle(
                new Point(0, 0),
                new Point(0, 4),
                new Point(4, 0));
            var square = (int)((4 * 4) / 2) - 1;
            Assert.AreEqual((int)triangle.GetArea(), square);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionOnOneLineTriangle()
        {
            var actual = new Triangle(
                    new Point(0, 2),
                    new Point(0, 4),
                    new Point(0, 5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LeftTopPointLessThanRightDownPointSquare()
        {
            var actual = new Rectangle(0, 4, 4, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LeftTopPointHigherThanRightDownPointSquare()
        {
            var actual = new Rectangle(5, 4, 4, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LeftTopPointLessRightDownPointSquare()
        {
            var actual = new Rectangle(5, 0, 4, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExceptionOnRadius()
        {
            var actual = new Circle(0, 0, 0);
        }

        [TestMethod]
        public void GetCenterTest()
        {
            var circle = new Circle(0, 0, 4);
            var actual = circle.Center;
            var expected = new Point(0, 0);
            Assert.AreEqual(actual.X, expected.X);
            Assert.AreEqual(actual.Y, expected.Y);
        }

        [TestMethod]
        public void GetFirstPointTest()
        {
            var actual = new Triangle(
                    new Point(0, 0),
                    new Point(0, 4),
                    new Point(4, 0));
            var expected = new Point(0, 0);
            Assert.AreEqual(actual.FirstPoint.X, expected.X);
            Assert.AreEqual(actual.FirstPoint.Y, expected.Y);
        }

        [TestMethod]
        public void GetSecondPointTest()
        {
            var actual = new Triangle(
                    new Point(0, 0),
                    new Point(0, 4),
                    new Point(4, 0));
            var expected = new Point(0, 4);
            Assert.AreEqual(actual.SecondPoint.X, expected.X);
            Assert.AreEqual(actual.SecondPoint.Y, expected.Y);
        }

        [TestMethod]
        public void GetThirdPointTest()
        {
            var actual = new Triangle(
                    new Point(0, 0),
                    new Point(0, 4),
                    new Point(4, 0));
            var expected = new Point(4, 0);
            Assert.AreEqual(actual.ThirdPoint.X, expected.X);
            Assert.AreEqual(actual.ThirdPoint.Y, expected.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPointDistanceException()
        {
            var firstPoint = new Point(2, 3);
            Point.Distance(firstPoint, null);
        }

        [TestMethod]
        public void SecondTestPointDistance()
        {
            var firstPoint = new Point(2, 3);
            var secondPoint = new Point(3, 4);
            var expected = true;
            Assert.AreEqual(Point.OnOneLine(firstPoint, secondPoint), expected);
        }
    }
}