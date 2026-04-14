# CodeBrix.SvgParse

An SVG document object model (DOM) library for .NET.
CodeBrix.SvgParse provides comprehensive SVG parsing, element modeling, styling, and serialization capabilities, and is provided as a .NET 10 library and associated `CodeBrix.SvgParse.MsplLicenseForever` NuGet package.

CodeBrix.SvgParse supports applications and assemblies that target Microsoft .NET version 10.0 and later.
Microsoft .NET version 10.0 is a Long-Term Supported (LTS) version of .NET, and was released on Nov 11, 2025; and will be actively supported by Microsoft until Nov 14, 2028.
Please update your C#/.NET code and projects to the latest LTS version of Microsoft .NET.

CodeBrix.SvgParse is a fork of the code of the open source Svg.Custom project (part of the Svg.Skia projects) - see below for licensing details.

## CodeBrix.SvgParse supports:

* SVG document loading from files, streams, strings, and XmlReaders
* Complete SVG 1.1 element hierarchy (shapes, text, gradients, patterns, filters, etc.)
* CSS styling with specificity-based cascading
* SVG path parsing and manipulation
* Transforms (translate, rotate, scale, skew, matrix)
* Clipping and masking
* Filter effects (blur, blend, color matrix, lighting, etc.)
* Linear and radial gradients with stop colors
* Pattern fills
* Text elements with font properties and text paths
* Markers on shapes
* Deep cloning of elements and documents
* Security controls for external resource loading
* Many more...

## Sample Code

### Load and Inspect an SVG Document

```csharp
using CodeBrix.SvgParse;

var document = SvgDocument.Open("image.svg");

Console.WriteLine($"Width: {document.Width}");
Console.WriteLine($"Height: {document.Height}");

foreach (var element in document.Descendants())
{
    Console.WriteLine($"Element: {element.ElementName}");
}
```

### Load SVG from a String

```csharp
using CodeBrix.SvgParse;

var svg = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>" +
          "<circle cx='50' cy='50' r='40' fill='red'/></svg>";

var document = SvgDocument.FromSvg<SvgDocument>(svg);
var circle = document.Descendants().OfType<SvgCircle>().First();
Console.WriteLine($"Circle radius: {circle.Radius}");
```

### Find Elements by ID

```csharp
using CodeBrix.SvgParse;

var document = SvgDocument.Open("image.svg");
var element = document.GetElementById("myElement");

if (element is SvgRectangle rect)
{
    Console.WriteLine($"Rectangle: {rect.Width} x {rect.Height}");
}
```

Note that additional sample code and usage examples are available in the `CodeBrix.SvgParse.Tests` project.

## License

The project is licensed under the Microsoft Public License (Ms-PL). see: https://en.wikipedia.org/wiki/Shared_Source_Initiative#Microsoft_Public_License_(Ms-PL)

All code originating from Svg.Custom (part of the Svg.Skia projects) was included as required by the Microsoft Public License (Ms-PL) - as of Svg.Skia version 4.2.0.
This project (CodeBrix.SvgParse) complies with all provisions of the source code license of Svg.Custom (Ms-PL).
