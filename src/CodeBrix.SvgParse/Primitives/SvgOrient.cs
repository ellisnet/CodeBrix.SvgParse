using System.ComponentModel;
using System.Globalization;
using CodeBrix.SvgParse.Primitives;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Represents an orientation in a Scalable Vector Graphics document.
/// </summary>
[TypeConverter(typeof(SvgOrientConverter))]
public class SvgOrient
{
    private bool _isAuto;
    private float _angle;

    /// <summary>Gets or sets the SvgOrient().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgOrient"/> class.</summary>
    public SvgOrient()
        : this(0f)
    {
    }

    /// <summary>Gets or sets the SvgOrient(bool).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgOrient"/> class with the specified parameters.</summary>
    public SvgOrient(bool isAuto)
    {
        IsAuto = isAuto;
    }

    /// <summary>Gets or sets the SvgOrient(bool, bool).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgOrient"/> class with the specified parameters.</summary>
    public SvgOrient(bool isAuto, bool isAutoStartReverse)
    {
        IsAuto = isAuto;
        IsAutoStartReverse = isAutoStartReverse;
    }

    /// <summary>Gets or sets the SvgOrient(float).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgOrient"/> class with the specified parameters.</summary>
    public SvgOrient(float angle)
    {
        Angle = angle;
    }

    /// <summary>
    /// Gets the value of the unit.
    /// </summary>
    public float Angle
    {
        get { return _angle; }
        set
        {
            _angle = value;
            _isAuto = false;
        }
    }

    /// <summary>
    /// Gets the value of the unit.
    /// </summary>
    public bool IsAuto
    {
        get { return _isAuto; }
        set
        {
            _isAuto = value;
            _angle = 0f;
        }
    }

    /// <summary>
    /// If IsAuto is true, indicates if the orientation of a 'marker-start' must be rotated of 180° from the original orientation
    /// </summary>
    /// This allows a single arrowhead marker to be defined that can be used for both the start and end of a path, point in the right directions.
    public bool IsAutoStartReverse { get; set; }

    /// <summary>
    /// Indicates whether this instance and a specified object are equal.
    /// </summary>
    /// <param name="obj">Another object to compare to.</param>
    /// <returns>
    /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
    /// </returns>
    public override bool Equals(object obj)
    {
        if (!(obj is SvgOrient))
            return false;

        var orient = (SvgOrient)obj;
        return (orient.IsAuto == IsAuto && orient.Angle == Angle);
    }

    /// <summary>Gets or sets the GetHashCode().</summary>
    /// <inheritdoc />
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        if (IsAuto)
            return IsAutoStartReverse ? "auto-start-reverse" : "auto";
        else
            return Angle.ToSvgString();
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="System.Single"/> to <see cref="SvgOrient"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator SvgOrient(float value)
    {
        return new SvgOrient(value);
    }
}
