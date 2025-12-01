namespace adventofcode._2025;

public class Day01 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2025", "Day01", "input.txt");
    public void GetFirstPart() {
        string[] rotations = File.ReadAllLines(path);

        int position = 50;
        int count = 0;

        foreach (string rotation in rotations) {
            char direction = rotation[0];
            int point = int.Parse(rotation[1..]);

            if (direction == 'L') {
                position = (position - point) % 100;
                if (position < 0) position += 100;
            } else if (direction == 'R') {
                position = (position + point) % 100;
            }

            if (position == 0) count++;
        }

        Console.WriteLine("Part 1: " + count);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }
}

