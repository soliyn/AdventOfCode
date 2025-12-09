using CSharp.Day09;

namespace CSharp.Tests.Day09.RectangleFinderTests;

public class FindLargestRectangleAreaInsidePolygon
{
    [Fact]
    public void Should_ReturnMaxRectangle()
    {
        var points = new List<Point>
        {
            new Point(7, 1),
            new Point(11, 1),
            new Point(11, 7),
            new Point(9, 7),
            new Point(9, 5),
            new Point(2, 5),
            new Point(2, 3),
            new Point(7, 3)
        };

        var res = RectangleFinder.FindLargestRectangleAreaInsidePolygon(points);
        Assert.Equal(24, res);
    }
}