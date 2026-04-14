using System.IO;
using System.Text;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

public class SvgSerializationTests
{
    [Fact]
    public void Write_ProducesValidSvg()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="10" y="20" width="80" height="60" fill="red" />
            </svg>
            """);

        using var stream = new MemoryStream();
        doc.Write(stream);

        stream.Position = 0;
        var output = new StreamReader(stream).ReadToEnd();

        Assert.Contains("<svg", output);
        Assert.Contains("rect", output);
        Assert.Contains("width", output);
    }

    [Fact]
    public void RoundTrip_PreservesStructure()
    {
        var original = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="200" height="150">
              <g id="group1">
                <rect id="r1" x="10" y="20" width="80" height="60" />
                <circle id="c1" cx="150" cy="75" r="30" />
              </g>
            </svg>
            """);

        using var stream = new MemoryStream();
        original.Write(stream);
        stream.Position = 0;

        var reloaded = SvgDocument.Open<SvgDocument>(stream);

        Assert.NotNull(reloaded);
        Assert.NotNull(reloaded.GetElementById("group1"));
        Assert.NotNull(reloaded.GetElementById("r1"));
        Assert.NotNull(reloaded.GetElementById("c1"));
    }
}
