
namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

internal class GenericBoundable : ISvgBoundable
{
    private SvgRectangleF _rect;

    public GenericBoundable(SvgRectangleF rect)
    {
        _rect = rect;
    }
    public GenericBoundable(float x, float y, float width, float height)
    {
        _rect = new SvgRectangleF(x, y, width, height);
    }

    public SvgPointF Location
    {
        get { return _rect.Location; }
    }

    public SvgSizeF Size
    {
        get { return _rect.Size; }
    }

    public SvgRectangleF Bounds
    {
        get { return _rect; }
    }
}
