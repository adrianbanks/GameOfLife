namespace adrianbanks.GameOfLife
{
    internal sealed record Dimension(int Width, int Height)
    {
        public bool Contains(Coordinate coordinate) => coordinate.X >= 0 && coordinate.X < Width && coordinate.Y >= 0 && coordinate.Y < Height;

        public static Dimension Create(int? width, int? height) => Create(new Dimension(30, 30), width, height);

        public static Dimension Create(Dimension initialSize, int? width, int? height)
        {
            var dimension = initialSize;

            if (width != null)
            {
                dimension = new Dimension(width.Value, dimension.Height);
            }

            if (height != null)
            {
                dimension = new Dimension(dimension.Width, height.Value);
            }

            return dimension;
        }
    }
}
