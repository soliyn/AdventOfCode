namespace CSharp;

public static class Utilities
{
    public static (List<int>, List<int>) GetLeftAndRightLists(string filePath)
    {
        const string numbersDelimiter = "   ";
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        ReadInput(filePath, ln =>
        {
            var numbers = ln.Split(numbersDelimiter);
            left.Add(int.Parse(numbers[0]));
            right.Add(int.Parse(numbers[1]));
        });
        return (left, right);
    }

    public static int[][] GetArrayOfArrays(string filePath)
    {
        const string numbersDelimiter = " ";
        List<int[]> list = new List<int[]>();
        ReadInput(filePath, ln =>
        {
            var numbers = ln.Split(numbersDelimiter).Select(int.Parse).ToArray();
            list.Add(numbers);
        });
        return list.ToArray();
    }

    public static (Dictionary<int, List<int>> rules, int[][] updates) GetRulesAndUpdates(string filePath)
    {
        const string rulesDelimiter = "|";
        const string updatesDelimiter = ",";
        List<(int, int)> rules = new List<(int, int)>();
        var updates = new List<int[]>();
        bool isRulesPart = true;
        ReadInput(filePath, ln =>
        {
            if (string.IsNullOrEmpty(ln))
            {
                isRulesPart = false;
                return;
            }
            if (isRulesPart)
            {
                var pages = ln.Split(rulesDelimiter);
                rules.Add((int.Parse(pages[0]), int.Parse(pages[1])));
            }
            else
            {
                var pages = ln.Split(updatesDelimiter);
                updates.Add(pages.Select(int.Parse).ToArray());
            }
        });
        return (
            rules.GroupBy(x => x.Item1)
            .ToDictionary(g => g.Key, x => x.Select(x => x.Item2).ToList()), 
            updates.ToArray()
        );
    }

    private static void ReadInput(string filePath, Action<string> action)
    {
        using StreamReader streamReader = new StreamReader(filePath);
        while (streamReader.ReadLine() is { } ln)
        {
            action(ln);
        }
    }
}