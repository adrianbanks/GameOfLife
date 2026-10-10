using System.Collections.Generic;
using System.Threading;
using Spectre.Console;
using static adrianbanks.GameOfLife.GridNavigation;

namespace adrianbanks.GameOfLife.Rendering;

internal sealed class BoardRenderer : IBoardRenderer
{
    private readonly int _delay;
    private readonly Color _backColor;
    private readonly AgedColors _colors;
    private int _currentDelay;

    public BoardRenderer(int initialDelay, int delay, Color backColor, AgedColors colors)
    {
        _currentDelay = initialDelay;
        _delay = delay;
        _backColor = backColor;
        _colors = colors;
        AnsiConsole.Cursor.Show(false);
        AnsiConsole.Clear();
    }

    public void Render(Dimension dimension, IEnumerable<Coordinate> liveCells)
    {
        AnsiConsole.Cursor.SetPosition(0, 0);

        var canvas = new Canvas(dimension.Width, dimension.Height);

        foreach (var cell in AllCells(dimension))
        {
            canvas.SetPixel(cell.X, cell.Y, _backColor);
        }

        foreach (var cell in liveCells)
        {
            var color = _colors.GetColor(cell.Age);
            canvas.SetPixel(cell.X, cell.Y, color);
        }

        AnsiConsole.Write(canvas);
        Thread.Sleep(_currentDelay);
        _currentDelay = _delay;
    }
}
