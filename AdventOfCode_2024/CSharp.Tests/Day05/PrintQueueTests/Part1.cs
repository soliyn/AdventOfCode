using CSharp.Day05;
using FluentAssertions;

namespace CSharp.Tests.Day05.PrintQueueTests;

public class Part1
{
    [Fact]
    public void Should_Return_Expected_Result()
    {
        var rules = (new List<(int, int)>()
        {
            (47, 53),
            (97, 13),
            (97, 61),
            (97, 47),
            (75, 29),
            (61, 13),
            (75, 53),
            (29, 13),
            (97, 29),
            (53, 29),
            (61, 53),
            (97, 53),
            (61, 29),
            (47, 13),
            (75, 47),
            (97, 75),
            (47, 61),
            (75, 61),
            (47, 29),
            (75, 13),
            (53, 13),
        })
        .GroupBy(x => x.Item1)
        .ToDictionary(g => g.Key, x => x.Select(x => x.Item2).ToList());
        
        int[][] updates = [
            [75,47,61,53,29],
            [97,61,53,29,13],
            [75,29,13],
            [75,97,47,61,53],
            [61,13,29],
            [97,13,75,29,47],
        ];
        
        var result = PrintQueue.Part1(rules, updates);

        result.Should().Be(143);
    }
}