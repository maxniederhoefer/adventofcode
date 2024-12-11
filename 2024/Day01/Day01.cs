namespace adventofcode._2024;

public class Day01 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day01", "input.txt");

    public void GetFirstPart() {
        List<int> leftList = new();
        List<int> rightList = new();

        foreach (string line in File.ReadLines(path)) {
            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[1]));
        }

        leftList.Sort();
        rightList.Sort();

        int totalDistance = 0;
        for (int i = 0; i < leftList.Count; i++) {
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }

        Console.WriteLine("Part 1: " + totalDistance);
    }

    public void GetSecondPart() {
        List<int> leftList = new();
        List<int> rightList = new();

        foreach (string line in File.ReadLines(path)) {
            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[1]));
        }

        int similarityScore = CalculateSimilarityScore(leftList, rightList);
        Console.WriteLine("Part 2: " + similarityScore);
    }

    static int CalculateSimilarityScore(List<int> leftList, List<int> rightList) {
        Dictionary<int, int> rightCount = new();

        foreach (int num in rightList) {
            if (rightCount.ContainsKey(num)) {
                rightCount[num]++;
            } else {
                rightCount[num] = 1;
            }
        }

        int similarityScore = 0;
        foreach (int num in leftList) {
            if (rightCount.ContainsKey(num)) {
                similarityScore += num * rightCount[num];
            }
        }

        return similarityScore;
    }
}
