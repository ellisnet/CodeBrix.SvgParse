namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgMerge.</summary>
/// <summary>Represents the <see cref="SvgMerge"/> class.</summary>
[SvgElement("feMerge")]
public partial class SvgMerge : SvgFilterPrimitive
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgMerge>();
    }
}
