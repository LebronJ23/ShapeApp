using ShapeLib;
using ShapeLib.Shapes;
using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestTriangleAreaPoints()
        {
            // Arrange
            var tri = new Triangle(
                    new Point(1, 1),
                    new Point(1, 4),
                    new Point(5, 1)
                );
            // Act
            var area = tri.GetArea();
            // Assert
            Assert.Equal(6.0, area);
        }

        [Fact]
        public void TestTriangleAreaSides()
        {
            // Arrange
            var tri = new Triangle(5.0, 3.0, 4.0);
            // Act
            var area = tri.GetArea();
            // Assert
            Assert.Equal(6.0, area);
        }

        [Fact]
        public void TestTriangleIsRightAngledTrue()
        {
            // Arrange
            var tri = new Triangle(5.0, 3.0, 4.0);
            // Act
            var isRightAngle = tri.IsRightAngled();
            // Assert
            Assert.True(isRightAngle);
        }

        [Fact]
        public void TestTriangleIsRightAngledFalse()
        {
            // Arrange
            var tri = new Triangle(6.0, 4.0, 5.0);
            // Act
            var isRightAngle = tri.IsRightAngled();
            // Assert
            Assert.False(isRightAngle);
        }

        [Fact]
        public void TestSquareArea()
        {
            // Arrange
            var square = new Polygon(
                    new Point(1, 1),
                    new Point(1, 3),
                    new Point(3, 3),
                    new Point(3, 1)
                );
            // Act
            var area = square.GetArea();
            // Assert
            Assert.Equal(4.0, area);
        }

        [Fact]
        public void TestCircleArea()
        {
            // Arrange
            var radius = 5;
            var square = new Circle(radius);
            var expectedValue = Math.PI * Math.Pow(radius, 2);
            // Act
            var area = square.GetArea();
            // Assert
            Assert.Equal(expectedValue, area);
        }


    }
}
