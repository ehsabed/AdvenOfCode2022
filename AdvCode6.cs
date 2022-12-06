public class AdvCode6
{
    public static int StartPosition(string? inputData, int uniqueChars)
     {
        if (string.IsNullOrEmpty(inputData)) return -1;
        Console.WriteLine($"No of characters: {inputData.Length}");
        int maxPos = inputData.Length - 1;
        int position = 0;
        string substring = "";
        while (position + uniqueChars < maxPos)
        {
            substring = inputData.Substring(position, uniqueChars);
            if (substring.Distinct().Count() == uniqueChars) break;
            position++;
        }

        Console.WriteLine($"Substring {substring} at position {position + uniqueChars}.");
        return position + uniqueChars;
     }
}