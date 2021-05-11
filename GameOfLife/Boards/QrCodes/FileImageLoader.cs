using System.Drawing;
using System.IO;

namespace adrianbanks.GameOfLife.Boards.QrCodes
{
    internal sealed class FileImageLoader
    {
        public Bitmap Load(string path)
        {
            var stream = File.OpenRead(path);
            return new Bitmap(stream);
        }
    }
}
