namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// SvgPolyline defines a set of connected straight line segments. Typically, <see cref="SvgPolyline"/> defines open shapes.
/// </summary>
[SvgElement("polyline")]
public partial class SvgPolyline : SvgPolygon
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgPolyline>();
    }
}
