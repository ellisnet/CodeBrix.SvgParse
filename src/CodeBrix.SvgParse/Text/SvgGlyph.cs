using System.Linq;
using CodeBrix.SvgParse.Pathing;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgGlyph.</summary>
/// <summary>Represents the <see cref="SvgGlyph"/> class.</summary>
[SvgElement("glyph")]
public partial class SvgGlyph : SvgPathBasedElement, ISvgPathElement
{
    /// <summary>
    /// Gets or sets a <see cref="SvgPathSegmentList"/> of path data.
    /// </summary>
    [SvgAttribute("d")]
    public SvgPathSegmentList PathData
    {
        get { return GetAttribute<SvgPathSegmentList>("d", false); }
        set
        {
            var old = PathData;
            if (old != null)
                old.Owner = null;
            Attributes["d"] = value;
            value.Owner = this;
        }
    }

    /// <summary>Gets or sets the GlyphName.</summary>
    [SvgAttribute("glyph-name")]
    public virtual string GlyphName
    {
        get { return GetAttribute<string>("glyph-name", true); }
        set { Attributes["glyph-name"] = value; }
    }

    /// <summary>Gets or sets the HorizAdvX.</summary>
    [SvgAttribute("horiz-adv-x")]
    public float HorizAdvX
    {
        get { return GetAttribute("horiz-adv-x", true, Parents.OfType<SvgFont>().First().HorizAdvX); }
        set { Attributes["horiz-adv-x"] = value; }
    }

    /// <summary>Gets or sets the Unicode.</summary>
    [SvgAttribute("unicode")]
    public string Unicode
    {
        get { return GetAttribute<string>("unicode", true); }
        set { Attributes["unicode"] = value; }
    }

    /// <summary>Gets or sets the VertAdvY.</summary>
    [SvgAttribute("vert-adv-y")]
    public float VertAdvY
    {
        get { return GetAttribute("vert-adv-y", true, Parents.OfType<SvgFont>().First().VertAdvY); }
        set { Attributes["vert-adv-y"] = value; }
    }

    /// <summary>Gets or sets the VertOriginX.</summary>
    [SvgAttribute("vert-origin-x")]
    public float VertOriginX
    {
        get { return GetAttribute("vert-origin-x", true, Parents.OfType<SvgFont>().First().VertOriginX); }
        set { Attributes["vert-origin-x"] = value; }
    }

    /// <summary>Gets or sets the VertOriginY.</summary>
    [SvgAttribute("vert-origin-y")]
    public float VertOriginY
    {
        get { return GetAttribute("vert-origin-y", true, Parents.OfType<SvgFont>().First().VertOriginY); }
        set { Attributes["vert-origin-y"] = value; }
    }

    /// <summary>Gets or sets the OnPathUpdated().</summary>
    /// <summary>Performs the OnPathUpdated() operation.</summary>
    public void OnPathUpdated()
    {
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgGlyph>();
    }

    /// <summary>Gets or sets the DeepCopy.</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy<T>()
    {
        var newObj = base.DeepCopy<T>() as SvgGlyph;

        if (newObj.PathData != null)
            newObj.PathData.Owner = newObj;
        return newObj;
    }
}
