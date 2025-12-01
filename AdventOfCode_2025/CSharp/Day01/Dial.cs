namespace CSharp.Day01;

internal class Dial
{
    private int _value = 50;

    public int Rotate(int amount)
    {
        _value = NormalizeValue(_value + amount);
        return _value;
    }

    private int NormalizeValue(int value)
    {
        int normalized = value % 100;

        if (normalized < 0)
        {
            normalized += 100;
        }

        return normalized;
    }

}
