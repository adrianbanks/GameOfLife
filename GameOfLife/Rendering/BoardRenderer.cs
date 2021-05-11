using System.Collections.Generic;
using System.Threading;
using Spectre.Console;
using static adrianbanks.GameOfLife.GridNavigation;

namespace adrianbanks.GameOfLife.Rendering
{
    internal interface IBoardRenderer
    {
        void Render(Dimension dimension, IEnumerable<Coordinate> liveCells);
    }

    internal sealed class BoardRenderer : IBoardRenderer
    {
        private readonly int delay;
        private readonly Color backColor;
        private readonly AgedColors colors;
        private int currentDelay;

        public BoardRenderer(int initialDelay, int delay, Color backColor, AgedColors colors)
        {
            currentDelay = initialDelay;
            this.delay = delay;
            this.backColor = backColor;
            this.colors = colors;
            AnsiConsole.Cursor.Show(false);
            AnsiConsole.Clear();
        }

        public void Render(Dimension dimension, IEnumerable<Coordinate> liveCells)
        {
            AnsiConsole.Cursor.SetPosition(0, 0);

            var canvas = new Canvas(dimension.Width, dimension.Height);

            foreach (var cell in AllCells(dimension))
            {
                canvas.SetPixel(cell.X, cell.Y, backColor);
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
