using System;
using System.Linq;
using CodeBrix.SvgParse;
using Xunit;

namespace CodeBrix.SvgParse.Tests;

/// <summary>
/// Tests that verify the source generator correctly wired up property descriptors
/// for SvgElement-derived classes. The generated code includes Properties dictionaries,
/// GetValue/SetValue overrides, and ClassNames lists.
/// </summary>
public class SvgGeneratedPropertyTests
{
    [Fact]
    public void SvgElement_Properties_DictionaryIsGenerated()
    {
        // The source generator creates a Properties dictionary on each SvgElement subclass.
        var rect = new SvgRectangle();
        var properties = rect.Properties;

        Assert.NotNull(properties);
        Assert.True(properties.Count > 0,
            "Source generator should have populated the Properties dictionary.");
    }

    [Fact]
    public void SvgRectangle_Properties_ContainsExpectedAttributes()
    {
        var rect = new SvgRectangle();
        var properties = rect.Properties;

        Assert.True(properties.ContainsKey("x"), "Should contain 'x' attribute.");
        Assert.True(properties.ContainsKey("y"), "Should contain 'y' attribute.");
        Assert.True(properties.ContainsKey("width"), "Should contain 'width' attribute.");
        Assert.True(properties.ContainsKey("height"), "Should contain 'height' attribute.");
        Assert.True(properties.ContainsKey("rx"), "Should contain 'rx' attribute.");
        Assert.True(properties.ContainsKey("ry"), "Should contain 'ry' attribute.");
    }

    [Fact]
    public void SvgCircle_Properties_ContainsExpectedAttributes()
    {
        var circle = new SvgCircle();
        var properties = circle.Properties;

        Assert.True(properties.ContainsKey("cx"), "Should contain 'cx' attribute.");
        Assert.True(properties.ContainsKey("cy"), "Should contain 'cy' attribute.");
        Assert.True(properties.ContainsKey("r"), "Should contain 'r' attribute.");
    }

    [Fact]
    public void SvgElement_AttributeName_IsSetByGenerator()
    {
        var rect = new SvgRectangle();
        Assert.Equal("rect", rect.AttributeName);

        var circle = new SvgCircle();
        Assert.Equal("circle", circle.AttributeName);

        var path = new SvgPath();
        Assert.Equal("path", path.AttributeName);

        var group = new SvgGroup();
        Assert.Equal("g", group.AttributeName);
    }

    [Fact]
    public void SvgElement_ClassNames_IsSetByGenerator()
    {
        var rect = new SvgRectangle();
        Assert.NotNull(rect.ClassNames);
        Assert.Contains(typeof(SvgRectangle), rect.ClassNames);

        var circle = new SvgCircle();
        Assert.NotNull(circle.ClassNames);
        Assert.Contains(typeof(SvgCircle), circle.ClassNames);
    }

    [Fact]
    public void SvgElement_GetProperties_ReturnsInheritedProperties()
    {
        // GetProperties should return both the element's own properties and inherited ones.
        var rect = new SvgRectangle();
        var allProperties = rect.GetProperties().ToList();

        Assert.True(allProperties.Count > 0);

        // Should include properties from SvgRectangle itself (x, y, width, height)
        Assert.Contains(allProperties, p => p.AttributeName == "x");
        Assert.Contains(allProperties, p => p.AttributeName == "width");

        // Should also include inherited properties from base classes (e.g. fill, stroke from SvgElement)
        Assert.Contains(allProperties, p => p.AttributeName == "fill");
    }

    [Fact]
    public void SvgElement_GetValue_RetrievesPropertyValue()
    {
        var rect = new SvgRectangle();
        rect.X = new SvgUnit(SvgUnitType.User, 42);

        var value = rect.GetValue("x");
        Assert.NotNull(value);
        Assert.IsType<SvgUnit>(value);
        Assert.Equal(new SvgUnit(SvgUnitType.User, 42), (SvgUnit)value);
    }

    [Fact]
    public void SvgElement_SetValue_ReturnsTrueForKnownAttribute()
    {
        var doc = SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(
            """
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100">
              <rect id="r1" x="0" y="0" width="50" height="50" />
            </svg>
            """);

        var rect = doc.GetElementById<SvgRectangle>("r1");
        Assert.NotNull(rect);

        // SetValue should return true for known attributes
        var result = rect.SetValue("x", null, System.Globalization.CultureInfo.InvariantCulture, "99");
        Assert.True(result, "SetValue should return true for known attribute 'x'.");
    }

    [Fact]
    public void SvgElement_SetValue_ReturnsFalseForUnknownAttribute()
    {
        var rect = new SvgRectangle();
        var result = rect.SetValue("nonexistent-attribute", null, System.Globalization.CultureInfo.InvariantCulture, "value");
        Assert.False(result, "SetValue should return false for unknown attributes.");
    }
}
