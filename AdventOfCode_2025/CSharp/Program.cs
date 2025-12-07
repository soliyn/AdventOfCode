using CSharp.Day01;
using CSharp.Day02;
using CSharp.Day03;
using CSharp.Day04;
using CSharp.Day05;
using CSharp.Day06;
using CSharp.Day07;

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
// var input = File.ReadAllLines("Day04/input.txt")
//         .Select(line => line.ToCharArray())
//         .ToArray();
//     ;
// Console.WriteLine(GridOfPaper.GetNumberOfAccessedRolls(input));    
// Console.WriteLine(GridOfPaper.GetNumberOfRemovableRolls(input));    

// Day05
// var input = File.ReadAllLines("Day05/input.txt");
// List<(long, long)> ranges = [];
// List<long> ingredients = [];
// int i = 0;
// while (!string.IsNullOrEmpty(input[i]))
// {
//     string[] rangeStrings = input[i].Split('-');
//     ranges.Add((long.Parse(rangeStrings[0]), long.Parse(rangeStrings[1])));
//     i++;
// }
// // i++;
// // while (i < input.Length)
// // {
// //     ingredients.Add(long.Parse(input[i]));
// //     i++;
// // }
// // Console.WriteLine(IngredientManager.GetNumberOfFreshIngredients(ranges, ingredients));
// Console.WriteLine(IngredientManager.GetNumberOfFreshIngredientIds(ranges));

// Day06
// var input = File.ReadAllLines("Day06/input.txt");
// Console.WriteLine(CephalopodWorksheet.GetSum(input));
// Console.WriteLine(CephalopodWorksheet.GetSum2(input));

// Day07
var input = File.ReadAllLines("Day07/input.txt");
Console.WriteLine(Tachyon.GetNumberOfSplits(input));
