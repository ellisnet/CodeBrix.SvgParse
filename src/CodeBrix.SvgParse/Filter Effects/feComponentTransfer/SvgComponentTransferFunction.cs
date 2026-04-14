namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgComponentTransferFunction.</summary>
/// <summary>Represents the <see cref="SvgComponentTransferFunction"/> class.</summary>
public abstract partial class SvgComponentTransferFunction : SvgElement
{
    /// <summary>Gets or sets the Type.</summary>
    [SvgAttribute("type")]
    public SvgComponentTransferType Type
    {
        get { return GetAttribute("type", false, SvgComponentTransferType.Identity); }
        set { Attributes["type"] = value; }
    }

    /// <summary>Gets or sets the TableValues.</summary>
    [SvgAttribute("tableValues")]
    public SvgNumberCollection TableValues
    {
        get { return GetAttribute("tableValues", false, new SvgNumberCollection()); }
        set { Attributes["tableValues"] = value; }
    }

    /// <summary>Gets or sets the Slope.</summary>
    [SvgAttribute("slope")]
    public float Slope
    {
        get { return GetAttribute("slope", false, 1f); }
        set { Attributes["slope"] = value; }
    }

    /// <summary>Gets or sets the Intercept.</summary>
    [SvgAttribute("intercept")]
    public float Intercept
    {
        get { return GetAttribute("intercept", false, 0f); }
        set { Attributes["intercept"] = value; }
    }

    /// <summary>Gets or sets the Amplitude.</summary>
    [SvgAttribute("amplitude")]
    public float Amplitude
    {
        get { return GetAttribute("amplitude", false, 1f); }
        set { Attributes["amplitude"] = value; }
    }

    /// <summary>Gets or sets the Exponent.</summary>
    [SvgAttribute("exponent")]
    public float Exponent
    {
        get { return GetAttribute("exponent", false, 1f); }
        set { Attributes["exponent"] = value; }
    }

    /// <summary>Gets or sets the Offset.</summary>
    [SvgAttribute("offset")]
    public float Offset
    {
        get { return GetAttribute("offset", false, 0f); }
        set { Attributes["offset"] = value; }
    }
}
