var advCodeInput = System.IO.File.ReadLines(@".\data\advdata8.txt");

// var advCode = new AdvCode5();
// advCode.InitStacks(advCodeInput);
// advCode.MoveCrates(advCodeInput);
// var result = advCode.TopCrates();

// var startPacket = AdvCode6.StartPosition(advCodeInput.FirstOrDefault(), 4);
// var startMessage = AdvCode6.StartPosition(advCodeInput.FirstOrDefault(), 14);

// Console.WriteLine($"Start packet: {startPacket}, Start Message: {startMessage}");

var sum = AdvCode8.Sum(advCodeInput);

Console.WriteLine($"No of trees: {sum}");
Console.WriteLine($"No of Trees tot: {advCodeInput.Count() * advCodeInput.Count()}");