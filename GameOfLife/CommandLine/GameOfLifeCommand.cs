using System.CommandLine;

namespace adrianbanks.GameOfLife.CommandLine;

internal sealed class GameOfLifeCommand : RootCommand
{
    public GameOfLifeCommand() : base("Conway's Game of Life")
    {
        Add(new RunCommand());
        Add(new ShowPatternsCommand());
        Add(new ShowColorsCommand());
    }
}
