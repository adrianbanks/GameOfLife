using System;
using System.Collections.Generic;
using System.Linq;

namespace adrianbanks.GameOfLife.Boards
{
    internal sealed class RandomBoard
    {
        private readonly Random random;

        public RandomBoard() => random = new Random(DateTime.UtcNow.Millisecond);

        public Board Generate(Dimension dimension)
        {
            var maxCells = dimension.Width * dimension.Height;
            var numberOfLiveCells = random.Next(maxCells / 2);
            var liveCells = GenerateCells(dimension, numberOfLiveCells);
            return new(dimension, liveCells.ToArray());
        }

        private IEnumerable<Coordinate> GenerateCells(Dimension dimension, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var x = random.Next(dimension.Width);
                var y = random.Next(dimension.Height);
                yield return new Coordinate(x, y);
            }
        }
    }
}
