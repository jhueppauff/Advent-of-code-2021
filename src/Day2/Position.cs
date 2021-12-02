public class Position
{
    public Position()
    {
        Depth = 0;
        XPosition = 0;
    }

    public int Depth { get; set; }

    public int XPosition { get; set; }

    public int Aim { get; set; }

    public int MultiplyPosition()
    {
        return XPosition * Depth;
    }
}