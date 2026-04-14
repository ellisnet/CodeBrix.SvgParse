using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CodeBrix.SvgParse.Primitives;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgPoint.</summary>
/// <summary>Represents the <see cref="SvgPoint"/> structure.</summary>
public partial struct SvgPoint
{
    private SvgUnit x;
    private SvgUnit y;

    /// <summary>Gets or sets the X.</summary>
    public SvgUnit X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    /// <summary>Gets or sets the Y.</summary>
    public SvgUnit Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    /// <summary>Gets or sets the IsEmpty().</summary>
    /// <summary>Determines whether the specified condition is met for IsEmpty().</summary>
    public bool IsEmpty()
    {
        return (this.X.Value == 0.0f && this.Y.Value == 0.0f);
    }

    /// <summary>Gets or sets the Equals(object).</summary>
    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (obj == null) return false;

        if (!(obj.GetType() == typeof(SvgPoint))) return false;

        var point = (SvgPoint)obj;
        return (point.X.Equals(this.X) && point.Y.Equals(this.Y));
    }

    /// <summary>Gets or sets the GetHashCode().</summary>
    /// <inheritdoc />
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    /// <summary>Gets or sets the SvgPoint(string, string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgPoint"/> class with the specified parameters.</summary>
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicMethods, typeof(SvgUnitConverter))]
    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "DynamicDependency keeps converter safe")]
    public SvgPoint(string x, string y)
    {
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(SvgUnit));

        this.x = (SvgUnit)converter.ConvertFrom(x)!;
        this.y = (SvgUnit)converter.ConvertFrom(y)!;
    }

    /// <summary>Gets or sets the SvgPoint(SvgUnit, SvgUnit).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgPoint"/> class with the specified parameters.</summary>
    public SvgPoint(SvgUnit x, SvgUnit y)
    {
        this.x = x;
        this.y = y;
    }
}
