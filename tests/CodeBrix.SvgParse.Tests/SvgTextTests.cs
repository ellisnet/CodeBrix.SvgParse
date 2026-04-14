using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgTextTests
{
    [Fact]
    public void SvgText_ParsesTextContent()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="100">
              <text id="t1" x="10" y="30">Hello World</text>
            </svg>
            """);

        var text = doc.GetElementById<SvgText>("t1");
        Assert.NotNull(text);
        Assert.Contains("Hello World", text.Text);
    }

    [Fact]
    public void SvgText_ParsesPositionAttributes()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="100">
              <text id="t1" x="25" y="50">Test</text>
            </svg>
            """);

        var text = doc.GetElementById<SvgText>("t1");
        Assert.NotNull(text);
    }

    [Fact]
    public void SvgTextSpan_ParsesNestedSpans()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="100">
              <text id="t1" x="10" y="30">
                Hello <tspan id="bold" font-weight="bold">World</tspan>
              </text>
            </svg>
            """);

        var text = doc.GetElementById<SvgText>("t1");
        Assert.NotNull(text);

        var span = doc.GetElementById<SvgTextSpan>("bold");
        Assert.NotNull(span);
        Assert.Equal(text, span.Parent);
    }
}
