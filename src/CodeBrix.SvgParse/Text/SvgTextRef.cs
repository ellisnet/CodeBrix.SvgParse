using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgTextRef.</summary>
/// <summary>Represents the <see cref="SvgTextRef"/> class.</summary>
[SvgElement("tref")]
public partial class SvgTextRef : SvgTextBase
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
        return DeepCopy<SvgTextRef>();
    }
}
