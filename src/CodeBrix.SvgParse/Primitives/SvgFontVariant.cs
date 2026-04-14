using System.ComponentModel;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgFontVariant.</summary>
/// <summary>Defines the SvgFontVariant enumeration.</summary>
[TypeConverter(typeof(SvgFontVariantConverter))]
public enum SvgFontVariant
{
    /// <summary>Gets or sets the Normal.</summary>
    /// <summary>The Normal value.</summary>
    Normal,
    /// <summary>Gets or sets the SmallCaps.</summary>
    /// <summary>The SmallCaps value.</summary>
    SmallCaps,
    /// <summary>Gets or sets the Inherit.</summary>
    /// <summary>The Inherit value.</summary>
    Inherit
}
