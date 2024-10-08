namespace adventofcode._2022.Day01;

public class Day01 : IDay {
    private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2022\\Day01\\input.txt";

    public void GetFirstPart() {
        string[] lines = File.ReadAllLines(path);

        int maxCalories = 0;
        int currentCalories = 0;

        foreach (string line in lines) {
            if (string.IsNullOrWhiteSpace(line)) {
                if (currentCalories > maxCalories) {
                    maxCalories = currentCalories;
                }

                currentCalories = 0;
            } else {
                currentCalories += int.Parse(line);
            }
        }

        if (currentCalories > maxCalories) {
            maxCalories = currentCalories;
        }

        Console.WriteLine("Part1: " + maxCalories);
    }

    public void GetSecondPart() {
        string[] lines = File.ReadAllLines(path);

        List<int> elfCalories = new();
        int currentCalories = 0;

        foreach (string line in lines) {
            if (string.IsNullOrWhiteSpace(line)) {
                elfCalories.Add(currentCalories);

                currentCalories = 0;
            } else {
                currentCalories += int.Parse(line);
            }
        }

        elfCalories.Add(currentCalories);

        int topThreeCalories = elfCalories
            .OrderByDescending(calories => calories)
            .Take(3)
            .Sum();

        Console.WriteLine("Part2: " + topThreeCalories);
    }
}


