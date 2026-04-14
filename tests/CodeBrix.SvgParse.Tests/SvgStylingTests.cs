using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgStylingTests
{
    [Fact]
    public void Fill_ParsesSolidColor()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" fill="red" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect);
        var fill = Assert.IsType<SvgColorServer>(rect.Fill);
        Assert.Equal(SvgColor.Red.ToArgb(), fill.ColorValue.ToArgb());
    }

    [Fact]
    public void Fill_ParsesHexColor()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" fill="#00ff00" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        var fill = Assert.IsType<SvgColorServer>(rect.Fill);
        Assert.Equal(0, fill.ColorValue.R);
        Assert.Equal(255, fill.ColorValue.G);
        Assert.Equal(0, fill.ColorValue.B);
    }

    [Fact]
    public void Fill_ParsesNone()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" fill="none" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.Same(SvgPaintServer.None, rect.Fill);
    }

    [Fact]
    public void Stroke_ParsesColorAndWidth()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" stroke="blue" stroke-width="3" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        var stroke = Assert.IsType<SvgColorServer>(rect.Stroke);
        Assert.Equal(SvgColor.Blue.ToArgb(), stroke.ColorValue.ToArgb());
        Assert.Equal(new SvgUnit(SvgUnitType.User, 3), rect.StrokeWidth);
    }

    [Fact]
    public void Opacity_ParsesValue()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" opacity="0.5" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.Equal(0.5f, rect.Opacity);
    }

    [Fact]
    public void InlineStyle_OverridesPresentationAttribute()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" fill="red" style="fill: blue" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        var fill = Assert.IsType<SvgColorServer>(rect.Fill);
        Assert.Equal(SvgColor.Blue.ToArgb(), fill.ColorValue.ToArgb());
    }

    [Fact]
    public void StyleElement_AppliesRulesToMatchingElements()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <style>.highlight { fill: green; }</style>
              <rect id="r1" class="highlight" x="0" y="0" width="50" height="50" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        var fill = Assert.IsType<SvgColorServer>(rect.Fill);
        Assert.Equal(SvgColor.Green.ToArgb(), fill.ColorValue.ToArgb());
    }

    [Fact]
    public void Transform_ParsesTranslate()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" transform="translate(10, 20)" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect.Transforms);
        Assert.True(rect.Transforms.Count > 0);
    }

    [Fact]
    public void Visibility_ParsesHidden()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" visibility="hidden" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.Equal("hidden", rect.Visibility);
    }
}
