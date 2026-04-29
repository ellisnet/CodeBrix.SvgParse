================================================================================
AGENT-README: CodeBrix.SvgParse
A Comprehensive Guide for AI Coding Agents
================================================================================

OVERVIEW
--------
CodeBrix.SvgParse is a renderer-agnostic SVG document object model (DOM)
library for .NET 10.0+. It provides comprehensive SVG parsing, element
modeling, styling, and serialization capabilities. It supports loading SVG
documents from files, streams, strings, and XmlReaders, and provides a rich
object model for querying and manipulating SVG elements. CodeBrix.SvgParse
does not depend on any rendering engine and can serve as the foundation for
any SVG rendering backend.

CodeBrix.SvgParse is a fork of the Svg.Custom project (part of the
Svg.Skia projects, v4.2.0). All namespaces use "CodeBrix.SvgParse"
instead of "Svg". Do NOT use Svg namespaces.

The CodeBrix.SvgParse.Generators project is a build-time source
generator used during compilation of the main library. It is not included in
the NuGet package and should not be referenced directly.


INSTALLATION
------------
NuGet Package: CodeBrix.SvgParse.MsplLicenseForever
Dependencies:
  - CodeBrix.StyleSheetParse.MitLicenseForever

    dotnet add package CodeBrix.SvgParse.MsplLicenseForever

IMPORTANT: The NuGet package name is CodeBrix.SvgParse.MsplLicenseForever
(NOT CodeBrix.SvgParse). The namespace is CodeBrix.SvgParse.

Requirements: .NET 10.0 or higher
License: Microsoft Public License (Ms-PL)


KEY NAMESPACES
--------------
Most types live directly in the base namespace. A handful of sub-namespaces
group related types.

    using CodeBrix.SvgParse;                  // SvgDocument, SvgElement,
                                              //   SvgRectangle/Circle/Path/etc.,
                                              //   SvgColorServer, SvgGradientServer,
                                              //   SvgColor, SvgPointF, SvgRectangleF,
                                              //   SvgSizeF, SvgUnit, SvgViewBox, and
                                              //   most other types.
    using CodeBrix.SvgParse.Pathing;          // SvgPathSegment, SvgMoveToSegment,
                                              //   SvgLineSegment, SvgCubicCurveSegment,
                                              //   SvgQuadraticCurveSegment,
                                              //   SvgArcSegment, SvgClosePathSegment
    using CodeBrix.SvgParse.Transforms;       // SvgTransform, SvgTranslate, SvgRotate,
                                              //   SvgScale, SvgSkewX/SvgSkewY,
                                              //   SvgMatrix, SvgTransformCollection
    using CodeBrix.SvgParse.FilterEffects;    // SvgFilter, SvgGaussianBlur, and the
                                              //   rest of the filter primitives
    using CodeBrix.SvgParse.Css;              // CSS selector matching helpers
    using CodeBrix.SvgParse.Exceptions;       // SvgException and related types

Note: there is no "CodeBrix.SvgParse.Painting" namespace. Paint server types
(SvgPaintServer, SvgColorServer, SvgGradientServer, SvgLinearGradientServer,
SvgRadialGradientServer, SvgPatternServer, SvgGradientStop, etc.) live directly
in the base CodeBrix.SvgParse namespace, even though their source files are
under the "Painting" folder.

The headline primitive value types (SvgColor, SvgPointF, SvgRectangleF,
SvgSizeF, SvgUnit, SvgViewBox, SvgPoint, SvgAspectRatio, SvgOrient, and the
font/text/coordinate enums) also live in the base CodeBrix.SvgParse namespace.
A small "CodeBrix.SvgParse.Primitives" sub-namespace does exist and contains
a handful of converter / helper types (for example SvgAspectRatioConverter,
SvgOrientConverter, SvgColorInterpolation, SvgMarkerUnits) — you generally
will not need to reference it directly from consumer code.


================================================================================

CORE API REFERENCE
==================

LOADING SVG DOCUMENTS
----------------------
SvgDocument is the main entry point. Use static methods to load SVGs.

From file:
    var document = SvgDocument.Open("image.svg");
    var document = SvgDocument.Open<SvgDocument>("image.svg");

From stream:
    var document = SvgDocument.Open<SvgDocument>(stream);
    var document = SvgDocument.Open<SvgDocument>(stream, svgOptions);

From XmlReader:
    var document = SvgDocument.Open<SvgDocument>(reader);

From SVG string:
    var document = SvgDocument.FromSvg<SvgDocument>(svgString);

