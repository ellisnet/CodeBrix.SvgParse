using System.ComponentModel;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgDiffuseLighting.</summary>
/// <summary>Represents the <see cref="SvgDiffuseLighting"/> class.</summary>
[SvgElement("feDiffuseLighting")]
public partial class SvgDiffuseLighting : SvgFilterPrimitive
{
    /// <summary>Gets or sets the SurfaceScale.</summary>
    [SvgAttribute("surfaceScale")]
    public float SurfaceScale
    {
        get { return GetAttribute("surfaceScale", false, 1f); }
        set { Attributes["surfaceScale"] = value; }
    }

    /// <summary>Gets or sets the DiffuseConstant.</summary>
    [SvgAttribute("diffuseConstant")]
    public float DiffuseConstant
    {
        get { return GetAttribute("diffuseConstant", false, 1f); }
        set { Attributes["diffuseConstant"] = value; }
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
        return DeepCopy<SvgDiffuseLighting>();
    }
}
