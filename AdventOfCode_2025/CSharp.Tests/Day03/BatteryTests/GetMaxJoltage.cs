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
    public void Should_ReturnMaxJoltage(string joltages, string expected)
    {
        Assert.Equal(expected, Battery.GetMaxJoltage(joltages.ToCharArray()));
    }
}