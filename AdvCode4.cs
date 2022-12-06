public class AdvCode4
{
    public static string Run(IEnumerable<string> inputData)
    {
        int score = 0;
        foreach (string line in inputData)
        {
            int sep = line.IndexOf(",");
            var assignment1 = line.Substring(0, sep);
            var assignment2 = line.Substring(sep + 1);
            
            Console.WriteLine($"Assignment 1: {assignment1}, Assignment 2: {assignment2}");

            var range1 = GetRange(assignment1);
            var range2 = GetRange(assignment2);

            if (Overlap(range1, range2)) score++;
        }

        // noOfItems.Dump("Antal items: ");
        // score.Dump("Tot score: ");
        return $"Tot score: {score}";
    }

    private static IEnumerable<int> GetRange(string assignment)
    {
        string separator = "-";
        var sepIndex = assignment.IndexOf(separator);
        var start = int.Parse(assignment.Substring(0, sepIndex));
        var end = int.Parse(assignment.Substring(sepIndex + 1));
        var rangeLength = end - start + 1;
        return Enumerable.Range(start, rangeLength);
    }

    private static bool IsInRange(IEnumerable<int> range1, IEnumerable<int> range2)
    {
        bool result1 = true;
        foreach (var item in range2)
        {
            if(!range1.Contains(item))
            {
                result1 = false;
                break;
            }
        }

        bool result2 = true;
        foreach (var item in range1)
        {
            if(!range2.Contains(item))
            {
                result2 = false;
                break;
            }
        }

        return result1 || result2;
    }

    private static bool Overlap(IEnumerable<int> range1, IEnumerable<int> range2)
    {
        bool result1 = false;
        foreach (var item in range2)
        {
            if(range1.Contains(item))
            {
                result1 = true;
                break;
            }
        }

        return result1;
    }
}