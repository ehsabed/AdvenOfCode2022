var advCodeInput = System.IO.File.ReadLines(@".\data\advdata7.txt");

// var advCode = new AdvCode5();
// advCode.InitStacks(advCodeInput);
// advCode.MoveCrates(advCodeInput);
// var result = advCode.TopCrates();

// var startPacket = AdvCode6.StartPosition(advCodeInput.FirstOrDefault(), 4);
// var startMessage = AdvCode6.StartPosition(advCodeInput.FirstOrDefault(), 14);

// Console.WriteLine($"Start packet: {startPacket}, Start Message: {startMessage}");

var sum = AdvCode7.Sum(advCodeInput);

Console.WriteLine($"Tot size: {sum.Select(f => f.GetSize()).Sum()}");
Console.WriteLine($"No of directories: {sum.Count}");
Console.WriteLine($"{string.Join(',', sum.Select(f => f.Name))}");
Console.WriteLine($"No of Lines: {advCodeInput.Count()}");