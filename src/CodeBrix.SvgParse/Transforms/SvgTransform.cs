using System;

namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;

/// <summary>Gets or sets the SvgTransform.</summary>
/// <summary>Represents the <see cref="SvgTransform"/> class.</summary>
public abstract partial class SvgTransform : ICloneable
{
    /// <summary>Gets or sets the WriteToString().</summary>
    /// <summary>Performs the WriteToString() operation.</summary>
    public abstract string WriteToString();

    /// <summary>Gets or sets the Clone().</summary>
    /// <summary>Performs the Clone() operation.</summary>
    public abstract object Clone();

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        return WriteToString();
    }
}
