using System.Collections.Generic;

namespace adrianbanks.GameOfLife
{
    internal static class GridNavigation
    {
        public static IEnumerable<Coordinate> AllCells(Dimension dimension)
        {
            for (var y = 0; y < dimension.Height; y++)
            for (var x = 0; x < dimension.Width; x++)
            {
                yield return new Coordinate(x, y);
            }
        }

        public static IEnumerable<Coordinate> SurroundingCells(Coordinate center)
        {
            yield return new Coordinate(center.X - 1, center.Y - 1);
            yield return new Coordinate(center.X, center.Y - 1);
            yield return new Coordinate(center.X + 1, center.Y - 1);

            yield return new Coordinate(center.X - 1, center.Y);
            yield return new Coordinate(center.X + 1, center.Y);

            yield return new Coordinate(center.X - 1, center.Y + 1);
            yield return new Coordinate(center.X, center.Y + 1);
            yield return new Coordinate(center.X + 1, center.Y + 1);
        }
    }
}
