using CSharp.Day01;

namespace CSharp.Tests.Day01.SafeDialTests;

public class GetZeroTimes
{
    [Theory]
    [InlineData(new[] { "L50" }, 1)]
    [InlineData(new[] { "R50" }, 1)]
    [InlineData(new[] { "L10", "L40" }, 1)]
    [InlineData(new[] { "R20", "R30" }, 1)]
    [InlineData(new[] { "L10" }, 0)]
    [InlineData(new[] { "R10" }, 0)]
    public void Should_Return_Expected_Result(string[] input,  int expected)
    {
        Assert.Equal(expected, SafeDial.GetZeroTimes(input));
    }

    [Fact]
    public void Should_Return_Expected_Result_From_Example()
    {
        string[] input = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];
        Assert.Equal(3, SafeDial.GetZeroTimes(input));
    }
}