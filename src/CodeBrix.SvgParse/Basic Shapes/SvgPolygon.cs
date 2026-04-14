namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// SvgPolygon defines a closed shape consisting of a set of connected straight line segments.
/// </summary>
[SvgElement("polygon")]
public partial class SvgPolygon : SvgMarkerElement
{
    /// <summary>
    /// The points that make up the SvgPolygon
    /// </summary>
    [SvgAttribute("points")]
    public SvgPointCollection Points
    {
        get { return GetAttribute<SvgPointCollection>("points", false); }
        set { Attributes["points"] = value; IsPathDirty = true; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgPolygon>();
    }
}
