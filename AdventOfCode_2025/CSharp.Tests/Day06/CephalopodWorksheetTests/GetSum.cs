using CSharp.Day06;

namespace CSharp.Tests.Day06.CephalopodWorksheetTests;

public class GetSum
{
    [Fact]
    public void Should_Return_Sum()
    {
        var input = new string[]
        {
            "123 328  51 64 ",
            "45 64  387 23 ",
            "6 98  215 314 ",
            "*   +   *   + ",
        };
        Assert.Equal(4277556, CephalopodWorksheet.GetSum(input));
    }
}