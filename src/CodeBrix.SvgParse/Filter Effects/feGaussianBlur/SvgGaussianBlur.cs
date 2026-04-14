namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the BlurType.</summary>
/// <summary>Defines the BlurType enumeration.</summary>
public enum BlurType
{
    /// <summary>Gets or sets the Both.</summary>
    /// <summary>The Both value.</summary>
    Both,
    /// <summary>Gets or sets the HorizontalOnly.</summary>
    /// <summary>The HorizontalOnly value.</summary>
    HorizontalOnly,
    /// <summary>Gets or sets the VerticalOnly.</summary>
    /// <summary>The VerticalOnly value.</summary>
    VerticalOnly,
}

/// <summary>Gets or sets the SvgGaussianBlur.</summary>
/// <summary>Represents the <see cref="SvgGaussianBlur"/> class.</summary>
[SvgElement("feGaussianBlur")]
public partial class SvgGaussianBlur : SvgFilterPrimitive
{
    /// <summary>
    /// Gets or sets the radius of the blur (only allows for one value - not the two specified in the SVG Spec)
    /// </summary>
    [SvgAttribute("stdDeviation")]
    public SvgNumberCollection StdDeviation
    {
        get { return GetAttribute("stdDeviation", false, new SvgNumberCollection() { 0f }); }
        set { Attributes["stdDeviation"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgGaussianBlur>();
    }
}