SvgOptions - configuration for loading:
    var options = new SvgOptions();
    var options = new SvgOptions(entities);       // custom XML entities
    var options = new SvgOptions(css);            // external CSS string
    var options = new SvgOptions(entities, css);  // both

Example:
    var document = SvgDocument.Open("image.svg");
    Console.WriteLine($"Width: {document.Width}, Height: {document.Height}");


SVG DOCUMENT (SvgDocument)
---------------------------
Inherits from SvgFragment. Root of the SVG document model.

Properties:
    float Ppi                           // Pixels per inch
    Uri BaseUri                         // Base URI for resolving references
    string ExternalCSSHref              // External CSS to load

Security controls (static, library-wide):
    ExternalType ResolveExternalXmlEntites  // XXE prevention (default: None)
    ExternalType ResolveExternalImages      // Image loading (default: Local | Remote)
    ExternalType ResolveExternalElements    // Element loading
    bool DisableDtdProcessing               // DTD processing flag

Serialization settings:
    static bool EmitNamedColorsOnSerialization  // Library-wide default (default: false).
                                                // When true, serialization prefers the
                                                // W3C named color ("red") over the hex
                                                // value ("#ff0000") when the color has
                                                // a name.
    bool EnableEmitNamedColorsOnSerialization   // Per-document override. Initialized
                                                // from the static above at construction
                                                // time. Changing the static later does
                                                // NOT update existing documents.

Methods:
    SvgElement GetElementById(string id)
    T GetElementById<T>(string id) where T : SvgElement

ExternalType enum (bit flags):
    None, Local, Remote


SVG FRAGMENT (SvgFragment)
---------------------------
Root SVG element (for documents and nested <svg> elements).

Viewport properties:
    SvgUnit X, Y                        // Position
    SvgUnit Width, Height               // Dimensions
    SvgViewBox ViewBox                  // viewBox attribute
    SvgAspectRatio AspectRatio          // preserveAspectRatio
    SvgOverflow Overflow                // Visible, Hidden
    SvgUnit FontSize                    // Default font size
    string FontFamily                   // Default font family
    XmlSpaceHandling SpaceHandling      // xml:space


SVG ELEMENT (SvgElement)
-------------------------
Abstract base class for all SVG elements.

Core properties:
    string ElementName                  // SVG element name (rect, circle, etc.)
    SvgElement Parent                   // Parent element
    SvgElementCollection Children       // Child elements
    SvgDocument OwnerDocument           // Root document
    string Content                      // Text content
    SvgAttributeCollection Attributes   // Element attributes
    SvgCustomAttributeCollection CustomAttributes  // Non-standard attributes

Methods:
    T DeepCopy<T>()                     // Deep clone
    SvgElement DeepCopy()               // Deep clone
    void AddStyle(string name, string value, int specificity)
    void FlushStyles(bool children)     // Apply staged CSS styles
    IEnumerable<SvgElement> Descendants()

Traversal:
    Parents                             // Enumerate parent chain
    ParentsAndSelf                      // Include self in parent chain


SVG VISUAL ELEMENT (SvgVisualElement)
--------------------------------------
Abstract base for all graphical SVG elements.

Fill and stroke:
    SvgPaintServer Fill                 // Fill paint (color, gradient, pattern)
    SvgPaintServer Stroke               // Stroke paint
    SvgFillRule FillRule                 // NonZero, EvenOdd
    float Opacity                       // Element opacity (0-1)
    float FillOpacity                   // Fill opacity (0-1)
    float StrokeOpacity                 // Stroke opacity (0-1)
    SvgUnit StrokeWidth                 // Stroke width
    SvgStrokeLineCap StrokeLineCap      // Butt, Round, Square
    SvgStrokeLineJoin StrokeLineJoin    // Miter, Round, Bevel
    float StrokeMiterLimit              // Miter limit
    SvgUnitCollection StrokeDashArray   // Dash pattern
    SvgUnit StrokeDashOffset            // Dash offset

Clipping and filtering:
    Uri ClipPath                        // Reference to <clipPath>
    SvgClipRule ClipRule                // NonZero, EvenOdd
    string Clip                         // CSS clip property
    Uri Filter                          // Reference to <filter>

Rendering hints (for downstream renderers):
    SvgShapeRendering ShapeRendering    // shape-rendering attribute value


================================================================================

BASIC SHAPES
=============

SvgRectangle - [SvgElement("rect")]
    SvgUnit X, Y                        // Top-left position
    SvgUnit Width, Height               // Dimensions
    SvgUnit CornerRadiusX, CornerRadiusY  // Rounded corners (rx, ry)
    SvgPoint Location                   // Convenience property

