using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgSpecularLighting.</summary>
/// <summary>Represents the <see cref="SvgSpecularLighting"/> class.</summary>
[SvgElement("feSpecularLighting")]
public partial class SvgSpecularLighting : SvgFilterPrimitive
{
    /// <summary>Gets or sets the SurfaceScale.</summary>
    [SvgAttribute("surfaceScale")]
    public float SurfaceScale
    {
        get { return GetAttribute("surfaceScale", false, 1f); }
        set { Attributes["surfaceScale"] = value; }
    }

    /// <summary>Gets or sets the SpecularConstant.</summary>
    [SvgAttribute("specularConstant")]
    public float SpecularConstant
    {
        get { return GetAttribute("specularConstant", false, 1f); }
        set { Attributes["specularConstant"] = value; }
    }

    /// <summary>Gets or sets the SpecularExponent.</summary>
    [SvgAttribute("specularExponent")]
    public float SpecularExponent
    {
        get { return GetAttribute("specularExponent", false, 1f); }
        set { Attributes["specularExponent"] = value; }
    }

    /// <summary>Gets or sets the KernelUnitLength.</summary>
    [SvgAttribute("kernelUnitLength")]
    public SvgNumberCollection KernelUnitLength
    {
        get { return GetAttribute("kernelUnitLength", false, new SvgNumberCollection() { 1f, 1f }); }
        set { Attributes["kernelUnitLength"] = value; }
    }

    /// <summary>Gets or sets the LightingColor.</summary>
    [SvgAttribute("lighting-color")]
    [TypeConverter(typeof(SvgPaintServerFactory))]
    public SvgPaintServer LightingColor
    {
        get { return GetAttribute<SvgPaintServer>("lighting-color", true, new SvgColorServer(SvgColor.White)); }
        set { Attributes["lighting-color"] = value; }
    }

    /// <summary>Gets or sets the LightSource.</summary>
    public SvgElement LightSource
    {
        get
        {
            foreach (var child in this.Children)
            {
                if (child is SvgDistantLight || child is SvgPointLight || child is SvgSpotLight)
                    return child;
            }
            return null;
        }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgSpecularLighting>();
    }
}
