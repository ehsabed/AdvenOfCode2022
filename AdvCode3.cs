public class AdvCode3
{
    public static string Run(IEnumerable<string> inputData)
    {
        int score = 0;
        int noOfItems = 0;
        var group = new List<string>(3);
        int noOfGroups = inputData.Count() / 3;
        for (int i = 0; i < noOfGroups; ++i)
        {
            var groupLines = inputData.Skip(3 * i).Take(3).ToList();
            foreach (char item in groupLines[0])
            {
                if (groupLines[1].Contains(item) && groupLines[2].Contains(item))
                {
                    ++noOfItems;
                    //item.Dump("Found item: ");
                    if (char.IsLower(item)) 
                    {
                        int prio = ((int)item - (int)'a' + 1);
                        // prio.Dump("Prio: ");
                        score += prio;
                    }
                    if (char.IsUpper(item)) 
                    {
                        int prio = ((int)item - (int)'A' + 27);
                        // prio.Dump("Prio: ");
                        score += prio;
                    }
                    break;
                }
            }
        }

        // noOfItems.Dump("Antal items: ");
        // score.Dump("Tot score: ");
        return $"Tot score: {score}";
    }
}