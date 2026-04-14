namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;

/// <summary>
/// The class which applies the specified shear vector to this Matrix.
/// </summary>
public sealed partial class SvgShear : SvgTransform
{
    /// <summary>Gets or sets the X.</summary>
    public float X { get; set; }

    /// <summary>Gets or sets the Y.</summary>
    public float Y { get; set; }

    /// <summary>Gets or sets the WriteToString().</summary>
    /// <inheritdoc />
    public override string WriteToString()
    {
        return $"shear({X.ToSvgString()}, {Y.ToSvgString()})";
    }

    /// <summary>Gets or sets the SvgShear(float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgShear"/> class with the specified parameters.</summary>
    public SvgShear(float x)
        : this(x, x)
    {
    }

    /// <summary>Gets or sets the SvgShear(float, float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgShear"/> class with the specified parameters.</summary>
    public SvgShear(float x, float y)
    {
        X = x;
        Y = y;
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <inheritdoc />
    public override object Clone()
    {
        return new SvgShear(X, Y);
    }
}
