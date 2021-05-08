using System;
using System.CommandLine.Parsing;
using adrianbanks.GameOfLife.Boards;
using adrianbanks.GameOfLife.CommandLine;
using adrianbanks.GameOfLife.Rendering;

namespace adrianbanks.GameOfLife
{
    internal static class Program
    {
        internal static int Main(string[] args)
        {
            var parser = CommandFactory.Parse(Run, OnError);
            return parser.Invoke(args);
        }

        private static void Run(Args args)
        {
            if (args.ShowPatterns)
            {
                var patternNames = string.Join($"{Environment.NewLine}  ", KnownPatterns.GetAllNames());
                Console.WriteLine($"Available patterns: {patternNames}");
                return;
            }

            RunGame(args);
        }

        private static void RunGame(Args args)
        {
            var dimension = new Dimension(args.Width, args.Height);
            var board = new BoardFactory(args.Pattern).Create(dimension);
            var renderer = new BoardRenderer(args.InitialDelay, args.Delay);

            for (var i = 0; i < args.Iterations; i++)
            {
                board.Render(renderer);
                board = board.NextIteration();
            }        }

        private static void OnError(Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}
