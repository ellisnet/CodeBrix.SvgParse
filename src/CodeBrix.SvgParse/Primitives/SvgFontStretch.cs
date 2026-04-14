using System.ComponentModel;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>The desired amount of condensing or expansion in the glyphs used to render the text.</summary>
[TypeConverter(typeof(SvgFontStretchConverter))]
public enum SvgFontStretch
{
    /// <summary>Gets or sets the Normal.</summary>
    /// <summary>The Normal value.</summary>
    Normal,
    /// <summary>Gets or sets the Wider.</summary>
    /// <summary>The Wider value.</summary>
    Wider,
    /// <summary>Gets or sets the Narrower.</summary>
    /// <summary>The Narrower value.</summary>
    Narrower,
    /// <summary>Gets or sets the UltraCondensed.</summary>
    /// <summary>The UltraCondensed value.</summary>
    UltraCondensed,
    /// <summary>Gets or sets the ExtraCondensed.</summary>
    /// <summary>The ExtraCondensed value.</summary>
    ExtraCondensed,
    /// <summary>Gets or sets the Condensed.</summary>
    /// <summary>The Condensed value.</summary>
    Condensed,
    /// <summary>Gets or sets the SemiCondensed.</summary>
    /// <summary>The SemiCondensed value.</summary>
    SemiCondensed,
    /// <summary>Gets or sets the SemiExpanded.</summary>
    /// <summary>The SemiExpanded value.</summary>
    SemiExpanded,
    /// <summary>Gets or sets the Expanded.</summary>
    /// <summary>The Expanded value.</summary>
    Expanded,
    /// <summary>Gets or sets the ExtraExpanded.</summary>
    /// <summary>The ExtraExpanded value.</summary>
    ExtraExpanded,
    /// <summary>Gets or sets the UltraExpanded.</summary>
    /// <summary>The UltraExpanded value.</summary>
    UltraExpanded,
    /// <summary>Gets or sets the Inherit.</summary>
    /// <summary>The Inherit value.</summary>
    Inherit
}
