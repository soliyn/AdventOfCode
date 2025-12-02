using CSharp.Day02;

namespace CSharp.Tests.Day02.ProductIdsAnalyzerTests;

public class GetInvalidIdsSum2
{
    [Fact]
    public void Should_Return_Expected_Result_For_Example_Dataset()
    {
        var idRanges = new[] {
            new ProductIdRange(11, 22),
            new ProductIdRange(95, 115),
            new ProductIdRange(998, 1012),
            new ProductIdRange(1188511880, 1188511890),
            new ProductIdRange(222220, 222224),
            new ProductIdRange(1698522, 1698528),
            new ProductIdRange(446443, 446449),
            new ProductIdRange(38593856, 38593862),
            new ProductIdRange(565653, 565659),
            new ProductIdRange(824824821, 824824827),
            new ProductIdRange(2121212118, 2121212124)
        };
        
        Assert.Equal(4174379265, ProductIdsAnalyzer.GetInvalidIdsSum2(idRanges));
    }

}