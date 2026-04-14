namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Represents a list of re-usable SVG components.
/// </summary>
[SvgElement("defs")]
public partial class SvgDefinitionList : SvgElement
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgDefinitionList>();
    }
}
