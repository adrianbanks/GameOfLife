using System.CommandLine;

namespace adrianbanks.GameOfLife.CommandLine;

internal sealed class RunCommand : Command
{
    public RunCommand() : base("run", "Runs the game")
    {
        Add(_width);
        Add(_height);
        Add(_iterations);
        Add(_initialDelay);
        Add(_delay);
        Add(_backColor);
        Add(_baseColor);
        Add(_pattern);
        Add(_qrCode);

        SetAction(result =>
        {
            var args = new Args(
                result.GetValue(_width),
                result.GetValue(_height),
                result.GetValue(_iterations),
                result.GetValue(_initialDelay),
                result.GetValue(_delay),
                result.GetValue(_backColor),
                result.GetValue(_baseColor),
                result.GetValue(_pattern),
                result.GetValue(_qrCode));
            GameHost.Run(args);
        });
    }

    private readonly Option<int?> _width = new("--width")
    {
        Description = "The width of the grid",
        Aliases = { "-w" }
    };

    private readonly Option<int?> _height = new("--height")
    {
        Description = "The height of the grid",
        Aliases = { "-h" }
    };

    private readonly Option<int> _iterations = new("--iterations")
    {
        Description = "The number of iterations to perform",
        Aliases = { "-i" },
        DefaultValueFactory = _ => Defaults.Iterations
    };

    private readonly Option<int> _initialDelay = new("--initial-delay")
    {
        Description = "The delay for which the first iteration is shown (in milliseconds)",
        Aliases = { "-id" },
        DefaultValueFactory = _ => Defaults.InitialDelay
    };

    private readonly Option<int> _delay = new("--delay")
    {
        Description = "The delay between each iteration (in milliseconds)",
        Aliases = { "-d" },
        DefaultValueFactory = _ => Defaults.Delay
    };

    private readonly Option<string> _backColor = new("--back-color")
    {
        Description = "Sets the background color to use for rendering",
        Aliases = { "-b" },
        DefaultValueFactory = _ => Defaults.BackColor
    };

    private readonly Option<string> _baseColor = new("--base-color")
    {
        Description = "Sets the base color to use for rendering",
        Aliases = { "-c" },
        DefaultValueFactory = _ => Defaults.BaseColor
    };

    private readonly Option<string> _pattern = new("--pattern")
    {
        Description = "Generates a starting point using a known pattern",
        Aliases = { "-p" }
    };

    private readonly Option<string> _qrCode = new("--qr-code")
    {
        Description = "The file path/url of an image containing a QR code",
        Aliases = { "-q" }
    };
}
