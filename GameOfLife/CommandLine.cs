using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace adrianbanks.GameOfLife
{
    internal static class CommandLine
    {
        public static Parser Pars(Action<Args> runCallback, Action<Exception> errorCallback)
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
                .UseDefaults()
                .UseExceptionHandler((e, c) => errorCallback(e))
                .Build();
        }
    }
}
