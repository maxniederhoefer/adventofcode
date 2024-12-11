namespace adventofcode._2024;

public class Day09 : IDay {
    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "2024", "Day09", "input.txt");

    public void GetFirstPart() {
        string input = File.ReadAllText(path).Trim();

        List<string> disk = new();
        int fileId = 0;

        for (int i = 0; i < input.Length; i += 2) {
            if (i + 1 < input.Length) {
                int fileSize = int.Parse(input[i].ToString());
                int freeSize = int.Parse(input[i + 1].ToString());

                for (int j = 0; j < fileSize; j++) {
                    disk.Add(fileId.ToString());
                }

                for (int j = 0; j < freeSize; j++) {
                    disk.Add(".");
                }
            } else {
                int fileSize = int.Parse(input[i].ToString());

                for (int j = 0; j < fileSize; j++) {
                    disk.Add(fileId.ToString());
                }
            }

            fileId++;
        }

        Console.WriteLine("1: " + string.Join("", disk));

        List<string> newDisk = new(disk.Count);
        for (int i = 0; i < disk.Count; i++) {
            newDisk.Add(".");
        }

        int rightIndex = disk.Count - 1;

        for (int leftIndex = 0; leftIndex < newDisk.Count; leftIndex++) {
            if (leftIndex >= rightIndex) {
                break;
            }

            if (disk[leftIndex] != ".") {
                newDisk[leftIndex] = disk[leftIndex];
            } else {
                while (rightIndex > leftIndex && disk[rightIndex] == ".") {
                    rightIndex--;
                }

                if (rightIndex > leftIndex) {
                    string valueToMove = disk[rightIndex];

                    newDisk[leftIndex] = valueToMove;

                    disk[rightIndex] = ".";
                } else {
                    break;
                }
            }
        }

        Console.WriteLine("2: " + string.Join("", disk));

        long checksum = 0;
        for (int i = 0; i < newDisk.Count; i++) {
            if (newDisk[i] != ".") {
                int fileID = int.Parse(newDisk[i]);
                checksum += (long)i * fileID;
            }
        }

        Console.WriteLine("Part 1: " + checksum);
    }

    public void GetSecondPart() {
        string input = File.ReadAllText(path).Trim();

        List<string> disk = new();
        int fileId = 0;

        for (int i = 0; i < input.Length; i += 2) {
            if (i + 1 < input.Length) {
                int fileSize = int.Parse(input[i].ToString());
                int freeSize = int.Parse(input[i + 1].ToString());

                for (int j = 0; j < fileSize; j++) {
                    disk.Add(fileId.ToString());
                }

                for (int j = 0; j < freeSize; j++) {
                    disk.Add(".");
                }
            } else {
                int fileSize = int.Parse(input[i].ToString());

                for (int j = 0; j < fileSize; j++) {
                    disk.Add(fileId.ToString());
                }
            }

            fileId++;
        }

        Console.WriteLine(string.Join("", disk));

        List<string> newDisk = new(disk);

        for (int i = newDisk.Count - 1; i >= 0;) {
            if (newDisk[i] != ".") {
                string currentFileId = newDisk[i];

                int blockStart = i;
                while (blockStart > 0 && newDisk[blockStart - 1] == currentFileId) {
                    blockStart--;
                }
                int blockSize = i - blockStart + 1;

                bool blockMoved = false;

                for (int j = 0; j <= newDisk.Count - 1; j++) {
                    if (j + blockSize > newDisk.Count || j + blockSize > blockStart) {
                        break;
                    }

                    bool fits = true;
                    for (int z = 0; z < blockSize; z++) {
                        if (newDisk[j + z] != ".") {
                            fits = false;
                            break;
                        }
                    }

                    if (fits) {
                        for (int k = 0; k < blockSize; k++) {
                            newDisk[j + k] = currentFileId;
                        }

                        for (int k = blockStart; k <= i; k++) {
                            newDisk[k] = ".";
                        }

                        blockMoved = true;
                        break;
                    }
                }

                if (blockMoved) {
                    //Console.WriteLine(string.Join("", newDisk));
                    i--;
                } else {
                    i -= blockSize;
                }
            } else {
                i--;
            }
        }

        long checksum = 0;
        for (int i = 0; i < newDisk.Count; i++) {
            if (newDisk[i] != ".") {
                int blockFileId = int.Parse(newDisk[i]);
                checksum += (long)i * blockFileId;
            }
        }

        Console.WriteLine("Part 2: " + checksum);
    }
}

