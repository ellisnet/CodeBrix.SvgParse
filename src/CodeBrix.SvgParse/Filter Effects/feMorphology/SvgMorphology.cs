namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgMorphology.</summary>
/// <summary>Represents the <see cref="SvgMorphology"/> class.</summary>
[SvgElement("feMorphology")]
public partial class SvgMorphology : SvgFilterPrimitive
{
    /// <summary>Gets or sets the Operator.</summary>
    [SvgAttribute("operator")]
    public SvgMorphologyOperator Operator
    {
        get { return GetAttribute("operator", false, SvgMorphologyOperator.Erode); }
        set { Attributes["operator"] = value; }
    }

    /// <summary>Gets or sets the Radius.</summary>
    [SvgAttribute("radius")]
    public SvgNumberCollection Radius
    {
        get { return GetAttribute("radius", false, new SvgNumberCollection() { 0f, 0f }); }
        set { Attributes["radius"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgMorphology>();
    }
}
