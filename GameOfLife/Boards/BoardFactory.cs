namespace adrianbanks.GameOfLife.Boards
{
    internal sealed class BoardFactory
    {
        private readonly string pattern;

        public BoardFactory(string pattern) => this.pattern = pattern;

        public Board Create(Dimension dimension)
        {
            if (pattern == null)
            {
                return new RandomBoard().Generate(dimension);
            }

            var board = KnownPatterns.Get(pattern);
            return board.WithNewSize(dimension);
        }
    }
}
