namespace CodeBrix.SvgParse.Pathing; //Was previously: namespace Svg.Pathing;

/// <summary>Gets or sets the SvgClosePathSegment.</summary>
/// <summary>Represents the <see cref="SvgClosePathSegment"/> class.</summary>
public sealed partial class SvgClosePathSegment : SvgPathSegment
{
    /// <summary>Gets or sets the SvgClosePathSegment(bool).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgClosePathSegment"/> class with the specified parameters.</summary>
    public SvgClosePathSegment(bool isRelative)
        : base(isRelative)
    {
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        return IsRelative ? "z" : "Z";
    }

    /// <summary>Gets or sets the SvgClosePathSegment().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgClosePathSegment"/> class.</summary>
    [System.Obsolete("Use new constructor.")]
    public SvgClosePathSegment()
        : this(true)
    {
    }
}
