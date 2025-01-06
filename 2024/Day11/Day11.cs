namespace adventofcode._2024;

public class Day11 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day11", "input.txt");

    public void GetFirstPart() {
        string stones = new(File.ReadAllText(path).Trim());
        int blinks = 25;

        for (int i = 0; i < blinks; i++) {
            stones = Blinks(stones);
        }

        Console.WriteLine("Part 1: " + stones.Split(' ').Length);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }

    public string Blinks(string stones) {
        List<string> newStones = new();

        foreach (var stone in stones.Split(' ')) {
            if (stone == "0") {
                newStones.Add("1");
            } else if (stone.Length % 2 == 0) {
                int mid = stone.Length / 2;
                string left = stone.Substring(0, mid).TrimStart('0');
                string right = stone.Substring(mid).TrimStart('0');
                newStones.Add(string.IsNullOrWhiteSpace(left) ? "0" : left);
                newStones.Add(string.IsNullOrWhiteSpace(right) ? "0" : right);
            } else {
                long num = long.Parse(stone);
                newStones.Add((num * 2024).ToString());
            }
        }

        return string.Join(" ", newStones);
    }
}

