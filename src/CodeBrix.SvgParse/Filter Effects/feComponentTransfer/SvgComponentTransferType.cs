using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgComponentTransferType.</summary>
/// <summary>Defines the SvgComponentTransferType enumeration.</summary>
[TypeConverter(typeof(SvgComponentTransferTypeConverter))]
public enum SvgComponentTransferType
{
    /// <summary>Gets or sets the Identity.</summary>
    /// <summary>The Identity value.</summary>
    Identity,
    /// <summary>Gets or sets the Table.</summary>
    /// <summary>The Table value.</summary>
    Table,
    /// <summary>Gets or sets the Discrete.</summary>
    /// <summary>The Discrete value.</summary>
    Discrete,
    /// <summary>Gets or sets the Linear.</summary>
    /// <summary>The Linear value.</summary>
    Linear,
    /// <summary>Gets or sets the Gamma.</summary>
    /// <summary>The Gamma value.</summary>
    Gamma
}
