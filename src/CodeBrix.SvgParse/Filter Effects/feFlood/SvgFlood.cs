namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgFlood.</summary>
/// <summary>Represents the <see cref="SvgFlood"/> class.</summary>
[SvgElement("feFlood")]
public partial class SvgFlood : SvgFilterPrimitive
{
    /// <summary>Gets or sets the FloodColor.</summary>
    [SvgAttribute("flood-color")]
    public virtual SvgPaintServer FloodColor
    {
        get { return GetAttribute("flood-color", true, SvgPaintServer.NotSet); }
        set { Attributes["flood-color"] = value; }
    }

    /// <summary>Gets or sets the FloodOpacity.</summary>
    [SvgAttribute("flood-opacity")]
    public virtual float FloodOpacity
    {
        get { return GetAttribute("flood-opacity", true, 1f); }
        set { Attributes["flood-opacity"] = FixOpacityValue(value); }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgFlood>();
    }
}
