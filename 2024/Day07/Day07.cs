namespace adventofcode._2024;

public class Day07 : IDay {
    private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2024\\Day07\\input.txt";

    public void GetFirstPart() {
        long total = 0;

        foreach (var line in File.ReadLines(path)) {
            var parts = line.Split(':');
            long targetValue = long.Parse(parts[0].Trim());
            var numbers = Array.ConvertAll(parts[1].Trim().Split(' '), long.Parse);

            if (CanMatchTargetValue(numbers, targetValue, 0, numbers[0], false)) {
                total += targetValue;
            }
        }

        Console.WriteLine("Part 1: " + total);
    }

    public void GetSecondPart() {
        long total = 0;

        foreach (var line in File.ReadLines(path)) {
            var parts = line.Split(':');
            long targetValue = long.Parse(parts[0].Trim());
            var numbers = Array.ConvertAll(parts[1].Trim().Split(' '), long.Parse);

            if (CanMatchTargetValue(numbers, targetValue, 0, numbers[0], true)) {
                total += targetValue;
            }
        }

        Console.WriteLine("Part 2: " + total);
    }

    public bool CanMatchTargetValue(long[] numbers, long targetValue, int index, long currentValue, bool includeConcatenation) {
        int operatorCount = numbers.Length - 1;

        if (index == operatorCount) {
            return currentValue == targetValue;
        }

        long nextValue = numbers[index + 1];

        // +
        if (CanMatchTargetValue(numbers, targetValue, index + 1, currentValue + nextValue, includeConcatenation)) {
            return true;
        }

        // *
        if (CanMatchTargetValue(numbers, targetValue, index + 1, currentValue * nextValue, includeConcatenation)) {
            return true;
        }

        // ||
        if (includeConcatenation) {
            long concatenatedValue = long.Parse(currentValue.ToString() + nextValue.ToString());
            if (CanMatchTargetValue(numbers, targetValue, index + 1, concatenatedValue, includeConcatenation)) {
                return true;
            }
        }

        return false;
    }
}

