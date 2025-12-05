namespace CSharp.Day05;

public class IngredientRanges
{
    private readonly List<(long, long)> _ranges = [];
    
    public void AddRange(long start, long end)
    {
        _ranges.Add((start, end));
    }
    
    public bool IsInRange(long value) => 
        _ranges.Any(range => range.Item1 <= value && value <= range.Item2);
}