using System.Globalization;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgColorConverterTests
{
    private static SvgColor Parse(string text)
    {
        var converter = new SvgColorConverter();
        return (SvgColor)converter.ConvertFrom(null, CultureInfo.InvariantCulture, text);
    }

    private static void AssertArgb(SvgColor color, int a, int r, int g, int b)
    {
        Assert.Equal(a, color.A);
        Assert.Equal(r, color.R);
        Assert.Equal(g, color.G);
        Assert.Equal(b, color.B);
    }

    [Fact]
    public void Rgba_ParsesPercentageChannelsWithPercentageAlpha_LilyPondForm()
    {
        // LilyPond's SVG backend writes every color this way; the trailing % on the alpha
        // used to throw and the whole color fell back to black.
        var color = Parse("rgba(83.5294%, 36.8627%, 0.0000%, 100.0000%)");

        AssertArgb(color, 255, 213, 94, 0);
    }

    [Fact]
    public void Rgba_PercentageAlphaOfZero_IsFullyTransparent()
    {
        var color = Parse("rgba(0.0000%, 0.0000%, 0.0000%, 0.0000%)");

        Assert.Equal(0, color.A);
    }

    [Fact]
    public void Rgba_PercentageAlphaOfFifty_IsHalfOpaque()
    {
        var color = Parse("rgba(100%, 0%, 0%, 50%)");

        AssertArgb(color, 128, 255, 0, 0);
    }

    [Fact]
    public void Rgb_IntegerChannels_StillParse()
    {
        var color = Parse("rgb(255, 128, 0)");

        AssertArgb(color, 255, 255, 128, 0);
    }

    [Fact]
    public void Rgba_FractionalAlpha_StillParses()
    {
        AssertArgb(Parse("rgba(255, 0, 0, 0.5)"), 128, 255, 0, 0);
        AssertArgb(Parse("rgba(255, 0, 0, .5)"), 128, 255, 0, 0);
        AssertArgb(Parse("rgba(255, 0, 0, 0)"), 0, 255, 0, 0);
        AssertArgb(Parse("rgba(255, 0, 0, 1)"), 255, 255, 0, 0);
    }

    [Fact]
    public void Rgba_LegacyByteAlpha_StillParses()
    {
        var color = Parse("rgba(255, 0, 0, 128)");

        Assert.Equal(128, color.A);
    }

    [Fact]
    public void Rgb_CssColorLevel4SpaceSyntax_Parses()
    {
        AssertArgb(Parse("rgb(100% 0% 0% / 50%)"), 128, 255, 0, 0);
        AssertArgb(Parse("rgb(255 0 0 / 0.25)"), 64, 255, 0, 0);
        AssertArgb(Parse("rgb(0 128 255)"), 255, 0, 128, 255);
    }

    [Fact]
    public void Rgb_MixedPercentAndNumberChannels_Parse()
    {
        var color = Parse("rgb(100%, 128, 0%)");

        AssertArgb(color, 255, 255, 128, 0);
    }

    [Fact]
    public void Rgb_OutOfRangeValues_AreClamped()
    {
        AssertArgb(Parse("rgb(300, -20, 0)"), 255, 255, 0, 0);
        AssertArgb(Parse("rgba(120%, 0%, 0%, 150%)"), 255, 255, 0, 0);
        AssertArgb(Parse("rgba(0, 0, 0, 1.5)"), 2, 0, 0, 0);
    }

    [Fact]
    public void Rgb_FractionalChannels_Round()
    {
        var color = Parse("rgb(12.6, 0.4, 254.5)");

        AssertArgb(color, 255, 13, 0, 254);
    }

    [Theory]
    [InlineData("rgb(1, 2)")]
    [InlineData("rgb(1, 2, 3, 4, 5)")]
    [InlineData("rgb(a, b, c)")]
    [InlineData("rgb(1, 2, 3")]
    public void Rgb_MalformedArgumentLists_Throw(string text)
    {
        Assert.Throws<SvgException>(() => Parse(text));
    }

    [Fact]
    public void Fill_WithPercentageRgbaOnAnElement_KeepsColorAndAlpha()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" fill="rgba(83.5294%, 36.8627%, 0.0000%, 50.0000%)" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect);
        var fill = Assert.IsType<SvgColorServer>(rect.Fill);
        AssertArgb(fill.ColorValue, 128, 213, 94, 0);
    }

    [Fact]
    public void Color_WithPercentageRgbaOnAGroup_ReachesCurrentColorChildren()
    {
        // The exact shape LilyPond writes: a <g color="rgba(...)"> wrapping fill="currentColor".
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <g fill="currentColor" color="black">
                <g id="g1" color="rgba(0.0000%, 0.0000%, 0.0000%, 0.0000%)">
                  <rect id="r1" x="0" y="0" width="50" height="50" fill="currentColor" />
                </g>
              </g>
            </svg>
            """);

        var group = doc.GetElementById<SvgGroup>("g1");
        Assert.NotNull(group);
        var color = Assert.IsType<SvgColorServer>(group.Color);
        Assert.Equal(0, color.ColorValue.A);
    }
}
