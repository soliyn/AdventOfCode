using CSharp.Day05;

namespace CSharp.Tests.Day05.IngredientManagerTests;

public class GetNumberOfFreshIngredientIds
{
    [Fact]
    public void Should_Return_Correct_Number_Of_Fresh_IngredientIds()
    {
        List<(long, long)> ranges = new List<(long, long)>()
        {
            (3, 5),
            (10, 14),
            (16, 20),
            (12, 18),
        };
        Assert.Equal(14, IngredientManager.GetNumberOfFreshIngredientIds(ranges));
    }
    
    [Fact]
    public void Should_Return_Correct_Number_Of_Fresh_IngredientIds2()
    {
        List<(long, long)> ranges = new List<(long, long)>()
        {
            (10, 20),
            (14, 18),
            (15, 22),
            (30, 40),
            (32, 32),
            (32, 41),
            (40, 41),
        };
        Assert.Equal(25, IngredientManager.GetNumberOfFreshIngredientIds(ranges));
    }
}
