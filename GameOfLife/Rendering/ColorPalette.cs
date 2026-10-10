using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Spectre.Console;

namespace adrianbanks.GameOfLife.Rendering;

internal sealed class ColorPalette(string backColor, string baseColor)
{
    public Color BackColor { get; } = FindColor(backColor);

    public AgedColors GetColors()
    {
        var color = FindColor(baseColor);
        return new AgedColors(color);
    }

    public static IEnumerable<string> GetAllColors()
    {
        var properties = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public);
        return properties.Select(p => p.Name).OrderBy(n => n);
    }

    private static Color FindColor(string name)
    {
        var properties = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public);
        var colorProperty = properties.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.InvariantCultureIgnoreCase));

        if (colorProperty == null)
        {
            throw new Exception($"Invalid color: {name}");
        }

        var value = colorProperty.GetValue(null);

        if (value == null)
        {
            throw new Exception($"Invalid color: {name}");
        }

        return (Color) value;
    }
}
