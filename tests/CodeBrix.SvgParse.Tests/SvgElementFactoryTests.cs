using System;
using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

/// <summary>
/// Tests that verify the source generator (AvailableElementsGenerator) correctly
/// registered SVG element types in the SvgElementFactory.
/// </summary>
public class SvgElementFactoryTests
{
    [Fact]
    public void AvailableElements_ContainsRegisteredElements()
    {
        var factory = new SvgElementFactory();
        Assert.NotNull(factory.AvailableElements);
        Assert.True(factory.AvailableElements.Count > 0,
            "Source generator should have registered at least one element.");
    }

    [Theory]
    [InlineData("rect", typeof(SvgRectangle))]
    [InlineData("circle", typeof(SvgCircle))]
    [InlineData("ellipse", typeof(SvgEllipse))]
    [InlineData("line", typeof(SvgLine))]
    [InlineData("polyline", typeof(SvgPolyline))]
    [InlineData("polygon", typeof(SvgPolygon))]
    [InlineData("path", typeof(SvgPath))]
    [InlineData("g", typeof(SvgGroup))]
    [InlineData("svg", typeof(SvgFragment))]
    [InlineData("text", typeof(SvgText))]
    [InlineData("tspan", typeof(SvgTextSpan))]
    [InlineData("defs", typeof(SvgDefinitionList))]
    [InlineData("use", typeof(SvgUse))]
    [InlineData("symbol", typeof(SvgSymbol))]
    [InlineData("image", typeof(SvgImage))]
    [InlineData("linearGradient", typeof(SvgLinearGradientServer))]
    [InlineData("radialGradient", typeof(SvgRadialGradientServer))]
    [InlineData("stop", typeof(SvgGradientStop))]
    [InlineData("clipPath", typeof(SvgClipPath))]
    [InlineData("mask", typeof(SvgMask))]
    [InlineData("pattern", typeof(SvgPatternServer))]
    [InlineData("filter", typeof(CodeBrix.SvgParse.FilterEffects.SvgFilter))]
    public void AvailableElements_ContainsExpectedElement(string elementName, Type expectedType)
    {
        var factory = new SvgElementFactory();
        var match = factory.AvailableElements
            .FirstOrDefault(e => e.ElementName == elementName);

        Assert.NotNull(match);
        Assert.Equal(expectedType, match.ElementType);
    }

    [Theory]
    [InlineData("rect")]
    [InlineData("circle")]
    [InlineData("path")]
    [InlineData("g")]
    [InlineData("text")]
    [InlineData("linearGradient")]
    public void AvailableElements_CreateInstance_ReturnsCorrectType(string elementName)
    {
        var factory = new SvgElementFactory();
        var info = factory.AvailableElements
            .First(e => e.ElementName == elementName);

        var instance = info.CreateInstance();

        Assert.NotNull(instance);
        Assert.IsType(info.ElementType, instance);
    }

    [Fact]
    public void SvgElements_ElementNames_MapsTypesToNames()
    {
        Assert.True(SvgElements.ElementNames.ContainsKey(typeof(SvgRectangle)));
        Assert.Equal("rect", SvgElements.ElementNames[typeof(SvgRectangle)]);

        Assert.True(SvgElements.ElementNames.ContainsKey(typeof(SvgCircle)));
        Assert.Equal("circle", SvgElements.ElementNames[typeof(SvgCircle)]);

        Assert.True(SvgElements.ElementNames.ContainsKey(typeof(SvgPath)));
        Assert.Equal("path", SvgElements.ElementNames[typeof(SvgPath)]);
    }

    [Fact]
    public void AvailableElementsDictionary_ContainsExpectedEntries()
    {
        var factory = new SvgElementFactory();
        var dict = factory.AvailableElementsDictionary;

        Assert.NotNull(dict);
        Assert.True(dict.ContainsKey("rect"));
        Assert.True(dict.ContainsKey("circle"));
        Assert.True(dict.ContainsKey("path"));
        Assert.Contains(typeof(SvgRectangle), dict["rect"]);
    }
}
