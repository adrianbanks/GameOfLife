using System;
using System.Linq;
using adrianbanks.GameOfLife.CommandLine;
using Spectre.Console;

namespace adrianbanks.GameOfLife;

internal static class Program
{
    internal static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ConsoleMenu.Show();
        }
        else
        {
            RunGame(args);
        }
    }

    private static void RunGame(string[] args)
    {
        var command = new GameOfLifeCommand();
        var result = command.Parse(args);

        try
        {
            result.InvocationConfiguration.EnableDefaultExceptionHandler = false;
            result.Invoke();
        }
        catch (Exception exception)
        {
            var showStackTrace = result.Tokens.Any(t => t.Value == "[stacktrace]");

            if (showStackTrace)
            {
                AnsiConsole.WriteException(exception.GetBaseException(), ExceptionFormats.ShortenEverything);
            }
            else
            {
                AnsiConsole.Console.WriteLine(exception.GetBaseException().Message, new Style(Color.Red, Color.Default, Decoration.Bold));
            }
        }
    }
}
