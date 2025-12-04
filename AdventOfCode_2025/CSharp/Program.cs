using CSharp.Day01;
using CSharp.Day02;
using CSharp.Day03;
using CSharp.Day04;

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
// var input = File.ReadAllLines("Day03/input.txt");
// var result = input
//         .Select(line => Battery.GetMaxJoltage(line.ToCharArray(), 2))
//         .Select(int.Parse)
//         .Sum()
//     ;
// Console.WriteLine(result);
//
// var result2 = input
//         .Select(line => Battery.GetMaxJoltage(line.ToCharArray(), 12))
//         .Select(long.Parse)
//         .Sum()
//     ;
// Console.WriteLine(result2);

// Day04
var input = File.ReadAllLines("Day04/input.txt")
        .Select(line => line.ToCharArray())
        .ToArray();
    ;
Console.WriteLine(GridOfPaper.GetNumberOfAccessedRolls(input));    