SvgCircle - [SvgElement("circle")]
    SvgUnit CenterX, CenterY           // cx, cy
    SvgUnit Radius                      // r
    SvgPoint Center                     // Convenience property

SvgEllipse - [SvgElement("ellipse")]
    SvgUnit CenterX, CenterY           // cx, cy
    SvgUnit RadiusX, RadiusY            // rx, ry

SvgLine - [SvgElement("line")]
    SvgUnit StartX, StartY             // x1, y1
    SvgUnit EndX, EndY                 // x2, y2

SvgPolyline - [SvgElement("polyline")]
    SvgPointCollection Points           // Points list

SvgPolygon - [SvgElement("polygon")]
    SvgPointCollection Points           // Points list


================================================================================

PATHS
======

SvgPath - [SvgElement("path")]
    SvgPathSegmentList PathData         // d attribute (path commands)
    float PathLength                    // pathLength attribute

Path segment types:
    SvgMoveToSegment                    // M/m commands
    SvgLineSegment                      // L/l commands
    SvgCubicCurveSegment                // C/c, S/s commands
    SvgQuadraticCurveSegment            // Q/q, T/t commands
    SvgArcSegment                       // A/a commands
    SvgClosePathSegment                 // Z/z command

SvgPathBuilder - programmatically construct paths
CoordinateParser - parse coordinate strings


================================================================================

DOCUMENT STRUCTURE ELEMENTS
=============================

SvgGroup - [SvgElement("g")]
    Container element for grouping.

SvgUse - [SvgElement("use")]
    Uri ReferencedElement               // xlink:href
    SvgUnit X, Y, Width, Height
    bool HasRecursiveReference()        // Cycle detection

SvgImage - [SvgElement("image")]
    SvgUnit X, Y, Width, Height
    string Href                         // xlink:href
    SvgAspectRatio AspectRatio

SvgSymbol - [SvgElement("symbol")]
    SvgViewBox ViewBox
    SvgAspectRatio AspectRatio

SvgDefinitionList - [SvgElement("defs")]
    Container for gradients, patterns, masks, filters, etc.

SvgTitle - [SvgElement("title")]
SvgDescription - [SvgElement("desc")]
SvgSwitch - [SvgElement("switch")]
SvgForeignObject - [SvgElement("foreignObject")]


================================================================================

PAINTING AND COLORS
====================

SvgPaintServer - abstract base for all paint servers.

Static sentinels:
    SvgPaintServer.None                 // No paint
    SvgPaintServer.Inherit              // Inherit from parent
    SvgPaintServer.NotSet               // Not specified

SvgColorServer
    SvgColor ColorValue                 // The color value
    Construction:
        new SvgColorServer()            // defaults to SvgColor.Black
        new SvgColorServer(SvgColor)    // wrap a specific color
    Serialization:
        ToString() returns either the W3C named color ("red") or a hex string
        ("#ff0000"), controlled by the owning document's
        EnableEmitNamedColorsOnSerialization flag (default false -> always hex).

SvgLinearGradientServer - [SvgElement("linearGradient")]
    SvgUnit X1, Y1, X2, Y2             // Gradient line endpoints
    List<SvgGradientStop> Stops         // Color stops
    SvgGradientSpreadMethod SpreadMethod  // Pad, Reflect, Repeat
    SvgCoordinateUnits GradientUnits    // ObjectBoundingBox, UserSpaceOnUse
    SvgTransformCollection GradientTransform

SvgRadialGradientServer - [SvgElement("radialGradient")]
    SvgUnit CenterX, CenterY           // cx, cy
    SvgUnit Radius                      // r
    SvgUnit FocalX, FocalY              // fx, fy
    (same gradient properties as linear)

SvgPatternServer - [SvgElement("pattern")]
    SvgUnit X, Y, Width, Height
    SvgCoordinateUnits PatternUnits, PatternContentUnits
    SvgTransformCollection PatternTransform
    SvgViewBox ViewBox
    SvgAspectRatio AspectRatio

SvgGradientStop - [SvgElement("stop")]
    SvgUnit Offset                      // Stop position (0-1)
    SvgPaintServer StopColor            // Stop color
    float StopOpacity                   // Stop opacity

SvgGradientSpreadMethod enum: Pad, Reflect, Repeat
SvgCoordinateUnits enum: ObjectBoundingBox, UserSpaceOnUse


================================================================================

TEXT ELEMENTS
==============

SvgText - [SvgElement("text")]
    SvgUnit X, Y                        // Text position
    SvgNumberCollection DX, DY, Rotate
    SvgUnit TextLength
    SvgTextLengthAdjust LengthAdjust

