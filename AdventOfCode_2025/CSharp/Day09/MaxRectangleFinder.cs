namespace CSharp.Day09;

public class Point(long x, long y)
{ 
    public readonly long X = x;
    public readonly long Y = y;
}

public static class RectangleFinder
{
    public static long FindLargestRectangleArea(List<Point> points)
    {
        int n = points.Count;
        if (n < 2) return 0;

        long maxArea = 0;

        for (int i = 0; i < n; i++)
        {
            var p1 = points[i];
            for (int j = i + 1; j < n; j++)
            {
                var p2 = points[j];

                long width  = Math.Abs(p2.X - p1.X) + 1;
                long height = Math.Abs(p2.Y - p1.Y) + 1;

                long area = width * height;
                if (area > maxArea)
                    maxArea = area;
            }
        }

        return maxArea;
    }
}
