namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgSpotLight.</summary>
/// <summary>Represents the <see cref="SvgSpotLight"/> class.</summary>
[SvgElement("feSpotLight")]
public partial class SvgSpotLight : SvgElement
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

    /// <summary>Gets or sets the PointsAtX.</summary>
    [SvgAttribute("pointsAtX")]
    public float PointsAtX
    {
        get { return GetAttribute("pointsAtX", false, 0f); }
        set { Attributes["pointsAtX"] = value; }
    }

    /// <summary>Gets or sets the PointsAtY.</summary>
    [SvgAttribute("pointsAtY")]
    public float PointsAtY
    {
        get { return GetAttribute("pointsAtY", false, 0f); }
        set { Attributes["pointsAtY"] = value; }
    }

    /// <summary>Gets or sets the PointsAtZ.</summary>
    [SvgAttribute("pointsAtZ")]
    public float PointsAtZ
    {
        get { return GetAttribute("pointsAtZ", false, 0f); }
        set { Attributes["pointsAtZ"] = value; }
    }

    /// <summary>Gets or sets the SpecularExponent.</summary>
    [SvgAttribute("specularExponent")]
    public float SpecularExponent
    {
        get { return GetAttribute("specularExponent", false, 1f); }
        set { Attributes["specularExponent"] = value; }
    }

    /// <summary>Gets or sets the LimitingConeAngle.</summary>
    [SvgAttribute("limitingConeAngle")]
    public float LimitingConeAngle
    {
        get { return GetAttribute("limitingConeAngle", false, float.NaN); }
        set { Attributes["limitingConeAngle"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgSpotLight>();
    }
}