SvgTextSpan - [SvgElement("tspan")]
    Same properties as SvgText.

SvgTextPath - [SvgElement("textPath")]
    Uri Href                            // xlink:href to path
    SvgUnit StartOffset
    SvgTextPathMethod Method            // align, stretch
    SvgTextPathSpacing Spacing          // exact, letters

Font properties (on SvgTextBase):
    string FontFamily
    SvgUnit FontSize
    SvgFontStyle FontStyle              // Normal, Italic, Oblique
    SvgFontWeight FontWeight            // Normal, Bold, W100-W900, etc.
    SvgFontVariant FontVariant          // Normal, SmallCaps
    SvgFontStretch FontStretch          // Ultra-condensed to Ultra-expanded
    SvgTextAnchor TextAnchor            // Start, Middle, End
    SvgDominantBaseline DominantBaseline
    SvgTextDecoration TextDecoration    // Underline, Overline, LineThrough
    SvgTextTransformation TextTransform // Capitalize, Uppercase, Lowercase
    SvgUnit BaselineShift
    SvgUnit WordSpacing, LetterSpacing
    XmlSpaceHandling SpaceHandling      // Default, Preserve


================================================================================

TRANSFORMS
===========

All elements support the Transform attribute via ISvgTransformable.

SvgTransformCollection - ordered list of transformations.

Transform types:
    SvgTranslate            // translate(x, y)
    SvgRotate               // rotate(angle, centerX?, centerY?)
    SvgScale                // scale(scaleX, scaleY?)
    SvgSkewX                // skewX(angle)
    SvgSkewY                // skewY(angle)
    SvgMatrix               // matrix(a, b, c, d, e, f)

SvgTransformConverter - parses transform strings:
    "translate(10,20) rotate(45) scale(2)"


================================================================================

CLIPPING AND MASKING
=====================

SvgClipPath - [SvgElement("clipPath")]
    SvgCoordinateUnits ClipPathUnits

SvgMask - [SvgElement("mask")]
    SvgUnit X, Y, Width, Height
    SvgCoordinateUnits MaskUnits
    SvgCoordinateUnits MaskContentUnits

SvgClipRule enum: NonZero, EvenOdd


================================================================================

FILTER EFFECTS
===============

SvgFilter - [SvgElement("filter")]
    SvgUnit X, Y, Width, Height
    SvgCoordinateUnits FilterUnits, PrimitiveUnits

Filter primitives:
    SvgGaussianBlur         // feGaussianBlur - StdDeviation
    SvgOffset               // feOffset - Dx, Dy
    SvgBlend                // feBlend - BlendMode
    SvgColorMatrix          // feColorMatrix
    SvgComposite            // feComposite
    SvgConvolveMatrix       // feConvolveMatrix
    SvgDiffuseLighting      // feDiffuseLighting
    SvgSpecularLighting     // feSpecularLighting
    SvgDisplacementMap      // feDisplacementMap
    SvgFlood                // feFlood
    SvgMorphology           // feMorphology
    SvgTile                 // feTile
    SvgTurbulence           // feTurbulence
    SvgComponentTransfer    // feComponentTransfer
    SvgMerge                // feMerge

Light sources:
    SvgDistantLight         // feDistantLight
    SvgPointLight           // fePointLight
    SvgSpotLight            // feSpotLight


================================================================================

MARKERS
========

SvgMarkerElement - [SvgElement("marker")]
    SvgUnit RefX, RefY                  // Reference point
    SvgUnit MarkerWidth, MarkerHeight
    SvgViewBox ViewBox
    SvgAspectRatio AspectRatio
    SvgMarkerUnits MarkerUnits          // StrokeWidth, UserSpaceOnUse
    SvgOrient Orient

Used on shapes via:
    Uri MarkerStart, MarkerMid, MarkerEnd


================================================================================

DATA TYPES
===========

All value types below are library-native. The library does NOT depend on
System.Drawing or any other external geometric/color package.

SvgUnit (struct) - numeric value with a unit:
    float Value
    SvgUnitType Type
        User, Percentage, Em, Ex, Px, In, Cm, Mm, Pt, Pc, None
    bool IsEmpty, IsNone
    SvgUnit ToPercentage()

SvgUnitCollection   - List<SvgUnit>
SvgNumberCollection - List<float>

SvgPoint (struct) - unit-bearing 2D point:
    SvgUnit X, Y

SvgPointCollection - List<SvgPoint>

SvgPointF (struct) - raw float 2D point (used in path segments):
    float X, Y
    bool IsEmpty                    // X == 0 && Y == 0
    static readonly SvgPointF Empty // (0, 0)
    static readonly SvgPointF NaN   // (NaN, NaN) - placeholder for omitted
                                    //   control points in smooth curve commands

