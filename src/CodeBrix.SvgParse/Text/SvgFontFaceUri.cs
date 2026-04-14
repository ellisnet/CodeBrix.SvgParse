using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgFontFaceUri.</summary>
/// <summary>Represents the <see cref="SvgFontFaceUri"/> class.</summary>
[SvgElement("font-face-uri")]
public partial class SvgFontFaceUri : SvgElement
{
    /// <summary>Gets or sets the ReferencedElement.</summary>
    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public virtual Uri ReferencedElement
    {
        get { return GetAttribute<Uri>("href", false); }
        set { Attributes["href"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgFontFaceUri>();
    }
}
