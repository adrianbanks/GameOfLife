using Spectre.Console;

namespace adrianbanks.GameOfLife.Rendering;

internal sealed class AgedColors
{
    private readonly Color _generation0;
    private readonly Color _generation1;
    private readonly Color _generation2;
    private readonly Color _generation3;
    private readonly Color _generationOld;

    public AgedColors(Color baseColor)
    {
        const float factor = 0.25f;
        var toBlend = GetBlendColor(baseColor);

        _generation0 = baseColor;
        _generation1 = _generation0.Blend(toBlend, factor);
        _generation2 = _generation1.Blend(toBlend, factor);
        _generation3 = _generation2.Blend(toBlend, factor);
        _generationOld = _generation3.Blend(toBlend, factor);
    }

    private Color GetBlendColor(Color baseColor) =>
        baseColor is { R: <=112, G: <= 112, B: <= 112 }
            ? Color.White
            : Color.Black;

    public Color GetColor(int generation) =>
        generation switch
        {
            0 => _generation0,
            1 => _generation1,
            2 => _generation2,
            3 => _generation3,
            _ => _generationOld
        };
}
