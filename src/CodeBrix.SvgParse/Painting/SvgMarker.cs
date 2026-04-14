using System.Linq;
using CodeBrix.SvgParse.Primitives;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgMarker.</summary>
/// <summary>Represents the <see cref="SvgMarker"/> class.</summary>
[SvgElement("marker")]
public partial class SvgMarker : SvgPathBasedElement, ISvgViewPort
{
    private SvgVisualElement _markerElement = null;

    /// <summary>
    /// Return the child element that represent the marker
    /// </summary>
    private SvgVisualElement MarkerElement
    {
        get
        {
            if (_markerElement == null)
            {
                _markerElement = (SvgVisualElement)this.Children.FirstOrDefault(x => x is SvgVisualElement);
            }
            return _markerElement;
        }
    }

    /// <summary>Gets or sets the RefX.</summary>
    [SvgAttribute("refX")]
    public virtual SvgUnit RefX
    {
        get { return GetAttribute<SvgUnit>("refX", false, 0f); }
        set { Attributes["refX"] = value; }
    }

    /// <summary>Gets or sets the RefY.</summary>
    [SvgAttribute("refY")]
    public virtual SvgUnit RefY
    {
        get { return GetAttribute<SvgUnit>("refY", false, 0f); }
        set { Attributes["refY"] = value; }
    }

    /// <summary>Gets or sets the Orient.</summary>
    [SvgAttribute("orient")]
    public virtual SvgOrient Orient
    {
        get { return GetAttribute<SvgOrient>("orient", false, 0f); }
        set { Attributes["orient"] = value; }
    }

    /// <summary>Gets or sets the Overflow.</summary>
    [SvgAttribute("overflow")]
    public virtual SvgOverflow Overflow
    {
        get { return GetAttribute("overflow", false, SvgOverflow.Hidden); }
        set { Attributes["overflow"] = value; }
    }

    /// <summary>Gets or sets the ViewBox.</summary>
    [SvgAttribute("viewBox")]
    public virtual SvgViewBox ViewBox
    {
        get { return GetAttribute<SvgViewBox>("viewBox", false); }
        set { Attributes["viewBox"] = value; }
    }

    /// <summary>Gets or sets the AspectRatio.</summary>
    [SvgAttribute("preserveAspectRatio")]
    public virtual SvgAspectRatio AspectRatio
    {
        get { return GetAttribute<SvgAspectRatio>("preserveAspectRatio", false); }
        set { Attributes["preserveAspectRatio"] = value; }
    }

    /// <summary>Gets or sets the MarkerWidth.</summary>
    [SvgAttribute("markerWidth")]
    public virtual SvgUnit MarkerWidth
    {
        get { return GetAttribute<SvgUnit>("markerWidth", false, 3f); }
        set { Attributes["markerWidth"] = value; }
    }

    /// <summary>Gets or sets the MarkerHeight.</summary>
    [SvgAttribute("markerHeight")]
    public virtual SvgUnit MarkerHeight
    {
        get { return GetAttribute<SvgUnit>("markerHeight", false, 3f); }
        set { Attributes["markerHeight"] = value; }
    }

    /// <summary>Gets or sets the MarkerUnits.</summary>
    [SvgAttribute("markerUnits")]
    public virtual SvgMarkerUnits MarkerUnits
    {
        get { return GetAttribute("markerUnits", false, SvgMarkerUnits.StrokeWidth); }
        set { Attributes["markerUnits"] = value; }
    }

    /// <summary>
    /// If not set set in the marker, consider the attribute in the drawing element.
    /// </summary>
    public override SvgPaintServer Fill
    {
        get
        {
            if (MarkerElement != null)
                return MarkerElement.Fill;
            return base.Fill;
        }
    }

    /// <summary>
    /// If not set set in the marker, consider the attribute in the drawing element.
    /// </summary>
    public override SvgPaintServer Stroke
    {
        get
        {
            if (MarkerElement != null)
                return MarkerElement.Stroke;
            return base.Stroke;
        }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgMarker>();
    }
}
