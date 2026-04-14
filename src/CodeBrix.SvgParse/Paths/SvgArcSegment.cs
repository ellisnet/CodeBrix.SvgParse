using System;

namespace CodeBrix.SvgParse.Pathing; //Was previously: namespace Svg.Pathing;

/// <summary>Gets or sets the SvgArcSegment.</summary>
/// <summary>Represents the <see cref="SvgArcSegment"/> class.</summary>
public sealed partial class SvgArcSegment : SvgPathSegment
{
    private const double RadiansPerDegree = Math.PI / 180.0;
    private const double DoublePI = Math.PI * 2;

    /// <summary>Gets or sets the RadiusX.</summary>
    public float RadiusX { get; set; }

    /// <summary>Gets or sets the RadiusY.</summary>
    public float RadiusY { get; set; }

    /// <summary>Gets or sets the Angle.</summary>
    public float Angle { get; set; }

    /// <summary>Gets or sets the Sweep.</summary>
    public SvgArcSweep Sweep { get; set; }

    /// <summary>Gets or sets the Size.</summary>
    public SvgArcSize Size { get; set; }

    /// <summary>Gets or sets the SvgArcSegment(float, float, float, SvgArcSize, SvgArcSweep, bool, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgArcSegment"/> class with the specified parameters.</summary>
    public SvgArcSegment(float radiusX, float radiusY, float angle, SvgArcSize size, SvgArcSweep sweep, bool isRelative, SvgPointF end)
        : base(isRelative, end)
    {
        RadiusX = Math.Abs(radiusX);
        RadiusY = Math.Abs(radiusY);
        Angle = angle;
        Sweep = sweep;
        Size = size;
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        var arcFlag = Size == SvgArcSize.Large ? "1" : "0";
        var sweepFlag = Sweep == SvgArcSweep.Positive ? "1" : "0";
        return (IsRelative ? "a" : "A") + RadiusX.ToSvgString() + " " + RadiusY.ToSvgString() + " " + Angle.ToSvgString() + " " + arcFlag + " " + sweepFlag + " " + End.ToSvgString();
    }

    /// <summary>Gets or sets the SvgArcSegment(SvgPointF, float, float, float, SvgArcSize, SvgArcSweep, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgArcSegment"/> class with the specified parameters.</summary>
    [Obsolete("Use new constructor.")]
    public SvgArcSegment(SvgPointF start, float radiusX, float radiusY, float angle, SvgArcSize size, SvgArcSweep sweep, SvgPointF end)
        : this(radiusX, radiusY, angle, size, sweep, false, end)
    {
        Start = start;
    }
}

/// <summary>Gets or sets the SvgArcSweep.</summary>
/// <summary>Defines the SvgArcSweep enumeration.</summary>
[Flags]
public enum SvgArcSweep
{
    /// <summary>Gets or sets the Negative.</summary>
    /// <summary>The Negative value.</summary>
    Negative = 0,
    /// <summary>Gets or sets the Positive.</summary>
    /// <summary>The Positive value.</summary>
    Positive = 1
}

/// <summary>Gets or sets the SvgArcSize.</summary>
/// <summary>Defines the SvgArcSize enumeration.</summary>
[Flags]
public enum SvgArcSize
{
    /// <summary>Gets or sets the Small.</summary>
    /// <summary>The Small value.</summary>
    Small = 0,
    /// <summary>Gets or sets the Large.</summary>
    /// <summary>The Large value.</summary>
    Large = 1
}
