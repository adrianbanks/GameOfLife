using System;
using System.CommandLine;
using System.CommandLine.Builder;
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

            var argsBinder = new ArgsBinder();
            var runCommand = new Command("run", "Runs the game") { TreatUnmatchedTokensAsErrors = true };
            argsBinder.InitialiseOptions(runCommand);
            runCommand.SetHandler(runGame, argsBinder);
            rootCommand.Add(runCommand);

            var showPatternsCommand = new Command("show-patterns", "Shows the available known patterns") { TreatUnmatchedTokensAsErrors = true };
            showPatternsCommand.SetHandler(showPatterns);
            rootCommand.AddCommand(showPatternsCommand);

            var showColorsCommand = new Command("show-colors", "Shows the available base colors to use for rendering") { TreatUnmatchedTokensAsErrors = true };
            showColorsCommand.SetHandler(showColors);
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
