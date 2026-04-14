namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgFontFaceSrc.</summary>
/// <summary>Represents the <see cref="SvgFontFaceSrc"/> class.</summary>
[SvgElement("font-face-src")]
public partial class SvgFontFaceSrc : SvgElement
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return base.DeepCopy<SvgFontFaceSrc>();
    }
}
