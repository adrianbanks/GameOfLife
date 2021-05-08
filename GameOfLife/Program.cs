using System;
using System.CommandLine.Parsing;
using adrianbanks.GameOfLife.Boards;
using adrianbanks.GameOfLife.CommandLine;
using adrianbanks.GameOfLife.Rendering;

namespace adrianbanks.GameOfLife
{
    internal static class Program
    {
        internal static int Main(string[] args) => CommandFactory.Parse(RunGame, PatternList.Show, ColorList.Show, OnError).Invoke(args);

        private static void RunGame(Args args)
        {
            var board = new BoardFactory(args.Pattern).Create(args.Width, args.Height);
            var colorPalette = new ColorPalette(args.BackColor, args.BaseColor);
            var renderer = new BoardRenderer(args.InitialDelay, args.Delay, colorPalette.BackColor, colorPalette.GetColors());

            var runner = new GameRunner(board);
            runner.Run(renderer, args.Iterations);
        }

        private static void OnError(Exception exception) => Console.WriteLine($"An error occurred: {exception.Message}{Environment.NewLine}{exception}");
    }
}
