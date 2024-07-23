using System.IO;

namespace adventofcode._2023;

public class Day01 : IDay {
    private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2023\\Day01\\input.txt";
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
        throw new NotImplementedException();
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
