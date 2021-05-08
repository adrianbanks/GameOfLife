using Spectre.Console;

namespace adrianbanks.GameOfLife.Rendering
{
    internal sealed class AgedColors
    {
        private readonly Color generation0;
        private readonly Color generation1;
        private readonly Color generation2;
        private readonly Color generation3;
        private readonly Color generationOld;

        public AgedColors(Color baseColor)
        {
            const float factor = 0.25f;
            var toBlend = Color.Black;

            generation0 = baseColor;
            generation1 = generation0.Blend(toBlend, factor);
            generation2 = generation1.Blend(toBlend, factor);
            generation3 = generation2.Blend(toBlend, factor);
            generationOld = generation3.Blend(toBlend, factor);
        }

        public Color GetColor(int generation)
        {
            return generation switch
            {
                0 => generation0,
                1 => generation1,
                2 => generation2,
                3 => generation3,
                _ => generationOld
            };
        }
    }
}
