namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Represents an SVG line element.
/// </summary>
[SvgElement("line")]
public partial class SvgLine : SvgMarkerElement
{
    private SvgUnit _startX = 0f;
    private SvgUnit _startY = 0f;
    private SvgUnit _endX = 0f;
    private SvgUnit _endY = 0f;

    /// <summary>Gets or sets the StartX.</summary>
    [SvgAttribute("x1")]
    public SvgUnit StartX
    {
        get { return _startX; }
        set
        {
            if (_startX != value)
            {
                _startX = value;
                IsPathDirty = true;
            }
            Attributes["x1"] = value;
        }
    }

    /// <summary>Gets or sets the StartY.</summary>
    [SvgAttribute("y1")]
    public SvgUnit StartY
    {
        get { return _startY; }
        set
        {
            if (_startY != value)
            {
                _startY = value;
                IsPathDirty = true;
            }
            Attributes["y1"] = value;
        }
    }

    /// <summary>Gets or sets the EndX.</summary>
    [SvgAttribute("x2")]
    public SvgUnit EndX
    {
        get { return _endX; }
        set
        {
            if (_endX != value)
            {
                _endX = value;
                IsPathDirty = true;
            }
            Attributes["x2"] = value;
        }
    }

    /// <summary>Gets or sets the EndY.</summary>
    [SvgAttribute("y2")]
    public SvgUnit EndY
    {
        get { return _endY; }
        set
        {
            if (_endY != value)
            {
                _endY = value;
                IsPathDirty = true;
            }
            Attributes["y2"] = value;
        }
    }

    /// <summary>Gets or sets the Fill.</summary>
    public override SvgPaintServer Fill
    {
        get { return null; /* Line can't have a fill */ }
        set
        {
            // Do nothing
        }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgLine>();
    }

    /// <summary>Gets or sets the DeepCopy.</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy<T>()
    {
        var newObj = base.DeepCopy<T>() as SvgLine;

        newObj._startX = _startX;
        newObj._startY = _startY;
        newObj._endX = _endX;
        newObj._endY = _endY;
        return newObj;
    }
}
