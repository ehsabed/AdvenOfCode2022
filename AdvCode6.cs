using System.Text;

public class AdvCode6
{
    public static int StartPosition(string? inputData)
     {
        if (string.IsNullOrEmpty(inputData)) return -1;
        Console.WriteLine($"No of characters: {inputData.Length}");
        int maxPos = inputData.Length - 1;
        int position = 0;
        string substring = "";
        while (position + 4 < maxPos)
        {
            substring = inputData.Substring(position, 4);
            if (substring.Distinct().Count() == 4) break;
            position++;
        }

        Console.WriteLine($"Substring {substring} at position {position + 4}.");
        return position + 4;
     }
}