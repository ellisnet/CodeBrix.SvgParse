using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CodeBrix.SvgParse.Primitives;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Description of SvgAspectRatio.
/// </summary>
[TypeConverter(typeof(SvgPreserveAspectRatioConverter))]
public class SvgAspectRatio : ICloneable
{
    /// <summary>Gets or sets the SvgAspectRatio().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgAspectRatio"/> class with the specified parameters.</summary>
    public SvgAspectRatio() : this(SvgPreserveAspectRatio.none)
    {
    }

    /// <summary>Gets or sets the SvgAspectRatio(SvgPreserveAspectRatio).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgAspectRatio"/> class with the specified parameters.</summary>
    public SvgAspectRatio(SvgPreserveAspectRatio align)
        : this(align, false)
    {
    }

    /// <summary>Gets or sets the SvgAspectRatio(SvgPreserveAspectRatio, bool).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgAspectRatio"/> class with the specified parameters.</summary>
    public SvgAspectRatio(SvgPreserveAspectRatio align, bool slice)
        : this(align, slice, false)
    {
    }

    /// <summary>Gets or sets the SvgAspectRatio(SvgPreserveAspectRatio, bool, bool).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgAspectRatio"/> class with the specified parameters.</summary>
    public SvgAspectRatio(SvgPreserveAspectRatio align, bool slice, bool defer)
    {
        this.Align = align;
        this.Slice = slice;
        this.Defer = defer;
    }

    /// <summary>Gets or sets the Align.</summary>
    public SvgPreserveAspectRatio Align
    {
        get;
        set;
    }

    /// <summary>Gets or sets the Slice.</summary>
    public bool Slice
    {
        get;
        set;
    }

    /// <summary>Gets or sets the Defer.</summary>
    public bool Defer
    {
        get;
        set;
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <summary>Performs the Clone() operation.</summary>
    public object Clone()
    {
        return MemberwiseClone();
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicMethods, typeof(SvgPreserveAspectRatioConverter))]
    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "DynamicDependency keeps converter safe")]
    [UnconditionalSuppressMessage("AOT", "IL3050")]
    public override string ToString()
    {
        return TypeDescriptor.GetConverter(typeof(SvgPreserveAspectRatio)).ConvertToString(this.Align) + (Slice ? " slice" : "");
    }
}

/// <summary>Gets or sets the SvgPreserveAspectRatio.</summary>
/// <summary>Defines the SvgPreserveAspectRatio enumeration.</summary>
[TypeConverter(typeof(SvgPreserveAspectRatioConverter))]
public enum SvgPreserveAspectRatio
{
    /// <summary>Gets or sets the xMidYMid.</summary>
    /// <summary>The xMidYMid value.</summary>
    xMidYMid, //default
    /// <summary>Gets or sets the none.</summary>
    /// <summary>The none value.</summary>
    none,
    /// <summary>Gets or sets the xMinYMin.</summary>
    /// <summary>The xMinYMin value.</summary>
    xMinYMin,
    /// <summary>Gets or sets the xMidYMin.</summary>
    /// <summary>The xMidYMin value.</summary>
    xMidYMin,
    /// <summary>Gets or sets the xMaxYMin.</summary>
    /// <summary>The xMaxYMin value.</summary>
    xMaxYMin,
    /// <summary>Gets or sets the xMinYMid.</summary>
    /// <summary>The xMinYMid value.</summary>
    xMinYMid,
    /// <summary>Gets or sets the xMaxYMid.</summary>
    /// <summary>The xMaxYMid value.</summary>
    xMaxYMid,
    /// <summary>Gets or sets the xMinYMax.</summary>
    /// <summary>The xMinYMax value.</summary>
    xMinYMax,
    /// <summary>Gets or sets the xMidYMax.</summary>
    /// <summary>The xMidYMax value.</summary>
    xMidYMax,
    /// <summary>Gets or sets the xMaxYMax.</summary>
    /// <summary>The xMaxYMax value.</summary>
    xMaxYMax
}
