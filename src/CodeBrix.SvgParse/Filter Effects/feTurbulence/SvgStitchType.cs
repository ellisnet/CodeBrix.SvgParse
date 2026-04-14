using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgStitchType.</summary>
/// <summary>Defines the SvgStitchType enumeration.</summary>
[TypeConverter(typeof(SvgStitchTypeConverter))]
public enum SvgStitchType
{
    /// <summary>Gets or sets the Stitch.</summary>
    /// <summary>The Stitch value.</summary>
    Stitch,
    /// <summary>Gets or sets the NoStitch.</summary>
    /// <summary>The NoStitch value.</summary>
    NoStitch
}
