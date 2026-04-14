namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgConvolveMatrix.</summary>
/// <summary>Represents the <see cref="SvgConvolveMatrix"/> class.</summary>
[SvgElement("feConvolveMatrix")]
public partial class SvgConvolveMatrix : SvgFilterPrimitive
{
    /// <summary>Gets or sets the Order.</summary>
    [SvgAttribute("order")]
    public SvgNumberCollection Order
    {
        get { return GetAttribute("order", false, new SvgNumberCollection() { 3f, 3f }); }
        set { Attributes["order"] = value; }
    }

    /// <summary>Gets or sets the KernelMatrix.</summary>
    [SvgAttribute("kernelMatrix")]
    public SvgNumberCollection KernelMatrix
    {
        get { return GetAttribute<SvgNumberCollection>("kernelMatrix", false); }
        set { Attributes["kernelMatrix"] = value; }
    }

    /// <summary>Gets or sets the Divisor.</summary>
    [SvgAttribute("divisor")]
    public float Divisor
    {
        get { return GetAttribute<float>("divisor", false); }
        set { Attributes["divisor"] = value; }
    }

    /// <summary>Gets or sets the Bias.</summary>
    [SvgAttribute("bias")]
    public float Bias
    {
        get { return GetAttribute("bias", false, 0f); }
        set { Attributes["bias"] = value; }
    }

    /// <summary>Gets or sets the TargetX.</summary>
    [SvgAttribute("targetX")]
    public int TargetX
    {
        get { return GetAttribute<int>("targetX", false); }
        set { Attributes["targetX"] = value; }
    }

    /// <summary>Gets or sets the TargetY.</summary>
    [SvgAttribute("targetY")]
    public int TargetY
    {
        get { return GetAttribute<int>("targetY", false); }
        set { Attributes["targetY"] = value; }
    }

    /// <summary>Gets or sets the EdgeMode.</summary>
    [SvgAttribute("edgeMode")]
    public SvgEdgeMode EdgeMode
    {
        get { return GetAttribute("edgeMode", false, SvgEdgeMode.Duplicate); }
        set { Attributes["edgeMode"] = value; }
    }

    /// <summary>Gets or sets the KernelUnitLength.</summary>
    [SvgAttribute("kernelUnitLength")]
    public SvgNumberCollection KernelUnitLength
    {
        get { return GetAttribute("kernelUnitLength", false, new SvgNumberCollection() { 1f, 1f }); }
        set { Attributes["kernelUnitLength"] = value; }
    }

    /// <summary>Gets or sets the PreserveAlpha.</summary>
    [SvgAttribute("preserveAlpha")]
    public bool PreserveAlpha
    {
        get { return GetAttribute("preserveAlpha", false, defaultValue: false); }
        set { Attributes["preserveAlpha"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgConvolveMatrix>();
    }
}
