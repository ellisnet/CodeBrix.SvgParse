namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;

/// <summary>Gets or sets the SvgScale.</summary>
/// <summary>Represents the <see cref="SvgScale"/> class.</summary>
public sealed partial class SvgScale : SvgTransform
{
    /// <summary>Gets or sets the X.</summary>
    public float X { get; set; }

    /// <summary>Gets or sets the Y.</summary>
    public float Y { get; set; }

    /// <summary>Gets or sets the WriteToString().</summary>
    /// <inheritdoc />
    public override string WriteToString()
    {
        if (X == Y)
            return $"scale({X.ToSvgString()})";
        return $"scale({X.ToSvgString()}, {Y.ToSvgString()})";
    }

    /// <summary>Gets or sets the SvgScale(float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgScale"/> class with the specified parameters.</summary>
    public SvgScale(float x)
        : this(x, x)
    {
    }

    /// <summary>Gets or sets the SvgScale(float, float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgScale"/> class with the specified parameters.</summary>
    public SvgScale(float x, float y)
    {
        X = x;
        Y = y;
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <inheritdoc />
    public override object Clone()
    {
        return new SvgScale(X, Y);
    }
}
