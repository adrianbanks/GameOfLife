using System.Collections.Generic;
using System.Threading;
using Spectre.Console;
using static adrianbanks.GameOfLife.GridNavigation;

namespace adrianbanks.GameOfLife.Rendering
{
    internal sealed class BoardRenderer
    {
        private readonly int delay;
        private readonly AgedColors colors;
        private int currentDelay;

        public BoardRenderer(int initialDelay, int delay)
        {
            currentDelay = initialDelay;
            this.delay = delay;
            AnsiConsole.Cursor.Show(false);
            AnsiConsole.Clear();

            colors = new AgedColors(Color.Red1);
        }

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
                var color = colors.GetColor(cell.Age);
                canvas.SetPixel(cell.X, cell.Y, color);
            }

            AnsiConsole.Render(canvas);
            Thread.Sleep(currentDelay);
            currentDelay = delay;
        }
    }
}
