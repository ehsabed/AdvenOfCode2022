var advCodeInput = System.IO.File.ReadLines(@"c:\temp\adventofcode\advdata5.txt");

var advCode = new AdvCode5();
advCode.InitStacks(advCodeInput);
advCode.MoveCrates(advCodeInput);
var result = advCode.TopCrates();

Console.WriteLine($"Result: {result}");
Console.WriteLine($"No of Lines: {advCodeInput.Count()}");
//System.Console.WriteLine(advCode);