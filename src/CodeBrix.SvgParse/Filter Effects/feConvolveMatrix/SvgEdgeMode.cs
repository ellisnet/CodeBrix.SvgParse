using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgEdgeMode.</summary>
/// <summary>Defines the SvgEdgeMode enumeration.</summary>
[TypeConverter(typeof(SvgEdgeModeConverter))]
public enum SvgEdgeMode
{
    /// <summary>Gets or sets the Duplicate.</summary>
    /// <summary>The Duplicate value.</summary>
    Duplicate,
    /// <summary>Gets or sets the Wrap.</summary>
    /// <summary>The Wrap value.</summary>
    Wrap,
    /// <summary>Gets or sets the None.</summary>
    /// <summary>The None value.</summary>
    None
}
