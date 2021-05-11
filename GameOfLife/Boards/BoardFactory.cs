using System;
using System.IO;
using adrianbanks.GameOfLife.Boards.QrCodes;

namespace adrianbanks.GameOfLife.Boards
{
    internal sealed class BoardFactory
    {
        private readonly string pattern;
        private readonly string qrCode;

        public BoardFactory(string pattern, string qrCode)
        {
            this.pattern = pattern;
            this.qrCode = qrCode;
        }

        public Board Create(int? width, int? height)
        {
            if (pattern == null && qrCode == null)
            {
                var dimension = Dimension.Create(width, height);
                return new RandomBoard().Generate(dimension);
            }

            if (pattern != null && qrCode == null)
            {
                var board = KnownPatterns.Get(pattern);
                return board.WithNewSize(width, height);
            }

            if (pattern == null && qrCode != null)
            {
                if (File.Exists(qrCode))
                {
                    var board = new QrCodeParser().Parse(qrCode);
                    return board.WithNewSize(width, height);
                }

                return new QrCodeCreator().Create(qrCode, width, height);
            }

            throw new Exception("Cannot set both a pattern and a QR code at the same time");
        }
    }
}
