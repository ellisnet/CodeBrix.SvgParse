namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgMissingGlyph.</summary>
/// <summary>Represents the <see cref="SvgMissingGlyph"/> class.</summary>
[SvgElement("missing-glyph")]
public partial class SvgMissingGlyph : SvgGlyph
{
    /// <summary>Gets or sets the GlyphName.</summary>
    [SvgAttribute("glyph-name")]
    public override string GlyphName
    {
        get { return GetAttribute("glyph-name", true, "__MISSING_GLYPH__"); }
        set { Attributes["glyph-name"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgMissingGlyph>();
    }
}
