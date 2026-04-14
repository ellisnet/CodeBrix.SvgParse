namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgKern.</summary>
/// <summary>Represents the <see cref="SvgKern"/> class.</summary>
public abstract partial class SvgKern : SvgElement
{
    /// <summary>Gets or sets the Glyph1.</summary>
    [SvgAttribute("g1")]
    public string Glyph1
    {
        get { return GetAttribute<string>("g1", true); }
        set { Attributes["g1"] = value; }
    }

    /// <summary>Gets or sets the Glyph2.</summary>
    [SvgAttribute("g2")]
    public string Glyph2
    {
        get { return GetAttribute<string>("g2", true); }
        set { Attributes["g2"] = value; }
    }

    /// <summary>Gets or sets the Unicode1.</summary>
    [SvgAttribute("u1")]
    public string Unicode1
    {
        get { return GetAttribute<string>("u1", true); }
        set { Attributes["u1"] = value; }
    }

    /// <summary>Gets or sets the Unicode2.</summary>
    [SvgAttribute("u2")]
    public string Unicode2
    {
        get { return GetAttribute<string>("u2", true); }
        set { Attributes["u2"] = value; }
    }

    /// <summary>Gets or sets the Kerning.</summary>
    [SvgAttribute("k")]
    public float Kerning
    {
        get { return GetAttribute("k", true, 0f); }
        set { Attributes["k"] = value; }
    }
}

/// <summary>Gets or sets the SvgVerticalKern.</summary>
/// <summary>Represents the <see cref="SvgVerticalKern"/> class.</summary>
[SvgElement("vkern")]
public partial class SvgVerticalKern : SvgKern
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return base.DeepCopy<SvgVerticalKern>();
    }
}
/// <summary>Gets or sets the SvgHorizontalKern.</summary>
/// <summary>Represents the <see cref="SvgHorizontalKern"/> class.</summary>
[SvgElement("hkern")]
public partial class SvgHorizontalKern : SvgKern
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return base.DeepCopy<SvgHorizontalKern>();
    }
}
