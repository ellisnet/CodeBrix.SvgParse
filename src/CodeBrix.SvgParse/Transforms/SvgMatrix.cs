using System.Collections.Generic;

namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;

/// <summary>
/// The class which applies custom transform to this Matrix (Required for projects created by the Inkscape).
/// </summary>
public sealed partial class SvgMatrix : SvgTransform
{
    /// <summary>Gets or sets the Points.</summary>
    public List<float> Points { get; set; }

    /// <summary>Gets or sets the WriteToString().</summary>
    /// <inheritdoc />
    public override string WriteToString()
    {
        return $"matrix({Points[0].ToSvgString()}, {Points[1].ToSvgString()}, {Points[2].ToSvgString()}, {Points[3].ToSvgString()}, {Points[4].ToSvgString()}, {Points[5].ToSvgString()})";
    }

    /// <summary>Gets or sets the SvgMatrix(List.</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgMatrix"/> class with the specified parameters.</summary>
    public SvgMatrix(List<float> m)
    {
        Points = m;
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <inheritdoc />
    public override object Clone()
    {
        return new SvgMatrix(Points);
    }
}
