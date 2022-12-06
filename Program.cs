var advCodeInput = System.IO.File.ReadLines(@".\data\advdata6.txt");

// var advCode = new AdvCode5();
// advCode.InitStacks(advCodeInput);
// advCode.MoveCrates(advCodeInput);
// var result = advCode.TopCrates();

var startPacket = AdvCode6.StartPosition(advCodeInput.FirstOrDefault(), 4);
var startMessage = AdvCode6.StartPosition(advCodeInput.FirstOrDefault(), 14);


Console.WriteLine($"Start packet: {startPacket}, Start Message: {startMessage}");
Console.WriteLine($"No of Lines: {advCodeInput.Count()}");