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
}