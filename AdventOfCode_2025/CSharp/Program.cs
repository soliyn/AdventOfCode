using CSharp.Day01;
using CSharp.Day02;

// Day01
// var input = File.ReadAllLines("Day01/input.txt");
// Console.WriteLine(SafeDial.GetZeroTimes(input));
// Console.WriteLine(SafeDial.GetZeroClickTimes(input));

// Day02
var input = File.ReadAllText("Day02/input.txt")
    .Split(',')
    .Select(x =>
    {
        var ids = x.Split('-');
        return new ProductIdRange(long.Parse(ids[0]), long.Parse(ids[1]));
    })
    ;
Console.WriteLine(ProductIdsAnalyzer.GetInvalidIdsSum(input));
