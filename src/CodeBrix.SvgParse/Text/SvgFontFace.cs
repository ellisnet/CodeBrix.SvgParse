namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgFontFace.</summary>
/// <summary>Represents the <see cref="SvgFontFace"/> class.</summary>
[SvgElement("font-face")]
public partial class SvgFontFace : SvgElement
{
    /// <summary>Gets or sets the Alphabetic.</summary>
    [SvgAttribute("alphabetic")]
    public float Alphabetic
    {
        get { return GetAttribute("alphabetic", true, 0f); }
        set { Attributes["alphabetic"] = value; }
    }

    /// <summary>Gets or sets the Ascent.</summary>
    [SvgAttribute("ascent")]
    public float Ascent
    {
        get { return GetAttribute("ascent", true, Parent is SvgFont ? UnitsPerEm - ((SvgFont)Parent).VertOriginY : 0f); }
        set { Attributes["ascent"] = value; }
    }

    /// <summary>Gets or sets the AscentHeight.</summary>
    [SvgAttribute("ascent-height")]
    public float AscentHeight
    {
        get { return GetAttribute("ascent-height", true, Ascent); }
        set { Attributes["ascent-height"] = value; }
    }

    /// <summary>Gets or sets the Descent.</summary>
    [SvgAttribute("descent")]
    public float Descent
    {
        get { return GetAttribute("descent", true, Parent is SvgFont ? ((SvgFont)Parent).VertOriginY : 0f); }
        set { Attributes["descent"] = value; }
    }

    /// <summary>Gets or sets the Panose1.</summary>
    [SvgAttribute("panose-1")]
    public string Panose1
    {
        get { return GetAttribute<string>("panose-1", true); }
        set { Attributes["panose-1"] = value; }
    }

    /// <summary>Gets or sets the UnitsPerEm.</summary>
    [SvgAttribute("units-per-em")]
    public float UnitsPerEm
    {
        get { return GetAttribute("units-per-em", true, 1000f); }
        set { Attributes["units-per-em"] = value; }
    }

    /// <summary>Gets or sets the XHeight.</summary>
    [SvgAttribute("x-height")]
    public float XHeight
    {
        get { return GetAttribute("x-height", true, float.MinValue); }
        set { Attributes["x-height"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return base.DeepCopy<SvgFontFace>();
    }
}
