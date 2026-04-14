using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgTurbulenceType.</summary>
/// <summary>Defines the SvgTurbulenceType enumeration.</summary>
[TypeConverter(typeof(SvgTurbulenceTypeConverter))]
public enum SvgTurbulenceType
{
    /// <summary>Gets or sets the FractalNoise.</summary>
    /// <summary>The FractalNoise value.</summary>
    FractalNoise,
    /// <summary>Gets or sets the Turbulence.</summary>
    /// <summary>The Turbulence value.</summary>
    Turbulence
}
