namespace adrianbanks.GameOfLife
{
    internal static class KnownPatterns
    {
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
        }
    }
}
