namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgFuncG.</summary>
/// <summary>Represents the <see cref="SvgFuncG"/> class.</summary>
[SvgElement("feFuncG")]
public partial class SvgFuncG : SvgComponentTransferFunction
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgFuncG>();
    }
}
