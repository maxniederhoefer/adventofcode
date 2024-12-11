namespace adventofcode._2023;

public class Day01 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2023", "Day01", "input.txt");

    public void GetFirstPart() {
        string[] lines = File.ReadAllLines(path);
        List<int> ints = new();

        foreach (var line in lines) {
            int num1 = GetFirstDigit(line);
            int num2 = GetLastDigit(line);
            int number = int.Parse($"{num1}{num2}");

            ints.Add(number);
        }

        Console.WriteLine("Part1: " + ints.Sum());
    }

    public void GetSecondPart() {
        string[] lines = File.ReadAllLines(path);

        Dictionary<string, string> numbers = new() {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
            { "1", "1" },
            { "2", "2" },
            { "3", "3" },
            { "4", "4" },
            { "5", "5" },
            { "6", "6" },
            { "7", "7" },
            { "8", "8" },
            { "9", "9" }
        };

        int sum = 0;

        foreach (string line in lines) {
            int firstIndex = line.Length;
            int lastIndex = -1;
            string firstNumber = "";
            string lastNumber = "";

            foreach (var number in numbers) {
                int numberIndex = line.IndexOf(number.Key);
                int numberLastIndex = line.LastIndexOf(number.Key);

                if (numberIndex != -1 && numberIndex < firstIndex) {
                    firstNumber = numbers[number.Value];
                    firstIndex = numberIndex;
                }

                if (numberLastIndex != -1 && numberLastIndex > lastIndex) {
                    lastNumber = numbers[number.Value];
                    lastIndex = numberLastIndex;
                }
            }

            sum += int.Parse(firstNumber + lastNumber);
        }

        Console.WriteLine("Part2: " + sum);
    }

    private int GetFirstDigit(string line) {
        for (int i = 0; i < line.Length; i++) {
            if (int.TryParse(line[i].ToString(), out int num)) return num;
        }

        throw new Exception("ERROR (GetFirstDigit): " + line);
    }

    private int GetLastDigit(string line) {
        for (int i = line.Length - 1; i >= 0; i--) {
            if (int.TryParse(line[i].ToString(), out int num)) return num;
        }

        throw new Exception("ERROR (GetLastDigit): " + line);
    }
}
