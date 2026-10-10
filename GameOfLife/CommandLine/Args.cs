namespace adrianbanks.GameOfLife.CommandLine;

internal sealed class Args(
    int? width,
    int? height,
    int iterations,
    int initialDelay,
    int delay,
    string baseColor,
    string backColor,
    string? pattern,
    string? qrCode)
{
    public int? Width => width;

    public int? Height => height;

    public int Iterations => iterations;

    public int InitialDelay => initialDelay;

    public int Delay => delay;

    public string BaseColor => baseColor;

    public string BackColor => backColor;

    public string? Pattern => pattern;

    public string? QrCode => qrCode;
}
