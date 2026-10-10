using System.Collections.Generic;
using System.Linq;
using adrianbanks.GameOfLife.Rendering;
using static adrianbanks.GameOfLife.GridNavigation;

namespace adrianbanks.GameOfLife;

internal sealed class Board(Dimension dimension, params Coordinate[] liveCells)
{
    private readonly HashSet<Coordinate> _liveCells = [.. liveCells];

    public Board NextIteration()
    {
        var nextGeneration = new List<Coordinate>();

        foreach (var cell in AllCells(dimension))
        {
            var neighbourhood = new Neighbourhood(_liveCells, cell);
            var nextGenerationCells = neighbourhood.NextGenerationCells();
            nextGeneration.AddRange(nextGenerationCells);
        }

        return new Board(dimension, nextGeneration.ToArray());
    }

    public void Render(IBoardRenderer renderer)
    {
        var cellsWithinBounds = _liveCells.Where(dimension.Contains);
        renderer.Render(dimension, cellsWithinBounds);
    }

    public Board WithNewSize(int? width, int? height)
    {
        var size = Dimension.Create(dimension, width, height);
        return new(size, _liveCells.ToArray());
    }
}
