namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgPointLight.</summary>
/// <summary>Represents the <see cref="SvgPointLight"/> class.</summary>
[SvgElement("fePointLight")]
public partial class SvgPointLight : SvgElement
{
    /// <summary>Gets or sets the X.</summary>
    [SvgAttribute("x")]
    public float X
    {
        get { return GetAttribute("x", false, 0f); }
        set { Attributes["x"] = value; }
    }

    /// <summary>Gets or sets the Y.</summary>
    [SvgAttribute("y")]
    public float Y
    {
        get { return GetAttribute("y", false, 0f); }
        set { Attributes["y"] = value; }
    }

    /// <summary>Gets or sets the Z.</summary>
    [SvgAttribute("z")]
    public float Z
    {
        get { return GetAttribute("z", false, 0f); }
        set { Attributes["z"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgPointLight>();
    }
}