SvgRectangleF (struct) - raw float rectangle:
    float X, Y, Width, Height
    SvgPointF Location, SvgSizeF Size
    float Left, Top, Right, Bottom
    bool IsEmpty                    // Width <= 0 || Height <= 0
    static readonly SvgRectangleF Empty

SvgSizeF (struct) - raw float size:
    float Width, Height
    bool IsEmpty                    // both zero
    static readonly SvgSizeF Empty

SvgViewBox (struct) - SVG viewport:
    float MinX, MinY, Width, Height

SvgAspectRatio:
    SvgPreserveAspectRatio Align
        xMinYMin, xMidYMid, xMaxYMax, etc.
    bool Defer

SvgOrient (struct):
    Angle (float) or "auto" keyword


SvgColor (readonly struct) - 8-bit-per-channel ARGB color:
    byte R, G, B, A                 // component accessors
    bool IsEmpty                    // default (unset) sentinel
    int ToArgb()                    // packed ARGB as 32-bit signed int

    Factory methods:
        SvgColor.FromRgb(r, g, b)           // alpha = 255
        SvgColor.FromRgba(r, g, b, a)
        SvgColor.FromArgb(a, r, g, b)       // alpha-first (System.Drawing order)
        SvgColor.FromArgb(r, g, b)          // alpha = 255
        SvgColor.FromArgb(int argb)         // packed value
        SvgColor.FromArgb(a, baseColor)     // override alpha of existing color

    Parsing:
        SvgColor.ParseHex("#rgb" | "#rgba" | "#rrggbb" | "#rrggbbaa")
        SvgColor.TryParseHex(hex, out color)
        SvgColor.Parse("red" | "#rgb" | etc.)         // name OR hex
        SvgColor.TryParse(str, out color)
        SvgColor.TryFromName("red", out color)        // case-insensitive

    Serialization:
        string ToHex()                      // "#rrggbb" or "#rrggbbaa"
        string ToString()                   // same as ToHex()
        string GetKnownName()               // returns "red" for #ff0000, or null

    Named colors (static readonly):
        140 W3C/CSS3 named colors: SvgColor.AliceBlue ... SvgColor.YellowGreen.
        Also includes SvgColor.Black, Red, Green, Blue, White, Transparent, etc.

    Name lookup is case-insensitive. British spellings (grey/darkgrey/etc.)
    resolve to the same color as the American spelling. Similarly, "aqua" and
    "cyan" resolve to the same color, and "fuchsia" and "magenta" resolve to
    the same color.

    Notes:
      - SvgColor is a value struct; equality compares packed ARGB.
      - IsEmpty is the default (zero-ARGB) sentinel. Because SvgColor.Transparent
        also has packed ARGB value 0, Empty and Transparent compare as equal
        and both return true from IsEmpty. Use SvgPaintServer sentinels
        (None / NotSet / Inherit) if you need to distinguish "unset" from
        "transparent" at the paint layer.
      - Unlike System.Drawing.Color, SvgColor.FromName is not exposed; use
        Parse/TryParse/TryFromName for string-to-color conversion.


================================================================================

ATTRIBUTES AND EXTENSIBILITY
==============================

SvgAttributeAttribute - marks C# properties as SVG attributes:
    [SvgAttribute("stroke-width")]
    public SvgUnit StrokeWidth { get; set; }

    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public Uri Href { get; set; }

SvgElementAttribute - marks C# classes as SVG elements:
    [SvgElement("myElement")]
    public class SvgMyElement : SvgVisualElement { }

SvgAttributeCollection - dictionary-like access to element attributes
    with automatic type conversion and inheritance support.

SvgCustomAttributeCollection - non-standard attributes.

SvgNamespaces constants:
    SvgNamespace    = "http://www.w3.org/2000/svg"
    XLinkNamespace  = "http://www.w3.org/1999/xlink"
    XmlNamespace    = "http://www.w3.org/XML/1998/namespace"


================================================================================

CODE GENERATOR (BUILD-TIME ONLY)
==================================

The CodeBrix.SvgParse.Generators project is a build-time incremental
source generator. It is NOT included in the NuGet package.

AvailableElementsGenerator:
    - Scans the assembly for classes with [SvgElement] attribute
    - Generates SvgElements.ElementNames metadata dictionary
    - Generates factory methods in SvgElementFactory
    - Enables runtime element creation by name:
        var element = SvgElementFactory.CreateElementByName("rect");


================================================================================

COMPLETE EXAMPLES
==================

