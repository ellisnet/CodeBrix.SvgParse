using System.Linq;
using CodeBrix.SvgParse;
using CodeBrix.SvgParse.FilterEffects;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgClippingAndFilterTests
{
    [Fact]
    public void ClipPath_ParsesAndReferences()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <defs>
                <clipPath id="clip1">
                  <circle cx="50" cy="50" r="40" />
                </clipPath>
              </defs>
              <rect id="r1" x="0" y="0" width="100" height="100" clip-path="url(#clip1)" />
            </svg>
            """);

        var clipPath = doc.GetElementById<SvgClipPath>("clip1");
        Assert.NotNull(clipPath);
        Assert.True(clipPath.Children.Count > 0);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect);
        Assert.NotNull(rect.ClipPath);
    }

    [Fact]
    public void Mask_ParsesElement()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <defs>
                <mask id="mask1">
                  <rect x="0" y="0" width="100" height="100" fill="white" />
                  <circle cx="50" cy="50" r="30" fill="black" />
                </mask>
              </defs>
              <rect id="r1" x="0" y="0" width="100" height="100" fill="red" mask="url(#mask1)" />
            </svg>
            """);

        var mask = doc.GetElementById<SvgMask>("mask1");
        Assert.NotNull(mask);
        Assert.True(mask.Children.Count >= 2);
    }

    [Fact]
    public void Filter_ParsesElement()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <defs>
                <filter id="blur1">
                  <feGaussianBlur in="SourceGraphic" stdDeviation="5" />
                </filter>
              </defs>
              <rect id="r1" x="10" y="10" width="80" height="80" filter="url(#blur1)" />
            </svg>
            """);

        var filter = doc.GetElementById<SvgFilter>("blur1");
        Assert.NotNull(filter);
        Assert.True(filter.Children.Count > 0);
    }
}
