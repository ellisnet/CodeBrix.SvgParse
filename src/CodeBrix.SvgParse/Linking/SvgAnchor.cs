namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgAnchor.</summary>
/// <summary>Represents the <see cref="SvgAnchor"/> class.</summary>
[SvgElement("a")]
public partial class SvgAnchor : SvgElement
{
    /// <summary>Gets or sets the Href.</summary>
    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public string Href
    {
        get { return GetAttribute<string>("href", false); }
        set { Attributes["href"] = value; }
    }

    /// <summary>Gets or sets the Show.</summary>
    [SvgAttribute("show", SvgAttributeAttribute.XLinkNamespace)]
    public string Show
    {
        get { return GetAttribute<string>("show", false); }
        set { Attributes["show"] = value; }
    }

    /// <summary>Gets or sets the Title.</summary>
    [SvgAttribute("title", SvgAttributeAttribute.XLinkNamespace)]
    public string Title
    {
        get { return GetAttribute<string>("title", false); }
        set { Attributes["title"] = value; }
    }

    /// <summary>Gets or sets the Target.</summary>
    [SvgAttribute("target")]
    public string Target
    {
        get { return GetAttribute<string>("target", false); }
        set { Attributes["target"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgAnchor>();
    }
}
