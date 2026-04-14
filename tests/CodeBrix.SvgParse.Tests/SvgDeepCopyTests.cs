using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgDeepCopyTests
{
    [Fact]
    public void DeepCopy_Rectangle_CreatesIndependentCopy()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="10" y="20" width="80" height="60" fill="red" />
            </svg>
            """);

        var original = doc.GetElementById<SvgRectangle>("r1");
        var copy = original.DeepCopy() as SvgRectangle;

        Assert.NotNull(copy);
        Assert.NotSame(original, copy);
        Assert.Equal(original.X, copy.X);
        Assert.Equal(original.Y, copy.Y);
        Assert.Equal(original.Width, copy.Width);
        Assert.Equal(original.Height, copy.Height);
    }

    [Fact]
    public void DeepCopy_Group_CopiesChildren()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <g id="g1">
                <rect id="r1" x="0" y="0" width="50" height="50" />
                <circle id="c1" cx="75" cy="75" r="20" />
              </g>
            </svg>
            """);

        var original = doc.GetElementById<SvgGroup>("g1");
        var copy = original.DeepCopy() as SvgGroup;

        Assert.NotNull(copy);
        Assert.NotSame(original, copy);
        Assert.Equal(original.Children.Count, copy.Children.Count);
        Assert.NotSame(original.Children[0], copy.Children[0]);
    }

    [Fact]
    public void DeepCopy_ModifyingCopy_DoesNotAffectOriginal()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="10" y="20" width="80" height="60" />
            </svg>
            """);

        var original = doc.GetElementById<SvgRectangle>("r1");
        var copy = original.DeepCopy() as SvgRectangle;

        copy.X = new SvgUnit(SvgUnitType.User, 999);

        Assert.Equal(new SvgUnit(SvgUnitType.User, 10), original.X);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 999), copy.X);
    }
}
