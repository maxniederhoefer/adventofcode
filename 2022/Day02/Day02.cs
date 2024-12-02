namespace adventofcode._2022;

public class Day02 : IDay {
    private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2022\\Day02\\input.txt";

    public void GetFirstPart() {
        int totalScore = 0;

        foreach (string line in File.ReadAllLines(path)) {
            var moves = line.Split(' ');

            char opponent = moves[0][0];
            char player = moves[1][0];

            totalScore += GetShapeScore(player) + GetOutcomeScore(opponent, player);
        }

        Console.WriteLine("Part1: " + totalScore);
    }

    public void GetSecondPart() {
        int totalScore = 0;

        foreach (string line in File.ReadAllLines(path)) {
            var moves = line.Split(' ');

            char opponent = moves[0][0];
            char desiredOutcome = moves[1][0];

            char player = GetPlayerShape(opponent, desiredOutcome);

            totalScore += GetShapeScore(player) + GetOutcomeScore(opponent, player);
        }

        Console.WriteLine("Part2: " + totalScore);
    }

    private int GetShapeScore(char shape) {
        return shape switch {
            'X' => 1, // Rock
            'Y' => 2, // Paper
            'Z' => 3, // Scissors
            _ => 0
        };
    }

    private int GetOutcomeScore(char opponent, char player) {
        return (opponent, player) switch {
            ('A', 'Y') or // Rock vs Paper
            ('B', 'Z') or // Paper vs Scissors
            ('C', 'X') => 6, // Scissors vs Rock

            ('A', 'X') or // Rock vs Rock
            ('B', 'Y') or // Paper vs Paper
            ('C', 'Z') => 3, // Scissors vs Scissors

            _ => 0 // Lose
        };
    }

    private char GetPlayerShape(char opponent, char desiredOutcome) {
        return desiredOutcome switch {
            'X' => opponent switch { 'A' => 'Z', 'B' => 'X', 'C' => 'Y' }, // Lose
            'Y' => opponent switch { 'A' => 'X', 'B' => 'Y', 'C' => 'Z' }, // Draw
            'Z' => opponent switch { 'A' => 'Y', 'B' => 'Z', 'C' => 'X' }, // Win
            _ => 'X'
        };
    }
}

