namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>
/// Note: this is not used in calculations to bitmap - used only to allow for svg xml output
/// </summary>
[SvgElement("feColorMatrix")]
public partial class SvgColorMatrix : SvgFilterPrimitive
{
    private SvgColorMatrixType _type;
    private string _values;

    /// <summary>
    /// matrix | saturate | hueRotate | luminanceToAlpha
    /// Indicates the type of matrix operation. The keyword 'matrix' indicates that a full 5x4 matrix of values will be provided. The other keywords represent convenience shortcuts to allow commonly used color operations to be performed without specifying a complete matrix. If attribute 'type' is not specified, then the effect is as if a value of matrix were specified.
    /// Note: this is not used in calculations to bitmap - used only to allow for svg xml output
    /// </summary>
    [SvgAttribute("type")]
    public SvgColorMatrixType Type
    {
        get { return _type; }
        set { _type = value; Attributes["type"] = value; }
    }

    /// <summary>
    /// list of numbers
    /// The contents of ?values? depends on the value of attribute ?type?:
    /// Note: this is not used in calculations to bitmap - used only to allow for svg xml output
    /// </summary>
    [SvgAttribute("values")]
    public string Values
    {
        get { return _values; }
        set { _values = value; Attributes["values"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgColorMatrix>();
    }

    /// <summary>Gets or sets the DeepCopy.</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy<T>()
    {
        var newObj = base.DeepCopy<T>() as SvgColorMatrix;

        newObj._type = _type;
        newObj._values = _values;
        return newObj;
    }
}
