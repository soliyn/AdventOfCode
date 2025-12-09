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
    
    public static long FindLargestRectangleAreaInsidePolygon(List<Point> poly)
    {
        int n = poly.Count;
        if (n < 2) return 0;

        long maxArea = 0;
        long bestI = -1, bestJ = -1;

        for (int i = 0; i < n; ++i)
        {
            for (int j = i + 1; j < n; ++j)
            {
                var x1 = Math.Min(poly[i].X, poly[j].X);
                var x2 = Math.Max(poly[i].X, poly[j].X);
                var y1 = Math.Min(poly[i].Y, poly[j].Y);
                var y2 = Math.Max(poly[i].Y, poly[j].Y);

                // corners
                var corners = new Point[] {
                    new Point(x1, y1),
                    new Point(x1, y2),
                    new Point(x2, y2),
                    new Point(x2, y1)
                };

                // 1) every corner must be inside or on boundary
                bool allCornersInside = true;
                foreach (var c in corners)
                {
                    if (!PointInPolygonInclusive(c, poly))
                    {
                        allCornersInside = false;
                        break;
                    }
                }
                if (!allCornersInside) continue;

                // 2) no polygon edge may pass through rectangle INTERIOR
                if (PolygonEdgesCrossInterior(poly, x1, x2, y1, y2))
                    continue;

                // compute inclusive-grid area
                // assume integer-grid polygon (if not, this uses floor of abs diff + 1)
                int width = (int)(Math.Abs(poly[i].X - poly[j].X) + 1.0 + 1e-9);
                int height = (int)(Math.Abs(poly[i].Y - poly[j].Y) + 1.0 + 1e-9);
                int area = width * height;

                if (area > maxArea)
                {
                    maxArea = area;
                    bestI = i; bestJ = j;
                }
            }
        }

        return maxArea;
    }

    private static bool PolygonEdgesCrossInterior(List<Point> poly, double xmin, double xmax, double ymin, double ymax)
    {
        int n = poly.Count;
        for (int k = 0; k < n; ++k)
        {
            Point a = poly[k];
            Point b = poly[(k + 1) % n];

            // if either polygon endpoint is strictly inside rectangle -> edge enters interior -> reject
            if (IsPointStrictlyInsideRect(a, xmin, xmax, ymin, ymax) ||
                IsPointStrictlyInsideRect(b, xmin, xmax, ymin, ymax))
                return true;

            // else check clipped portion of edge inside rectangle; if clipped portion's midpoint is strictly inside -> crosses interior
            if (LiangBarskySegmentClip(a, b, xmin, xmax, ymin, ymax, out double t0, out double t1))
            {
                // if clipped portion is non-empty (including touching boundary)
                double tm = (t0 + t1) / 2.0;
                Point pm = new Point((long)(a.X + (b.X - a.X) * tm), (long)(a.Y + (b.Y - a.Y) * tm));
                if (IsPointStrictlyInsideRect(pm, xmin, xmax, ymin, ymax))
                    return true;
            }
        }
        return false;
    }

    // Ray-casting point-in-polygon; returns true for inside OR on boundary
    private static bool PointInPolygonInclusive(Point p, List<Point> poly)
    {
        int n = poly.Count;
        bool inside = false;
        const double eps = 1e-12;

        for (int i = 0, j = n - 1; i < n; j = i++)
        {
            Point a = poly[i];
            Point b = poly[j];

            if (PointOnSegment(p, a, b)) return true;

            bool intersect = ((a.Y > p.Y) != (b.Y > p.Y)) &&
                             (p.X < (b.X - a.X) * (p.Y - a.Y) / (b.Y - a.Y) + a.X);
            if (intersect) inside = !inside;
        }
        return inside;
    }

    private static bool PointOnSegment(Point p, Point a, Point b)
    {
        const double eps = 1e-9;
        double cross = (p.Y - a.Y) * (b.X - a.X) - (p.X - a.X) * (b.Y - a.Y);
        if (Math.Abs(cross) > eps) return false;
        double minX = Math.Min(a.X, b.X) - eps, maxX = Math.Max(a.X, b.X) + eps;
        double minY = Math.Min(a.Y, b.Y) - eps, maxY = Math.Max(a.Y, b.Y) + eps;
        return p.X >= minX && p.X <= maxX && p.Y >= minY && p.Y <= maxY;
    }

    private static bool LiangBarskySegmentClip(Point a, Point b, double xmin, double xmax, double ymin, double ymax, out double t0, out double t1)
    {
        t0 = 0.0; t1 = 1.0;
        double dx = b.X - a.X;
        double dy = b.Y - a.Y;
        const double eps = 1e-12;

        bool Clip(double p, double q, ref double t0r, ref double t1r)
        {
            if (Math.Abs(p) < eps)
            {
                if (q < 0) return false;
                return true;
            }
            double r = q / p;
            if (p < 0)
            {
                if (r > t1r) return false;
                if (r > t0r) t0r = r;
            }
            else
            {
                if (r < t0r) return false;
                if (r < t1r) t1r = r;
            }
            return true;
        }

        double t0r = t0, t1r = t1;
        if (!Clip(-dx, a.X - xmin, ref t0r, ref t1r)) return false;
        if (!Clip(dx, xmax - a.X, ref t0r, ref t1r)) return false;
        if (!Clip(-dy, a.Y - ymin, ref t0r, ref t1r)) return false;
        if (!Clip(dy, ymax - a.Y, ref t0r, ref t1r)) return false;

        if (t0r > t1r) return false;
        t0 = t0r; t1 = t1r;
        return true;
    }

    private static bool IsPointStrictlyInsideRect(Point p, double xmin, double xmax, double ymin, double ymax)
    {
        const double eps = 1e-12;
        return (p.X > xmin + eps && p.X < xmax - eps && p.Y > ymin + eps && p.Y < ymax - eps);
    }
}
