namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgTextSpan.</summary>
/// <summary>Represents the <see cref="SvgTextSpan"/> class.</summary>
[SvgElement("tspan")]
public partial class SvgTextSpan : SvgTextBase
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgTextSpan>();
    }
}
