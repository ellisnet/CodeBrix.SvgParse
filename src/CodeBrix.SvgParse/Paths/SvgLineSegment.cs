
namespace CodeBrix.SvgParse.Pathing; //Was previously: namespace Svg.Pathing;

/// <summary>Gets or sets the SvgLineSegment.</summary>
/// <summary>Represents the <see cref="SvgLineSegment"/> class.</summary>
public sealed partial class SvgLineSegment : SvgPathSegment
{
    /// <summary>Gets or sets the SvgLineSegment(bool, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgLineSegment"/> class with the specified parameters.</summary>
    public SvgLineSegment(bool isRelative, SvgPointF end)
        : base(isRelative, end)
    {
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        if (float.IsNaN(End.Y))
            return (IsRelative ? "h" : "H") + End.X.ToSvgString();
        else if (float.IsNaN(End.X))
            return (IsRelative ? "v" : "V") + End.Y.ToSvgString();
        else
            return (IsRelative ? "l" : "L") + End.ToSvgString();
    }

    /// <summary>Gets or sets the SvgLineSegment(SvgPointF, SvgPointF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgLineSegment"/> class with the specified parameters.</summary>
    [System.Obsolete("Use new constructor.")]
    public SvgLineSegment(SvgPointF start, SvgPointF end)
        : this(false, end)
    {
        Start = start;
    }
}
