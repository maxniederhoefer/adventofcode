namespace adventofcode._2024;

public class Day13 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day13", "input.txt");

    public void GetFirstPart() {
        string[] lines = File.ReadAllLines(path);
        var machines = new List<Machine>();

        for (int i = 0; i < lines.Length; i += 4) {
            string[] buttonA = lines[i].Split(',');
            string[] buttonB = lines[i + 1].Split(',');
            string[] prize = lines[i + 2].Split(',');

            machines.Add(new Machine {
                AX = int.Parse(buttonA[0].Split('+')[1]),
                AY = int.Parse(buttonA[1].Split('+')[1]),
                BX = int.Parse(buttonB[0].Split('+')[1]),
                BY = int.Parse(buttonB[1].Split('+')[1]),
                PrizeX = int.Parse(prize[0].Split('=')[1]),
                PrizeY = int.Parse(prize[1].Split('=')[1])
            });
        }

        int maxPresses = 100;
        int totalTokens = 0;
        int prizes = 0;

        foreach (var machine in machines) {
            int? cost = SolveMachine(machine, maxPresses);
            if (cost != null) {
                totalTokens += cost.Value;
                prizes++;
            }
        }

        Console.WriteLine("Part 1: " + totalTokens);
    }

    public void GetSecondPart() {
        throw new NotImplementedException();
    }

    public class Machine {
        public int AX;
        public int AY;
        public int BX;
        public int BY;
        public int PrizeX;
        public int PrizeY;
    }

    private int? SolveMachine(Machine machine, int maxPresses) {
        int? minTokens = null;

        for (int a = 0; a <= maxPresses; a++) {
            for (int b = 0; b <= maxPresses; b++) {
                int x = a * machine.AX + b * machine.BX;
                int y = a * machine.AY + b * machine.BY;

                if (x == machine.PrizeX && y == machine.PrizeY) {
                    int cost = a * 3 + b * 1;
                    if (minTokens == null || cost < minTokens) {
                        minTokens = cost;
                    }
                }
            }
        }

        return minTokens;
    }
}

