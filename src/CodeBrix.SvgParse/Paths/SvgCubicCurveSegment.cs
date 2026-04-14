
namespace CodeBrix.SvgParse.Pathing; //Was previously: namespace Svg.Pathing;

/// <summary>Gets or sets the SvgCubicCurveSegment.</summary>
/// <summary>Represents the <see cref="SvgCubicCurveSegment"/> class.</summary>
public sealed partial class SvgCubicCurveSegment : SvgPathSegment
{
    /// <summary>Gets or sets the FirstControlPoint.</summary>
    public SvgPointF FirstControlPoint { get; set; }
    /// <summary>Gets or sets the SecondControlPoint.</summary>
    public SvgPointF SecondControlPoint { get; set; }

    /// <summary>Gets or sets the SvgCubicCurveSegment(bool, SvgPointF, SvgPointF, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgCubicCurveSegment"/> class with the specified parameters.</summary>
    public SvgCubicCurveSegment(bool isRelative, SvgPointF firstControlPoint, SvgPointF secondControlPoint, SvgPointF end)
        : base(isRelative, end)
    {
        FirstControlPoint = firstControlPoint;
        SecondControlPoint = secondControlPoint;
    }

    /// <summary>Gets or sets the SvgCubicCurveSegment(bool, SvgPointF, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgCubicCurveSegment"/> class with the specified parameters.</summary>
    public SvgCubicCurveSegment(bool isRelative, SvgPointF secondControlPoint, SvgPointF end)
        : this(isRelative, NaN, secondControlPoint, end)
    {
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        if (float.IsNaN(FirstControlPoint.X) || float.IsNaN(FirstControlPoint.Y))
            return (IsRelative ? "s" : "S") + SecondControlPoint.ToSvgString() + " " + End.ToSvgString();
        else
            return (IsRelative ? "c" : "C") + FirstControlPoint.ToSvgString() + " " + SecondControlPoint.ToSvgString() + " " + End.ToSvgString();
    }

    /// <summary>Gets or sets the SvgCubicCurveSegment(SvgPointF, SvgPointF, SvgPointF, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgCubicCurveSegment"/> class with the specified parameters.</summary>
    [System.Obsolete("Use new constructor.")]
    public SvgCubicCurveSegment(SvgPointF start, SvgPointF firstControlPoint, SvgPointF secondControlPoint, SvgPointF end)
        : this(false, firstControlPoint, secondControlPoint, end)
    {
        Start = start;
    }
}
