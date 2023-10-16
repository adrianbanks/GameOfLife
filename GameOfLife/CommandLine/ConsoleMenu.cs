using System;
using System.Text.RegularExpressions;
using adrianbanks.GameOfLife.Rendering;
using Spectre.Console;

namespace adrianbanks.GameOfLife.CommandLine
{
    internal static class ConsoleMenu
    {
        public static int Show(Action<Args> runGame)
        {
            const string runTheGame = "Run the game";
            const string showAvailablePatterns = "Show available known patterns";
            const string showAvailableColors = "Show available colors";

            var command = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What would you like to do?")
                    .AddChoices(runTheGame, showAvailablePatterns, showAvailableColors, "Quit"));

            switch (command)
            {
                case runTheGame:
                    var args = GetGameArguments();
                    runGame(args);
                    break;
                case showAvailablePatterns:
                    PatternList.Show();
                    break;
                case showAvailableColors:
                    ColorList.Show();
                    break;
            }

            return 0;
        }

        private static Args GetGameArguments()
        {
            var width = GetInteger("Width of grid", Defaults.Width);
            var height = GetInteger("Height of grid", Defaults.Height);

            var backgroundColor = GetColor("Background color of the grid");
            var baseColor = GetColor("Color of cells");

            var initialDelay = GetInteger("Time to show the initial iteration (ms)", Defaults.InitialDelay);
            var delay = GetInteger("Time between iterations (ms)", Defaults.Delay);
            var iterations = GetInteger("Number of iterations to perform", Defaults.Iterations);

            return new Args
            {
                Width = width,
                Height = height,
                BackColor = backgroundColor,
                BaseColor = baseColor,
                InitialDelay = initialDelay,
                Delay = delay,
                Iterations = iterations
            };
        }

        private static int GetInteger(string prompt, int defaultValue)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>(prompt)
                    .DefaultValue(defaultValue)
                    .Validate(value =>
                    {
                        return value switch
                        {
                            < 0 => ValidationResult.Error("[red]Must have a positive value[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
        }

        private static string GetColor(string prompt)
        {
            var selectionPrompt = new SelectionPrompt<string>()
                .Title(prompt)
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more colors)[/]");

            foreach (var color in ColorPalette.GetAllColors())
            {
                selectionPrompt.AddChoice($"[{color}]{color}[/]");
            }

            var choice = AnsiConsole.Prompt(selectionPrompt);
            var match = Regex.Match(choice, @"\](?<color>.*)\[");
            return match.Groups["color"].Value;
        }
    }
}
