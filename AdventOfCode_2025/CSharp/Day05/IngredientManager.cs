namespace CSharp.Day05;

public static class IngredientManager
{
    public static long GetNumberOfFreshIngredients(IEnumerable<(long, long)> ranges, IEnumerable<long> ingredients)
    {
        IngredientRanges ingredientRanges = new();
        foreach (var range in ranges)
        {
            ingredientRanges.AddRange(range.Item1, range.Item2);
        }
        
        return ingredients.Count(i => ingredientRanges.IsInRange(i));
    }

    public static long GetNumberOfFreshIngredientIds(IEnumerable<(long, long)> ranges)
    {
        long numberOfIds = 0;
        var sortedRanges = ranges.OrderBy(r => r.Item1).ThenBy(r => r.Item2).ToList();
        NormalizeRanges();
        foreach (var (start, end) in sortedRanges)
        {
            if (start <= end)
            {
                numberOfIds += end - start + 1;
            }
        }
        
        return numberOfIds;

        void NormalizeRanges()
        {
            var prevRangeEnd = sortedRanges[0].Item2;
            for (int i = 1; i < sortedRanges.Count; i++)
            {
                var (start, end) = sortedRanges[i];
                if (start <= prevRangeEnd)
                {
                    start = prevRangeEnd + 1;
                }
                prevRangeEnd = Math.Max(prevRangeEnd, end);

                sortedRanges[i] = (start, end);
            }            
        }
    }
}