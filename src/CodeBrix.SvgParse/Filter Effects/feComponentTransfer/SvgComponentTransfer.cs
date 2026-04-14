namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgComponentTransfer.</summary>
/// <summary>Represents the <see cref="SvgComponentTransfer"/> class.</summary>
[SvgElement("feComponentTransfer")]
public partial class SvgComponentTransfer : SvgFilterPrimitive
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgComponentTransfer>();
    }
}
