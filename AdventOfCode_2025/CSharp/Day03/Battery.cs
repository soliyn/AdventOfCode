using System.Diagnostics;

namespace CSharp.Day03;

public static class Battery
{
    public static string GetMaxJoltage(char[] jValues)
    {
        Debug.Assert(jValues.Length > 1);
        
        char firstMax = jValues[0];
        char secondMax = jValues[1];

        for (int i = 1; i < (jValues.Length - 1); i++)
        {
            if (jValues[i] > firstMax)
            {
                firstMax = jValues[i];
                secondMax = jValues[i + 1];
                continue;
            }

            if (jValues[i] > secondMax)
            {
                secondMax = jValues[i];
            }
        }

        if (jValues[^1] > secondMax)
        {
            secondMax = jValues[^1];
        }
        return $"{firstMax}{secondMax}";
    }    
    
    public static string GetMaxJoltage2(char[] jValues)
    {
        Debug.Assert(jValues.Length >= 12);

        char[] maxDigits = new char[12];
        int maxPos = -1;
        
        for (int i = 0; i < 12; i++)
        {
            (var max, maxPos) = GetMaxDigit(jValues, maxPos + 1, jValues.Length - 12 + i);
            maxDigits[i] = max;
        }

        return string.Join("", maxDigits);
    }

    private static (char, int) GetMaxDigit(char[] jValues, int start, int end)
    {
        Debug.Assert(end - start >= 0, $"end: {end} - start:{start}");
        char max = jValues[start];
        int maxPos = start;

        for (int i = start; i <= end; i++)
        {
            if (jValues[i] > max)
            {
                max = jValues[i];
                maxPos = i;
            }
        }

        return (max, maxPos);
    }
}