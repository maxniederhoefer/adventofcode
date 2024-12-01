namespace adventofcode._2024.Day01 {
    public class Day01 : IDay {
        private const string path = "C:\\Users\\max.niederhoefer\\source\\2delete\\adventofcode\\2024\\Day01\\input.txt";

        public void GetFirstPart() {
            List<int> leftList = new();
            List<int> rightList = new();

            foreach (string line in File.ReadLines(path)) {
                string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2) {
                    continue;
                }

                if (int.TryParse(parts[0], out int left) && int.TryParse(parts[1], out int right)) {
                    leftList.Add(left);
                    rightList.Add(right);
                }
            }

            if (leftList.Count != rightList.Count) {
                return;
            }

            leftList.Sort();
            rightList.Sort();

            int totalDistance = 0;
            for (int i = 0; i < leftList.Count; i++) {
                totalDistance += Math.Abs(leftList[i] - rightList[i]);
            }

            Console.WriteLine("Part1: " + totalDistance);
        }

        public void GetSecondPart() {
            throw new NotImplementedException();
        }
    }
}
