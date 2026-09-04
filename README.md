# CodeBrix.SvgParse

An SVG document object model (DOM) library for .NET.
CodeBrix.SvgParse provides comprehensive SVG parsing, element modeling, styling, and serialization capabilities, and is provided as a .NET 10 library and associated `CodeBrix.SvgParse.MsplLicenseForever` NuGet package.

CodeBrix.SvgParse supports applications and assemblies that target Microsoft .NET version 10.0 and later.
Microsoft .NET version 10.0 is a Long-Term Supported (LTS) version of .NET, and was released on Nov 11, 2025; and will be actively supported by Microsoft until Nov 14, 2028.
Please update your C#/.NET code and projects to the latest LTS version of Microsoft .NET.

## Installation

```
dotnet add package CodeBrix.SvgParse.MsplLicenseForever
```

Note that the NuGet package ID and the namespace are different - there is no package named plain `CodeBrix.SvgParse`:

* NuGet package ID: `CodeBrix.SvgParse.MsplLicenseForever`
* Assembly and namespace: `CodeBrix.SvgParse` - i.e. `using CodeBrix.SvgParse;`

This package has one NuGet dependency, `CodeBrix.StyleSheetParse.MitLicenseForever`, which NuGet restores automatically and which is used for the CSS styling support. There are no native libraries and no other dependencies. XML documentation (IntelliSense) ships alongside the assembly.

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

CodeBrix.SvgParse is a document object model, not a renderer: nothing is drawn. It does not rasterize or export to PNG, JPEG or PDF, play animations, perform hit testing, measure text or load fonts, or compute geometry such as bounding boxes and path flattening. Rendering is the job of a backend built on top of this DOM - `CodeBrix.SkiaSvg` is one such backend.

## Sample Code

### Load and Inspect an SVG Document

```csharp
using CodeBrix.SvgParse;

var document = SvgDocument.Open("image.svg");

Console.WriteLine($"Width: {document.Width}");
Console.WriteLine($"Height: {document.Height}");

foreach (var element in document.Descendants())
{
    // There is no public element.ElementName; identify elements by CLR type.
    Console.WriteLine($"Element: {element.GetType().Name} id={element.ID}");
}
```

### Load SVG from a String

```csharp
using System.Linq;
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

## Documentation

The NuGet package includes `AGENT-README.txt`, a complete API reference and usage guide written for AI coding agents - point your agent at that file when it is writing code against this library.

Additional sample code and usage examples are available in the `CodeBrix.SvgParse.Tests` project:
https://github.com/ellisnet/CodeBrix.SvgParse/tree/main/tests/CodeBrix.SvgParse.Tests

Note that the test project has `InternalsVisibleTo` access to the library, so some of what it calls (for example `SvgElement.ElementName` and `SvgElement.Attributes`) is internal and is not available to package consumers.

## License

CodeBrix.SvgParse is licensed under the Microsoft Public License (Ms-PL) - see the
[LICENSE](https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/LICENSE) file.

For licensing and provenance information about the open source code included in
this package, see [THIRD-PARTY-NOTICES.txt](https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/THIRD-PARTY-NOTICES.txt).
