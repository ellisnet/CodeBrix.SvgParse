using System;
using System.Collections.Generic;
using System.ComponentModel;
using CodeBrix.SvgParse.Transforms;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Svg.Custom copy of the upstream gradient server base class.
///
/// The original implementation delegates stop-color and stop-opacity to the generic attribute
/// inheritance machinery. That is normally fine, but W3C gradients such as
/// <c>pservers-grad-18-b</c> rely on two SVG-specific edge cases:
///
/// - <c>stop-color="inherit"</c> on a child stop must resolve through the parent gradient's
///   computed stop color, which differs from simply scanning for any ancestor value.
/// - <c>stop-opacity="inherit"</c> must follow the same parent-computed rule even when the
///   keyword survives only as a raw presentation attribute.
/// - Neither property should fall back through <c>xlink:href</c>; resvg fixtures such as
///   <c>e-stop-018</c> expect referenced gradients to keep the initial stop defaults unless
///   the referenced gradient explicitly authors a stop value of its own.
///
/// Upstream stores <c>inherit</c> for paint servers as the shared
/// <see cref="SvgPaintServer.Inherit"/> sentinel, which generic code can misread as a concrete
/// black color. This local copy keeps the rest of the upstream behavior intact, but routes the
/// stop getters through <see cref="SvgStopInheritanceResolver"/> so Svg.Skia follows the same
/// inheritance chain Chrome does, without carrying a permanent submodule patch.
/// </summary>
public abstract partial class SvgGradientServer : SvgPaintServer
{
    /// <summary>Gets or sets the AddElement(SvgElement, int).</summary>
    protected override void AddElement(SvgElement child, int index)
    {
        if (child is SvgGradientStop svgGradientStop)
        {
            Stops.Add(svgGradientStop);
        }

        base.AddElement(child, index);
    }

    /// <summary>Gets or sets the RemoveElement(SvgElement).</summary>
    protected override void RemoveElement(SvgElement child)
    {
        if (child is SvgGradientStop svgGradientStop)
        {
            Stops.Remove(svgGradientStop);
        }

        base.RemoveElement(child);
    }

    /// <summary>Gets or sets the Stops.</summary>
    public List<SvgGradientStop> Stops { get; } = new List<SvgGradientStop>();

    /// <summary>Gets or sets the SpreadMethod.</summary>
    [SvgAttribute("spreadMethod")]
    public SvgGradientSpreadMethod SpreadMethod
    {
        get { return GetAttribute("spreadMethod", false, SvgDeferredPaintServer.TryGet<SvgGradientServer>(InheritGradient, null)?.SpreadMethod ?? SvgGradientSpreadMethod.Pad); }
        set { Attributes["spreadMethod"] = value; }
    }

    /// <summary>Gets or sets the GradientUnits.</summary>
    [SvgAttribute("gradientUnits")]
    public SvgCoordinateUnits GradientUnits
    {
        get { return GetAttribute("gradientUnits", false, SvgDeferredPaintServer.TryGet<SvgGradientServer>(InheritGradient, null)?.GradientUnits ?? SvgCoordinateUnits.ObjectBoundingBox); }
        set { Attributes["gradientUnits"] = value; }
    }

    /// <summary>Gets or sets the InheritGradient.</summary>
    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public SvgDeferredPaintServer InheritGradient
    {
        get { return GetAttribute<SvgDeferredPaintServer>("href", false); }
        set { Attributes["href"] = value; }
    }

    /// <summary>Gets or sets the GradientTransform.</summary>
    [SvgAttribute("gradientTransform")]
    public SvgTransformCollection GradientTransform
    {
        get { return GetAttribute("gradientTransform", false, SvgDeferredPaintServer.TryGet<SvgGradientServer>(InheritGradient, null)?.GradientTransform); }
        set { Attributes["gradientTransform"] = value; }
    }

    /// <summary>Gets or sets the StopColor.</summary>
    [SvgAttribute("stop-color")]
    [TypeConverter(typeof(SvgPaintServerFactory))]
    public SvgPaintServer StopColor
    {
        get
        {
            return SvgStopInheritanceResolver.ResolveStopColor(this, false, new SvgColorServer(SvgColor.Black));
        }
        set { Attributes["stop-color"] = value; }
    }

    /// <summary>Gets or sets the StopOpacity.</summary>
    [SvgAttribute("stop-opacity")]
    public float StopOpacity
    {
        get
        {
            return SvgStopInheritanceResolver.ResolveStopOpacity(this, false, 1f);
        }
        set { Attributes["stop-opacity"] = FixOpacityValue(value); }
    }

    /// <summary>Gets or sets the CalculateDistance(SvgPointF, SvgPointF).</summary>
    protected static double CalculateDistance(SvgPointF first, SvgPointF second)
    {
        return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
    }

    /// <summary>Gets or sets the CalculateLength(SvgPointF).</summary>
    protected static float CalculateLength(SvgPointF vector)
    {
        return (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
    }

    private void LoadStops(SvgVisualElement parent)
    {
        Stops.RemoveAll(s => s.Parent != this);

        var gradient = this;
        while (gradient?.Stops.Count == 0)
        {
            gradient = SvgDeferredPaintServer.TryGet<SvgGradientServer>(gradient.InheritGradient, parent);
        }

        if (gradient != this && gradient != null)
        {
            Stops.AddRange(gradient.Stops);
        }
    }
}
