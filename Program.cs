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

        // Find the Year directory with the highest number
        string highestYear = directories
            .Select(Path.GetFileName)
            .Where(name => int.TryParse(name, out _))
            .OrderByDescending(name => int.Parse(name))
            .FirstOrDefault() ?? throw new Exception("No valid year directories found");

        string yearDirectoryPath = Path.Combine(projectDir, highestYear);
        string[] dayDirectories = Directory.GetDirectories(yearDirectoryPath, "Day*");

        // Find the Day directory with the highest number
        string highestDayDirectory = dayDirectories
            .Select(Path.GetFileName)
            .Where(name => name.StartsWith("Day") && int.TryParse(name[3..], out _))
            .OrderByDescending(name => int.Parse(name[3..]))
            .FirstOrDefault() ?? throw new Exception("No valid Day directories found");

        string highestDayClassName = highestDayDirectory;

        // Find the Day class with the matching name
        Type highestDayType = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(t => t.Name == highestDayClassName) ?? throw new Exception($"Day class {highestDayClassName} not found in assembly");

        return Activator.CreateInstance(highestDayType);
    }
}
