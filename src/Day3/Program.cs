string[] inputFile = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));

Console.WriteLine($"Solution of Task one: {SolveTaskOne(inputFile)}");
Console.WriteLine($"Solution of Task two: {SolveTaskTwo(inputFile)}");

int SolveTaskOne(string[] inputFile)
{
    string gammaRate = string.Empty;
    string epsilonRate = string.Empty;

    for (int i = 0; i < inputFile[0].Length; i++)
    {
        int mostCommon = inputFile.Select(x => x[i] == '0' ? 0 : 1)
        .GroupBy(b => b)
        .OrderByDescending(gp => gp.Count())
        .Select(g => g.Key)
        .First<int>();

        gammaRate += mostCommon;
        epsilonRate += 1 - mostCommon;
    }

    return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
}

int SolveTaskTwo(string[] inputFile)
{
    string[] inputFiltered = inputFile;

    for (int i = 0; i < inputFile[0].Length; i++)
    {
        string[] leadingZeros = inputFiltered.Where(x => x[i] == '0').ToArray();
        string[] leadingOnes = inputFiltered.Where(x => x[i] == '1').ToArray();

        if (leadingZeros.Length > leadingOnes.Length)
        {
            inputFiltered = leadingZeros;
        }
        else
        {
            inputFiltered = leadingOnes;
        }
    }

    int oxygenRating = Convert.ToInt32(inputFiltered.First(), 2);
    inputFiltered = inputFile;

    for (int i = 0; i < inputFile[0].Length; i++)
    {
        if (inputFiltered.Length == 1)
        {
            break;
        }

        string[] leadingZeros = inputFiltered.Where(x => x[i] == '0').ToArray();
        string[] leadingOnes = inputFiltered.Where(x => x[i] == '1').ToArray();

        if (leadingZeros.Length <= leadingOnes.Length)
        {
            inputFiltered = leadingZeros;
        }
        else
        {
            inputFiltered = leadingOnes;
        }
    }

    int co2Rating = Convert.ToInt32(inputFiltered.First(), 2);
    return co2Rating * oxygenRating;
}