Example 1: Load and Traverse an SVG Document
----------------------------------------------
    using CodeBrix.SvgParse;

    var document = SvgDocument.Open("drawing.svg");

    Console.WriteLine($"Document size: {document.Width} x {document.Height}");
    Console.WriteLine($"ViewBox: {document.ViewBox}");

    foreach (var element in document.Descendants())
    {
        Console.WriteLine($"{element.ElementName}: {element.GetType().Name}");
    }


Example 2: Parse SVG from String and Query Elements
-----------------------------------------------------
    using CodeBrix.SvgParse;
    using System.Linq;

    var svg = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
        <rect id='bg' x='0' y='0' width='200' height='200' fill='white'/>
        <circle id='dot' cx='100' cy='100' r='50' fill='red'/>
        <text x='100' y='180' text-anchor='middle'>Hello</text>
    </svg>";

    var document = SvgDocument.FromSvg<SvgDocument>(svg);

    // Find by ID
    var circle = document.GetElementById<SvgCircle>("dot");
    Console.WriteLine($"Circle radius: {circle.Radius}");

    // Find all shapes
    var shapes = document.Descendants().OfType<SvgVisualElement>();
    foreach (var shape in shapes)
    {
        Console.WriteLine($"{shape.ElementName}: fill={shape.Fill}");
    }


Example 3: Deep Copy an Element
---------------------------------
    using CodeBrix.SvgParse;

    var document = SvgDocument.Open("image.svg");
    var original = document.GetElementById<SvgCircle>("myCircle");

    // Create independent deep copy
    var copy = original.DeepCopy<SvgCircle>();
    copy.CenterX = new SvgUnit(200);
    copy.Fill = new SvgColorServer(SvgColor.Blue);

    // Add copy to document
    document.Children.Add(copy);


Example 4: Load with Options
------------------------------
    using CodeBrix.SvgParse;

    // Load with external CSS
    var options = new SvgOptions("circle { fill: blue; } rect { stroke: red; }");
    using var stream = File.OpenRead("image.svg");
    var document = SvgDocument.Open<SvgDocument>(stream, options);


Example 5: Inspect Path Data
------------------------------
    using CodeBrix.SvgParse;
    using System.Linq;

    var document = SvgDocument.Open("icon.svg");
    var paths = document.Descendants().OfType<SvgPath>();

    foreach (var path in paths)
    {
        Console.WriteLine($"Path segments: {path.PathData.Count}");
        foreach (var segment in path.PathData)
        {
            Console.WriteLine($"  {segment.GetType().Name}");
        }
    }


Example 6: Inspect Gradients
------------------------------
    using CodeBrix.SvgParse;
    using System.Linq;

    var document = SvgDocument.Open("gradient.svg");
    var gradients = document.Descendants().OfType<SvgLinearGradientServer>();

    foreach (var gradient in gradients)
    {
        Console.WriteLine($"Gradient: ({gradient.X1},{gradient.Y1}) -> ({gradient.X2},{gradient.Y2})");
        foreach (var stop in gradient.Stops)
        {
            Console.WriteLine($"  Stop at {stop.Offset}: {stop.StopColor}");
        }
    }


Example 7: Named-Color Serialization
--------------------------------------
    using CodeBrix.SvgParse;

    // Default: colors are written as hex
    var doc = SvgDocument.FromSvg<SvgDocument>(
        "<svg xmlns='http://www.w3.org/2000/svg'><rect fill='red'/></svg>");
    Console.WriteLine(doc.GetXML()); // ... fill="#ff0000" ...

    // Opt-in: emit W3C named colors when they match
    doc.EnableEmitNamedColorsOnSerialization = true;
    Console.WriteLine(doc.GetXML()); // ... fill="red" ...

    // Library-wide default: flip for all new documents
    SvgDocument.EmitNamedColorsOnSerialization = true;
    var doc2 = SvgDocument.FromSvg<SvgDocument>(svgText);
    // doc2.EnableEmitNamedColorsOnSerialization == true (snapshotted from static).
    // doc (created earlier) is unaffected by the static change.


================================================================================

PERFORMANCE TIPS
=================

1. Reuse SvgDocument instances when querying the same SVG repeatedly.
   Parsing is the expensive operation.

2. Use GetElementById() instead of iterating Descendants() when looking
   for a specific element.

3. Use SvgDocument.Open<SvgDocument>(stream) for large files instead of
   FromSvg<SvgDocument>(string) to avoid loading the entire file into a
   string first.

4. Set ResolveExternalXmlEntites = ExternalType.None (the default) to
   prevent XXE attacks and avoid network calls during parsing.

