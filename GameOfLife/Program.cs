using System;
using System.CommandLine.Parsing;
using adrianbanks.GameOfLife.Boards;
using adrianbanks.GameOfLife.CommandLine;
using adrianbanks.GameOfLife.Rendering;
using Spectre.Console;

namespace adrianbanks.GameOfLife
{
    internal static class Program
    {
        internal static int Main(string[] args) => CommandFactory.Parse(RunGame, PatternList.Show, ColorList.Show, OnError).Invoke(args);

        private static void RunGame(Args args)
        {
            var boardFactory = new BoardFactory(args.Pattern, args.QrCode);
            var board = boardFactory.Create(args.Width, args.Height);
            var colorPalette = new ColorPalette(args.BackColor, args.BaseColor);
            var renderer = new BoardRenderer(args.InitialDelay, args.Delay, colorPalette.BackColor, colorPalette.GetColors());

            var runner = new GameRunner(board);
            runner.Run(renderer, args.Iterations);
        }

        private static void OnError(Exception exception) => AnsiConsole.Console.WriteLine(exception.GetBaseException().Message, new Style(Color.Red, Color.Default, Decoration.Bold));
    }
}
