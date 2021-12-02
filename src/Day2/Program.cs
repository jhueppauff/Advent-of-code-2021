string[] inputFile = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));

Console.WriteLine($"Solution of Task One: {SolveTaskOne(inputFile)}");
Console.WriteLine($"Solution of Task Two: {SolveTaskTwo(inputFile)}");

int SolveTaskOne(string[] commands)
{
    Position position = new Position();
    foreach (string command in commands)
    {
        string[] course = command.Split(' ');

        switch (course[0].ToLowerInvariant())
        {
            case "forward":
                position.XPosition += Convert.ToInt32(course[1]);
                break;
            case "up":
                position.Depth -= Convert.ToInt32(course[1]);
                break;
            case "down":
                position.Depth += Convert.ToInt32(course[1]);
                break;
            default:
                throw new Exception("Unknown command");
        }
    }

    return position.MultiplyPosition();
}

int SolveTaskTwo(string[] commands) 
{
    Position position = new Position();
    foreach (string command in commands)
    {
        string[] course = command.Split(' ');

        switch (course[0].ToLowerInvariant())
        {
            case "forward":
                position.XPosition += Convert.ToInt32(course[1]);
                position.Depth += position.Aim * Convert.ToInt32(course[1]);
                break;
            case "up":
                position.Aim -= Convert.ToInt32(course[1]);
                break;
            case "down":
                position.Aim += Convert.ToInt32(course[1]);
                break;
            default:
                throw new Exception("Unknown command");
        }
    }

    return position.MultiplyPosition();
}