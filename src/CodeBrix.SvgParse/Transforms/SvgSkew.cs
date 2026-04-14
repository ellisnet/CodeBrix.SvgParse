namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;

/// <summary>
/// The class which applies the specified skew vector to this Matrix.
/// </summary>
public sealed partial class SvgSkew : SvgTransform
{
    /// <summary>Gets or sets the AngleX.</summary>
    public float AngleX { get; set; }

    /// <summary>Gets or sets the AngleY.</summary>
    public float AngleY { get; set; }

    /// <summary>Gets or sets the WriteToString().</summary>
    /// <inheritdoc />
    public override string WriteToString()
    {
        if (AngleY == 0f)
            return $"skewX({AngleX.ToSvgString()})";
        return $"skewY({AngleY.ToSvgString()})";
    }

    /// <summary>Gets or sets the SvgSkew(float, float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgSkew"/> class with the specified parameters.</summary>
    public SvgSkew(float x, float y)
    {
        AngleX = x;
        AngleY = y;
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <inheritdoc />
    public override object Clone()
    {
        return new SvgSkew(AngleX, AngleY);
    }
}
