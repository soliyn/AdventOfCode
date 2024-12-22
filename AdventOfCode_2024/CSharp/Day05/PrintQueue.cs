namespace CSharp.Day05;

public static class PrintQueue
{
    public static int Part1(Dictionary<int, List<int>> rules, int[][] updates)
    {
        int sum = 0;

        foreach (var update in updates)
        {
            bool isValid = true;
            for (var i = 0; i < update.Length; i++)
            {
                var page = update[i];
                if (rules.TryGetValue(page, out var nextPages))
                {
                    if (update.Take(i).Any(x => nextPages.Contains(x)))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            if (isValid)
            {
                sum += update[update.Length / 2];
            }
        }
        
        return sum;
    }
}