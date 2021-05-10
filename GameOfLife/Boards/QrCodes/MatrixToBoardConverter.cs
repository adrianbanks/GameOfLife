using System.Collections.Generic;
using ZXing.Common;

namespace adrianbanks.GameOfLife.Boards.QrCodes
{
    internal static class MatrixToBoardConverter
    {
        public static Board Convert(BitMatrix matrix)
        {
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
            return new Board(boardSize, liveCells.ToArray());
        }
    }
}
