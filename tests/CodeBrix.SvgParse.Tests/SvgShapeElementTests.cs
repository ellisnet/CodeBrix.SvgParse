using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgShapeElementTests
{
    [Fact]
    public void SvgRectangle_ParsesAllAttributes()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="200">
              <rect id="r1" x="10" y="20" width="80" height="60" rx="5" ry="3" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 10), rect.X);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 20), rect.Y);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 80), rect.Width);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 60), rect.Height);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 5), rect.CornerRadiusX);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 3), rect.CornerRadiusY);
    }

    [Fact]
    public void SvgCircle_ParsesAllAttributes()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="200">
              <circle id="c1" cx="100" cy="50" r="25" />
            </svg>
            """);

        var circle = doc.GetElementById<SvgCircle>("c1");
        Assert.NotNull(circle);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 100), circle.CenterX);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 50), circle.CenterY);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 25), circle.Radius);
    }

    [Fact]
    public void SvgEllipse_ParsesAllAttributes()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="200">
              <ellipse id="e1" cx="100" cy="80" rx="50" ry="30" />
            </svg>
            """);

        var ellipse = doc.GetElementById<SvgEllipse>("e1");
        Assert.NotNull(ellipse);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 100), ellipse.CenterX);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 80), ellipse.CenterY);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 50), ellipse.RadiusX);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 30), ellipse.RadiusY);
    }

    [Fact]
    public void SvgLine_ParsesAllAttributes()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="200">
              <line id="l1" x1="10" y1="20" x2="90" y2="80" />
            </svg>
            """);

        var line = doc.GetElementById<SvgLine>("l1");
        Assert.NotNull(line);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 10), line.StartX);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 20), line.StartY);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 90), line.EndX);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 80), line.EndY);
    }

    [Fact]
    public void SvgPath_ParsesPathData()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="200">
              <path id="p1" d="M 10 20 L 90 80 Z" />
            </svg>
            """);

        var path = doc.GetElementById<SvgPath>("p1");
        Assert.NotNull(path);
        Assert.NotNull(path.PathData);
        Assert.True(path.PathData.Count >= 3, "Path should have at least M, L, and Z segments.");
    }

    [Fact]
    public void SvgPolygon_ParsesPoints()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="200">
              <polygon id="pg1" points="50,0 100,100 0,100" />
            </svg>
            """);

        var polygon = doc.GetElementById<SvgPolygon>("pg1");
        Assert.NotNull(polygon);
        Assert.NotNull(polygon.Points);
        Assert.Equal(6, polygon.Points.Count); // 3 points x 2 coordinates
    }

    [Fact]
    public void SvgPolyline_ParsesPoints()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="200">
              <polyline id="pl1" points="10,10 40,40 70,10 100,40" />
            </svg>
            """);

        var polyline = doc.GetElementById<SvgPolyline>("pl1");
        Assert.NotNull(polyline);
        Assert.NotNull(polyline.Points);
        Assert.Equal(8, polyline.Points.Count); // 4 points x 2 coordinates
    }
}
