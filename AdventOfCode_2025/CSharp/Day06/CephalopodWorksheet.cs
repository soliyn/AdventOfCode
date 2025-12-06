namespace CSharp.Day06;

public static class CephalopodWorksheet
{
    public static long GetSum(string[] input)
    {
        var worksheet = input
                .Select(line => line.Split((char[])null!, StringSplitOptions.RemoveEmptyEntries))
                .ToArray()
            ;
        var sum = 0L;
        for (int col = 0; col < worksheet[0].Length; col++)
        {
            Func<long, long, long> op = worksheet[^1][col].Trim() == "+" ? (val1, val2) => val1 + val2 : (val1, val2) => val1 * val2;
            long colResult = int.Parse(worksheet[0][col]);
            for (int row = 1; row < worksheet.Length - 1; row++)
            {
                colResult = op(colResult, int.Parse(worksheet[row][col]));
            }
            sum += colResult;
        } 
        return sum;
    }
}