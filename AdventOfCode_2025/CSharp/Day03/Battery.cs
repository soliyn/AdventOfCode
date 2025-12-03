using System.Diagnostics;

namespace CSharp.Day03;

public static class Battery
{
    public static string GetMaxJoltage(char[] jValues, int numberOfBanks)
    {
        Debug.Assert(jValues.Length >= numberOfBanks);

        char[] maxDigits = new char[numberOfBanks];
        int maxPos = -1;
        
        for (int i = 0; i < numberOfBanks; i++)
        {
            (var max, maxPos) = GetMaxDigit(jValues, maxPos + 1, jValues.Length - numberOfBanks + i);
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