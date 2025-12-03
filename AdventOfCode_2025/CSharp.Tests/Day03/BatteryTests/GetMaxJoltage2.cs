using CSharp.Day03;

namespace CSharp.Tests.Day03.BatteryTests;

public class GetMaxJoltage2
{
    [Theory]
    [InlineData("987654321111111", "987654321111")]
    [InlineData("811111111111119", "811111111119")]
    [InlineData("234234234234278", "434234234278")]
    [InlineData("818181911112111", "888911112111")]
    public void Should_ReturnMaxJoltage(string joltages, string expected)
    {
        Assert.Equal(expected, Battery.GetMaxJoltage2(joltages.ToCharArray()));
    }
}