5. Use DeepCopy() sparingly on large subtrees. It copies the entire
   element hierarchy.

6. When applying CSS styles programmatically, call FlushStyles(true)
   once after all styles are added rather than after each individual style.


================================================================================

COMMON PITFALLS TO AVOID
==========================

1. DO NOT confuse the NuGet package name with the namespace.
   - Package: CodeBrix.SvgParse.MsplLicenseForever
     Namespace: CodeBrix.SvgParse

2. DO NOT use Svg namespaces. Even though this is a fork of Svg.Custom,
   all namespaces are CodeBrix.SvgParse.

3. DO NOT target .NET versions below 10.0.

4. DO NOT forget that SvgDocument.Open() is a static method that returns
   a new document. It is not an instance method.

5. DO NOT mix SvgUnit types carelessly. Always check the Type property
   when comparing or converting units.

6. DO NOT assume all elements are SvgVisualElement. Container elements
   like SvgGroup and SvgDefinitionList inherit from SvgElement, not
   SvgVisualElement.

7. DO NOT forget that Fill and Stroke are SvgPaintServer, not SvgColor.
   Use SvgColorServer to wrap an SvgColor value.

8. DO NOT forget about SVG attribute inheritance. Many properties (fill,
   stroke, font-family, etc.) inherit from parent elements. Check parent
   elements if a property appears unset.

9. DO NOT modify the Children collection while iterating over it. Use
   ToList() to create a snapshot first.

10. DO NOT forget that DeepCopy() creates a completely independent copy.
    Changes to the copy do not affect the original.

11. DO NOT set ResolveExternalImages to Remote without considering
    security implications. This allows the parser to make network requests.

12. DO NOT expect SvgDocument.EmitNamedColorsOnSerialization to
    retroactively affect existing documents. The static is snapshotted
    into each SvgDocument's EnableEmitNamedColorsOnSerialization property
    at construction time. To change behavior for an already-loaded document,
    set its instance property directly.

13. DO NOT use System.Drawing types (Color, PointF, RectangleF, SizeF) with
    this library. Use the library-native equivalents: SvgColor, SvgPointF,
    SvgRectangleF, SvgSizeF. If you need to interop with System.Drawing in
    your own code, add a small conversion helper at your application boundary.

14. DO NOT expect SvgColor.Empty and SvgColor.Transparent to be
    distinguishable - both have packed ARGB value 0, so they compare as
    equal and both return true from IsEmpty. If you need to represent
    "fully transparent but set" vs. "unset," use an SvgPaintServer
    sentinel (None / NotSet / Inherit) at the paint-server layer rather
    than trying to encode that in SvgColor itself.


================================================================================

WHAT THIS LIBRARY DOES NOT DO
===============================

Do NOT attempt to use this library for the following:

  - Rendering SVG to images or screens (CodeBrix.SkiaSvg provides one such
    rendering backend via SkiaSharp; other backends could be built on this
    library)
  - Rasterizing SVG to PNG, JPEG, or other image formats
  - SVG animation playback
  - Interactive SVG (mouse events, hit testing)
  - Converting between SVG and other vector formats (PDF, EPS, etc.)
  - SVG optimization or minification
  - Generating SVG from scratch with a drawing API (this library models
    existing SVG content; you can construct elements programmatically but
    there is no high-level drawing API)

CodeBrix.SvgParse IS for: loading and parsing SVG documents into a
strongly-typed object model, querying and manipulating SVG elements and
attributes, applying CSS styles, deep cloning elements, and working with
the SVG DOM programmatically.


================================================================================

QUICK REFERENCE CARD
=====================

--- Install ---
dotnet add package CodeBrix.SvgParse.MsplLicenseForever

--- Namespace ---
using CodeBrix.SvgParse;

--- Load ---
From file:          SvgDocument.Open("path.svg")
From stream:        SvgDocument.Open<SvgDocument>(stream)
With options:       SvgDocument.Open<SvgDocument>(stream, options)
From XmlReader:     SvgDocument.Open<SvgDocument>(reader)
From string:        SvgDocument.FromSvg<SvgDocument>(svgString)

--- Query ---
By ID:              document.GetElementById("id")
By ID (typed):      document.GetElementById<SvgCircle>("id")
All descendants:    document.Descendants()
Typed descendants:  document.Descendants().OfType<SvgPath>()
Children:           element.Children
Parent:             element.Parent
Parent chain:       element.Parents

--- Element Properties ---
Name:               element.ElementName
Attributes:         element.Attributes
Custom attrs:       element.CustomAttributes
Content:            element.Content

