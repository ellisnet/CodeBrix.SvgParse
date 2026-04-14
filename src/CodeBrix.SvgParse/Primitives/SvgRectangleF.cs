using System;

namespace CodeBrix.SvgParse;

/// <summary>
/// Represents a rectangle defined by a top-left coordinate and a width and height, all
/// as single-precision floating-point values.
/// </summary>
public struct SvgRectangleF : IEquatable<SvgRectangleF>
{
    /// <summary>
    /// Represents an <see cref="SvgRectangleF"/> whose X, Y, Width, and Height are all zero.
    /// </summary>
    public static readonly SvgRectangleF Empty = new SvgRectangleF(0f, 0f, 0f, 0f);

    /// <summary>Gets or sets the X.</summary>
    public float X { get; set; }

    /// <summary>Gets or sets the Y.</summary>
    public float Y { get; set; }

    /// <summary>Gets or sets the Width.</summary>
    public float Width { get; set; }

    /// <summary>Gets or sets the Height.</summary>
    public float Height { get; set; }

    /// <summary>Gets or sets the SvgRectangleF(float, float, float, float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgRectangleF"/> class with the specified parameters.</summary>
    public SvgRectangleF(float x, float y, float width, float height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    /// <summary>Gets or sets the SvgRectangleF(SvgPointF, SvgSizeF).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgRectangleF"/> class with the specified parameters.</summary>
    public SvgRectangleF(SvgPointF location, SvgSizeF size)
    {
        X = location.X;
        Y = location.Y;
        Width = size.Width;
        Height = size.Height;
    }

    /// <summary>Gets or sets the Location.</summary>
    public SvgPointF Location
    {
        get => new SvgPointF(X, Y);
        set { X = value.X; Y = value.Y; }
    }

    /// <summary>Gets or sets the Size.</summary>
    public SvgSizeF Size
    {
        get => new SvgSizeF(Width, Height);
        set { Width = value.Width; Height = value.Height; }
    }

    /// <summary>Gets or sets the Left.</summary>
    public float Left => X;

    /// <summary>Gets or sets the Top.</summary>
    public float Top => Y;

    /// <summary>Gets or sets the Right.</summary>
    public float Right => X + Width;

    /// <summary>Gets or sets the Bottom.</summary>
    public float Bottom => Y + Height;

    /// <summary>Gets or sets the IsEmpty.</summary>
    public bool IsEmpty => Width <= 0f || Height <= 0f;

    /// <summary>Gets or sets the Equals(SvgRectangleF).</summary>
    /// <summary>Performs the Equals(SvgRectangleF) operation.</summary>
    public bool Equals(SvgRectangleF other) =>
        X.Equals(other.X) && Y.Equals(other.Y) &&
        Width.Equals(other.Width) && Height.Equals(other.Height);

    /// <summary>Gets or sets the Equals(object).</summary>
    /// <inheritdoc />
    public override bool Equals(object obj) => obj is SvgRectangleF other && Equals(other);

    /// <summary>Gets or sets the GetHashCode().</summary>
    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(X, Y, Width, Height);

    /// <summary>Gets or sets the operator ==(SvgRectangleF, SvgRectangleF).</summary>
    /// <summary>Determines whether two instances are equal.</summary>
    public static bool operator ==(SvgRectangleF left, SvgRectangleF right) => left.Equals(right);

    /// <summary>Gets or sets the operator !=(SvgRectangleF, SvgRectangleF).</summary>
    /// <summary>Determines whether two instances are not equal.</summary>
    public static bool operator !=(SvgRectangleF left, SvgRectangleF right) => !left.Equals(right);

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString() =>
        $"{{X={X}, Y={Y}, Width={Width}, Height={Height}}}";
}
