using System.Collections.Generic;

namespace adrianbanks.GameOfLife.Rendering;

internal interface IBoardRenderer
{
    void Render(Dimension dimension, IEnumerable<Coordinate> liveCells);
}