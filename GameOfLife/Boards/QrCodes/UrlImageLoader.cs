using System.Drawing;
using System.IO;
using System.Net.Http;

namespace adrianbanks.GameOfLife.Boards.QrCodes
{
    internal sealed class UrlImageLoader
    {
        public Bitmap Load(string url)
        {
            using var client = new HttpClient();
            var bytes = client.GetByteArrayAsync(url).GetAwaiter().GetResult();
            var stream = new MemoryStream(bytes);
            return new Bitmap(stream);
        }
    }
}
