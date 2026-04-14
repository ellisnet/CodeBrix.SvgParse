namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgDisplacementMap.</summary>
/// <summary>Represents the <see cref="SvgDisplacementMap"/> class.</summary>
[SvgElement("feDisplacementMap")]
public partial class SvgDisplacementMap : SvgFilterPrimitive
{
    /// <summary>Gets or sets the Scale.</summary>
    [SvgAttribute("scale")]
    public float Scale
    {
        get { return GetAttribute("scale", false, 0f); }
        set { Attributes["scale"] = value; }
    }

    /// <summary>Gets or sets the XChannelSelector.</summary>
    [SvgAttribute("xChannelSelector")]
    public SvgChannelSelector XChannelSelector
    {
        get { return GetAttribute("xChannelSelector", false, SvgChannelSelector.A); }
        set { Attributes["xChannelSelector"] = value; }
    }

    /// <summary>Gets or sets the YChannelSelector.</summary>
    [SvgAttribute("yChannelSelector")]
    public SvgChannelSelector YChannelSelector
    {
        get { return GetAttribute("yChannelSelector", false, SvgChannelSelector.A); }
        set { Attributes["yChannelSelector"] = value; }
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
        return DeepCopy<SvgDisplacementMap>();
    }
}
