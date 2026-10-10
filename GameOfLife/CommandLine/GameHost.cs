using adrianbanks.GameOfLife.Boards;
using adrianbanks.GameOfLife.Rendering;

namespace adrianbanks.GameOfLife.CommandLine;

internal static class GameHost
{
    public static void Run(Args args)
    {
        var boardFactory = new BoardFactory(args.Pattern, args.QrCode);
        var board = boardFactory.Create(args.Width, args.Height);
        var colorPalette = new ColorPalette(args.BackColor, args.BaseColor);
        var renderer = new BoardRenderer(args.InitialDelay, args.Delay, colorPalette.BackColor, colorPalette.GetColors());

        var runner = new GameRunner(board);
        runner.Run(renderer, args.Iterations);
    }
}
