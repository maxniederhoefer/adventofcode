using System.Text.RegularExpressions;

namespace adventofcode._2024;

public class Day03 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day03", "input.txt");

    public void GetFirstPart() {
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        Regex regex = new(pattern);

        var matches = regex.Matches(File.ReadAllText(path));

        int sum = 0;

        foreach (Match match in matches) {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);

            sum += x * y;
        }

        Console.WriteLine("Part 1: " + sum);
    }

    public void GetSecondPart() {
        string pattern = @"(do\(\)|don't\(\)|mul\((\d{1,3}),(\d{1,3})\))";
        Regex regex = new Regex(pattern);

        var matches = regex.Matches(File.ReadAllText(path));

        int sum = 0;
        bool mul = true;

        foreach (Match match in matches) {
            if (match.Value == "do()") {
                mul = true;
            } else if (match.Value == "don't()") {
                mul = false;
            } else {
                int x = int.Parse(match.Groups[2].Value);
                int y = int.Parse(match.Groups[3].Value);

                if (mul) {
                    sum += x * y;
                }
            }
        }

        Console.WriteLine("Part 2: " + sum);
    }
}

