public class AdvCode7
{
    public static List<FileSystemObject> Sum(IEnumerable<string> inputData)
     {
        int sizeLimit = 100000;
        List<Directory> topSizeDirs = new List<Directory>();
        Directory currentDir = null;
        Directory topDir = null;
        foreach (var line in inputData)
        {
            if (BaseCommand.IsCommand(line))
            {
                var cmd = line.Substring(2, 2);
                if (cmd == "cd")
                {
                    string move = line.Substring(5);
                    if (move == "..")
                    {
                        currentDir = currentDir.Parent;
                    }
                    else
                    {
                        var newDir = new Directory(move);
                        currentDir?.Children.Add(newDir);
                        newDir.Parent = currentDir;
                        currentDir = newDir;
                        if (topDir is null && move == "/") topDir = currentDir;
                    }
                }
                else
                {
                    // Assume ls without argument
                }
            }
            else
            {
                if (line.StartsWith("dir"))
                {
                    //currentDir.Children.Add(new Directory(line.Substring(4)));
                }
                else
                {
                    currentDir.Children.Add(new File(line));
                }
            }
        }

        var allObjects = GetAllFileSystemObjects(new [] {topDir});

        Console.WriteLine($"Tot no of directories: {allObjects.Where(o => o.FsType == FileSystemType.DIR).Count()}");
        Console.WriteLine($"Tot no of files: {allObjects.Where(o => o.FsType == FileSystemType.FILE).Count()}");

        return allObjects.Where(fs => fs.FsType == FileSystemType.DIR && fs.GetSize() <= sizeLimit).ToList();
     }
    
    public class BaseCommand
    {
        public string Name { get; set; }
        public static bool IsCommand(string input) { return !string.IsNullOrEmpty(input) && input.StartsWith("$"); }

        // static BaseCommand ParseCommand(string input)
        // {
        //     var substrings = input.Split(' ');
        //     if (substrings[1].Trim() == "cd") return new CdCommand();
        // }

    }

    public class CdCommand : BaseCommand
    {
        public CdCommand()
        {
            Name = "cd";
        }
    }

    public class LsCommand : BaseCommand
    {
        public LsCommand()
        {
            Name = "ls";
        }
    }

    public enum FileSystemType
    {
        FILE,
        DIR
    }

    public abstract class FileSystemObject
    {
        public FileSystemType FsType {get; set;}
        public string Name { get; set; }

        public List<FileSystemObject> Children { get; set; }

        public abstract int GetSize();
    }

    public class File : FileSystemObject
    {
        public File(string input)
        {
            FsType = FileSystemType.FILE;
            var subStrings = input.Split(' ');
            Name = subStrings[1].Trim();
            size = int.Parse(subStrings[0].Trim());
            Children = Enumerable.Empty<FileSystemObject>().ToList();
        }

        private int size = 0;
        public override int GetSize()
        { 
            return size;
        }
    }

    public class Directory : FileSystemObject
    {
        public Directory(string dirName)
        {
            FsType = FileSystemType.DIR;
            Name = dirName;
            Children = new List<FileSystemObject>();
        }

        public Directory Parent {get;set;}

        public override int GetSize()
        { 
            return DirSize(this);
        }
    }

    public static IEnumerable<FileSystemObject> GetAllFileSystemObjects(IEnumerable<FileSystemObject> masterList)
    {
        foreach(var node in masterList) 
        {
            yield return node;
            foreach(var children in GetAllFileSystemObjects(node.Children))
                yield return children;
        }
    }

    public static int DirSize(FileSystemObject fso)
    {
        if (fso is Directory)
        {
            var filesInDir = GetAllFileSystemObjects(new [] {fso}).Where(f => f.FsType == FileSystemType.FILE);
            var totalSize = filesInDir.Select(f => f.GetSize()).Sum();
            Console.WriteLine($"Files in {fso.Name}: {string.Join(',', filesInDir.Select(f => f.Name))}");
            Console.WriteLine($"Size: {totalSize}");
            Console.WriteLine();
            return totalSize;
        }

        return 0;
    }
}