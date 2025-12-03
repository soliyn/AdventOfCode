using CSharp.Day03;

namespace CSharp.Tests.Day03.BatteryTests;

public class GetMaxJoltage
{
    [Theory]
    [InlineData("987654321111111", "98")]
    [InlineData("811111111111119", "89")]
    [InlineData("234234234234278", "78")]
    [InlineData("818181911112111", "92")]
    [InlineData("2611412222222222223252122222224521623224122252552522222122222212112222123211212222222232213322222222", "66")]
    public void Should_Return_MaxJoltage_With_2_Banks(string joltages, string expected)
    {
        Assert.Equal(expected, Battery.GetMaxJoltage(joltages.ToCharArray(), 2));
    }
    
    [Theory]
    [InlineData("987654321111111", "987654321111")]
    [InlineData("811111111111119", "811111111119")]
    [InlineData("234234234234278", "434234234278")]
    [InlineData("818181911112111", "888911112111")]
    public void Should_Return_MaxJoltage_With_12_Banks(string joltages, string expected)
    {
        Assert.Equal(expected, Battery.GetMaxJoltage(joltages.ToCharArray(), 12));
    }
}