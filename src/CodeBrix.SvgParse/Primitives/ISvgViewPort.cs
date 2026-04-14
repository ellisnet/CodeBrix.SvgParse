using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Provides properties and methods to be implemented by view port elements.
/// </summary>
public interface ISvgViewPort
{
    /// <summary>
    /// Gets or sets the viewport of the element.
    /// </summary>
    SvgViewBox ViewBox { get; set; }
    /// <summary>Gets or sets the AspectRatio.</summary>
    SvgAspectRatio AspectRatio { get; set; }
    /// <summary>Gets or sets the Overflow.</summary>
    SvgOverflow Overflow { get; set; }
}
