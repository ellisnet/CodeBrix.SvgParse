namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgTurbulence.</summary>
/// <summary>Represents the <see cref="SvgTurbulence"/> class.</summary>
[SvgElement("feTurbulence")]
public partial class SvgTurbulence : SvgFilterPrimitive
{
    /// <summary>Gets or sets the BaseFrequency.</summary>
    [SvgAttribute("baseFrequency")]
    public SvgNumberCollection BaseFrequency
    {
        get { return GetAttribute("baseFrequency", false, new SvgNumberCollection() { 0f, 0f }); }
        set { Attributes["baseFrequency"] = value; }
    }

    /// <summary>Gets or sets the NumOctaves.</summary>
    [SvgAttribute("numOctaves")]
    public int NumOctaves
    {
        get { return GetAttribute("numOctaves", false, 1); }
        set { Attributes["numOctaves"] = value; }
    }

    /// <summary>Gets or sets the Seed.</summary>
    [SvgAttribute("seed")]
    public float Seed
    {
        get { return GetAttribute("seed", false, 0f); }
        set { Attributes["seed"] = value; }
    }

    /// <summary>Gets or sets the StitchTiles.</summary>
    [SvgAttribute("stitchTiles")]
    public SvgStitchType StitchTiles
    {
        get { return GetAttribute("stitchTiles", false, SvgStitchType.NoStitch); }
        set { Attributes["stitchTiles"] = value; }
    }

    /// <summary>Gets or sets the Type.</summary>
    [SvgAttribute("type")]
    public SvgTurbulenceType Type
    {
        get { return GetAttribute("type", false, SvgTurbulenceType.Turbulence); }
        set { Attributes["type"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgTurbulence>();
    }
}
