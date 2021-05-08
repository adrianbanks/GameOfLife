using System;
using System.CommandLine.Parsing;
using adrianbanks.GameOfLife.Boards;
using adrianbanks.GameOfLife.Rendering;

namespace adrianbanks.GameOfLife
{
    internal static class Program
    {
        internal static int Main(string[] args)
        {
            var parser = CommandLine.Pars(Run, OnError);
            return parser.Invoke(args);
        }

        private static void Run(Args args)
        {
            var dimension = new Dimension(args.Width, args.Height);
            Board board;

            if (args.Pattern == null)
            {
                board = new RandomBoard().Generate(dimension);
            }
            else
            {
                board = KnownPatterns.Oscillators.Beacon;
                board = board.WithNewSize(dimension);
            }

            var renderer = new BoardRenderer(args.InitialDelay, args.Delay);

            for (var i = 0; i < args.Iterations; i++)
            {
                board.Render(renderer);
                board = board.NextIteration();
            }
        }

        private static void OnError(Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}
