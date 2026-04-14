namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgFuncR.</summary>
/// <summary>Represents the <see cref="SvgFuncR"/> class.</summary>
[SvgElement("feFuncR")]
public partial class SvgFuncR : SvgComponentTransferFunction
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgFuncR>();
    }
}
