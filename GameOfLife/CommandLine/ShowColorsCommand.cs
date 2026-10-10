using System.CommandLine;

namespace adrianbanks.GameOfLife.CommandLine;

internal sealed class ShowColorsCommand : Command
{
    public ShowColorsCommand() : base("show-colors", "Shows the available base colors to use for rendering")
    {
        SetAction(_ => ColorList.Show());
    }
}
