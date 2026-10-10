using adrianbanks.GameOfLife.Rendering;

namespace adrianbanks.GameOfLife;

internal sealed class GameRunner(Board board)
{
    public void Run(BoardRenderer renderer, int numberOfIterations)
    {
        var workingBoard = board;

        for (var i = 0; i < numberOfIterations; i++)
        {
            workingBoard.Render(renderer);
            workingBoard = workingBoard.NextIteration();
        }
    }
}
