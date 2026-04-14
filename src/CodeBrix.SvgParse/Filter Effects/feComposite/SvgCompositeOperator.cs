using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgCompositeOperator.</summary>
/// <summary>Defines the SvgCompositeOperator enumeration.</summary>
[TypeConverter(typeof(SvgCompositeOperatorConverter))]
public enum SvgCompositeOperator
{
    /// <summary>Gets or sets the Over.</summary>
    /// <summary>The Over value.</summary>
    Over,
    /// <summary>Gets or sets the In.</summary>
    /// <summary>The In value.</summary>
    In,
    /// <summary>Gets or sets the Out.</summary>
    /// <summary>The Out value.</summary>
    Out,
    /// <summary>Gets or sets the Atop.</summary>
    /// <summary>The Atop value.</summary>
    Atop,
    /// <summary>Gets or sets the Xor.</summary>
    /// <summary>The Xor value.</summary>
    Xor,
    /// <summary>Gets or sets the Arithmetic.</summary>
    /// <summary>The Arithmetic value.</summary>
    Arithmetic
}
