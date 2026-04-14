using System;

namespace CodeBrix.SvgParse;

/// <summary>
/// Represents an ordered pair of single-precision floating-point X and Y coordinates
/// that defines a point in a two-dimensional plane.
/// </summary>
public struct SvgPointF : IEquatable<SvgPointF>
{
    /// <summary>
    /// Represents an <see cref="SvgPointF"/> whose X and Y coordinates are both zero.
    /// </summary>
    public static readonly SvgPointF Empty = new SvgPointF(0f, 0f);

    /// <summary>
    /// Represents an <see cref="SvgPointF"/> whose X and Y coordinates are both <see cref="float.NaN"/>.
    /// Used as a sentinel for omitted or unspecified coordinates (e.g. smooth curve control points).
    /// </summary>
    public static readonly SvgPointF NaN = new SvgPointF(float.NaN, float.NaN);

    /// <summary>Gets or sets the X.</summary>
    public float X { get; set; }

    /// <summary>Gets or sets the Y.</summary>
    public float Y { get; set; }

    /// <summary>Gets or sets the SvgPointF(float, float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgPointF"/> class with the specified parameters.</summary>
    public SvgPointF(float x, float y)
    {
        X = x;
        Y = y;
    }

    /// <summary>Gets or sets the IsEmpty.</summary>
    public bool IsEmpty => X == 0f && Y == 0f;

    /// <summary>Gets or sets the Equals(SvgPointF).</summary>
    /// <summary>Performs the Equals(SvgPointF) operation.</summary>
    public bool Equals(SvgPointF other) => X.Equals(other.X) && Y.Equals(other.Y);

    /// <summary>Gets or sets the Equals(object).</summary>
    /// <inheritdoc />
    public override bool Equals(object obj) => obj is SvgPointF other && Equals(other);

    /// <summary>Gets or sets the GetHashCode().</summary>
    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(X, Y);

    /// <summary>Gets or sets the operator ==(SvgPointF, SvgPointF).</summary>
    /// <summary>Determines whether two instances are equal.</summary>
    public static bool operator ==(SvgPointF left, SvgPointF right) => left.Equals(right);

    /// <summary>Gets or sets the operator !=(SvgPointF, SvgPointF).</summary>
    /// <summary>Determines whether two instances are not equal.</summary>
    public static bool operator !=(SvgPointF left, SvgPointF right) => !left.Equals(right);

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString() => $"{{X={X}, Y={Y}}}";
}
