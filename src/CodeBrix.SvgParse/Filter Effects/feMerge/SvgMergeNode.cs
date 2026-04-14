namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgMergeNode.</summary>
/// <summary>Represents the <see cref="SvgMergeNode"/> class.</summary>
[SvgElement("feMergeNode")]
public partial class SvgMergeNode : SvgElement
{
    /// <summary>Gets or sets the Input.</summary>
    [SvgAttribute("in")]
    public string Input
    {
        get { return GetAttribute<string>("in", false); }
        set { Attributes["in"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgMergeNode>();
    }
}
