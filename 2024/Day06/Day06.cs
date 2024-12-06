namespace adventofcode._2024;

public class Day06 : IDay {
    private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2024\\Day06\\input.txt";

    public void GetFirstPart() {
        string[] map = File.ReadAllLines(path);

        int startX = 0;
        int startY = 0;
        char startDirection = '^';

        for (int y = 0; y < map.Length; y++) {
            for (int x = 0; x < map[y].Length; x++) {
                if (startDirection == map[y][x]) {
                    startX = x;
                    startY = y;
                    break;
                }
            }
        }

        Dictionary<char, (int dx, int dy)> directions = new() {
            { '^', (0, -1) },
            { '>', (1, 0) },
            { 'v', (0, 1) },
            { '<', (-1, 0) }
        };

        char currentDirection = startDirection;
        int posX = startX;
        int posY = startY;
        HashSet<(int x, int y)> visited = new();

        visited.Add((posX, posY));

        while (posX >= 0 && posX < map[0].Length && posY >= 0 && posY < map.Length) {
            int nextX = posX + directions[currentDirection].dx;
            int nextY = posY + directions[currentDirection].dy;

            if (nextX < 0 || nextX >= map[0].Length || nextY < 0 || nextY >= map.Length) {
                break; // Labyrinth verlassen
            }

            if (map[nextY][nextX] == '#') {
                currentDirection = TurnRight(currentDirection);
            } else {
                posX = nextX;
                posY = nextY;
                visited.Add((posX, posY));
            }

            visited.Add((posX, posY));
        }

        Console.WriteLine("Part 1: " + visited.Count);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }

    public char TurnRight(char currentDir) {
        return currentDir switch {
            '^' => '>',
            '>' => 'v',
            'v' => '<',
            '<' => '^',
            _ => currentDir
        };
    }
}

