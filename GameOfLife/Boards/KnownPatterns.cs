using System.Collections.Generic;

namespace adrianbanks.GameOfLife.Boards
{
    internal static class KnownPatterns
    {
        public static IEnumerable<Board> All()
        {
            yield return StillLifes.Block;
            yield return StillLifes.BeeHive;
            yield return StillLifes.Loaf;
            yield return StillLifes.Boat;
            yield return StillLifes.Tub;

            yield return Oscillators.Blinker;
            yield return Oscillators.Toad;
            yield return Oscillators.Beacon;
            yield return Oscillators.Pulsar;
            yield return Oscillators.PentaDecathlon;

            yield return Spaceships.Glider;
            yield return Spaceships.Lightweight;
            yield return Spaceships.Middleweight;
            yield return Spaceships.Heavyweight;
        }

        public static class StillLifes
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

        public static class Oscillators
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

        public static class Spaceships
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
    }
}
