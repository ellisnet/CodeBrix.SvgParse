using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgColorMatrixType.</summary>
/// <summary>Defines the SvgColorMatrixType enumeration.</summary>
[TypeConverter(typeof(SvgColorMatrixTypeConverter))]
public enum SvgColorMatrixType
{
    /// <summary>Gets or sets the Matrix.</summary>
    /// <summary>The Matrix value.</summary>
    Matrix,
    /// <summary>Gets or sets the Saturate.</summary>
    /// <summary>The Saturate value.</summary>
    Saturate,
    /// <summary>Gets or sets the HueRotate.</summary>
    /// <summary>The HueRotate value.</summary>
    HueRotate,
    /// <summary>Gets or sets the LuminanceToAlpha.</summary>
    /// <summary>The LuminanceToAlpha value.</summary>
    LuminanceToAlpha
}
