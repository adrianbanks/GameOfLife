namespace adrianbanks.GameOfLife;

internal sealed class Coordinate(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public int Age { get; }

    public Coordinate(Coordinate coordinate) : this(coordinate.X, coordinate.Y)
    {
        Age = coordinate.Age + 1;
    }

    public override bool Equals(object? obj) => Equals(this, obj as Coordinate);

    public override int GetHashCode() => X + Y;

    private static bool Equals(Coordinate? x, Coordinate? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
        {
            return false;
        }

        return x.X == y.X && x.Y == y.Y;
    }

    public override string ToString() => $"({X}, {Y})";
}
