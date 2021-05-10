using System.Collections.Generic;
using ZXing;

namespace adrianbanks.GameOfLife.Boards.QrCodes
{
    internal sealed class QrCodeCreator
    {
        public Board Create(string text, int? width, int? height)
        {
            var size = Dimension.Create(width, height);

            var encoder = new MultiFormatWriter();
            var hints = new Dictionary<EncodeHintType, object>
            {
                { EncodeHintType.WIDTH, size.Width},
                { EncodeHintType.HEIGHT, size.Height},
                { EncodeHintType.MARGIN, 0}
            };
            var matrix = encoder.encode(text, BarcodeFormat.QR_CODE, size.Width, size.Height, hints);

            return MatrixToBoardConverter.Convert(matrix);
        }
    }
}
