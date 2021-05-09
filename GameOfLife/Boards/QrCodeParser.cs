using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ZXing;
using ZXing.Common;

namespace adrianbanks.GameOfLife.Boards
{
    internal sealed class QrCodeParser
    {
        public Board Parse(string path)
        {
            using var stream = File.OpenRead(path);
            using var image = new Bitmap(stream);

            var matrix = GetCellMatrix(image);
            var liveCells = new List<Coordinate>();

            for (var x = 0; x < matrix.Width; x++)
            for (var y = 0; y < matrix.Height; y++)
            {
                if (matrix[x, y])
                {
                    liveCells.Add(new Coordinate(x, y));
                }
            }

            var boardSize = new Dimension(matrix.Width, matrix.Height);
            var board = new Board(boardSize, liveCells.ToArray());
            return board;
        }

        private static BitMatrix GetCellMatrix(Bitmap image)
        {
            var luminanceSource = new BitmapLuminanceSource(image);
            var binarizer = new HybridBinarizer(luminanceSource);
            var bitmap = new BinaryBitmap(binarizer);
            var result = new ZXing.QrCode.Internal.Detector(bitmap.BlackMatrix).detect();
            return result.Bits;
        }
    }
}
