namespace adventofcode;

public class Day02 : IDay {
    private const string path = $"C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2023\\Day02\\input.txt";

    public void GetFirstPart() {
        string[] lines = File.ReadAllLines(path);
        List<int> erg = new();

        var colorLimits = new Dictionary<string, int> {
            { "green", 13 },
            { "blue", 14 },
            { "red", 12 }
        };

        foreach (var line in lines) {
            string game = line.Split(":")[0].Replace("Game", "").Trim();
            bool isPossible = true;

            string[] rounds = line.Split(":")[1].Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var round in rounds) {
                var items = round.Split(",", StringSplitOptions.TrimEntries);

                foreach (var item in items) {
                    string[] parts = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int cubes = int.Parse(parts[0]);
                    string color = parts[1];

                    if (colorLimits.TryGetValue(color, out int maxCubes)) {
                        if (cubes > maxCubes) {
                            isPossible = false;
                            break;
                        }
                    }
                }

                if (!isPossible) break;
            }

            if (isPossible) {
                erg.Add(int.Parse(game));
            }
        }

        Console.WriteLine("Part1: " + erg.Sum());
    }

    public void GetSecondPart() {
        string[] lines = File.ReadAllLines(path);
        List<int> erg = new();

        foreach (var line in lines) {
            // game start
            var maxCubes = new Dictionary<string, int> {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };

            string roundsData = line.Split(":")[1];
            var rounds = roundsData.Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var round in rounds) {
                var items = round.Split(",", StringSplitOptions.TrimEntries);

                foreach (var item in items) {
                    var parts = item.Split(" ");
                    int cubes = int.Parse(parts[0]);
                    string color = parts[1];

                    if (maxCubes.TryGetValue(color, out int value) && cubes > value) {
                        maxCubes[color] = cubes;
                    }
                }
            }

            erg.Add(maxCubes["red"] * maxCubes["green"] * maxCubes["blue"]);
        }

        Console.WriteLine("Part2: " + erg.Sum());
    }
}

