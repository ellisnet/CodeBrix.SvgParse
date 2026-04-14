namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;

/// <summary>Gets or sets the SvgTranslate.</summary>
/// <summary>Represents the <see cref="SvgTranslate"/> class.</summary>
public sealed partial class SvgTranslate : SvgTransform
{
    /// <summary>Gets or sets the X.</summary>
    public float X { get; set; }

    /// <summary>Gets or sets the Y.</summary>
    public float Y { get; set; }

    /// <summary>Gets or sets the WriteToString().</summary>
    /// <inheritdoc />
    public override string WriteToString()
    {
        return $"translate({X.ToSvgString()}, {Y.ToSvgString()})";
    }

    /// <summary>Gets or sets the SvgTranslate(float, float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgTranslate"/> class with the specified parameters.</summary>
    public SvgTranslate(float x, float y)
    {
        X = x;
        Y = y;
    }

    /// <summary>Gets or sets the SvgTranslate(float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgTranslate"/> class with the specified parameters.</summary>
    public SvgTranslate(float x)
        : this(x, 0f)
    {
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <inheritdoc />
    public override object Clone()
    {
        return new SvgTranslate(X, Y);
    }
}
