namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;

/// <summary>Gets or sets the SvgRotate.</summary>
/// <summary>Represents the <see cref="SvgRotate"/> class.</summary>
public sealed partial class SvgRotate : SvgTransform
{
    /// <summary>Gets or sets the Angle.</summary>
    public float Angle { get; set; }

    /// <summary>Gets or sets the CenterX.</summary>
    public float CenterX { get; set; }

    /// <summary>Gets or sets the CenterY.</summary>
    public float CenterY { get; set; }

    /// <summary>Gets or sets the WriteToString().</summary>
    /// <inheritdoc />
    public override string WriteToString()
    {
        return $"rotate({Angle.ToSvgString()}, {CenterX.ToSvgString()}, {CenterY.ToSvgString()})";
    }

    /// <summary>Gets or sets the SvgRotate(float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgRotate"/> class with the specified parameters.</summary>
    public SvgRotate(float angle)
    {
        Angle = angle;
    }

    /// <summary>Gets or sets the SvgRotate(float, float, float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgRotate"/> class with the specified parameters.</summary>
    public SvgRotate(float angle, float centerX, float centerY)
        : this(angle)
    {
        CenterX = centerX;
        CenterY = centerY;
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <inheritdoc />
    public override object Clone()
    {
        return new SvgRotate(Angle, CenterX, CenterY);
    }
}