--- Visual Properties ---
Fill:               element.Fill (SvgPaintServer)
Stroke:             element.Stroke (SvgPaintServer)
Opacity:            element.Opacity
Stroke width:       element.StrokeWidth
Clip path:          element.ClipPath
Filter:             element.Filter

--- Shapes ---
Rectangle:          X, Y, Width, Height, CornerRadiusX, CornerRadiusY
Circle:             CenterX, CenterY, Radius
Ellipse:            CenterX, CenterY, RadiusX, RadiusY
Line:               StartX, StartY, EndX, EndY
Polygon/Polyline:   Points
Path:               PathData (SvgPathSegmentList)

--- Text ---
Text/Tspan:         X, Y, FontFamily, FontSize, FontWeight, TextAnchor
TextPath:           Href, StartOffset

--- Transforms ---
Translate:          SvgTranslate
Rotate:             SvgRotate
Scale:              SvgScale
SkewX/Y:            SvgSkewX, SvgSkewY
Matrix:             SvgMatrix

--- Manipulation ---
Deep copy:          element.DeepCopy<T>()
Add child:          element.Children.Add(child)
Add style:          element.AddStyle(name, value, specificity)
Flush styles:       element.FlushStyles(true)

--- Data Types ---
Unit:               new SvgUnit(SvgUnitType.Pixel, 10f)
Point (SvgUnits):   new SvgPoint(x, y)
Point (floats):     new SvgPointF(x, y)
Rect (floats):      new SvgRectangleF(x, y, width, height)
Size (floats):      new SvgSizeF(width, height)
Color (named):      SvgColor.Red
Color (hex):        SvgColor.ParseHex("#ff0000")
Color (parse):      SvgColor.Parse("red") / TryParse
Color (construct):  SvgColor.FromRgb(r, g, b) / FromRgba / FromArgb
Color server:       new SvgColorServer(SvgColor.Red)
ViewBox:            new SvgViewBox(minX, minY, width, height)

--- Security (static, library-wide) ---
XXE prevention:     SvgDocument.ResolveExternalXmlEntites = ExternalType.None
Image loading:      SvgDocument.ResolveExternalImages = ExternalType.Local

--- Serialization ---
Emit named colors:  SvgDocument.EmitNamedColorsOnSerialization = true  // static default
                    doc.EnableEmitNamedColorsOnSerialization = true    // per-document
                    // Default is false (always hex output). Static is
                    // snapshotted into new documents at construction.

Target: .NET 10.0+
License: Ms-PL


================================================================================

DEEPER LEARNING: TEST FILE CROSS-REFERENCES
=============================================

The CodeBrix.SvgParse.Tests project contains working examples:

    https://github.com/ellisnet/CodeBrix.SvgParse
    Path: tests/CodeBrix.SvgParse.Tests/

Feature-to-test-file mapping:

  SVG document parsing and loading:
    -> tests/CodeBrix.SvgParse.Tests/SvgDocumentParsingTests.cs

  Element deep copy and cloning:
    -> tests/CodeBrix.SvgParse.Tests/SvgDeepCopyTests.cs

  Element factory and element creation by name:
    -> tests/CodeBrix.SvgParse.Tests/SvgElementFactoryTests.cs

  Element ID management:
    -> tests/CodeBrix.SvgParse.Tests/SvgElementIdTests.cs

  Generated property tests:
    -> tests/CodeBrix.SvgParse.Tests/SvgGeneratedPropertyTests.cs

  Gradient handling (linear, radial, stops):
    -> tests/CodeBrix.SvgParse.Tests/SvgGradientTests.cs

  SVG serialization (writing back to SVG text):
    -> tests/CodeBrix.SvgParse.Tests/SvgSerializationTests.cs

  Shape elements (rect, circle, ellipse, line, path, polygon):
    -> tests/CodeBrix.SvgParse.Tests/SvgShapeElementTests.cs

  CSS styling and specificity:
    -> tests/CodeBrix.SvgParse.Tests/SvgStylingTests.cs

  Text elements and font handling:
    -> tests/CodeBrix.SvgParse.Tests/SvgTextTests.cs

  Clipping and filter effects:
    -> tests/CodeBrix.SvgParse.Tests/SvgClippingAndFilterTests.cs

HOW TO USE: Fetch the raw file content from GitHub using a URL like:
    https://raw.githubusercontent.com/ellisnet/CodeBrix.SvgParse/main/{path}
For example:
    https://raw.githubusercontent.com/ellisnet/CodeBrix.SvgParse/main/tests/CodeBrix.SvgParse.Tests/SvgDocumentParsingTests.cs


================================================================================

END OF AGENT-README
