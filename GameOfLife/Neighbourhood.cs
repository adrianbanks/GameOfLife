using System.Collections.Generic;
using System.Linq;
using static adrianbanks.GameOfLife.GridNavigation;

namespace adrianbanks.GameOfLife
{
    internal sealed class Neighbourhood
    {
        private readonly HashSet<Coordinate> liveCells;
        private readonly Coordinate center;
        private readonly bool currentCellIsAlive;

        public Neighbourhood(HashSet<Coordinate> liveCells, Coordinate center)
        {
            this.liveCells = liveCells;
            this.center = center;
            currentCellIsAlive = liveCells.Contains(center);
        }

        public IEnumerable<Coordinate> NextGenerationCells()
        {
            var numberOfLiveNeighbours = SurroundingCells(center).Count(liveCells.Contains);

            return numberOfLiveNeighbours switch
            {
                2 or 3 when currentCellIsAlive => new[] { center },
                3 when !currentCellIsAlive => new[] { center },
                _ => Enumerable.Empty<Coordinate>()
            };
        }
    }
}
