namespace adrianbanks.GameOfLife
{
    internal sealed record Dimension(int Width, int Height)
    {
        public bool Contains(Coordinate coordinate) => coordinate.X > 0 && coordinate.X < Width && coordinate.Y > 0 && coordinate.Y < Height;
    }
}
