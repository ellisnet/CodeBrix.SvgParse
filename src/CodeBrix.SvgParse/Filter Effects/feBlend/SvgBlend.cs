namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgBlend.</summary>
/// <summary>Represents the <see cref="SvgBlend"/> class.</summary>
[SvgElement("feBlend")]
public partial class SvgBlend : SvgFilterPrimitive
{
    /// <summary>Gets or sets the Mode.</summary>
    [SvgAttribute("mode")]
    public SvgBlendMode Mode
    {
        get { return GetAttribute("mode", false, SvgBlendMode.Normal); }
        set { Attributes["mode"] = value; }
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
        return DeepCopy<SvgBlend>();
    }
}
