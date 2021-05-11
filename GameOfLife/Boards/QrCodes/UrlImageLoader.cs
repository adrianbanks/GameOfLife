using System.Drawing;
using System.IO;
using System.Net;

namespace adrianbanks.GameOfLife.Boards.QrCodes
{
    internal sealed class UrlImageLoader
    {
        public Bitmap Load(string url)
        {
            using var client = new WebClient();
            var bytes = client.DownloadData(url);
            var stream = new MemoryStream(bytes);
            return new Bitmap(stream);
        }
    }
}
