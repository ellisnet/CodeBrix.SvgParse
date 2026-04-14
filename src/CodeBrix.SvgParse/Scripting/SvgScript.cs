using System.Xml;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// An element used to define scripts within SVG documents.
/// Use the Script property to get the script content (proxies the content)
/// </summary>
[SvgElement("script")]
public partial class SvgScript : SvgElement
{
    /// <summary>Gets or sets the Script.</summary>
    public string Script
    {
        get { return this.Content; }
        set { this.Content = value; }
    }

    /// <summary>Gets or sets the ScriptType.</summary>
    [SvgAttribute("type")]
    public string ScriptType
    {
        get { return GetAttribute<string>("type", false); }
        set { Attributes["type"] = value; }
    }

    /// <summary>Gets or sets the CrossOrigin.</summary>
    [SvgAttribute("crossorigin")]
    public string CrossOrigin
    {
        get { return GetAttribute<string>("crossorigin", false); }
        set { Attributes["crossorigin"] = value; }
    }

    /// <summary>Gets or sets the Href.</summary>
    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public string Href
    {
        get { return GetAttribute<string>("href", false); }
        set { Attributes["href"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgScript>();
    }

    /// <summary>Gets or sets the WriteChildren(XmlWriter).</summary>
    protected override void WriteChildren(XmlWriter writer)
    {
        if (!string.IsNullOrEmpty(Content))
        {
            // Always put the script in a CDATA tag
            writer.WriteCData(this.Content);
        }
    }
}
