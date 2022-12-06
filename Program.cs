var advCodeInput = System.IO.File.ReadLines(@".\data\advdata6.txt");

// var advCode = new AdvCode5();
// advCode.InitStacks(advCodeInput);
// advCode.MoveCrates(advCodeInput);
// var result = advCode.TopCrates();

var result = AdvCode6.StartPosition(advCodeInput.FirstOrDefault());


Console.WriteLine($"Result: {result}");
Console.WriteLine($"No of Lines: {advCodeInput.Count()}");