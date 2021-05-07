using System.Threading;

namespace adrianbanks.GameOfLife
{
    internal static class Program
    {
        internal static void Main()
        {
            var dimension = new Dimension(20, 20);
            // var board = KnownPatterns.Spaceships.Glider.WithNewSize(dimension);
            var board = new RandomBoardGenerator().Generate(dimension);
            var renderer = new BoardRenderer();

            var renderDelay = 1500;

            while (true)
            {
                board.Render(renderer);
                board = board.NextIteration();
                Thread.Sleep(renderDelay);
                renderDelay = 200;
            }
        }
    }
}
