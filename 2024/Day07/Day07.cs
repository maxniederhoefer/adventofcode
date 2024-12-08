namespace adventofcode._2024;

public class Day07 : IDay {
    private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2024\\Day07\\input.txt";

    public void GetFirstPart() {
        long total = 0;

        foreach (var line in File.ReadLines(path)) {
            var parts = line.Split(':');
            long targetValue = long.Parse(parts[0].Trim());
            var numbers = Array.ConvertAll(parts[1].Trim().Split(' '), long.Parse);

            if (CanMatchTargetValue(numbers, targetValue, 0, numbers[0])) {
                total += targetValue;
            }
        }

        Console.WriteLine("Part 1: " + total);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }

    public bool CanMatchTargetValue(long[] numbers, long targetValue, int index, long currentValue) {
        int operatorCount = numbers.Length - 1;

        if (index == operatorCount) {
            return currentValue == targetValue;
        }

        long nextValue = numbers[index + 1];

        // +
        if (CanMatchTargetValue(numbers, targetValue, index + 1, currentValue + nextValue)) {
            return true;
        }

        // *
        if (CanMatchTargetValue(numbers, targetValue, index + 1, currentValue * nextValue)) {
            return true;
        }

        return false;
    }
}

