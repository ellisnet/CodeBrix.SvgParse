namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgImage.</summary>
/// <summary>Represents the <see cref="SvgImage"/> class.</summary>
[SvgElement("feImage")]
public partial class SvgImage : SvgFilterPrimitive
{
    /// <summary>Gets or sets the Href.</summary>
    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public virtual string Href
    {
        get { return GetAttribute<string>("href", false); }
        set { Attributes["href"] = value; }
    }

    /// <summary>Gets or sets the AspectRatio.</summary>
    [SvgAttribute("preserveAspectRatio")]
    public SvgAspectRatio AspectRatio
    {
        get { return GetAttribute("preserveAspectRatio", false, new SvgAspectRatio(SvgPreserveAspectRatio.xMidYMid)); }
        set { Attributes["preserveAspectRatio"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgImage>();
    }
}
