using System;

namespace adrianbanks.GameOfLife.Boards
{
    internal sealed class BoardFactory
    {
        private readonly string pattern;
        private readonly string qrCodePath;

        public BoardFactory(string pattern, string qrCodePath)
        {
            this.pattern = pattern;
            this.qrCodePath = qrCodePath;
        }

        public Board Create(int? width, int? height)
        {
            var dimension = Dimension.Create(width, height);

            if (pattern == null && qrCodePath == null)
            {
                return new RandomBoard().Generate(dimension);
            }

            if (pattern != null && qrCodePath == null)
            {
                var board = KnownPatterns.Get(pattern);
                return board.WithNewSize(width, height);
            }

            if (pattern == null && qrCodePath != null)
            {
                var board = new QrCodeParser().Parse(qrCodePath);
                return board.WithNewSize(width, height);
            }

            throw new Exception("Cannot set both a pattern and a QR code at the same time");
        }
    }
}
