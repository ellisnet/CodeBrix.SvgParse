using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// An element used to group SVG shapes.
/// </summary>
[SvgElement("symbol")]
public partial class SvgSymbol : SvgVisualElement
{
    /// <summary>
    /// Gets or sets the viewport of the element.
    /// </summary>
    /// <value></value>
    [SvgAttribute("viewBox")]
    public SvgViewBox ViewBox
    {
        get { return GetAttribute<SvgViewBox>("viewBox", false); }
        set { Attributes["viewBox"] = value; }
    }

    /// <summary>
    /// Gets or sets the aspect of the viewport.
    /// </summary>
    /// <value></value>
    [SvgAttribute("preserveAspectRatio")]
    public SvgAspectRatio AspectRatio
    {
        get { return GetAttribute<SvgAspectRatio>("preserveAspectRatio", false); }
        set { Attributes["preserveAspectRatio"] = value; }
    }

    /// <summary>Gets or sets the Renderable.</summary>
    protected override bool Renderable { get { return false; } }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgSymbol>();
    }
}
