using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace adrianbanks.GameOfLife.CommandLine
{
    internal static class CommandFactory
    {
        public static Parser Parse(Action<Args> runGame, Action showPatterns, Action showColors, Action<Exception> errorCallback)
        {
            var rootCommand = new RootCommand
            {
                Name = "game-of-life",
                Description = "Conway's Game of Life",
                TreatUnmatchedTokensAsErrors = true,
                Handler = CommandHandler.Create(runGame),
            };

            var showPatternsCommand = new Command("show-patterns", "Shows the available known patterns")
            {
                TreatUnmatchedTokensAsErrors = true,
                Handler = CommandHandler.Create(showPatterns),
            };
            rootCommand.AddCommand(showPatternsCommand);

            var showColorsCommand = new Command("show-colors", "Shows the available base colors to use for rendering")
            {
                TreatUnmatchedTokensAsErrors = true,
                Handler = CommandHandler.Create(showColors),
            };
            rootCommand.AddCommand(showColorsCommand);

            return new CommandLineBuilder(rootCommand)
                .AddOption(new Option<int>(new[] { "--width", "-w" }, () => 20, "The width of the grid"))
                .AddOption(new Option<int>(new[] { "--height", "-h" }, () => 20, "The height of the grid"))
                .AddOption(new Option<int>(new[] { "--iterations", "-i" }, () => 100, "The number of iterations to perform"))
                .AddOption(new Option<int>(new[] { "--initial-delay", "-id" }, () => 1000, "The delay for which the first iteration will be shown (in milliseconds)"))
                .AddOption(new Option<int>(new[] { "--delay", "-d" }, () => 200, "The delay between each iteration (in milliseconds)"))
                .AddOption(new Option<string>(new[] { "--pattern", "-p" }, "Generates a starting point using a known pattern"))
                .AddOption(new Option<string>(new[] { "--base-color", "-c" }, () => "Red1", "Sets the base color to use for rendering"))
                .UseDefaults()
                .UseExceptionHandler((e, _) => errorCallback(e))
                .Build();
        }
    }
}
