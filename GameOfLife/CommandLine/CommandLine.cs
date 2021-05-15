using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace adrianbanks.GameOfLife.CommandLine
{
    internal static class CommandFactory
    {
        public static Parser Parse(Action<Args> runGame, Action showPatterns, Action showColors, Action<Exception, bool> errorCallback)
        {
            var rootCommand = new RootCommand
            {
                Name = "game-of-life",
                Description = "Conway's Game of Life",
                TreatUnmatchedTokensAsErrors = true
            };

            var runCommand = new Command("run", "Runs the game")
            {
                TreatUnmatchedTokensAsErrors = true,
                Handler = CommandHandler.Create(runGame)
            };
            runCommand.AddOption(new Option<int?>(new[] { "--width", "-w" }, "The width of the grid"));
            runCommand.AddOption(new Option<int?>(new[] { "--height", "-h" }, "The height of the grid"));
            runCommand.AddOption(new Option<int>(new[] { "--iterations", "-i" }, () => Defaults.Iterations, "The number of iterations to perform"));
            runCommand.AddOption(new Option<int>(new[] { "--initial-delay", "-id" }, () => Defaults.InitialDelay, "The delay for which the first iteration is shown (in milliseconds)"));
            runCommand.AddOption(new Option<int>(new[] { "--delay", "-d" }, () => Defaults.Delay, "The delay between each iteration (in milliseconds)"));
            runCommand.AddOption(new Option<string>(new[] { "--back-color", "-b" }, () => Defaults.BackColor, "Sets the background color to use for rendering"));
            runCommand.AddOption(new Option<string>(new[] { "--base-color", "-c" }, () => Defaults.BaseColor, "Sets the base color to use for rendering"));
            runCommand.AddOption(new Option<string>(new[] { "--pattern", "-p" }, "Generates a starting point using a known pattern"));
            runCommand.AddOption(new Option<string>(new[] { "--qr-code", "-q" }, "The file path of an image containing a QR code"));
            rootCommand.Add(runCommand);

            var showPatternsCommand = new Command("show-patterns", "Shows the available known patterns")
            {
                TreatUnmatchedTokensAsErrors = true,
                Handler = CommandHandler.Create(showPatterns)
            };
            rootCommand.AddCommand(showPatternsCommand);

            var showColorsCommand = new Command("show-colors", "Shows the available base colors to use for rendering")
            {
                TreatUnmatchedTokensAsErrors = true,
                Handler = CommandHandler.Create(showColors)
            };
            rootCommand.AddCommand(showColorsCommand);

            return new CommandLineBuilder(rootCommand)
                .UseDefaults()
                .UseExceptionHandler((e, context) =>
                {
                    var showStackTrace = context.ParseResult.Directives.Contains("stacktrace");
                    errorCallback(e, showStackTrace);
                })
                .Build();
        }
    }
}
