using System;
using System.CommandLine.Parsing;
using adrianbanks.GameOfLife.Boards;
using adrianbanks.GameOfLife.CommandLine;
using adrianbanks.GameOfLife.Rendering;

namespace adrianbanks.GameOfLife
{
    internal static class Program
    {
        internal static int Main(string[] args) => CommandFactory.Parse(Run, OnError).Invoke(args);

        private static void Run(Args args)
        {
            if (args.ShowPatterns)
            {
                var patternNames = string.Join($"{Environment.NewLine}  ", KnownPatterns.GetAllNames());
                Console.WriteLine($"Available patterns: {patternNames}");
                return;
            }

            if (args.ShowColors)
            {
                var patternNames = string.Join($"{Environment.NewLine}  ", ColorPalette.GetAllColors());
                Console.WriteLine($"Available colors: {patternNames}");
                return;
            }

            RunGame(args);
        }

        private static void RunGame(Args args)
        {
            var dimension = new Dimension(args.Width, args.Height);
            var board = new BoardFactory(args.Pattern).Create(dimension);
            var colorPalette = new ColorPalette(args.BaseColor);
            var renderer = new BoardRenderer(args.InitialDelay, args.Delay, colorPalette.GetColors());

            var runner = new GameRunner(board);
            runner.Run(renderer, args.Iterations);
        }

        private static void OnError(Exception exception) => Console.WriteLine($"An error occurred: {exception.Message}{Environment.NewLine}{exception}");
    }
}
