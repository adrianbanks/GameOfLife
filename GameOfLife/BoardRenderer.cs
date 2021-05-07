using System.Collections.Generic;
using Spectre.Console;
using static adrianbanks.GameOfLife.GridNavigation;

namespace adrianbanks.GameOfLife
{
    internal sealed class BoardRenderer
    {
        public BoardRenderer() => AnsiConsole.Cursor.Show(false);

        public void Render(Dimension dimension, IEnumerable<Coordinate> liveCells)
        {
            AnsiConsole.Cursor.SetPosition(0, 0);

            var canvas = new Canvas(dimension.Width, dimension.Height);

            foreach (var cell in AllCells(dimension))
            {
                canvas.SetPixel(cell.X, cell.Y, Color.Grey15);
            }

            foreach (var cell in liveCells)
            {
                canvas.SetPixel(cell.X, cell.Y, Color.Red);
            }

            AnsiConsole.Render(canvas);
        }
    }
}
