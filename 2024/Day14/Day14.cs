using System.Text.RegularExpressions;

namespace adventofcode._2024;

public class Day14 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day14", "input.txt");

    public void GetFirstPart() {
        string[] lines = File.ReadAllLines(path);
        List<Robot> robots = new();

        var regex = new Regex(@"p=(\d+),(\d+) v=(-?\d+),(-?\d+)");

        foreach (var line in lines) {
            var match = regex.Match(line);

            if (match.Success) {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                int vx = int.Parse(match.Groups[3].Value);
                int vy = int.Parse(match.Groups[4].Value);
                robots.Add(new Robot(x, y, vx, vy));
            }
        }

        int time = 100;
        int width = 101;
        int height = 103;

        for (int i = 0; i < time; i++) {
            foreach (var robot in robots) {
                robot.Move(width, height);
            }
        }

        int centerX = width / 2;
        int centerY = height / 2;

        var quadrantCounts = new int[4];

        foreach (var robot in robots) {
            if (robot.PositionX != centerX && robot.PositionY != centerY) {
                int quadrant = GetQuadrant(robot, centerX, centerY);
                quadrantCounts[quadrant]++;
            }
        }

        int safetyFactor = 1;
        foreach (var count in quadrantCounts) {
            safetyFactor *= count;
        }

        Console.WriteLine("Part 1: " + safetyFactor);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }

    class Robot(int positionX, int positionY, int velocityX, int velocityY) {
        public int PositionX { get; set; } = positionX;
        public int PositionY { get; set; } = positionY;
        public int VelocityX { get; set; } = velocityX;
        public int VelocityY { get; set; } = velocityY;

        public void Move(int widht, int height) {
            PositionX = (PositionX + VelocityX + widht) % widht;
            PositionY = (PositionY + VelocityY + height) % height;
        }
    }

    private int GetQuadrant(Robot robot, int centerX, int centerY) {
        if (robot.PositionX < centerX && robot.PositionY < centerY) {
            return 0; // top left
        }

        if (robot.PositionX >= centerX && robot.PositionY < centerY) {
            return 1; // top right
        }

        if (robot.PositionX < centerX && robot.PositionY >= centerY) {
            return 2; // bottom left
        }

        return 3; // bottom right
    }
}
