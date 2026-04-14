namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgDistantLight.</summary>
/// <summary>Represents the <see cref="SvgDistantLight"/> class.</summary>
[SvgElement("feDistantLight")]
public partial class SvgDistantLight : SvgElement
{
    /// <summary>Gets or sets the Azimuth.</summary>
    [SvgAttribute("azimuth")]
    public float Azimuth
    {
        get { return GetAttribute("azimuth", false, 0f); }
        set { Attributes["azimuth"] = value; }
    }

    /// <summary>Gets or sets the Elevation.</summary>
    [SvgAttribute("elevation")]
    public float Elevation
    {
        get { return GetAttribute("elevation", false, 0f); }
        set { Attributes["elevation"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgDistantLight>();
    }
}
