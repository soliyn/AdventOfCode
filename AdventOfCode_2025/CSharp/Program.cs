using CSharp.Day01;
using CSharp.Day02;
using CSharp.Day03;

// Day01
// var input = File.ReadAllLines("Day01/input.txt");
// Console.WriteLine(SafeDial.GetZeroTimes(input));
// Console.WriteLine(SafeDial.GetZeroClickTimes(input));

// Day02
// var input = File.ReadAllText("Day02/input.txt")
//     .Split(',')
//     .Select(x =>
//     {
//         var ids = x.Split('-');
//         return new ProductIdRange(long.Parse(ids[0]), long.Parse(ids[1]));
//     })
//     ;
// Console.WriteLine(ProductIdsAnalyzer.GetInvalidIdsSum(input));
// Console.WriteLine(ProductIdsAnalyzer.GetInvalidIdsSum2(input));

// Day03
var input = File.ReadAllLines("Day03/input.txt");
var debug = input
    .Select(line => Battery.GetMaxJoltage(line.ToCharArray()));
foreach (var joltage in debug)
{
    Console.WriteLine(joltage);
}

var result = input
        .Select(line => Battery.GetMaxJoltage(line.ToCharArray()))
        .Select(int.Parse)
        .Sum()
    ;
Console.WriteLine(result);
