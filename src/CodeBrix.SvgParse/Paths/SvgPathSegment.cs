using System;

namespace CodeBrix.SvgParse.Pathing; //Was previously: namespace Svg.Pathing;

/// <summary>Gets or sets the SvgPathSegment.</summary>
/// <summary>Represents the <see cref="SvgPathSegment"/> class.</summary>
public abstract partial class SvgPathSegment
{
    /// <summary>Gets or sets the NaN.</summary>
    protected static readonly SvgPointF NaN = new SvgPointF(float.NaN, float.NaN);

    /// <summary>Gets or sets the IsRelative.</summary>
    public bool IsRelative { get; set; }

    /// <summary>Gets or sets the End.</summary>
    public SvgPointF End { get; set; }

    /// <summary>Gets or sets the SvgPathSegment(bool).</summary>
    protected SvgPathSegment(bool isRelative)
    {
        IsRelative = isRelative;
    }

    /// <summary>Gets or sets the SvgPathSegment(bool, SvgPointF).</summary>
    protected SvgPathSegment(bool isRelative, SvgPointF end)
        : this(isRelative)
    {
        End = end;
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <summary>Performs the Clone() operation.</summary>
    public SvgPathSegment Clone()
    {
        return MemberwiseClone() as SvgPathSegment;
    }

    /// <summary>Gets or sets the Start.</summary>
    [Obsolete("Will be removed.")]
    public SvgPointF Start { get; set; }
}
