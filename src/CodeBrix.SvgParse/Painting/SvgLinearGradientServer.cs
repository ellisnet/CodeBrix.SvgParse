namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgLinearGradientServer.</summary>
/// <summary>Represents the <see cref="SvgLinearGradientServer"/> class.</summary>
[SvgElement("linearGradient")]
public partial class SvgLinearGradientServer : SvgGradientServer
{
    /// <summary>Gets or sets the X1.</summary>
    [SvgAttribute("x1")]
    public SvgUnit X1
    {
        get { return GetAttribute("x1", false, SvgDeferredPaintServer.TryGet<SvgLinearGradientServer>(InheritGradient, null)?.X1 ?? new SvgUnit(SvgUnitType.Percentage, 0f)); }
        set { Attributes["x1"] = value; }
    }

    /// <summary>Gets or sets the Y1.</summary>
    [SvgAttribute("y1")]
    public SvgUnit Y1
    {
        get { return GetAttribute("y1", false, SvgDeferredPaintServer.TryGet<SvgLinearGradientServer>(InheritGradient, null)?.Y1 ?? new SvgUnit(SvgUnitType.Percentage, 0f)); }
        set { Attributes["y1"] = value; }
    }

    /// <summary>Gets or sets the X2.</summary>
    [SvgAttribute("x2")]
    public SvgUnit X2
    {
        get { return GetAttribute("x2", false, SvgDeferredPaintServer.TryGet<SvgLinearGradientServer>(InheritGradient, null)?.X2 ?? new SvgUnit(SvgUnitType.Percentage, 100f)); }
        set { Attributes["x2"] = value; }
    }

    /// <summary>Gets or sets the Y2.</summary>
    [SvgAttribute("y2")]
    public SvgUnit Y2
    {
        get { return GetAttribute("y2", false, SvgDeferredPaintServer.TryGet<SvgLinearGradientServer>(InheritGradient, null)?.Y2 ?? new SvgUnit(SvgUnitType.Percentage, 0f)); }
        set { Attributes["y2"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgLinearGradientServer>();
    }
}
