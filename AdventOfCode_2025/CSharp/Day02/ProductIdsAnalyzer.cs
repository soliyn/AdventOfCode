namespace CSharp.Day02;

public static class ProductIdsAnalyzer
{
    public static long GetInvalidIdsSum(IEnumerable<ProductIdRange> idRanges)
    {
        long sum = 0;
        foreach (var idRange in idRanges)
        {
            for (long id = idRange.Start; id <= idRange.End; id++)
            {
                if (IsInvalidId(id))
                {
                    sum += id;
                }
            }
        }
        return sum;
    }

    private static bool IsInvalidId(long id)
    {
        int numberOfDigits = (int)Math.Floor(Math.Log10(id)) + 1;
        if (IsEvenNumberOfDigits(numberOfDigits))
        {
            return false;
        }
        (long left, long right) = SplitEvenDigitsFast(id);
        return left == right;
    }

    private static bool IsEvenNumberOfDigits(int numberOfDigits) => 
        (numberOfDigits & 1) == 1;
    
    private static (long left, long right) SplitEvenDigitsFast(long n)
    {
        if (n < 100)                       return (n / 10,           n % 10);            // 2 digits
        if (n < 10_000)                    return (n / 100,          n % 100);           // 4 digits
        if (n < 1_000_000)                 return (n / 1_000,        n % 1_000);         // 6 digits
        if (n < 100_000_000)               return (n / 10_000,       n % 10_000);        // 8 digits
        if (n < 10_000_000_000)            return (n / 100_000,      n % 100_000);       // 10 digits
        if (n < 1_000_000_000_000)         return (n / 1_000_000,    n % 1_000_000);     // 12 digits
        if (n < 100_000_000_000_000)       return (n / 10_000_000,   n % 10_000_000);    // 14 digits
        if (n < 10_000_000_000_000_000)    return (n / 100_000_000,  n % 100_000_000);   // 16 digits
        if (n < 1_000_000_000_000_000_000) return (n / 1_000_000_000, n % 1_000_000_000);// 18 digits

        throw new ArgumentException("Number has an odd number of digits or exceeds 18 digits.");
    }

}