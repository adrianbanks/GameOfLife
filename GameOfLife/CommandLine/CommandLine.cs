using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace adrianbanks.GameOfLife.CommandLine
{
    internal static class CommandFactory
    {
        public static Parser Parse(Action<Args> runCallback, Action<Exception> errorCallback)
        {
            var rootCommand = new RootCommand
            {
                Name = "game-of-life",
                Description = "TODO",
                TreatUnmatchedTokensAsErrors = true,
                Handler = CommandHandler.Create(runCallback),
            };

            return new CommandLineBuilder(rootCommand)
                .AddOption(new Option<int>(new[] { "--width", "-w" }, () => 20, "The width of the grid"))
                .AddOption(new Option<int>(new[] { "--height", "-h" }, () => 20, "The height of the grid"))
                .AddOption(new Option<int>(new[] { "--iterations", "-i" }, () => 100, "The number of iterations to perform"))
                .AddOption(new Option<int>(new[] { "--initial-delay", "-id" }, () => 1000, "The delay for which the first iteration will be shown (in milliseconds)"))
                .AddOption(new Option<int>(new[] { "--delay", "-d" }, () => 200, "The delay between each iteration (in milliseconds)"))
                .AddOption(new Option<string>(new[] { "--pattern", "-p" }, "Generates a starting point using a known pattern"))
                .AddOption(new Option<bool>(new[] { "--show-patterns", "-sp" }, "Shows the available known patterns"))
                .AddOption(new Option<string>(new[] { "--base-color", "-c" }, () => "Red1", "Sets the base color to use for rendering"))
                .AddOption(new Option<bool>(new[] { "--show-colors", "-sc" }, "Shows the available base colors to use for rendering"))
                .UseDefaults()
                .UseExceptionHandler((e, _) => errorCallback(e))
                .Build();
        }
    }
}
