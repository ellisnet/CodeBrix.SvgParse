namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// An element used to group SVG shapes.
/// </summary>
[SvgElement("g")]
public partial class SvgGroup : SvgMarkerElement
{
    /// <summary>Gets or sets the Renderable.</summary>
    protected override bool Renderable { get { return false; } }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgGroup>();
    }
}
