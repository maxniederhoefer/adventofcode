namespace adventofcode._2024;

public class Day04 : IDay {
    private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2024\\Day04\\input.txt";

    public void GetFirstPart() {
        string[] input = File.ReadAllLines(path);

        string word = "XMAS";
        int count = 0;

        int rowCount = input.Length;
        int colCount = input[0].Length;

        int[] dirX = { 0, 1, 1, 1, 0, -1, -1, -1 };
        int[] dirY = { 1, 1, 0, -1, -1, -1, 0, 1 };

        for (int x = 0; x < rowCount; x++) {
            for (int y = 0; y < colCount; y++) {
                var letter = input[x][y];

                for (int z = 0; z < 8; z++) {
                    if (IsWordFound(input, rowCount, colCount, word, x, y, dirX[z], dirY[z])) {
                        count++;
                    }
                }
            }
        }

        Console.WriteLine("Part 1: " + count);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }

    public static bool IsWordFound(string[] input, int rowCount, int colCount, string word, int x, int y, int dirX, int dirY) {
        for (int i = 0; i < word.Length; i++) {
            int newX = x + i * dirX;
            int newY = y + i * dirY;

            if (newX < 0 || newY < 0 || newX >= rowCount || newY >= colCount || input[newX][newY] != word[i]) {
                return false;
            }
        }

        return true;
    }
}

