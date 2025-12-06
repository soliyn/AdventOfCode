using System.Diagnostics;

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
    
    public static long GetSum2(string[] input)
    {
        var worksheet = input
                .ToArray()
            ;
        var sum = 0L;

        string numberString = "";
        long colResult = 0;
        Func<long, long, long> op = null!;
        for (int j = 0; j < worksheet[0].Length; j++)
        {
            if (worksheet[^1][j] != ' ')
            {
                op = worksheet[^1][j] == '+' ? (val1, val2) => val1 + val2 : (val1, val2) => val1 * val2;
                colResult = worksheet[^1][j] == '+' ? 0 : 1;
            }

            for (int i = 0; i < worksheet.Length - 1; i++)
            {
                char c = worksheet[i][j];
                if (c == ' ')
                {
                    continue;
                }

                numberString += c;
            }

            if (numberString == "")
            {
                sum += colResult;
                continue;
            }
            Debug.Assert(op is not null);
            colResult = op(colResult, int.Parse(numberString));
            numberString = "";
        }
        sum += colResult;
 
        return sum;
    }
}