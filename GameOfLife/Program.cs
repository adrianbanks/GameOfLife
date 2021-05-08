using System.Threading;
using adrianbanks.GameOfLife.Boards;
using adrianbanks.GameOfLife.Rendering;

namespace adrianbanks.GameOfLife
{
    internal static class Program
    {
        internal static void Main()
        {
            var dimension = new Dimension(40, 40);
            // var board = original.WithNewSize(dimension);
            var board = new RandomBoard().Generate(dimension);
            var renderer = new BoardRenderer();

            var renderDelay = 1000;

            for (int i = 0; i < 2500; i++)
            {
                board.Render(renderer);
                board = board.NextIteration();
                Thread.Sleep(renderDelay);
                renderDelay = 200;
            }
        }
    }
}
