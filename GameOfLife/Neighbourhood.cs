using System.Collections.Generic;
using System.Linq;
using static adrianbanks.GameOfLife.GridNavigation;

namespace adrianbanks.GameOfLife;

internal sealed class Neighbourhood(HashSet<Coordinate> liveCells, Coordinate center)
{
    private readonly bool _currentCellIsAlive = liveCells.Contains(center);

    public IEnumerable<Coordinate> NextGenerationCells()
    {
        var numberOfLiveNeighbours = SurroundingCells(center).Count(liveCells.Contains);
        var originalCell = liveCells.SingleOrDefault(c => c.Equals(center));

        return numberOfLiveNeighbours switch
        {
            2 or 3 when _currentCellIsAlive => [new Coordinate(originalCell)],
            3 when !_currentCellIsAlive => [center],
            _ => []
        };
    }
}
