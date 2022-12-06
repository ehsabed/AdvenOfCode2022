using System.Text;

public class AdvCode5
{
    Dictionary<int, Stack<string>> stacks = new Dictionary<int, Stack<string>>();

     public AdvCode5()
     {
        for (int i = 1; i  < 10; i ++)
        {
            stacks.Add(i, new Stack<string>());
        }
     }

     public void InitStacks(IEnumerable<string> inputData)
     {
        var crateLines = inputData.Where(line => line.StartsWith("[")).Reverse();
        foreach (var line in crateLines)
        {
            for (int i = 0; i < 9; i++)
            {                
                var length = i == 8 ? 3 : 4;
                var letter = line.Substring(i * 4, length).Trim().TrimStart('[').TrimEnd(']');
                if (!string.IsNullOrWhiteSpace(letter))
                {
                    Console.WriteLine($"Letter {letter} in stack {i + 1}.");
                    stacks[i + 1].Push(letter);
                }
            }
        }
     }

     public void MoveCrates(IEnumerable<string> inputData)
     {
        var moveLines = inputData.Where(line => line.ToLower().StartsWith("m"));
        foreach (var moveLine in moveLines)
        {            
            int noToMove = int.Parse(moveLine.Substring(5, 2).Trim());
            int fromIndex = moveLine.ToLower().IndexOf("from");
            var fromStack = int.Parse(moveLine.Substring(fromIndex + 5, 1));
            int toIndex = moveLine.IndexOf("to");
            var toStack = int.Parse(moveLine.Substring(toIndex + 3, 1));
            Console.WriteLine($"Move {noToMove} crates from {fromStack} to {toStack}.");
            var tempStack = new Stack<string>();
            for (int i = 0; i < noToMove; i++)
            {
                var crate = stacks[fromStack].Pop();
                tempStack.Push(crate);                            
            }
            for (int i = 0; i < noToMove; i++)
            {
                stacks[toStack].Push(tempStack.Pop());
            }
        }
     }

     public string TopCrates()
     {
        var sb = "";
        for (int i = 1; i < 10; i++)
        {
            sb += stacks[i].Pop();
            sb += " ";
        }
        return sb;
     }
}