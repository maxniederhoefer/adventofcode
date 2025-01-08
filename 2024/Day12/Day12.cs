namespace adventofcode._2024;

public class Day12 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day12", "input.txt");

    public void GetFirstPart() {
        string[] map = File.ReadAllLines(path);

        int rows = map.Length;
        int cols = map[0].Length;
        bool[,] visited = new bool[rows, cols];

        int totalPrice = 0;

        for (int x = 0; x < rows; x++) {
            for (int y = 0; y < cols; y++) {
                if (!visited[x, y]) {
                    char plantType = map[x][y];
                    int area = 0;
                    int perimeter = 0;

                    CalculateRegion(map, visited, x, y, plantType, ref area, ref perimeter);

                    int price = area * perimeter;
                    totalPrice += price;
                }
            }
        }

        Console.WriteLine("Part 1: " + totalPrice);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }

    private void CalculateRegion(string[] map, bool[,] visited, int x, int y, char plantType, ref int area, ref int perimeter) {
        int rows = map.Length;
        int cols = map[0].Length;

        if (x < 0 || x >= rows || y < 0 || y >= cols) {
            perimeter++;
            return;
        }

        if (visited[x, y]) return;
        if (map[x][y] != plantType) {
            perimeter++;
            return;
        }

        visited[x, y] = true;
        area++;

        // up
        if (x == 0 || map[x - 1][y] != plantType) {
            perimeter++;
        } else {
            CalculateRegion(map, visited, x - 1, y, plantType, ref area, ref perimeter);
        }

        // down
        if (x == rows - 1 || map[x + 1][y] != plantType) {
            perimeter++;
        } else {
            CalculateRegion(map, visited, x + 1, y, plantType, ref area, ref perimeter);
        }

        // left
        if (y == 0 || map[x][y - 1] != plantType) {
            perimeter++;
        } else {
            CalculateRegion(map, visited, x, y - 1, plantType, ref area, ref perimeter);
        }

        // right
        if (y == cols - 1 || map[x][y + 1] != plantType) {
            perimeter++;
        } else {
            CalculateRegion(map, visited, x, y + 1, plantType, ref area, ref perimeter);
        }
    }
}
