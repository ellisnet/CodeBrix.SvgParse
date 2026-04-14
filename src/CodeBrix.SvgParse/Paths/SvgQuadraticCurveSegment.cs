
namespace CodeBrix.SvgParse.Pathing; //Was previously: namespace Svg.Pathing;

/// <summary>Gets or sets the SvgQuadraticCurveSegment.</summary>
/// <summary>Represents the <see cref="SvgQuadraticCurveSegment"/> class.</summary>
public sealed partial class SvgQuadraticCurveSegment : SvgPathSegment
{
    /// <summary>Gets or sets the ControlPoint.</summary>
    public SvgPointF ControlPoint { get; set; }

    /// <summary>Gets or sets the SvgQuadraticCurveSegment(bool, SvgPointF, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgQuadraticCurveSegment"/> class with the specified parameters.</summary>
    public SvgQuadraticCurveSegment(bool isRelative, SvgPointF controlPoint, SvgPointF end)
        : base(isRelative, end)
    {
        ControlPoint = controlPoint;
    }

    /// <summary>Gets or sets the SvgQuadraticCurveSegment(bool, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgQuadraticCurveSegment"/> class with the specified parameters.</summary>
    public SvgQuadraticCurveSegment(bool isRelative, SvgPointF end)
        : this(isRelative, NaN, end)
    {
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        if (float.IsNaN(ControlPoint.X) || float.IsNaN(ControlPoint.Y))
            return (IsRelative ? "t" : "T") + End.ToSvgString();
        else
            return (IsRelative ? "q" : "Q") + ControlPoint.ToSvgString() + " " + End.ToSvgString();
    }

    /// <summary>Gets or sets the SvgQuadraticCurveSegment(SvgPointF, SvgPointF, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgQuadraticCurveSegment"/> class with the specified parameters.</summary>
    [System.Obsolete("Use new constructor.")]
    public SvgQuadraticCurveSegment(SvgPointF start, SvgPointF controlPoint, SvgPointF end)
        : this(false, controlPoint, end)
    {
        Start = start;
    }
}
