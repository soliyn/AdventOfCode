namespace CSharp.Day07;

public static class Tachyon
{
    public static int GetNumberOfSplits(string[] input)
    {
        int numberOfSplits = 0;
        var tachyonIndexes = new HashSet<int> { input[0].IndexOf('S') };
        for (int i = 1; i < input.Length; i++)
        {
            var nextTachyonIndexes = new HashSet<int>();
            foreach (var tachyonIndex in tachyonIndexes)
            {
                if (input[i][tachyonIndex] == '^')
                {
                    numberOfSplits++;
                    nextTachyonIndexes.Add(tachyonIndex - 1);
                    nextTachyonIndexes.Add(tachyonIndex + 1);
                }
                else
                {
                    nextTachyonIndexes.Add(tachyonIndex);
                }
            }
            tachyonIndexes = nextTachyonIndexes;
        }
        return numberOfSplits;
    }

    public static long GetNumberOfTimelines(string[] input)
    {
        long numberOfTimelines = 1;
        var tachyonIndexes = new Dictionary<int, long> { {input[0].IndexOf('S'), 1} };
        for (int i = 1; i < input.Length; i++)
        {
            var nextTachyonIndexes = new Dictionary<int, long>();
            foreach (var tachyonIndex in tachyonIndexes)
            {
                if (input[i][tachyonIndex.Key] == '^')
                {
                    numberOfTimelines += tachyonIndex.Value;
                    AddOrUpdate(nextTachyonIndexes, tachyonIndex.Key - 1, tachyonIndex.Value);
                    AddOrUpdate(nextTachyonIndexes, tachyonIndex.Key + 1, tachyonIndex.Value);
                }
                else
                {
                    AddOrUpdate(nextTachyonIndexes, tachyonIndex.Key, tachyonIndex.Value);
                }
            }
            tachyonIndexes = nextTachyonIndexes;
        }
        return numberOfTimelines;
    }

    private static void AddOrUpdate(Dictionary<int, long> dict, int key, long value)
    {
        if (dict.TryGetValue(key, out var oldValue))
        {
            dict[key] = oldValue + value;
        }
        else
        {
            dict[key] = value; 
        }
    }
}
