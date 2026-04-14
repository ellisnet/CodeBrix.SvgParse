namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgFuncA.</summary>
/// <summary>Represents the <see cref="SvgFuncA"/> class.</summary>
[SvgElement("feFuncA")]
public partial class SvgFuncA : SvgComponentTransferFunction
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgFuncA>();
    }
}
