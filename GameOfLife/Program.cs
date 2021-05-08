using System;
using System.CommandLine.Parsing;
using adrianbanks.GameOfLife.Boards;
using adrianbanks.GameOfLife.CommandLine;
using adrianbanks.GameOfLife.Rendering;

namespace adrianbanks.GameOfLife
{
    internal static class Program
    {
        internal static int Main(string[] args) => CommandFactory.Parse(RunGame, ShowPatterns, ShowColors, OnError).Invoke(args);

        private static void RunGame(Args args)
        {
            var dimension = new Dimension(args.Width, args.Height);
            var board = new BoardFactory(args.Pattern).Create(dimension);
            var colorPalette = new ColorPalette(args.BackColor, args.BaseColor);
            var renderer = new BoardRenderer(args.InitialDelay, args.Delay, colorPalette.BackColor, colorPalette.GetColors());

            var runner = new GameRunner(board);
            runner.Run(renderer, args.Iterations);
        }

        private static void ShowPatterns() => Console.WriteLine($"Available patterns: {string.Join($"{Environment.NewLine}  ", KnownPatterns.GetAllNames())}");

        private static void ShowColors() => Console.WriteLine($"Available colors: {string.Join($"{Environment.NewLine}  ", ColorPalette.GetAllColors())}");

        private static void OnError(Exception exception) => Console.WriteLine($"An error occurred: {exception.Message}{Environment.NewLine}{exception}");
    }
}
