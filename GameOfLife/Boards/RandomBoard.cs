using System;
using System.Collections.Generic;

namespace adrianbanks.GameOfLife.Boards
{
    internal sealed class RandomBoard
    {
        private readonly Random _random = new(DateTime.UtcNow.Millisecond);

        public Board Generate(Dimension dimension)
        {
            var maxCells = dimension.Width * dimension.Height;
            var numberOfLiveCells = _random.Next(maxCells / 2);
            var liveCells = GenerateCells(dimension, numberOfLiveCells);
            return new Board(dimension, [.. liveCells]);
        }

        private IEnumerable<Coordinate> GenerateCells(Dimension dimension, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var x = _random.Next(dimension.Width);
                var y = _random.Next(dimension.Height);
                yield return new Coordinate(x, y);
            }
        }
    }
}
