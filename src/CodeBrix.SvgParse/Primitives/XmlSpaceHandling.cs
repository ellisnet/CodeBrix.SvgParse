using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the XmlSpaceHandling.</summary>
/// <summary>Defines the XmlSpaceHandling enumeration.</summary>
[TypeConverter(typeof(XmlSpaceHandlingConverter))]
public enum XmlSpaceHandling
{
    /// <summary>Gets or sets the Default.</summary>
    /// <summary>The Default value.</summary>
    Default,
    /// <summary>Gets or sets the Inherit.</summary>
    /// <summary>The Inherit value.</summary>
    Inherit,
    /// <summary>Gets or sets the Preserve.</summary>
    /// <summary>The Preserve value.</summary>
    Preserve
}
