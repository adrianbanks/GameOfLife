using System.CommandLine;
using System.CommandLine.Binding;

namespace adrianbanks.GameOfLife.CommandLine
{
    internal sealed class ArgsBinder : BinderBase<Args>
    {
        private readonly Option<int?> width = new(new[] {"--width", "-w"}, "The width of the grid");
        private readonly Option<int?> height = new(new[] {"--height", "-h"}, "The height of the grid");
        private readonly Option<int> iterations = new(new[] {"--iterations", "-i"}, () => Defaults.Iterations, "The number of iterations to perform");
        private readonly Option<int> initialDelay = new(new[] {"--initial-delay", "-id"}, () => Defaults.InitialDelay, "The delay for which the first iteration is shown (in milliseconds)");
        private readonly Option<int> delay = new(new[] {"--delay", "-d"}, () => Defaults.Delay, "The delay between each iteration (in milliseconds)");
        private readonly Option<string> backColor = new(new[] {"--back-color", "-b"}, () => Defaults.BackColor, "Sets the background color to use for rendering");
        private readonly Option<string> baseColor = new(new[] {"--base-color", "-c"}, () => Defaults.BaseColor, "Sets the base color to use for rendering");
        private readonly Option<string> pattern = new(new[] {"--pattern", "-p"}, "Generates a starting point using a known pattern");
        private readonly Option<string> qrCode = new(new[] {"--qr-code", "-q"}, "The file path/url of an image containing a QR code");

        protected override Args GetBoundValue(BindingContext bindingContext) =>
            new()
            {
                Width = bindingContext.ParseResult.GetValueForOption(width),
                Height = bindingContext.ParseResult.GetValueForOption(height),
                Iterations = bindingContext.ParseResult.GetValueForOption(iterations),
                InitialDelay = bindingContext.ParseResult.GetValueForOption(initialDelay),
                Delay = bindingContext.ParseResult.GetValueForOption(delay),
                BackColor = bindingContext.ParseResult.GetValueForOption(backColor),
                BaseColor = bindingContext.ParseResult.GetValueForOption(baseColor),
                Pattern = bindingContext.ParseResult.GetValueForOption(pattern),
                QrCode = bindingContext.ParseResult.GetValueForOption(qrCode)
            };

        public void InitialiseOptions(Command command)
        {
            command.Add(width);
            command.Add(height);
            command.Add(iterations);
            command.Add(initialDelay);
            command.Add(delay);
            command.Add(backColor);
            command.Add(baseColor);
            command.Add(pattern);
            command.Add(qrCode);
        }
    }
}
