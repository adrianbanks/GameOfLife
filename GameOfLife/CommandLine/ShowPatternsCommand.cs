using System.CommandLine;

namespace adrianbanks.GameOfLife.CommandLine;

internal sealed class ShowPatternsCommand : Command
{
    public ShowPatternsCommand() : base("show-patterns", "Shows the available known patterns")
    {
        SetAction(_ => PatternList.Show());
    }
}
