using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgFillRule.</summary>
/// <summary>Defines the SvgFillRule enumeration.</summary>
[TypeConverter(typeof(SvgFillRuleConverter))]
public enum SvgFillRule
{
    /// <summary>Gets or sets the NonZero.</summary>
    /// <summary>The NonZero value.</summary>
    NonZero,
    /// <summary>Gets or sets the EvenOdd.</summary>
    /// <summary>The EvenOdd value.</summary>
    EvenOdd,
    /// <summary>Gets or sets the Inherit.</summary>
    /// <summary>The Inherit value.</summary>
    Inherit
}
