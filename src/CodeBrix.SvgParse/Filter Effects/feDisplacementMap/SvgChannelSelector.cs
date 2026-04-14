using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgChannelSelector.</summary>
/// <summary>Defines the SvgChannelSelector enumeration.</summary>
[TypeConverter(typeof(SvgChannelSelectorConverter))]
public enum SvgChannelSelector
{
    /// <summary>Gets or sets the R.</summary>
    /// <summary>The R value.</summary>
    R,
    /// <summary>Gets or sets the G.</summary>
    /// <summary>The G value.</summary>
    G,
    /// <summary>Gets or sets the B.</summary>
    /// <summary>The B value.</summary>
    B,
    /// <summary>Gets or sets the A.</summary>
    /// <summary>The A value.</summary>
    A
}
