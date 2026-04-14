using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgBlendMode.</summary>
/// <summary>Defines the SvgBlendMode enumeration.</summary>
[TypeConverter(typeof(SvgBlendModeConverter))]
public enum SvgBlendMode
{
    /// <summary>Gets or sets the Normal.</summary>
    /// <summary>The Normal value.</summary>
    Normal,
    /// <summary>Gets or sets the Multiply.</summary>
    /// <summary>The Multiply value.</summary>
    Multiply,
    /// <summary>Gets or sets the Screen.</summary>
    /// <summary>The Screen value.</summary>
    Screen,
    /// <summary>Gets or sets the Overlay.</summary>
    /// <summary>The Overlay value.</summary>
    Overlay,
    /// <summary>Gets or sets the Darken.</summary>
    /// <summary>The Darken value.</summary>
    Darken,
    /// <summary>Gets or sets the Lighten.</summary>
    /// <summary>The Lighten value.</summary>
    Lighten,
    /// <summary>Gets or sets the ColorDodge.</summary>
    /// <summary>The ColorDodge value.</summary>
    ColorDodge,
    /// <summary>Gets or sets the ColorBurn.</summary>
    /// <summary>The ColorBurn value.</summary>
    ColorBurn,
    /// <summary>Gets or sets the HardLight.</summary>
    /// <summary>The HardLight value.</summary>
    HardLight,
    /// <summary>Gets or sets the SoftLight.</summary>
    /// <summary>The SoftLight value.</summary>
    SoftLight,
    /// <summary>Gets or sets the Difference.</summary>
    /// <summary>The Difference value.</summary>
    Difference,
    /// <summary>Gets or sets the Exclusion.</summary>
    /// <summary>The Exclusion value.</summary>
    Exclusion,
    /// <summary>Gets or sets the Hue.</summary>
    /// <summary>The Hue value.</summary>
    Hue,
    /// <summary>Gets or sets the Saturation.</summary>
    /// <summary>The Saturation value.</summary>
    Saturation,
    /// <summary>Gets or sets the Color.</summary>
    /// <summary>The Color value.</summary>
    Color,
    /// <summary>Gets or sets the Luminosity.</summary>
    /// <summary>The Luminosity value.</summary>
    Luminosity
}
