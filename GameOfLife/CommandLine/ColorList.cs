using System;
using System.Collections.Generic;
using System.Linq;
using adrianbanks.GameOfLife.Rendering;
using Spectre.Console;

namespace adrianbanks.GameOfLife.CommandLine
{
    internal static class ColorList
    {
        public static void Show()
        {
            var colors = ColorPalette.GetAllColors().ToList();
            var maxColorLength = colors.Max(c => c.Length) + 2;
            var numberOfColumns = Console.WindowWidth / maxColorLength;

            var numberOfRows = Math.Ceiling(colors.Count * 1.0f / numberOfColumns);
            var rows = colors.Select((color, i) => new { Color = color, Index = i })
                .GroupBy(item => item.Index % numberOfRows, item => item.Color)
                .Cast<IEnumerable<string>>();

            var table = new Table();
            table.HideHeaders();

            for (var i = 0; i < numberOfColumns; i++)
            {
                table.AddColumn("Color");
            }

            foreach (var rowItems in rows)
            {
                var coloursInRow = rowItems.Select(c => $"[{c}]{c}[/]").ToArray();
                table.AddRow(coloursInRow);
            }

            AnsiConsole.Render(table);
        }
    }
}
