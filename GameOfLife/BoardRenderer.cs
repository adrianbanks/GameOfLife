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
                var color = GetColour(cell.Age);
                canvas.SetPixel(cell.X, cell.Y, color);
            }

            AnsiConsole.Render(canvas);
        }

        private static Color GetColour(int age)
        {
            return age switch
            {
                0 => Color.Red1,
                1 => Color.Red3_1,
                2 => Color.Red3,
                3 => Color.DarkRed_1,
                _ => Color.DarkRed
            };
        }
    }
}
