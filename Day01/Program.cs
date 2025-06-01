string[] sequence = File.ReadAllText("input.txt").Split(", ");

int x = 0;
int y = 0;
int d = 0;
string directions = "NESW";

int fx = 0;
int fy = 0;
bool firstTwiceVisitedFound = false;
HashSet<string> visited = [];

foreach (string instruction in sequence)
{
    int blocks = int.Parse(instruction[1..]);
    int directionIncrement = instruction[0] == 'L' ? -1 : 1;

    d = (d + directionIncrement) % directions.Length;
    if (d == -1)
    {
        d = directions.Length - 1;
    }


    int xChange = directions[d] == 'E' ? blocks : directions[d] == 'W' ? -blocks : 0;
    int yChange = directions[d] == 'N' ? blocks : directions[d] == 'S' ? -blocks : 0;

    if (!firstTwiceVisitedFound)
    {
        firstTwiceVisitedFound = UpdateVisited(x, y, xChange, yChange, ref fx, ref fy);
    }

    x += xChange;
    y += yChange;
}

Console.WriteLine($"P1 Easter Bunny HQ is {Math.Abs(x) + Math.Abs(y)} blocks away");
Console.WriteLine($"P2 First location visited twice {Math.Abs(fx) + Math.Abs(fy)} blocks away");

bool UpdateVisited(int cx, int cy, int dx, int dy, ref int ox, ref int oy)
{
    if (dx != 0)
    {
        if (cx > cx + dx)
        {
            for (int i = cx; i > cx + dx; i--)
            {
                if (!visited.Add($"x{i}y{cy}"))
                {
                    ox = i;
                    oy = cy;
                    return true;
                }
            }
        }
        else
        {
            for (int i = cx; i < cx + dx; i++)
            {
                if (!visited.Add($"x{i}y{cy}"))
                {
                    ox = i;
                    oy = cy;
                    return true;
                }
            }
        }
    }
    
    if (cy != 0)
    {
        if (cy > cy + dy)
        {
            for (int i = cy; i > cy + dy; i--)
            {
                if (!visited.Add($"x{cx}y{i}"))
                {
                    ox = cx;
                    oy = i;
                    return true;
                }
            }
        }
        else
        {
            for (int i = cy; i < cy + dy; i++)
            {
                if (!visited.Add($"x{cx}y{i}"))
                {
                    ox = cx;
                    oy = i;
                    return true;
                }
            }
        }
    }

    return false;
}