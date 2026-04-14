using System.IO;
using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgDocumentParsingTests
{
    [Fact]
    public void FromSvg_ParsesMinimalDocument()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """<svg xmlns="http://www.w3.org/2000/svg" width="100" height="50"></svg>""");

        Assert.NotNull(doc);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 100), doc.Width);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 50), doc.Height);
    }

    [Fact]
    public void FromSvg_ParsesDocumentWithChildren()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="200">
              <rect id="r1" x="10" y="20" width="80" height="60" fill="red" />
              <circle id="c1" cx="100" cy="100" r="40" fill="blue" />
            </svg>
            """);

        Assert.NotNull(doc);
        Assert.True(doc.Children.Count >= 2);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect);

        var circle = doc.GetElementById<SvgCircle>("c1");
        Assert.NotNull(circle);
    }

    [Fact]
    public void FromSvg_ParsesNestedGroups()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <g id="group1">
                <rect id="inner" x="0" y="0" width="50" height="50" />
              </g>
            </svg>
            """);

        var group = doc.GetElementById<SvgGroup>("group1");
        Assert.NotNull(group);

        var inner = doc.GetElementById<SvgRectangle>("inner");
        Assert.NotNull(inner);
        Assert.Equal(group, inner.Parent);
    }

    [Fact]
    public void FromSvg_ParsesViewBox()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 800 600" width="400" height="300"></svg>""");

        Assert.Equal(0, doc.ViewBox.MinX);
        Assert.Equal(0, doc.ViewBox.MinY);
        Assert.Equal(800, doc.ViewBox.Width);
        Assert.Equal(600, doc.ViewBox.Height);
    }

    [Fact]
    public void FromSvg_ReturnsDocumentWithOwnerDocumentSet()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect);
        Assert.Same(doc, rect.OwnerDocument);
    }

    [Fact]
    public void Open_FromStream_ParsesDocument()
    {
        var svg = """<svg xmlns="http://www.w3.org/2000/svg" width="100" height="100"><rect id="test" x="0" y="0" width="50" height="50" /></svg>""";
        using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(svg));

        var doc = SvgDocument.Open<SvgDocument>(stream);

        Assert.NotNull(doc);
        var rect = doc.GetElementById<SvgRectangle>("test");
        Assert.NotNull(rect);
    }

    [Fact]
    public void Descendants_ReturnsAllNestedElements()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <g id="g1">
                <g id="g2">
                  <rect id="r1" x="0" y="0" width="10" height="10" />
                </g>
                <circle id="c1" cx="50" cy="50" r="5" />
              </g>
            </svg>
            """);

        var descendants = doc.Descendants().ToList();
        Assert.Contains(descendants, e => e.ID == "g1");
        Assert.Contains(descendants, e => e.ID == "g2");
        Assert.Contains(descendants, e => e.ID == "r1");
        Assert.Contains(descendants, e => e.ID == "c1");
    }
}
