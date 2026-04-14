using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the ISvgFilterable.</summary>
/// <summary>Defines the <see cref="ISvgFilterable"/> interface.</summary>
public interface ISvgFilterable
{
    /// <summary>Gets or sets the Filter.</summary>
    SvgFilter Filter { get; set; }
}
