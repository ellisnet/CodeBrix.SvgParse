using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgGradientTests
{
    [Fact]
    public void LinearGradient_ParsesStops()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <defs>
                <linearGradient id="grad1">
                  <stop offset="0%" stop-color="red" />
                  <stop offset="100%" stop-color="blue" />
                </linearGradient>
              </defs>
              <rect id="r1" x="0" y="0" width="100" height="100" fill="url(#grad1)" />
            </svg>
            """);

        var gradient = doc.GetElementById<SvgLinearGradientServer>("grad1");
        Assert.NotNull(gradient);
        var stops = gradient.Stops.ToList();
        Assert.Equal(2, stops.Count);
    }

    [Fact]
    public void LinearGradient_ParsesCoordinates()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <defs>
                <linearGradient id="grad1" x1="0%" y1="0%" x2="100%" y2="0%">
                  <stop offset="0%" stop-color="red" />
                  <stop offset="100%" stop-color="blue" />
                </linearGradient>
              </defs>
            </svg>
            """);

        var gradient = doc.GetElementById<SvgLinearGradientServer>("grad1");
        Assert.NotNull(gradient);
    }

    [Fact]
    public void RadialGradient_ParsesAttributes()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <defs>
                <radialGradient id="grad1" cx="50%" cy="50%" r="50%">
                  <stop offset="0%" stop-color="white" />
                  <stop offset="100%" stop-color="black" />
                </radialGradient>
              </defs>
            </svg>
            """);

        var gradient = doc.GetElementById<SvgRadialGradientServer>("grad1");
        Assert.NotNull(gradient);
        var stops = gradient.Stops.ToList();
        Assert.Equal(2, stops.Count);
    }

    [Fact]
    public void GradientStop_ParsesStopColor()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <defs>
                <linearGradient id="grad1">
                  <stop id="s1" offset="0%" stop-color="red" />
                  <stop id="s2" offset="100%" stop-color="#0000ff" />
                </linearGradient>
              </defs>
            </svg>
            """);

        var s1 = doc.GetElementById<SvgGradientStop>("s1");
        Assert.NotNull(s1);
        var color1 = s1.GetColor(s1);
        Assert.Equal(255, color1.R);
        Assert.Equal(0, color1.G);
        Assert.Equal(0, color1.B);

        var s2 = doc.GetElementById<SvgGradientStop>("s2");
        Assert.NotNull(s2);
        var color2 = s2.GetColor(s2);
        Assert.Equal(0, color2.R);
        Assert.Equal(0, color2.G);
        Assert.Equal(255, color2.B);
    }

    [Fact]
    public void Fill_ResolvesGradientReference()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <defs>
                <linearGradient id="myGrad">
                  <stop offset="0%" stop-color="red" />
                  <stop offset="100%" stop-color="blue" />
                </linearGradient>
              </defs>
              <rect id="r1" x="0" y="0" width="100" height="100" fill="url(#myGrad)" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect.Fill);
        // Fill should be a deferred paint server referencing the gradient
        Assert.False(rect.Fill == SvgPaintServer.None);
    }
}
