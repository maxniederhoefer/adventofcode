namespace adventofcode._2021;

public class Day01 : IDay {
    private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2021\\Day01\\input.txt";
    public void GetFirstPart() {
        string[] lines = File.ReadAllLines(path);
        int result = 0;

        for (int i = 1; i < lines.Length; i++) {
            int prevNum = int.Parse(lines[i - 1]);
            int num = int.Parse(lines[i]);

            if (prevNum < num) result += 1;
        }
        Console.WriteLine(result);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }
}
