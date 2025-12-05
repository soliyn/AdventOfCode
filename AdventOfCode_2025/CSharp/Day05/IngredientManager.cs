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
}