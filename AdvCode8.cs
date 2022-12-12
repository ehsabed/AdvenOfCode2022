public class AdvCode8
{
    public static int Sum(IEnumerable<string> inputData)
    {
        Console.WriteLine($"No of Lines: {inputData.Count()}, Chars in each line: {inputData.First().Length} ({inputData.First()})");
        int treesVisible = 0;
        var matrix = inputData.Select(line => line.Select(l => int.Parse(l.ToString())).ToArray()).ToArray();
        var foregroundColor = Console.ForegroundColor;
        var visibleColor = ConsoleColor.Green;

        Console.ForegroundColor = visibleColor;
        Console.WriteLine(inputData.First());
        Console.ForegroundColor = foregroundColor;

        for (int i = 1; i < matrix.Length - 1; i++)
        {
            Console.ForegroundColor = visibleColor;
            Console.Write(matrix[i][0]);
            Console.ForegroundColor = foregroundColor;
            for (int j = 1; j < matrix.Length - 1; j++)
            {
                int currTree = matrix[i][j];
                try
                {                    
                    // var elementsToLeft = i == 1 ? matrix[0][..j] : matrix[i][..(j-1)];
                    var maxToLeft = matrix[i].Take(j).Max();
                    // if (elementsToLeft != elementsToLeftLinq) Console.WriteLine("To left diff");
                    // var elementsToRight = matrix[i][(j+1)..^0];
                    var maxToRight = matrix[i].Skip(j + 1).Take(matrix.Length - j).Max();
                    // if (elementsToRight != elementsToRightLinq) Console.WriteLine("To right diff");
                    //var elementsAbove = i == 1 ? new [] { matrix[0][j] } : matrix[..(i-1)][j];
                    // var elementsAbove = matrix.Where((c, index) => index < j).Select(c => c[j]).ToArray();
                    var maxAbove = matrix.Select(c => c[j]).Take(i).Max();
                    // if (elementsAbove != elementsAboveLinq) Console.WriteLine("Above diff");
                    // var elementsBelow = matrix[(i+1)..^0][j];
                    // var elementsBelow = matrix.Where((c, index) => index > j).Select(c => c[j]).ToArray();
                    var maxBelow = matrix.Select(c => c[j]).Skip(i + 1).Take(matrix.Length - i).Max();
                    // if (elementsBelow != elementsBelowLinq) Console.WriteLine("Below diff");
                    bool visible = currTree > maxToLeft ||
                                    currTree > maxToRight ||
                                    currTree > maxAbove ||
                                    currTree > maxBelow;
                    if (visible) 
                    {
                        //Console.WriteLine($"Tree, {currTree} at {i} - {j}, visible.");
                        Console.ForegroundColor = visibleColor;
                        Console.Write($"{currTree}");
                        Console.ForegroundColor = foregroundColor;
                        ++treesVisible;
                    }        
                    else
                    {
                        Console.Write($"{currTree}");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Curr tree: {currTree}. Error at {i} and {j}. {e.Message}, {e.StackTrace}");
                    
                    return -1;
                }
            }
            Console.ForegroundColor = visibleColor;
            Console.Write(matrix[i][matrix.Length - 1]);
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine();
        }
        
        Console.ForegroundColor = visibleColor;
        Console.WriteLine(inputData.Skip(inputData.Count() - 1).First());
        Console.ForegroundColor = foregroundColor;
        int edgeTrees = matrix.Length * 2 + (matrix.Length - 2) * 2;
        return treesVisible + edgeTrees;
    }
    
    public static int[,] CreateMatrix(IEnumerable<string> inputData)
    {
        int length = inputData.Count();
        var inputArray = inputData.ToArray();
        var result = new int[length, length];
        for (int i = 0; i < length; i++)
        {
            var charArray = inputArray.Select( c => int.Parse(c)).ToArray();
            for (int j = 0; j < length; j++)
            {                
                result[i, j] = charArray[j];
            }
        }
        
        return result;
    }
}