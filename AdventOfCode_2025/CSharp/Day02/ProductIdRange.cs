namespace CSharp.Day02;

public struct ProductIdRange(long start, long end)
{
    public long Start { get; set; } = start;
    public long End { get; set; } = end;
}