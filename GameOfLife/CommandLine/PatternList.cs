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
            var groupedPatterns = KnownPatterns.GetAllNames();

            var table = new Table();
            table.AddColumns(groupedPatterns.Keys.ToArray());

            var numberOfRows = groupedPatterns.Max(g => g.Value.Count);

            for (var i = 0; i < numberOfRows; i++)
            {
                var itemsInRow = new List<string>();

                foreach (var group in groupedPatterns)
                {
                    var patternsInCategory = group.Value;
                    itemsInRow.Add(patternsInCategory.TryPop(out var pattern) ? pattern : string.Empty);
                }

                table.AddRow(itemsInRow.ToArray());
            }

            AnsiConsole.Write(table);
        }
    }
}
