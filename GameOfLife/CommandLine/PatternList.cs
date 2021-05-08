using System;
using System.Collections.Generic;
using System.Linq;
using adrianbanks.GameOfLife.Boards;
using Spectre.Console;

namespace adrianbanks.GameOfLife.CommandLine
{
    internal static class PatternList
    {
        public static void Show()
        {
            var patterns = KnownPatterns.GetAllNames().ToList();
            var categories = patterns.Select(p => p.category).Distinct().ToArray();
            var names = patterns.Select(c => c.name).ToList();

            var table = new Table();
            table.AddColumns(categories);

            var numberOfRows = Math.Ceiling(names.Count * 1.0f / categories.Length);
            var rows = names.Select((name, i) => new { Name = name, Index = i })
                .GroupBy(item => item.Index % numberOfRows, item => item.Name)
                .Cast<IEnumerable<string>>();

            foreach (var rowItems in rows)
            {
                var items = rowItems.Select(i => i).ToArray();
                table.AddRow(items);
            }

            AnsiConsole.Render(table);
        }
    }
}
