string[] inputFile = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));
int[] measurements = (Array.ConvertAll(inputFile, x => Int32.Parse(x)));

Console.WriteLine($"Solution of Task One: {SolveTaskOne(measurements)}");
Console.WriteLine($"Solution of Task Two: {SolveTaskTwo(measurements)}");

int SolveTaskOne(int[] measurements)
{
    int countOfMeasurementIncreases = 0;

    for (int i = 1; i < measurements.Count(); i++)
    {
        if (measurements[i] > measurements[i - 1])
        {
            countOfMeasurementIncreases++;
        }
    }

    return countOfMeasurementIncreases;
}

int SolveTaskTwo(int[] measurements)
{
    int countOfMeasurementIncreases = 0;

    for (int i = 1; i < measurements.Count() - 2; i++)
    {
        int currentMeasurement = measurements[i - 1] + measurements[i] + measurements[i + 1];
        int nextMeasurement = measurements[i] + measurements[i + 1] + measurements[i + 2];

        if (currentMeasurement < nextMeasurement)
        {
            countOfMeasurementIncreases++;
        }
    }

    return countOfMeasurementIncreases;
}