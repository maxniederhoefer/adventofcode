using static System.Formats.Asn1.AsnWriter;

namespace adventofcode._2024;

public class Day10 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day10", "input.txt");

    public void GetFirstPart() {
        List<string> map = new(File.ReadAllLines(path));
        int x = map.Count;
        int y = map[0].Length;
        int totalScore = 0;

        for (int xx = 0; xx < x; xx++) {
            for (int yy = 0; yy < y; yy++) {
                if (map[xx][yy] == '0') {
                    totalScore += CalculateTrailheadScore(map, xx, yy);
                }
            }
        }

        Console.WriteLine(totalScore);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }

    public int CalculateTrailheadScore(List<string> map, int startX, int startY) {
        int x = map.Count;
        int y = map[0].Length;
        var visited = new bool[x, y];
        int score = 0;

        void DFS(int xx, int yy, int currentValue) {
            if (xx < 0 || yy < 0 || xx >= x || yy >= y) return;
            if (visited[xx, yy] || map[xx][yy] - '0' != currentValue) return;

            visited[xx, yy] = true;

            if (currentValue == 9) {
                score++;
                return;
            }

            DFS(xx + 1, yy, currentValue + 1);
            DFS(xx - 1, yy, currentValue + 1);
            DFS(xx, yy + 1, currentValue + 1);
            DFS(xx, yy - 1, currentValue + 1);
        }

        DFS(startX, startY, 0);

        return score;
    }

    
}

