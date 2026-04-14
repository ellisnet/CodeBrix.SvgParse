namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgTile.</summary>
/// <summary>Represents the <see cref="SvgTile"/> class.</summary>
[SvgElement("feTile")]
public partial class SvgTile : SvgFilterPrimitive
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgTile>();
    }
}
