
namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Defines the methods and properties required for an SVG element to be styled.
/// </summary>
public interface ISvgStylable
{
    /// <summary>Gets or sets the Fill.</summary>
    SvgPaintServer Fill { get; set; }
    /// <summary>Gets or sets the Stroke.</summary>
    SvgPaintServer Stroke { get; set; }
    /// <summary>Gets or sets the FillRule.</summary>
    SvgFillRule FillRule { get; set; }
    /// <summary>Gets or sets the Opacity.</summary>
    float Opacity { get; set; }
    /// <summary>Gets or sets the FillOpacity.</summary>
    float FillOpacity { get; set; }
    /// <summary>Gets or sets the StrokeOpacity.</summary>
    float StrokeOpacity { get; set; }
    /// <summary>Gets or sets the StrokeWidth.</summary>
    SvgUnit StrokeWidth { get; set; }
    /// <summary>Gets or sets the StrokeLineCap.</summary>
    SvgStrokeLineCap StrokeLineCap { get; set; }
    /// <summary>Gets or sets the StrokeLineJoin.</summary>
    SvgStrokeLineJoin StrokeLineJoin { get; set; }
    /// <summary>Gets or sets the StrokeMiterLimit.</summary>
    float StrokeMiterLimit { get; set; }
    /// <summary>Gets or sets the StrokeDashArray.</summary>
    SvgUnitCollection StrokeDashArray { get; set; }
    /// <summary>Gets or sets the StrokeDashOffset.</summary>
    SvgUnit StrokeDashOffset { get; set; }
}
