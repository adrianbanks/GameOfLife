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

        public ColorPalette(string baseColor) => this.baseColor = baseColor;

        public AgedColors GetColors()
        {
            var properties = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public);
            var colorProperty = properties.FirstOrDefault(p => string.Equals(p.Name, baseColor, StringComparison.InvariantCultureIgnoreCase));

            if (colorProperty == null)
            {
                throw new Exception($"Invalid base color: {baseColor}");
            }

            var color = (Color) colorProperty.GetValue(null);
            return new AgedColors(color);
        }

        public static IEnumerable<string> GetAllColors()
        {
            var properties = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public);
            return properties.Select(p => p.Name).OrderBy(n => n);
        }
    }
}
