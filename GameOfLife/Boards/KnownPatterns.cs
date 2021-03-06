using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace adrianbanks.GameOfLife.Boards
{
    internal static class KnownPatterns
    {
        public static IDictionary<string, Stack<string>> GetAllNames()
        {
            var groupedPatterns = new Dictionary<string, Stack<string>>();
            var nestedTypes = typeof(KnownPatterns).GetNestedTypes(BindingFlags.NonPublic).Where(t => !t.Name.Contains("<"));

            foreach (var categoryType in nestedTypes)
            {
                var fields = categoryType.GetFields(BindingFlags.Static | BindingFlags.Public);

                foreach (var field in fields.OrderByDescending(f => f.Name))
                {
                    if (!groupedPatterns.TryGetValue(categoryType.Name, out var patterns))
                    {
                        patterns = new Stack<string>();
                        groupedPatterns.Add(categoryType.Name, patterns);
                    }

                    patterns.Push(field.Name);
                }
            }

            return groupedPatterns;
        }

        public static Board Get(string name)
        {
            var patterns = GetAllPatterns();

            if (patterns.TryGetValue(name, out var pattern))
            {
                return pattern();
            }

            throw new Exception($"Invalid pattern: '{name}'");
        }

        private static Dictionary<string, Func<Board>> GetAllPatterns()
        {
            var patterns = new Dictionary<string, Func<Board>>(StringComparer.InvariantCultureIgnoreCase);
            var nestedTypes = typeof(KnownPatterns).GetNestedTypes(BindingFlags.NonPublic).Where(t => !t.Name.Contains("<"));

            foreach (var nestedType in nestedTypes)
            {
                var fields = nestedType.GetFields(BindingFlags.Static | BindingFlags.Public);

                foreach (var field in fields)
                {
                    var pattern = field.Name;
                    Board GetBoard() => (Board) field.GetValue(null);
                    patterns.Add(pattern, GetBoard);
                    patterns.Add($"{nestedType.Name}.{pattern}", GetBoard);
                }
            }

            return patterns;
        }

        private static class StillLifes
        {
            public static readonly Board Block = new(
                new Dimension(4, 4),
                new Coordinate(1, 1),
                new Coordinate(2, 1),
                new Coordinate(1, 2),
                new Coordinate(2, 2)
            );

            public static readonly Board BeeHive = new(
                new Dimension(6, 5),
                new Coordinate(2, 1),
                new Coordinate(3, 1),
                new Coordinate(1, 2),
                new Coordinate(4, 2),
                new Coordinate(2, 3),
                new Coordinate(3, 3)
            );

            public static readonly Board Loaf = new(
                new Dimension(6, 6),
                new Coordinate(2, 1),
                new Coordinate(3, 1),
                new Coordinate(1, 2),
                new Coordinate(4, 2),
                new Coordinate(2, 3),
                new Coordinate(4, 3),
                new Coordinate(3, 4)
            );

            public static readonly Board Boat = new(
                new Dimension(5, 5),
                new Coordinate(1, 1),
                new Coordinate(2, 1),
                new Coordinate(1, 2),
                new Coordinate(3, 2),
                new Coordinate(2, 3)
            );

            public static readonly Board Tub = new(
                new Dimension(5, 5),
                new Coordinate(2, 1),
                new Coordinate(1, 2),
                new Coordinate(3, 2),
                new Coordinate(2, 3)
            );
        }

        private static class Oscillators
        {
            public static Board Blinker = new(
                new Dimension(5, 5),
                new Coordinate(2, 1),
                new Coordinate(2, 2),
                new Coordinate(2, 3)
            );

            public static Board Toad = new(
                new Dimension(6, 6),
                new Coordinate(2, 2),
                new Coordinate(3, 2),
                new Coordinate(4, 2),
                new Coordinate(1, 3),
                new Coordinate(2, 3),
                new Coordinate(3, 3)
            );

            public static Board Beacon = new(
                new Dimension(6, 6),
                new Coordinate(1, 1),
                new Coordinate(2, 1),
                new Coordinate(1, 2),
                new Coordinate(4, 3),
                new Coordinate(3, 4),
                new Coordinate(4, 4)
            );

            public static Board Pulsar = new(
                new Dimension(17, 17),
                new Coordinate(4, 2),
                new Coordinate(5, 2),
                new Coordinate(6, 2),
                new Coordinate(10, 2),
                new Coordinate(11, 2),
                new Coordinate(12, 2),
                new Coordinate(2, 4),
                new Coordinate(7, 4),
                new Coordinate(9, 4),
                new Coordinate(14, 4),
                new Coordinate(2, 5),
                new Coordinate(7, 5),
                new Coordinate(9, 5),
                new Coordinate(14, 5),
                new Coordinate(2, 6),
                new Coordinate(7, 6),
                new Coordinate(9, 6),
                new Coordinate(14, 6),
                new Coordinate(4, 7),
                new Coordinate(5, 7),
                new Coordinate(6, 7),
                new Coordinate(10, 7),
                new Coordinate(11, 7),
                new Coordinate(12, 7),
                new Coordinate(4, 9),
                new Coordinate(5, 9),
                new Coordinate(6, 9),
                new Coordinate(10, 9),
                new Coordinate(11, 9),
                new Coordinate(12, 9),
                new Coordinate(2, 10),
                new Coordinate(7, 10),
                new Coordinate(9, 10),
                new Coordinate(14, 10),
                new Coordinate(2, 11),
                new Coordinate(7, 11),
                new Coordinate(9, 11),
                new Coordinate(14, 11),
                new Coordinate(2, 12),
                new Coordinate(7, 12),
                new Coordinate(9, 12),
                new Coordinate(14, 12),
                new Coordinate(4, 14),
                new Coordinate(5, 14),
                new Coordinate(6, 14),
                new Coordinate(10, 14),
                new Coordinate(11, 14),
                new Coordinate(12, 14)
            );

            public static Board PentaDecathlon = new(
                new Dimension(10, 17),
                new Coordinate(5, 2),
                new Coordinate(4, 3),
                new Coordinate(5, 3),
                new Coordinate(6, 3),
                new Coordinate(4, 6),
                new Coordinate(5, 6),
                new Coordinate(6, 6),
                new Coordinate(4, 8),
                new Coordinate(6, 8),
                new Coordinate(4, 9),
                new Coordinate(6, 9),
                new Coordinate(4, 11),
                new Coordinate(5, 11),
                new Coordinate(6, 11),
                new Coordinate(4, 14),
                new Coordinate(5, 14),
                new Coordinate(6, 14),
                new Coordinate(5, 15)
            );
        }

        private static class Spaceships
        {
            public static readonly Board Glider = new(
                new Dimension(5, 5),
                new Coordinate(1, 1),
                new Coordinate(2, 2),
                new Coordinate(3, 2),
                new Coordinate(1, 3),
                new Coordinate(2, 3)
            );

            public static readonly Board Lightweight = new(
                new Dimension(8, 6),
                new Coordinate(2, 1),
                new Coordinate(5, 1),
                new Coordinate(6, 2),
                new Coordinate(2, 3),
                new Coordinate(6, 3),
                new Coordinate(3, 4),
                new Coordinate(4, 4),
                new Coordinate(5, 4),
                new Coordinate(6, 4)
            );

            public static readonly Board Middleweight = new(
                new Dimension(8, 8),
                new Coordinate(3, 1),
                new Coordinate(1, 2),
                new Coordinate(5, 2),
                new Coordinate(6, 3),
                new Coordinate(1, 4),
                new Coordinate(6, 4),
                new Coordinate(2, 5),
                new Coordinate(3, 5),
                new Coordinate(4, 5),
                new Coordinate(5, 5),
                new Coordinate(6, 5)
            );

            public static readonly Board Heavyweight = new(
                new Dimension(10, 8),
                new Coordinate(4, 1),
                new Coordinate(5, 1),
                new Coordinate(2, 2),
                new Coordinate(7, 2),
                new Coordinate(8, 3),
                new Coordinate(2, 4),
                new Coordinate(8, 4),
                new Coordinate(3, 5),
                new Coordinate(4, 5),
                new Coordinate(5, 5),
                new Coordinate(6, 5),
                new Coordinate(7, 5),
                new Coordinate(8, 5)
            );
        }

        private static class Guns
        {
            public static readonly Board GosperGliderGun = new(
                new Dimension(38, 11),
                new Coordinate(26, 1),
                new Coordinate(24, 2),
                new Coordinate(26, 2),
                new Coordinate(14, 3),
                new Coordinate(15, 3),
                new Coordinate(22, 3),
                new Coordinate(23, 3),
                new Coordinate(36, 3),
                new Coordinate(37, 3),
                new Coordinate(13, 4),
                new Coordinate(17, 4),
                new Coordinate(22, 4),
                new Coordinate(23, 4),
                new Coordinate(35, 4),
                new Coordinate(36, 4),
                new Coordinate(2, 5),
                new Coordinate(3, 5),
                new Coordinate(12, 5),
                new Coordinate(18, 5),
                new Coordinate(22, 5),
                new Coordinate(23, 5),
                new Coordinate(2, 6),
                new Coordinate(3, 6),
                new Coordinate(12, 6),
                new Coordinate(16, 6),
                new Coordinate(18, 6),
                new Coordinate(19, 6),
                new Coordinate(24, 6),
                new Coordinate(26, 6),
                new Coordinate(12, 7),
                new Coordinate(18, 7),
                new Coordinate(26, 7),
                new Coordinate(13, 8),
                new Coordinate(17, 8),
                new Coordinate(14, 9),
                new Coordinate(15, 9)
            );
        }
    }
}
