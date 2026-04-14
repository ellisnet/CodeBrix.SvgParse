using System;

namespace CodeBrix.SvgParse;

/// <summary>
/// Represents a single-precision floating-point width and height that defines a size
/// in a two-dimensional plane.
/// </summary>
public struct SvgSizeF : IEquatable<SvgSizeF>
{
    /// <summary>
    /// Represents an <see cref="SvgSizeF"/> whose Width and Height are both zero.
    /// </summary>
    public static readonly SvgSizeF Empty = new SvgSizeF(0f, 0f);

    /// <summary>Gets or sets the Width.</summary>
    public float Width { get; set; }

    /// <summary>Gets or sets the Height.</summary>
    public float Height { get; set; }

    /// <summary>Gets or sets the SvgSizeF(float, float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgSizeF"/> class with the specified parameters.</summary>
    public SvgSizeF(float width, float height)
    {
        Width = width;
        Height = height;
    }

    /// <summary>Gets or sets the IsEmpty.</summary>
    public bool IsEmpty => Width == 0f && Height == 0f;

    /// <summary>Gets or sets the Equals(SvgSizeF).</summary>
    /// <summary>Performs the Equals(SvgSizeF) operation.</summary>
    public bool Equals(SvgSizeF other) => Width.Equals(other.Width) && Height.Equals(other.Height);

    /// <summary>Gets or sets the Equals(object).</summary>
    /// <inheritdoc />
    public override bool Equals(object obj) => obj is SvgSizeF other && Equals(other);

    /// <summary>Gets or sets the GetHashCode().</summary>
    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(Width, Height);

    /// <summary>Gets or sets the operator ==(SvgSizeF, SvgSizeF).</summary>
    /// <summary>Determines whether two instances are equal.</summary>
    public static bool operator ==(SvgSizeF left, SvgSizeF right) => left.Equals(right);

    /// <summary>Gets or sets the operator !=(SvgSizeF, SvgSizeF).</summary>
    /// <summary>Determines whether two instances are not equal.</summary>
    public static bool operator !=(SvgSizeF left, SvgSizeF right) => !left.Equals(right);

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString() => $"{{Width={Width}, Height={Height}}}";
}
