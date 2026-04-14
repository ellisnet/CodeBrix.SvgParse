
namespace CodeBrix.SvgParse.Pathing; //Was previously: namespace Svg.Pathing;

/// <summary>Gets or sets the SvgMoveToSegment.</summary>
/// <summary>Represents the <see cref="SvgMoveToSegment"/> class.</summary>
public sealed partial class SvgMoveToSegment : SvgPathSegment
{
    /// <summary>Gets or sets the SvgMoveToSegment(bool, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgMoveToSegment"/> class with the specified parameters.</summary>
    public SvgMoveToSegment(bool isRelative, SvgPointF moveTo)
        : base(isRelative, moveTo)
    {
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        return (IsRelative ? "m" : "M") + End.ToSvgString();
    }

    /// <summary>Gets or sets the SvgMoveToSegment(SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgMoveToSegment"/> class with the specified parameters.</summary>
    [System.Obsolete("Use new constructor.")]
    public SvgMoveToSegment(SvgPointF moveTo)
        : this(false, moveTo)
    {
        Start = moveTo;
    }
}
