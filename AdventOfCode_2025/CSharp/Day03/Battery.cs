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
}