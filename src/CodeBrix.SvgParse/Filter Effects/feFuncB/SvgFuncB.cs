namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgFuncB.</summary>
/// <summary>Represents the <see cref="SvgFuncB"/> class.</summary>
[SvgElement("feFuncB")]
public partial class SvgFuncB : SvgComponentTransferFunction
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgFuncB>();
    }
}
