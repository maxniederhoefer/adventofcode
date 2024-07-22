using System.Reflection;

namespace adventofcode;

internal class Program {
    static void Main(string[] args) {
        var lastDay = GetLastDayInstance();
        lastDay?.GetFirstPart();
        lastDay?.GetSecondPart();
    }

    static dynamic GetLastDayInstance() {
        var workingDir = Environment.CurrentDirectory;
        string projectDir = Directory.GetParent(workingDir).Parent.Parent.FullName;
        string[] directories = Directory.GetDirectories(projectDir);

        // Find the directory with the highest number (year)
        string highestYear = directories
            .Select(Path.GetFileName)
            .Where(name => int.TryParse(name, out _))
            .OrderByDescending(name => int.Parse(name))
            .FirstOrDefault() ?? throw new Exception("No valid year directories found");

        string yearDirectoryPath = Path.Combine(projectDir, highestYear);
        string[] files = Directory.GetFiles(yearDirectoryPath, "Day*.cs");

        // Find the Day class with the highest number
        Type highestDayType = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Name.StartsWith("Day") && int.TryParse(t.Name[3..], out _))
            .OrderByDescending(t => int.Parse(t.Name[3..]))
            .FirstOrDefault() ?? throw new Exception("No valid Day classes found");

        return highestDayType == null ? throw new Exception("Day class not found in assembly") : (dynamic)Activator.CreateInstance(highestDayType);
    }
}
