using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgMorphologyOperator.</summary>
/// <summary>Defines the SvgMorphologyOperator enumeration.</summary>
[TypeConverter(typeof(SvgMorphologyOperatorConverter))]
public enum SvgMorphologyOperator
{
    /// <summary>Gets or sets the Erode.</summary>
    /// <summary>The Erode value.</summary>
    Erode,
    /// <summary>Gets or sets the Dilate.</summary>
    /// <summary>The Dilate value.</summary>
    Dilate
}
