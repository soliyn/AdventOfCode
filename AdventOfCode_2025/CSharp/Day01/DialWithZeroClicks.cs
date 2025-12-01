namespace CSharp.Day01;

internal class DialWithZeroClicks
{
    private int _value = 50;

    public int Rotate(int amount)
    {
        int normalized = (_value + amount) % 100;
        int zeroPointsNumber = Math.Abs((_value + amount) / 100);

        if (normalized < 0)
        {
            normalized += 100;
            if (_value != 0)
            {
                zeroPointsNumber++;    
            }
        }

        _value = normalized;
        return zeroPointsNumber + (_value == 0 && amount < 0 ? 1 : 0);
    }
}
