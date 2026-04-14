using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// The <see cref="SvgText"/> element defines a graphics element consisting of text.
/// </summary>
[SvgElement("textPath")]
public partial class SvgTextPath : SvgTextBase
{
    /// <summary>Gets or sets the Dx.</summary>
    public override SvgUnitCollection Dx
    {
        get { return null; }
        set { /* do nothing */ }
    }

    /// <summary>Gets or sets the StartOffset.</summary>
    [SvgAttribute("startOffset")]
    public virtual SvgUnit StartOffset
    {
        get { return base.Dx.Count < 1 ? SvgUnit.None : base.Dx[0]; }
        set
        {
            if (base.Dx.Count < 1)
                base.Dx.Add(value);
            else
                base.Dx[0] = value;
            Attributes["startOffset"] = value;
        }
    }

    /// <summary>Gets or sets the Method.</summary>
    [SvgAttribute("method")]
    public virtual SvgTextPathMethod Method
    {
        get { return GetAttribute("method", true, SvgTextPathMethod.Align); }
        set { Attributes["method"] = value; }
    }

    /// <summary>Gets or sets the Spacing.</summary>
    [SvgAttribute("spacing")]
    public virtual SvgTextPathSpacing Spacing
    {
        get { return GetAttribute("spacing", true, SvgTextPathSpacing.Exact); }
        set { Attributes["spacing"] = value; }
    }

    /// <summary>Gets or sets the ReferencedPath.</summary>
    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public virtual Uri ReferencedPath
    {
        get { return GetAttribute<Uri>("href", false); }
        set { Attributes["href"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return base.DeepCopy<SvgTextPath>();
    }
}
