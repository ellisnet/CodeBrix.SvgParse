using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgElementIdTests
{
    [Fact]
    public void GetElementById_ReturnsCorrectElement()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="first" x="0" y="0" width="50" height="50" />
              <rect id="second" x="50" y="50" width="50" height="50" />
            </svg>
            """);

        var first = doc.GetElementById("first");
        var second = doc.GetElementById("second");

        Assert.NotNull(first);
        Assert.NotNull(second);
        Assert.NotSame(first, second);
        Assert.Equal("first", first.ID);
        Assert.Equal("second", second.ID);
    }

    [Fact]
    public void GetElementById_ReturnsNullForMissingId()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="exists" x="0" y="0" width="50" height="50" />
            </svg>
            """);

        var result = doc.GetElementById("does_not_exist");
        Assert.Null(result);
    }

    [Fact]
    public void GetElementById_Generic_ReturnsTypedElement()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <circle id="c1" cx="50" cy="50" r="25" />
            </svg>
            """);

        var circle = doc.GetElementById<SvgCircle>("c1");
        Assert.NotNull(circle);
        Assert.IsType<SvgCircle>(circle);
    }

    [Fact]
    public void Children_Add_RegistersElementId()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """<svg xmlns="http://www.w3.org/2000/svg" width="100" height="100"></svg>""");

        var rect = new SvgRectangle { ID = "dynamic" };
        doc.Children.Add(rect);

        var found = doc.GetElementById("dynamic");
        Assert.NotNull(found);
        Assert.Same(rect, found);
    }

    [Fact]
    public void Children_Remove_UnregistersElementId()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="removeme" x="0" y="0" width="50" height="50" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("removeme");
        Assert.NotNull(rect);

        doc.Children.Remove(rect);
        var afterRemoval = doc.GetElementById("removeme");
        Assert.Null(afterRemoval);
    }
}
