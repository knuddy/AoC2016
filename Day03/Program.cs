using System.Text.RegularExpressions;

List<int[]> triangles = File
    .ReadAllLines("input.txt")
    .Select(s => Regex.Matches(s, "[0-9]+"))
    .Select(m => m.Select(n => int.Parse(n.Value)).ToArray())
    .ToList();

PartOne();
PartTwo();

void PartOne()
{
    Console.WriteLine($"P1 possible triangles {triangles.Count(sides => TestTriangle(sides[0], sides[1], sides[2]))}");
}

void PartTwo()
{
    int possible = 0;

    for (int i = 0; i < triangles.Count; i += 3)
    {
        for (int j = 0; j < 3; j++)
        {
            if (TestTriangle(triangles[i + 0][j], triangles[i + 1][j], triangles[i + 2][j]))
            {
                possible++;
            }
        }
    }
    
    Console.WriteLine($"P2 possible triangles {possible} ");
}

bool TestTriangle(int a, int b, int c)
{
    return a + b > c && b + c > a && a + c > b;
}