namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgRadialGradientServer.</summary>
/// <summary>Represents the <see cref="SvgRadialGradientServer"/> class.</summary>
[SvgElement("radialGradient")]
public partial class SvgRadialGradientServer : SvgGradientServer
{
    /// <summary>Gets or sets the CenterX.</summary>
    [SvgAttribute("cx")]
    public SvgUnit CenterX
    {
        get { return GetAttribute("cx", false, SvgDeferredPaintServer.TryGet<SvgRadialGradientServer>(InheritGradient, null)?.CenterX ?? new SvgUnit(SvgUnitType.Percentage, 50f)); }
        set { Attributes["cx"] = value; }
    }

    /// <summary>Gets or sets the CenterY.</summary>
    [SvgAttribute("cy")]
    public SvgUnit CenterY
    {
        get { return GetAttribute("cy", false, SvgDeferredPaintServer.TryGet<SvgRadialGradientServer>(InheritGradient, null)?.CenterY ?? new SvgUnit(SvgUnitType.Percentage, 50f)); }
        set { Attributes["cy"] = value; }
    }

    /// <summary>Gets or sets the Radius.</summary>
    [SvgAttribute("r")]
    public SvgUnit Radius
    {
        get { return GetAttribute("r", false, SvgDeferredPaintServer.TryGet<SvgRadialGradientServer>(InheritGradient, null)?.Radius ?? new SvgUnit(SvgUnitType.Percentage, 50f)); }
        set { Attributes["r"] = value; }
    }

    /// <summary>Gets or sets the FocalX.</summary>
    [SvgAttribute("fx")]
    public SvgUnit FocalX
    {
        get
        {
            var value = GetAttribute("fx", false, SvgDeferredPaintServer.TryGet<SvgRadialGradientServer>(InheritGradient, null)?.FocalX ?? SvgUnit.None);
            if (value.IsEmpty || value.IsNone)
                value = CenterX;
            return value;
        }
        set { Attributes["fx"] = value; }
    }

    /// <summary>Gets or sets the FocalY.</summary>
    [SvgAttribute("fy")]
    public SvgUnit FocalY
    {
        get
        {
            var value = GetAttribute("fy", false, SvgDeferredPaintServer.TryGet<SvgRadialGradientServer>(InheritGradient, null)?.FocalY ?? SvgUnit.None);
            if (value.IsEmpty || value.IsNone)
                value = CenterY;
            return value;
        }
        set { Attributes["fy"] = value; }
    }

    /// <summary>Gets or sets the FocalRadius.</summary>
    [SvgAttribute("fr")]
    public SvgUnit FocalRadius
    {
        get { return GetAttribute("fr", false, SvgDeferredPaintServer.TryGet<SvgRadialGradientServer>(InheritGradient, null)?.FocalRadius ?? new SvgUnit(SvgUnitType.Percentage, 0f)); }
        set { Attributes["fr"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgRadialGradientServer>();
    }
}
