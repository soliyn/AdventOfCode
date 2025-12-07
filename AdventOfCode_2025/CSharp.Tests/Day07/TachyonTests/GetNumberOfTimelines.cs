using CSharp.Day07;

namespace CSharp.Tests.Day07.TachyonTests;

public class GetNumberOfTimelines
{
    [Fact]
    public void Should_Return_Expected_NumberOfSplits()
    {
        string[] input =
        [
            ".......S.......",
            "...............",
            ".......^.......",
            "...............",
            "......^.^......",
            "...............",
            ".....^.^.^.....",
            "...............",
            "....^.^...^....",
            "...............",
            "...^.^...^.^...",
            "...............",
            "..^...^.....^..",
            "...............",
            ".^.^.^.^.^...^.",
            "...............",
        ];
        Assert.Equal(40, Tachyon.GetNumberOfTimelines(input));
    }
}