namespace CSharp.Day08;

using System;
using System.Collections.Generic;
using System.Linq;

public class Point3D
{
    public int X, Y, Z;
    public Point3D(int x, int y, int z) => (X, Y, Z) = (x, y, z);

    public double DistanceTo(Point3D other)
    {
        long dx = X - other.X;
        long dy = Y - other.Y;
        long dz = Z - other.Z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}

public static class JunctionBoxCreator
{
    // Union-Find (Disjoint Set)
    class UnionFind
    {
        private readonly int[] parent;
        private readonly int[] rank;

        public UnionFind(int n)
        {
            parent = Enumerable.Range(0, n).ToArray();
            rank = new int[n];
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Union(int a, int b)
        {
            int ra = Find(a);
            int rb = Find(b);
            if (ra == rb) return;

            if (rank[ra] < rank[rb]) parent[ra] = rb;
            else if (rank[ra] > rank[rb]) parent[rb] = ra;
            else { parent[rb] = ra; rank[ra]++; }
        }
    }

    public static List<List<Point3D>> BuildJunctionBoxes(List<Point3D> points, int iterations)
    {
        int n = points.Count;
        var uf = new UnionFind(n);

        // Build all point pairs with distance
        var pairs = new List<(double dist, int a, int b)>();

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                double d = points[i].DistanceTo(points[j]);
                pairs.Add((d, i, j));
            }
        }

        // Sort by increasing distance
        pairs.Sort((p1, p2) => p1.dist.CompareTo(p2.dist));

        // Process first N nearest pairs
        int limit = Math.Min(iterations, pairs.Count);
        for (int k = 0; k < limit; k++)
        {
            var (_, a, b) = pairs[k];
            uf.Union(a, b);
        }

        // Build result groups (junction boxes)
        var groups = new Dictionary<int, List<Point3D>>();

        for (int i = 0; i < n; i++)
        {
            int root = uf.Find(i);
            if (!groups.ContainsKey(root))
                groups[root] = new List<Point3D>();

            groups[root].Add(points[i]);
        }

        return groups.Values.ToList();
    }
    
    public static (Point3D A, Point3D B) BuildJunctionBoxesUntilSingleGroup(List<Point3D> points)
    {
        int n = points.Count;
        var uf = new UnionFind(n);

        // Build all pairs with distances
        var pairs = new List<(double dist, int a, int b)>();
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                double d = points[i].DistanceTo(points[j]);
                pairs.Add((d, i, j));
            }
        }

        // Sort by ascending distance
        pairs.Sort((p1, p2) => p1.dist.CompareTo(p2.dist));

        int components = n; // initially each point is its own group
        (Point3D A, Point3D B) lastPair = (null!, null!);

        // Keep merging until only ONE group remains
        foreach (var (dist, a, b) in pairs)
        {
            int ra = uf.Find(a);
            int rb = uf.Find(b);

            if (ra != rb)
            {
                // Merge them
                uf.Union(ra, rb);
                components--;

                // Record the last merged points
                lastPair = (points[a], points[b]);

                if (components == 1)
                    break;
            }
        }

        return lastPair;
    }

}
