string[] inputFile = (await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"))).FirstOrDefault().Split(',');
int[] positions = (Array.ConvertAll(inputFile, x => Int32.Parse(x)));

Console.WriteLine($"Solution Task One: {SolveTaskOne(positions)}");
Console.WriteLine($"Solution Task Two: {SolveTaskTwo(positions)}");

int SolveTaskOne(int[] positions)
{
    int maximumPosition = positions.Max();
    int[] results = new int[maximumPosition];

    for (int i = 1; i < maximumPosition; i++)
    {
        int result = 0;

        for (int j = 0; j < positions.Length; j++)
        {
            result += Math.Abs(positions[j] - i);
        }

        results[i] = result;
    }

    return Convert.ToInt32(results.Where(x => x != 0).Min());
}

int SolveTaskTwo(int[] positions)
{
    Dictionary<int, int> keyValuePairs = new();
    int maximumPosition = positions.Max();
    int[] results = new int[maximumPosition];

    for (int i = 1; i < maximumPosition; i++)
    {
        int result = 0;

        for (int j = 0; j < positions.Length; j++)
        {
            int amountOfPositionChanges = Math.Abs(positions[j] - i);

            if (keyValuePairs.ContainsKey(amountOfPositionChanges))
            {
                result += keyValuePairs[amountOfPositionChanges];
            }
            else
            {
                int sum = Enumerable.Range(1, amountOfPositionChanges).ToArray().Sum();
                keyValuePairs.Add(amountOfPositionChanges, sum);
                result += sum;
            }
        }

        results[i] = result;
    }

    return Convert.ToInt32(results.Where(x => x != 0).Min());
}