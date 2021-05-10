using System.Drawing;
using System.IO;
using ZXing;
using ZXing.Common;

namespace adrianbanks.GameOfLife.Boards.QrCodes
{
    internal sealed class QrCodeParser
    {
        public Board Parse(string path)
        {
            using var stream = File.OpenRead(path);
            using var image = new Bitmap(stream);

            var matrix = GetCellMatrix(image);
            return MatrixToBoardConverter.Convert(matrix);
        }

        public static BitMatrix GetCellMatrix(Bitmap image)
        {
            var luminanceSource = new BitmapLuminanceSource(image);
            var binarizer = new HybridBinarizer(luminanceSource);
            var bitmap = new BinaryBitmap(binarizer);
            var result = new ZXing.QrCode.Internal.Detector(bitmap.BlackMatrix).detect();
            return result.Bits;
        }
    }
}
