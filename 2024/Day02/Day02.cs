namespace adventofcode._2024;

public class Day02 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day02", "input.txt");

    public void GetFirstPart() {
        int safeReports = 0;

        foreach (var report in File.ReadAllLines(path)) {
            var levels = report.Split(' ').Select(int.Parse).ToArray();
            if (IsSafe(levels)) {
                safeReports++;
            }
        }

        Console.WriteLine("Part 1: " + safeReports);
    }

    public void GetSecondPart() {
        int safeReports = 0;

        foreach (var report in File.ReadAllLines(path)) {
            var levels = report.Split(' ').Select(int.Parse).ToArray();

            if (IsSafe(levels) || CanBeMadeSafe(levels)) {
                safeReports++;
            }
        }

        Console.WriteLine("Part 2: " + safeReports);
    }

    static bool IsSafe(int[] levels) {
        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = 1; i < levels.Length; i++) {
            int diff = levels[i] - levels[i - 1];

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                return false;

            if (diff > 0)
                isDecreasing = false;
            if (diff < 0)
                isIncreasing = false;
        }

        return isIncreasing || isDecreasing;
    }

    static bool CanBeMadeSafe(int[] levels) {
        for (int i = 0; i < levels.Length; i++) {
            var modifiedLevels = levels.Where((_, index) => index != i).ToArray();
            if (IsSafe(modifiedLevels)) {
                return true;
            }
        }
        return false;
    }
}
