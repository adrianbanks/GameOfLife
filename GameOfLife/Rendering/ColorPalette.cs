using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Spectre.Console;

namespace adrianbanks.GameOfLife.Rendering
{
    internal sealed class ColorPalette
    {
        private readonly string baseColor;

        public Color BackColor { get;  }

        public ColorPalette(string backColor, string baseColor)
        {
            BackColor = FindColor(backColor);
            this.baseColor = baseColor;
        }

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

            var color = (Color) colorProperty.GetValue(null);
            return color;
        }
    }
}
