namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Represents and SVG ellipse element.
/// </summary>
[SvgElement("ellipse")]
public partial class SvgEllipse : SvgPathBasedElement
{
    private SvgUnit _centerX = 0f;
    private SvgUnit _centerY = 0f;
    private SvgUnit _radiusX = 0f;
    private SvgUnit _radiusY = 0f;

    /// <summary>Gets or sets the CenterX.</summary>
    [SvgAttribute("cx")]
    public virtual SvgUnit CenterX
    {
        get { return _centerX; }
        set { _centerX = value; Attributes["cx"] = value; IsPathDirty = true; }
    }

    /// <summary>Gets or sets the CenterY.</summary>
    [SvgAttribute("cy")]
    public virtual SvgUnit CenterY
    {
        get { return _centerY; }
        set { _centerY = value; Attributes["cy"] = value; IsPathDirty = true; }
    }

    /// <summary>Gets or sets the RadiusX.</summary>
    [SvgAttribute("rx")]
    public virtual SvgUnit RadiusX
    {
        get { return _radiusX; }
        set { _radiusX = value; Attributes["rx"] = value; IsPathDirty = true; }
    }

    /// <summary>Gets or sets the RadiusY.</summary>
    [SvgAttribute("ry")]
    public virtual SvgUnit RadiusY
    {
        get { return _radiusY; }
        set { _radiusY = value; Attributes["ry"] = value; IsPathDirty = true; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgEllipse>();
    }

    /// <summary>Gets or sets the DeepCopy.</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy<T>()
    {
        var newObj = base.DeepCopy<T>() as SvgEllipse;

        newObj._centerX = _centerX;
        newObj._centerY = _centerY;
        newObj._radiusX = _radiusX;
        newObj._radiusY = _radiusY;
        return newObj;
    }
}
