using System.Text.RegularExpressions;

namespace adventofcode._2025;

public class Day02 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2025", "Day02", "input.txt");
    public void GetFirstPart() {
        Console.WriteLine("Part 1: " + GetInvalidIDs(new Regex(@"^(\d+)\1$")));
    }

    public void GetSecondPart() {
        Console.WriteLine("Part 2: " + GetInvalidIDs(new Regex(@"^(\d+)\1+$")));
    }

    private long GetInvalidIDs(Regex regex) {
        string lines = File.ReadAllText(path);
        long sum = 0;

        foreach (string range in lines.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
            var parts = range.Split('-', StringSplitOptions.RemoveEmptyEntries);
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);

            for (long id = start; id <= end; id++) {
                if (regex.IsMatch(id.ToString())) {
                    sum += id;
                }
            }
        }

        return sum;
    }
}

