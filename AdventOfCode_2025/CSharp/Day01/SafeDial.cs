namespace CSharp.Day01;

public static class SafeDial
{
    public static int GetZeroTimes(IEnumerable<string> input)
    {
        Dial dial = new();

        return ParseInput(input)
            .Select(i => dial.Rotate(i))
            .Count(i => i == 0)
            ;
    }
    
    public static int GetZeroClickTimes(IEnumerable<string> input)
    {
        DialWithZeroClicks dial = new();

        return ParseInput(input)
            .Select(i => dial.Rotate(i))
            .Sum()
            ;
    }

    private static IEnumerable<int> ParseInput(IEnumerable<string> input)
    {
        foreach (var rotation in input)
        {
            var direction = rotation[..1];
            var value = int.Parse(rotation[1..]);
            yield return direction == "L" ? -value : value;
        }
    }
}