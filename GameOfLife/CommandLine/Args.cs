namespace adrianbanks.GameOfLife.CommandLine
{
    internal sealed class Args
    {
        public int Iterations { get; set; }
        public int InitialDelay { get; set; }
        public int Delay { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Pattern { get; set; }
        public string BaseColor { get; set; }
    }
}
