string[] instructions = File.ReadAllLines("input.txt");

PartOne();
PartTwo();

void PartOne()
{
    int[,] keypad = new[,]
    {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 9 }
    };

    int px = 1;
    int py = 1;

    int[] passcode = new int[instructions.Length];

    for (int index = 0; index < instructions.Length; index++)
    {
        foreach (char ch in instructions[index])
        {
            switch (ch)
            {
                case 'U':
                    py = Math.Max(0, py - 1);
                    break;
                case 'D':
                    py = Math.Min(keypad.GetLength(0) - 1, py + 1);
                    break;
                case 'L':
                    px = Math.Max(0, px - 1);
                    break;
                case 'R':
                    px = Math.Min(keypad.GetLength(1) - 1, px + 1);
                    break;
            }
        }

        passcode[index] = keypad[py, px];
    }

    Console.WriteLine($"P1 passcode = {string.Join(String.Empty, passcode)}");
}

void PartTwo()
{
    const char BLANK = 'X';
    char[,] keypad = new[,]
    {
        { 'X', 'X', '1', 'X', 'X' },
        { 'X', '2', '3', '4', 'X' },
        { '5', '6', '7', '8', '9' },
        { 'X', 'A', 'B', 'C', 'X' },
        { 'X', 'X', 'D', 'X', 'X' },
    };

    int px = 1;
    int py = 1;

    char[] passcode = new char[instructions.Length];

    for (int index = 0; index < instructions.Length; index++)
    {
        foreach (char ch in instructions[index])
        {
            int temp;
            switch (ch)
            {
                case 'U':
                    temp = Math.Max(0, py - 1);
                    if (keypad[temp, px] != BLANK)
                    {
                        py = temp;
                    }

                    break;
                case 'D':
                    temp = Math.Min(keypad.GetLength(0) - 1, py + 1);
                    if (keypad[temp, px] != 'X')
                    {
                        py = temp;
                    }

                    break;
                case 'L':
                    temp = Math.Max(0, px - 1);
                    if (keypad[py, temp] != 'X')
                    {
                        px = temp;
                    }
                    break;
                case 'R':
                    temp = Math.Min(keypad.GetLength(1) - 1, px + 1);
                    if (keypad[py, temp] != 'X')
                    {
                        px = temp;
                    }
                    break;
            }
        }

        passcode[index] = keypad[py, px];
    }

    Console.WriteLine($"P2 passcode = {string.Join(String.Empty, passcode)}");
}