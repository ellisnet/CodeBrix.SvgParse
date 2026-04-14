namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgComposite.</summary>
/// <summary>Represents the <see cref="SvgComposite"/> class.</summary>
[SvgElement("feComposite")]
public partial class SvgComposite : SvgFilterPrimitive
{
    /// <summary>Gets or sets the Operator.</summary>
    [SvgAttribute("operator")]
    public SvgCompositeOperator Operator
    {
        get { return GetAttribute("operator", false, SvgCompositeOperator.Over); }
        set { Attributes["operator"] = value; }
    }

    /// <summary>Gets or sets the K1.</summary>
    [SvgAttribute("k1")]
    public float K1
    {
        get { return GetAttribute("k1", false, 0f); }
        set { Attributes["k1"] = value; }
    }

    /// <summary>Gets or sets the K2.</summary>
    [SvgAttribute("k2")]
    public float K2
    {
        get { return GetAttribute("k2", false, 0f); }
        set { Attributes["k2"] = value; }
    }

    /// <summary>Gets or sets the K3.</summary>
    [SvgAttribute("k3")]
    public float K3
    {
        get { return GetAttribute("k3", false, 0f); }
        set { Attributes["k3"] = value; }
    }

    /// <summary>Gets or sets the K4.</summary>
    [SvgAttribute("k4")]
    public float K4
    {
        get { return GetAttribute("k4", false, 0f); }
        set { Attributes["k4"] = value; }
    }

    /// <summary>Gets or sets the Input2.</summary>
    [SvgAttribute("in2")]
    public string Input2
    {
        get { return GetAttribute<string>("in2", false); }
        set { Attributes["in2"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgComposite>();
    }
}
