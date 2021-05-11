using System;
using System.Drawing;
using ZXing;
using ZXing.Common;

namespace adrianbanks.GameOfLife.Boards.QrCodes
{
    internal sealed class QrCodeParser
    {
        public Board Parse(string path, Bitmap image)
        {
            var matrix = GetCellMatrix(path, image);
            return MatrixToBoardConverter.Convert(matrix);
        }

        private static BitMatrix GetCellMatrix(string path, Bitmap image)
        {
            var luminanceSource = new BitmapLuminanceSource(image);
            var binarizer = new HybridBinarizer(luminanceSource);
            var bitmap = new BinaryBitmap(binarizer);
            var result = new ZXing.QrCode.Internal.Detector(bitmap.BlackMatrix).detect();

            if (result == null)
            {
                throw new Exception($"Could not find QR code in '{path}'");
            }

            return result.Bits;
        }
    }
}
