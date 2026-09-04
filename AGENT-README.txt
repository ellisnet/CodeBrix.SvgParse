================================================================================
AGENT-README: CodeBrix.SvgParse
A Guide for AI Coding Agents -- CONSUMING the
CodeBrix.SvgParse.MsplLicenseForever NuGet package
================================================================================

OVERVIEW
========
CodeBrix.SvgParse is a renderer-agnostic SVG document object model (DOM)
library. It parses SVG documents into a strongly-typed element tree, models
every SVG element family (shapes, paths, paint servers, text, fonts and
glyphs, transforms, clipping and masking, filter effects, markers and
animation elements), applies CSS styling, and serializes the tree back to
SVG text. It does not depend on any rendering engine, on System.Drawing, or
on any external geometry/color package: every geometric and color value type
it exposes is library-native. It can serve as the front half of any SVG
rendering backend.

Target framework: .NET 10 or later.

Provenance: CodeBrix.SvgParse is a fork of the Svg.Custom project (part of
the Svg.Skia projects). Every namespace was renamed from "Svg" to
"CodeBrix.SvgParse" -- for example, upstream "Svg.Transforms" is
"CodeBrix.SvgParse.Transforms" here. Do NOT write "using Svg;" or any other
upstream namespace, and do not assume upstream API shapes that are not
documented below; several members that are public upstream are internal in
this fork.


INSTALLATION
============
PackageId: CodeBrix.SvgParse.MsplLicenseForever

    dotnet add package CodeBrix.SvgParse.MsplLicenseForever

IMPORTANT: the package id is CodeBrix.SvgParse.MsplLicenseForever, NOT
"CodeBrix.SvgParse". The root namespace and the assembly name are
CodeBrix.SvgParse.

NuGet dependencies:
  - CodeBrix.StyleSheetParse.MitLicenseForever   (CSS parsing/selectors)

License: MS-PL (Microsoft Public License). The package requires license
acceptance.

Requirements and limits:
  - .NET 10 or later. There is no netstandard or .NET Framework target.
  - No native libraries; no OS-specific dependencies. Runs anywhere .NET 10
    runs.
  - Pure managed parsing/serialization: nothing is drawn, rasterized or
    measured against a real font.


KEY NAMESPACES / USINGS
=======================
Nearly the whole public surface lives in the base namespace. A single
`using CodeBrix.SvgParse;` covers most consumer code.

    using CodeBrix.SvgParse;               // SvgDocument, SvgElement, all
                                           //   shape/structure/text/font/
                                           //   animation elements, all paint
                                           //   servers, SvgColor, SvgUnit,
                                           //   SvgPoint, SvgPointF,
                                           //   SvgRectangleF, SvgSizeF,
                                           //   SvgViewBox, SvgAspectRatio,
                                           //   SvgOrient, the presentation
                                           //   enums, the type converters,
                                           //   the event-args classes and
                                           //   SvgException / SvgIDException.
    using CodeBrix.SvgParse.Pathing;       // SvgPathSegment and the six
                                           //   segment types, SvgPathSegmentList,
                                           //   ISvgPathElement, SvgArcSize,
                                           //   SvgArcSweep.
    using CodeBrix.SvgParse.Transforms;    // SvgTransform, SvgTranslate,
                                           //   SvgRotate, SvgScale, SvgSkew,
                                           //   SvgShear, SvgMatrix,
                                           //   SvgTransformCollection,
                                           //   SvgTransformConverter.
    using CodeBrix.SvgParse.FilterEffects; // SvgFilter, SvgFilterPrimitive and
                                           //   every fe* primitive, the light
                                           //   sources, ISvgFilterable and the
                                           //   filter enums.
    using CodeBrix.SvgParse.Primitives;    // SvgOrientConverter,
                                           //   SvgPreserveAspectRatioConverter,
                                           //   SvgColorInterpolation,
                                           //   SvgMarkerUnits.
    using CodeBrix.SvgParse.Exceptions;    // SvgMemoryException (only).
    using CodeBrix.SvgParse.ExtensionMethods; // UriExtensions.

Namespace gotchas that cost compile errors:

  - There is NO "CodeBrix.SvgParse.Painting" namespace. SvgPaintServer,
    SvgColorServer, SvgGradientServer, SvgLinearGradientServer,
    SvgRadialGradientServer, SvgPatternServer, SvgGradientStop, SvgMarker,
    SvgDeferredPaintServer and SvgFallbackPaintServer are all in the base
    CodeBrix.SvgParse namespace even though their source files sit in a
    "Painting" folder. The same is true of "Text", "Animation",
    "Document Structure", "Basic Shapes", "Clipping and Masking",
    "Metadata", "Linking", "Scripting" and "Interaction": folders, not
    namespaces.
  - CodeBrix.SvgParse.Exceptions contains exactly ONE public type,
    SvgMemoryException. SvgException, SvgIDException, SvgIDExistsException,
    SvgIDWrongFormatException and SvgGdiPlusCannotBeLoadedException are in
    the base CodeBrix.SvgParse namespace.
  - CodeBrix.SvgParse.Css exists but contains only internal types. There is
    nothing there for a consumer to use; do not add a using for it.
  - ISvgTransformable is in CodeBrix.SvgParse, not in
    CodeBrix.SvgParse.Transforms, even though SvgTransformCollection (its one
    member's type) is in Transforms.
  - CodeBrix.SvgParse.Primitives holds only four public types. The value
    types you actually use (SvgUnit, SvgPoint, SvgColor, SvgViewBox,
    SvgAspectRatio, SvgOrient, ...) are in the base namespace.


================================================================================

CORE API REFERENCE
==================

LOADING SVG DOCUMENTS
---------------------
There are two loaders. Both return an SvgDocument (or a subclass).

SvgDocument static loaders -- the classic entry points:

    static SvgDocument Open(string path)
    static T Open<T>(string path)                        where T : SvgDocument, new()
    static T Open<T>(string path, SvgOptions svgOptions) where T : SvgDocument, new()
    static T Open<T>(Stream stream)                      where T : SvgDocument, new()
    static T Open<T>(Stream stream, SvgOptions svgOptions) where T : SvgDocument, new()
    static T Open<T>(XmlReader reader)                   where T : SvgDocument, new()
    static SvgDocument Open(XmlDocument document)
    static T FromSvg<T>(string svg)                      where T : SvgDocument, new()

    Two further overloads take a raw Dictionary<string, string> of XML
    entities and are marked [Obsolete]; pass an SvgOptions instead:
        static T Open<T>(string path, Dictionary<string, string> entities)
        static T Open<T>(Stream stream, Dictionary<string, string> entities)

SvgDocumentCompatibilityLoader -- the browser-compatibility loader:

    public static class SvgDocumentCompatibilityLoader
    {
        static T Open<T>(string path, SvgOptions svgOptions)   where T : SvgDocument, new()
        static T Open<T>(Stream stream, SvgOptions svgOptions) where T : SvgDocument, new()
        static T FromSvg<T>(string svg)                        where T : SvgDocument, new()
        static T Open<T>(XmlReader reader)                     where T : SvgDocument, new()
    }

    This loader builds the same element tree but (a) captures an absolute
    document base URI before reading, so relative stylesheet references
    resolve the way a browser would resolve them, and (b) preserves the raw
    <style> text so a stricter, Chrome-aligned CSS pass can run after the
    tree is built. Prefer it whenever CSS correctness matters -- external
    stylesheets, @import, selector specificity. The repository's own test
    suite uses it for essentially all styling assertions.

SvgOptions -- loader configuration (also an IDictionary<string, string>):

    new SvgOptions()
    new SvgOptions(Dictionary<string, string> entities)          // custom XML entities
    new SvgOptions(string css)                                   // extra CSS text
    new SvgOptions(Dictionary<string, string> entities, string css)

    Dictionary<string, string> Entities { get; }
    string Css { get; }

Example:

    var document = SvgDocument.Open("image.svg");
    Console.WriteLine($"Width: {document.Width}, Height: {document.Height}");


SVG DOCUMENT (SvgDocument)
--------------------------
    public partial class SvgDocument : SvgFragment, ITypeDescriptorContext

Root of the document model; inherits every viewport property from
SvgFragment.

Instance members:

    int Ppi { get; set; }                       // pixels per inch; initialized
                                                //   from PointsPerInch
    Uri BaseUri { get; set; }                   // must be absolute or the setter
                                                //   throws ArgumentException
    string ExternalCSSHref { get; set; }        // external stylesheet reference
    bool EnableEmitNamedColorsOnSerialization { get; set; }
    SvgElement GetElementById(string id)        // virtual
    T GetElementById<T>(string id) where T : SvgElement          // virtual
    void OverwriteIdManager(SvgElementIdManager manager)
    void RasterizeDimensions(ref SvgSizeF size, int rasterWidth, int rasterHeight)
    void Write(XmlWriter writer)                // override
    void Write(Stream stream, bool useBom = true)
    void Write(string path, bool useBom = true)

Static, library-wide security controls (they affect every document):

    static ExternalType ResolveExternalXmlEntities { get; set; }   // default None
    static ExternalType ResolveExternalImages { get; set; }        // default Local|Remote
    static ExternalType ResolveExternalElements { get; set; }      // default Local|Remote
    static bool DisableDtdProcessing { get; set; }                 // default false
    static int PointsPerInch { get; set; }      // lazily seeded from the system DPI

    NOTE the spelling: ResolveExternalXmlEntities, with the "i" --
    "ResolveExternalXmlEntites" does not exist and will not compile.

    [Flags] enum ExternalType { None = 0, Local = 1, Remote = 2 }
    bool ExternalTypeExtensions.AllowsResolving(this ExternalType, Uri uri)

Static serialization default:

    static bool EmitNamedColorsOnSerialization { get; set; }   // default false

    When true, a color that matches a W3C/CSS3 name is written out by name
    (fill="red") instead of hex (fill="#ff0000"). The static is SNAPSHOTTED
    into each new SvgDocument's EnableEmitNamedColorsOnSerialization at
    construction time; changing the static afterwards does not retro-fit
    existing documents.


SVG FRAGMENT (SvgFragment)
--------------------------
    [SvgElement("svg")]
    public partial class SvgFragment : SvgElement, ISvgViewPort

The <svg> element -- both the document root and any nested viewport.

    static readonly Uri Namespace               // http://www.w3.org/2000/svg
    SvgUnit X, Y                                // virtual
    SvgUnit Width, Height
    SvgViewBox ViewBox
    SvgAspectRatio AspectRatio                  // preserveAspectRatio
    SvgOverflow Overflow                        // virtual
    SvgUnit FontSize                            // override
    string FontFamily                           // override
    XmlSpaceHandling SpaceHandling              // override; xml:space


SVG ELEMENT (SvgElement)
------------------------
    public abstract partial class SvgElement
        : ISvgElement, ISvgTransformable, ICloneable, ISvgNode

Abstract base for every element in the tree.

Identity and tree:

    string ID { get; set; }
    SvgElement Parent { get; }                          // virtual
    SvgElementCollection Children { get; }              // virtual
    IList<ISvgNode> Nodes { get; }                      // mixed element/text nodes
    SvgDocument OwnerDocument { get; }                  // virtual
    string Content { get; set; }                        // virtual; text content
    Dictionary<string, string> Namespaces { get; }
    SvgCustomAttributeCollection CustomAttributes { get; }   // Dictionary<string,string>
    SvgTransformCollection Transforms { get; set; }
    XmlSpaceHandling SpaceHandling { get; set; }        // virtual

Traversal:

    IEnumerable<SvgElement> Descendants()               // self excluded, depth-first
    IEnumerable<SvgElement> Parents                     // parent chain, nearest first
    IEnumerable<SvgElement> ParentsAndSelf
    bool HasChildren()                                  // virtual

Attributes (string level):

    bool ContainsAttribute(string name)
    bool TryGetAttribute(string name, out string value)

    IMPORTANT: the strongly-typed SvgAttributeCollection behind these helpers
    is `protected internal`, and so is the element's SVG element name. From a
    consumer assembly you have ContainsAttribute / TryGetAttribute /
    CustomAttributes, the typed CLR properties, and the CLR type itself --
    there is no public `element.Attributes` and no public
    `element.ElementName`. See COMMON PITFALLS.

Cloning:

    SvgElement DeepCopy()                               // abstract
    SvgElement DeepCopy<T>() where T : SvgElement, new()  // virtual
    object Clone()                                      // virtual; ICloneable

Styling:

    void AddStyle(string name, string value, int specificity)
    void FlushStyles(bool children = false)
    void InvalidateChildPaths()

Animation runtime (generic attribute get/set by SVG attribute name):

    object GetAnimationValue(string attributeName)                       // virtual
    bool TrySetAnimationValue(string attributeName, object value)        // virtual
    bool TrySetAnimationValue(string attributeName, ITypeDescriptorContext context,
                              CultureInfo culture, object value)         // virtual
    bool ClearAnimationValue(string attributeName)                       // virtual

Serialization and parsing hooks:

    void Write(XmlWriter writer)                                     // virtual
    bool ShouldWriteElement()                                        // virtual
    void InitialiseFromXML(XmlReader reader, SvgDocument document)    // virtual
    void SetAndForceUniqueID(string value, bool autoForceUniqueID = true,
                             Action<SvgElement, string, string> logElementOldIDNewID = null)

Events (see EXCEPTIONS AND EVENTS below):

    event EventHandler Load
    event EventHandler<ChildAddedEventArgs> ChildAdded
    event EventHandler<AttributeEventArgs> AttributeChanged
    event EventHandler<ContentEventArgs> ContentChanged
    event EventHandler<MouseArg> Click, MouseDown, MouseUp, MouseMove,
                                 MouseOver, MouseOut
    event EventHandler<MouseScrollArg> MouseScroll
    public bool AutoPublishEvents               // field, default true
    void RegisterEvents(ISvgEventCaller caller)     // virtual
    void UnregisterEvents(ISvgEventCaller caller)   // virtual

Extension methods on the tree:

    IEnumerable<SvgElement> Extensions.Descendants<T>(this IEnumerable<T> source)
                                                    where T : SvgElement
    void SvgExtensions.ApplyRecursive(this SvgElement elem, Action<SvgElement> action)
    void SvgExtensions.ApplyRecursiveDepthFirst(this SvgElement elem,
                                                Action<SvgElement> action)
    bool SvgExtensions.HasNonEmptyCustomAttribute(this SvgElement element, string name)
    void SvgExtensions.SetRectangle(this SvgRectangle r, SvgRectangleF bounds)
    Uri UriExtensions.ReplaceWithNullIfNone(this Uri uri)   // CodeBrix.SvgParse.ExtensionMethods


PRESENTATION PROPERTIES (declared on SvgElement)
------------------------------------------------
All SVG presentation attributes are declared on SvgElement itself, so every
element -- container elements included -- exposes them. They are `virtual`
unless noted, and they honour SVG attribute inheritance: reading one walks up
the parent chain when the element does not set it.

Paint and stroke:

    SvgPaintServer Fill                 // fill
    SvgPaintServer Stroke               // stroke
    SvgPaintServer Color                // color (declared on SvgElement)
    SvgFillRule FillRule                // fill-rule
    float Opacity                       // opacity
    float FillOpacity                   // fill-opacity
    float StrokeOpacity                 // stroke-opacity
    SvgUnit StrokeWidth                 // stroke-width
    SvgStrokeLineCap StrokeLineCap      // stroke-linecap
    SvgStrokeLineJoin StrokeLineJoin    // stroke-linejoin
    float StrokeMiterLimit              // stroke-miterlimit
    SvgUnitCollection StrokeDashArray   // stroke-dasharray
    SvgUnit StrokeDashOffset            // stroke-dashoffset

Rendering hints, visibility and color management:

    SvgShapeRendering ShapeRendering        // shape-rendering
    SvgColorInterpolation ColorInterpolation           // color-interpolation
    SvgColorInterpolation ColorInterpolationFilters    // color-interpolation-filters
    string Visibility                       // visibility (raw string)
    string Display                          // display   (raw string)

Text and font (usable on any element; they inherit down into text):

    string FontFamily                       // font-family
    SvgUnit FontSize                        // font-size
    SvgFontStyle FontStyle                  // font-style
    SvgFontVariant FontVariant              // font-variant
    SvgFontWeight FontWeight                // font-weight
    SvgFontStretch FontStretch              // font-stretch
    string Font                             // the "font" shorthand, raw string
    SvgTextAnchor TextAnchor                // text-anchor
    SvgDominantBaseline DominantBaseline    // dominant-baseline
    string BaselineShift                    // baseline-shift (raw string, NOT SvgUnit)
    SvgTextDecoration TextDecoration        // text-decoration
    SvgTextTransformation TextTransformation  // text-transform (note the full name)


SVG VISUAL ELEMENT (SvgVisualElement)
-------------------------------------
    public abstract partial class SvgVisualElement : SvgElement, ISvgStylable

Base for elements that produce graphics. It adds clipping, filtering and
visibility on top of the presentation properties above.

    string Clip                     // virtual; the CSS "clip" property
    Uri ClipPath                    // virtual; url(#id) reference to a <clipPath>
    SvgClipRule ClipRule            // clip-rule
    Uri Filter                      // virtual; url(#id) reference to a <filter>
    bool Visible                    // virtual
    string EnableBackground         // virtual; enable-background

Inheritance chain that matters when you write type tests:

    SvgElement
      -> SvgVisualElement                (ISvgStylable)
           -> SvgPathBasedElement
                -> SvgMarkerElement      (marker-start/mid/end)
                     -> SvgGroup, SvgLine, SvgPath, SvgPolygon
                          -> SvgPolyline (derives from SvgPolygon)
                -> SvgCircle, SvgEllipse, SvgRectangle, SvgMarker, SvgGlyph
           -> SvgUse, SvgImage, SvgSymbol, SvgSwitch, SvgForeignObject,
              SvgTextBase (-> SvgText, SvgTextSpan, SvgTextPath, SvgTextRef)
      -> SvgFragment/SvgDocument, SvgDefinitionList, SvgClipPath, SvgMask,
         SvgGradientStop, SvgPaintServer (and its gradient/pattern subclasses),
         SvgFilter and the filter primitives, the font/glyph elements, the
         animation elements, SvgTitle, SvgDescription, SvgAnchor, SvgScript,
         SvgDocumentMetadata, SvgUnknownElement, NonSvgElement


BASIC SHAPES
------------
Every shape below inherits the presentation properties and (through
SvgMarkerElement, where applicable) the marker properties.

SvgRectangle -- [SvgElement("rect")] : SvgPathBasedElement
    SvgUnit X, Y                            // x, y
    SvgUnit Width, Height                   // width, height
    SvgUnit CornerRadiusX, CornerRadiusY    // rx, ry
    SvgPoint Location                       // convenience: (X, Y)

SvgCircle -- [SvgElement("circle")] : SvgPathBasedElement
    SvgUnit CenterX, CenterY                // cx, cy   (virtual)
    SvgUnit Radius                          // r        (virtual)
    SvgPoint Center                         // convenience: (CenterX, CenterY)

SvgEllipse -- [SvgElement("ellipse")] : SvgPathBasedElement
    SvgUnit CenterX, CenterY                // cx, cy   (virtual)
    SvgUnit RadiusX, RadiusY                // rx, ry   (virtual)

SvgLine -- [SvgElement("line")] : SvgMarkerElement
    SvgUnit StartX, StartY                  // x1, y1
    SvgUnit EndX, EndY                      // x2, y2
    Fill is overridden to default to SvgPaintServer.None.

SvgPolygon -- [SvgElement("polygon")] : SvgMarkerElement
    SvgPointCollection Points               // points

SvgPolyline -- [SvgElement("polyline")] : SvgPolygon
    Inherits Points. NOTE the inheritance: `polyline is SvgPolygon` is true,
    so order your type tests polyline-first if you switch on them.


PATHS
-----
SvgPath -- [SvgElement("path")] : SvgMarkerElement, ISvgPathElement
    SvgPathSegmentList PathData             // d
    float PathLength                        // pathLength
    void OnPathUpdated()                    // ISvgPathElement

SvgPathSegmentList (CodeBrix.SvgParse.Pathing)
    public sealed class SvgPathSegmentList : IList<SvgPathSegment>, ICloneable
    ISvgPathElement Owner { get; set; }
    SvgPathSegment First { get; }
    SvgPathSegment Last { get; }
    ... plus the whole IList<SvgPathSegment> surface (indexer, Add, Insert,
    Remove, RemoveAt, Clear, Contains, IndexOf, CopyTo, Count, IsReadOnly)
    and object Clone().

SvgPathSegment (abstract base)
    bool IsRelative { get; set; }
    SvgPointF Start { get; set; }
    SvgPointF End { get; set; }
    SvgPathSegment Clone()

Segment types and their constructors:

    SvgMoveToSegment                        // M / m
        SvgMoveToSegment(bool isRelative, SvgPointF moveTo)
        SvgMoveToSegment(SvgPointF moveTo)
    SvgLineSegment                          // L / l, H, V
        SvgLineSegment(bool isRelative, SvgPointF end)
        SvgLineSegment(SvgPointF start, SvgPointF end)
    SvgCubicCurveSegment                    // C / c, S / s
        SvgPointF FirstControlPoint { get; set; }
        SvgPointF SecondControlPoint { get; set; }
        SvgCubicCurveSegment(bool isRelative, SvgPointF firstControlPoint,
                             SvgPointF secondControlPoint, SvgPointF end)
        SvgCubicCurveSegment(bool isRelative, SvgPointF secondControlPoint,
                             SvgPointF end)          // smooth (S) form
        SvgCubicCurveSegment(SvgPointF start, SvgPointF firstControlPoint,
                             SvgPointF secondControlPoint, SvgPointF end)
    SvgQuadraticCurveSegment                // Q / q, T / t
        SvgPointF ControlPoint { get; set; }
        SvgQuadraticCurveSegment(bool isRelative, SvgPointF controlPoint,
                                 SvgPointF end)
        SvgQuadraticCurveSegment(bool isRelative, SvgPointF end)   // smooth (T)
        SvgQuadraticCurveSegment(SvgPointF start, SvgPointF controlPoint,
                                 SvgPointF end)
    SvgArcSegment                           // A / a
        float RadiusX, RadiusY, Angle { get; set; }
        SvgArcSize Size { get; set; }       // Small, Large
        SvgArcSweep Sweep { get; set; }     // Negative, Positive
        SvgArcSegment(float radiusX, float radiusY, float angle, SvgArcSize size,
                      SvgArcSweep sweep, bool isRelative, SvgPointF end)
        SvgArcSegment(SvgPointF start, float radiusX, float radiusY, float angle,
                      SvgArcSize size, SvgArcSweep sweep, SvgPointF end)
    SvgClosePathSegment                     // Z / z
        SvgClosePathSegment(bool isRelative)
        SvgClosePathSegment()

Parsing and formatting path data:

    static SvgPathSegmentList SvgPathBuilder.Parse(ReadOnlySpan<char> path)

    SvgPathBuilder is a TypeConverter whose static Parse() turns a "d"
    string into a segment list. It is a parser, not a fluent builder -- to
    construct a path programmatically, new up the segment types above and
    Add() them to an SvgPathSegmentList.

    static class CoordinateParser                 // low-level number scanner
        static bool TryGetFloat(out float result, ReadOnlySpan<char> chars,
                                ref CoordinateParserState state)
        static bool TryGetBool(out bool result, ReadOnlySpan<char> chars,
                               ref CoordinateParserState state)
    ref struct CoordinateParserState              // scanner cursor
        CoordinateParserState(ref ReadOnlySpan<char> chars)
        NumState CurrNumState, NewNumState;  int CharsPosition, Position;  bool HasMore;

    static class PointFExtensions
        static string ToSvgString(this float value)
        static string ToSvgString(this SvgPointF p)

    Segment ToString() emits the SVG command text for that segment, and
    SvgPathSegmentList.ToString() emits a complete "d" attribute value.


DOCUMENT STRUCTURE ELEMENTS
---------------------------
SvgGroup -- [SvgElement("g")] : SvgMarkerElement
    A container. NOTE: SvgGroup IS an SvgVisualElement (via
    SvgMarkerElement -> SvgPathBasedElement -> SvgVisualElement).

SvgDefinitionList -- [SvgElement("defs")] : SvgElement
    Container for gradients, patterns, masks, filters, markers, symbols.
    NOT a visual element.

SvgUse -- [SvgElement("use")] : SvgVisualElement
    Uri ReferencedElement                   // xlink:href / href  (virtual)
    SvgUnit X, Y, Width, Height             // virtual
    SvgPoint Location                       // convenience: (X, Y)
    Recursion detection is performed internally while resolving the
    reference; there is no public API for it.

SvgImage -- [SvgElement("image")] : SvgVisualElement
    string Href                             // xlink:href / href (virtual, string)
    SvgUnit X, Y, Width, Height             // virtual
    SvgAspectRatio AspectRatio              // preserveAspectRatio
    SvgPoint Location

SvgSymbol -- [SvgElement("symbol")] : SvgVisualElement
    SvgViewBox ViewBox
    SvgAspectRatio AspectRatio

SvgSwitch -- [SvgElement("switch")] : SvgVisualElement
SvgForeignObject -- [SvgElement("foreignObject")] : SvgVisualElement
SvgTitle -- [SvgElement("title")] : SvgElement, ISvgDescriptiveElement
SvgDescription -- [SvgElement("desc")] : SvgElement, ISvgDescriptiveElement
    Both override ToString() to return their text content.


PAINTING AND COLORS
-------------------
SvgPaintServer -- abstract base for everything that can fill or stroke.

    static readonly SvgPaintServer None      // paint explicitly turned off
    static readonly SvgPaintServer Inherit   // inherit from the parent
    static readonly SvgPaintServer NotSet    // attribute absent
    Func<SvgPaintServer> GetCallback { get; set; }

    These three sentinels are reference-compared. Test with
    ReferenceEquals(element.Fill, SvgPaintServer.None) or `==`, not by
    inspecting the color.

SvgColorServer : SvgPaintServer
    SvgColor ColorValue { get; set; }
    new SvgColorServer()                     // defaults to SvgColor.Black
    new SvgColorServer(SvgColor color)
    ToString() returns the W3C name ("red") or hex ("#ff0000"), decided by
    the owning document's EnableEmitNamedColorsOnSerialization flag.

    Color syntax the parser (SvgColorConverter) accepts, for fill, stroke,
    color, stop-color, flood-color and lighting-color alike:
      named colors (case-insensitive, British "grey" aliases included)
      #rgb, #rgba, #rrggbb, #rrggbbaa
      rgb(r, g, b) / rgba(r, g, b, a)   CSS Color Level 3 comma form
      rgb(r g b / a)                    CSS Color Level 4 space form
      hsl(h, s%, l%)
    In rgb()/rgba() each channel is a 0-255 number (fractions allowed) OR a
    percentage, and the two may be mixed. The alpha is a percentage, a 0-1
    number, or - tolerated for legacy content - a 0-255 number when it is
    greater than 1. Out-of-range values clamp; they never throw. Percentage
    alpha matters in practice: LilyPond's SVG backend writes every color in
    that form - rgba(83.5294%, 36.8627%, 0.0000%, 100.0000%) - so a document
    from it parses with its colors and its transparency intact.

SvgGradientServer (abstract) : SvgPaintServer
    List<SvgGradientStop> Stops { get; }
    SvgGradientSpreadMethod SpreadMethod         // spreadMethod
    SvgCoordinateUnits GradientUnits             // gradientUnits
    SvgTransformCollection GradientTransform     // gradientTransform
    SvgDeferredPaintServer InheritGradient       // xlink:href to another gradient
    SvgPaintServer StopColor                     // stop-color
    float StopOpacity                            // stop-opacity

SvgLinearGradientServer -- [SvgElement("linearGradient")] : SvgGradientServer
    SvgUnit X1, Y1, X2, Y2

SvgRadialGradientServer -- [SvgElement("radialGradient")] : SvgGradientServer
    SvgUnit CenterX, CenterY                     // cx, cy
    SvgUnit Radius                               // r
    SvgUnit FocalX, FocalY                       // fx, fy
    SvgUnit FocalRadius                          // fr

SvgGradientStop -- [SvgElement("stop")] : SvgElement
    SvgUnit Offset                               // offset
    SvgPaintServer StopColor                     // stop-color
    float StopOpacity                            // stop-opacity
    new SvgGradientStop()
    new SvgGradientStop(SvgUnit offset, SvgColor color)
    SvgColor GetColor(SvgElement parent)         // resolves inherit/currentColor

SvgPatternServer -- [SvgElement("pattern")] : SvgPaintServer, ISvgViewPort
    SvgUnit X, Y, Width, Height
    SvgCoordinateUnits PatternUnits, PatternContentUnits
    SvgTransformCollection PatternTransform
    SvgViewBox ViewBox
    SvgAspectRatio AspectRatio
    SvgOverflow Overflow
    SvgDeferredPaintServer InheritGradient       // xlink:href to another pattern


DEFERRED AND FALLBACK PAINT
---------------------------
When a fill or stroke is written as url(#id) -- possibly with a fallback
color -- the parsed value is not the target paint server itself.

SvgDeferredPaintServer : SvgPaintServer
    SvgDocument Document { get; set; }
    string DeferredId { get; set; }              // the "#id" that was referenced
    SvgPaintServer FallbackServer { get; }       // the "url(#id) red" fallback
    new SvgDeferredPaintServer()
    new SvgDeferredPaintServer(string id)
    new SvgDeferredPaintServer(string id, SvgPaintServer fallbackServer)
    new SvgDeferredPaintServer(SvgDocument document, string id)
    new SvgDeferredPaintServer(SvgDocument document, string id,
                               SvgPaintServer fallbackServer)
    void EnsureServer(SvgElement styleOwner)     // resolves DeferredId now
    static T TryGet<T>(SvgPaintServer server, SvgElement parent)
                       where T : SvgPaintServer

    TryGet<T> is the safe way to read a fill: it resolves a deferred server
    and returns null when the reference does not point at a T.

SvgFallbackPaintServer : SvgPaintServer
    new SvgFallbackPaintServer()
    new SvgFallbackPaintServer(SvgPaintServer primary,
                               IEnumerable<SvgPaintServer> fallbacks)


TEXT ELEMENTS
-------------
SvgTextBase (abstract) : SvgVisualElement -- the shared text surface:

    string Text { get; set; }               // virtual; the element's text
    SvgUnitCollection X, Y                  // virtual -- LISTS, not single units
    SvgUnitCollection Dx, Dy                // virtual -- dx, dy
    string Rotate                           // virtual -- the raw rotate list
    SvgUnit TextLength                      // textLength
    SvgTextLengthAdjust LengthAdjust        // lengthAdjust
    SvgUnit LetterSpacing                   // letter-spacing
    SvgUnit WordSpacing                     // word-spacing
    XmlSpaceHandling SpaceHandling          // override
    event EventHandler<StringArg> Change    // "onchange"
    Fill is overridden to default to black rather than inheriting.

    The x/y/dx/dy attributes are per-glyph lists in SVG, which is why they
    are SvgUnitCollection here. For the common single-value case use
    text.X[0] / text.X.Add(new SvgUnit(10f)).

SvgText -- [SvgElement("text")] : SvgTextBase
    new SvgText()
    new SvgText(string text)

SvgTextSpan -- [SvgElement("tspan")] : SvgTextBase

SvgTextRef -- [SvgElement("tref")] : SvgTextBase
    Uri ReferencedElement                   // virtual; xlink:href

SvgTextPath -- [SvgElement("textPath")] : SvgTextBase
    Uri ReferencedPath                      // virtual; xlink:href to the path
    SvgUnit StartOffset                     // startOffset
    SvgTextPathMethod Method                // method: Align, Stretch
    SvgTextPathSpacing Spacing              // spacing: Exact, Auto
    Dx is overridden (a textPath has no dx offset list of its own).

Font and text presentation properties are declared on SvgElement -- see
PRESENTATION PROPERTIES above for FontFamily/FontSize/FontWeight/
TextAnchor/DominantBaseline/TextDecoration/TextTransformation.


FONT AND GLYPH ELEMENTS (SVG FONTS)
-----------------------------------
These model the <font> element family embedded in an SVG document. The
library parses and re-serializes them; it does not build a usable typeface
from them.

SvgFont -- [SvgElement("font")] : SvgElement
    float HorizAdvX, HorizOriginX, HorizOriginY
    float VertAdvY, VertOriginX, VertOriginY

SvgFontFace -- [SvgElement("font-face")] : SvgElement
    float Alphabetic, Ascent, AscentHeight, Descent, UnitsPerEm, XHeight
    string Panose1                          // panose-1

SvgFontFaceSrc -- [SvgElement("font-face-src")] : SvgElement
SvgFontFaceUri -- [SvgElement("font-face-uri")] : SvgElement
    Uri ReferencedElement                   // virtual; xlink:href

SvgGlyph -- [SvgElement("glyph")] : SvgPathBasedElement, ISvgPathElement
    SvgPathSegmentList PathData             // d
    string GlyphName                        // virtual; glyph-name
    string Unicode                          // unicode
    float HorizAdvX, VertAdvY, VertOriginX, VertOriginY
    void OnPathUpdated()

SvgMissingGlyph -- [SvgElement("missing-glyph")] : SvgGlyph
    Overrides GlyphName.

SvgKern (abstract) : SvgElement
    string Glyph1, Glyph2                   // g1, g2
    string Unicode1, Unicode2               // u1, u2
    float Kerning                           // k
SvgHorizontalKern -- [SvgElement("hkern")] : SvgKern
SvgVerticalKern   -- [SvgElement("vkern")] : SvgKern


ANIMATION ELEMENTS
------------------
SVG animation elements are parsed into a full typed model. The library does
NOT run a timeline -- nothing moves. What you get is the declarative content
plus a per-element runtime hook (SvgElement.TrySetAnimationValue and
friends) that a host can drive itself.

SvgAnimationElement (abstract) : SvgElement -- the shared timing surface:
    Uri ReferencedElement                   // virtual; xlink:href
    SvgElement TargetElement                // virtual; the resolved target
    string RequiredFeatures, RequiredExtensions, SystemLanguage
    bool ExternalResourcesRequired
    string Begin                            // begin
    string Duration                         // dur
    string End                              // end
    string Minimum, Maximum                 // min, max
    SvgAnimationRestart Restart             // restart
    string RepeatCount                      // repeatCount
    string RepeatDuration                   // repeatDur
    SvgAnimationFill AnimationFill          // fill  (Remove | Freeze)
    string OnBeginScript, OnEndScript, OnRepeatScript, OnLoadScript

SvgAnimationAttributeElement (abstract) : SvgAnimationElement
    string AnimationAttributeName           // attributeName
    SvgAnimationAttributeType AttributeType // attributeType

SvgAnimationValueElement (abstract) : SvgAnimationAttributeElement
    SvgAnimationCalcMode CalcMode           // calcMode
    string Values                           // values
    SvgNumberCollection KeyTimes            // keyTimes
    string KeySplines                       // keySplines
    string From, To, By                     // from, to, by
    SvgAnimationAdditive Additive           // additive
    SvgAnimationAccumulate Accumulate       // accumulate

Concrete elements:

    SvgAnimate -- [SvgElement("animate")] : SvgAnimationValueElement
    SvgAnimateColor -- [SvgElement("animateColor")] : SvgAnimationValueElement
    SvgAnimateTransform -- [SvgElement("animateTransform")] : SvgAnimationValueElement
        SvgAnimateTransformType TransformType   // type
    SvgAnimateMotion -- [SvgElement("animateMotion")] : SvgAnimationElement
        SvgPathSegmentList PathData             // path
        SvgNumberCollection KeyPoints           // keyPoints
        SvgNumberCollection KeyTimes            // keyTimes
        string Values, KeySplines, From, To, By, Rotate, Origin
        SvgAnimationCalcMode CalcMode
        SvgAnimationAdditive Additive
        SvgAnimationAccumulate Accumulate
    SvgSet -- [SvgElement("set")] : SvgAnimationAttributeElement
        string To                               // to
    SvgMPath -- [SvgElement("mpath")] : SvgElement
        Uri ReferencedPath                      // virtual; xlink:href
        bool ExternalResourcesRequired
        SvgPath TargetPath                      // virtual; the resolved <path>

Animation enums (each has a matching EnumBaseConverter<T> subclass):

    SvgAnimationAttributeType   Auto, Css, Xml
    SvgAnimationRestart         Always, Never, WhenNotActive
    SvgAnimationFill            Remove, Freeze
    SvgAnimationCalcMode        Discrete, Linear, Paced, Spline
    SvgAnimationAdditive        Replace, Sum
    SvgAnimationAccumulate      None, Sum
    SvgAnimateTransformType     Translate, Scale, Rotate, SkewX, SkewY

    Converters: SvgAnimationAttributeTypeConverter, SvgAnimationRestartConverter,
    SvgAnimationFillConverter, SvgAnimationCalcModeConverter,
    SvgAnimationAdditiveConverter, SvgAnimationAccumulateConverter,
    SvgAnimateTransformTypeConverter, plus
    SvgSemicolonNumberCollectionConverter for semicolon-separated value lists.


TRANSFORMS
----------
Namespace: CodeBrix.SvgParse.Transforms (except ISvgTransformable, which is
in CodeBrix.SvgParse).

    public interface ISvgTransformable
    {
        SvgTransformCollection Transforms { get; set; }
    }

SvgTransform (abstract) : ICloneable
    abstract string WriteToString()
    abstract object Clone()
    ToString() returns WriteToString()

Concrete transforms -- note the constructor shapes:

    SvgTranslate    float X, Y            SvgTranslate(float x, float y)
                                          SvgTranslate(float x)
    SvgRotate       float Angle,          SvgRotate(float angle)
                    CenterX, CenterY      SvgRotate(float angle, float centerX,
                                                    float centerY)
    SvgScale        float X, Y            SvgScale(float x)
                                          SvgScale(float x, float y)
    SvgSkew         float AngleX, AngleY  SvgSkew(float x, float y)
    SvgShear        float X, Y            SvgShear(float x)
                                          SvgShear(float x, float y)
    SvgMatrix       List<float> Points    SvgMatrix(List<float> m)  // a,b,c,d,e,f

    THERE IS NO SvgSkewX AND NO SvgSkewY TYPE. skewX(a) is
    new SvgSkew(a, 0f) and skewY(a) is new SvgSkew(0f, a); SvgSkew writes
    itself back as skewX(...) when AngleY is 0 and as skewY(...) otherwise.
    SvgShear has no SVG attribute equivalent -- it serializes as
    "shear(x, y)".

SvgTransformCollection : List<SvgTransform>, ICloneable
    new Add / AddRange / Remove / RemoveAt / indexer  (they raise the event)
    event EventHandler<AttributeEventArgs> TransformChanged
    object Clone()
    ToString() emits the whole transform attribute value.

SvgTransformConverter : TypeConverter
    static SvgTransformCollection Parse(ReadOnlySpan<char> transform)

    SvgTransformConverter.Parse("translate(10,20) rotate(45) scale(2)")


CLIPPING AND MASKING
--------------------
SvgClipPath -- [SvgElement("clipPath")] : SvgElement
    SvgCoordinateUnits ClipPathUnits        // clipPathUnits

SvgMask -- [SvgElement("mask")] : SvgElement
    SvgUnit X, Y, Width, Height
    SvgCoordinateUnits MaskUnits, MaskContentUnits

Elements reference a clip path through SvgVisualElement.ClipPath (a Uri),
and SvgVisualElement.ClipRule carries clip-rule. There is NO typed Mask
property: a mask="url(#id)" attribute is kept verbatim in the element's
CustomAttributes, so read it with element.CustomAttributes["mask"] or
element.TryGetAttribute("mask", out var value).


MARKERS
-------
Two DIFFERENT types, easy to confuse:

SvgMarker -- [SvgElement("marker")] : SvgPathBasedElement, ISvgViewPort
    THE <marker> ELEMENT ITSELF.
    SvgUnit RefX, RefY                      // virtual; refX, refY
    SvgUnit MarkerWidth, MarkerHeight       // virtual
    SvgMarkerUnits MarkerUnits              // virtual; StrokeWidth | UserSpaceOnUse
    SvgOrient Orient                        // virtual
    SvgViewBox ViewBox                      // virtual
    SvgAspectRatio AspectRatio              // virtual
    SvgOverflow Overflow                    // virtual
    Fill and Stroke are overridden with marker-specific defaults.

SvgMarkerElement (abstract) : SvgPathBasedElement
    THE SHAPE BASE that can CARRY markers -- SvgLine, SvgPath, SvgPolygon,
    SvgPolyline and SvgGroup derive from it.
    Uri MarkerStart                         // marker-start
    Uri MarkerMid                           // marker-mid
    Uri MarkerEnd                           // marker-end


FILTER EFFECTS
--------------
Namespace: CodeBrix.SvgParse.FilterEffects.

SvgFilter -- [SvgElement("filter")] : SvgElement
    SvgUnit X, Y, Width, Height
    SvgCoordinateUnits FilterUnits, PrimitiveUnits
    Uri Href                                // xlink:href to another filter

SvgFilterPrimitive (abstract) : SvgElement -- base for every fe* element
    SvgUnit X, Y, Width, Height
    string Input                            // "in"
    string Result                           // "result"
    Well-known input names (const string):
        SourceGraphic, SourceAlpha, BackgroundImage, BackgroundAlpha,
        FillPaint, StrokePaint

    public interface ISvgFilterable { SvgFilter Filter { get; set; } }

Filter primitives and their own properties:

    SvgGaussianBlur -- feGaussianBlur
        SvgNumberCollection StdDeviation
    SvgOffset -- feOffset
        SvgUnit Dx, Dy
    SvgBlend -- feBlend
        SvgBlendMode Mode;  string Input2      // in2
    SvgColorMatrix -- feColorMatrix
        SvgColorMatrixType Type;  string Values
    SvgComposite -- feComposite
        SvgCompositeOperator Operator;  float K1, K2, K3, K4;  string Input2
    SvgConvolveMatrix -- feConvolveMatrix
        SvgNumberCollection Order, KernelMatrix, KernelUnitLength
        float Divisor, Bias;  int TargetX, TargetY
        SvgEdgeMode EdgeMode;  bool PreserveAlpha
    SvgDisplacementMap -- feDisplacementMap
        float Scale;  SvgChannelSelector XChannelSelector, YChannelSelector
        string Input2
    SvgFlood -- feFlood
        SvgPaintServer FloodColor (virtual);  float FloodOpacity (virtual)
    SvgMorphology -- feMorphology
        SvgMorphologyOperator Operator;  SvgNumberCollection Radius
    SvgTurbulence -- feTurbulence
        SvgNumberCollection BaseFrequency;  int NumOctaves;  float Seed
        SvgStitchType StitchTiles;  SvgTurbulenceType Type
    SvgTile -- feTile                       (no extra properties)
    SvgMerge -- feMerge                     (children are SvgMergeNode)
    SvgMergeNode -- [SvgElement("feMergeNode")] : SvgElement
        string Input                        // "in"
    SvgComponentTransfer -- feComponentTransfer
        Children are SvgFuncR / SvgFuncG / SvgFuncB / SvgFuncA
    SvgComponentTransferFunction (abstract base of SvgFuncR/G/B/A)
        SvgComponentTransferType Type;  SvgNumberCollection TableValues
        float Slope, Intercept, Amplitude, Exponent, Offset
    SvgDiffuseLighting -- feDiffuseLighting
        float SurfaceScale, DiffuseConstant
        SvgNumberCollection KernelUnitLength;  SvgPaintServer LightingColor
    SvgSpecularLighting -- feSpecularLighting
        float SurfaceScale, SpecularConstant, SpecularExponent
        SvgNumberCollection KernelUnitLength;  SvgPaintServer LightingColor
        SvgElement LightSource
    SvgImage -- feImage   (CodeBrix.SvgParse.FilterEffects.SvgImage --
                          a DIFFERENT type from CodeBrix.SvgParse.SvgImage)
        string Href (virtual);  SvgAspectRatio AspectRatio

Light sources (plain SvgElement children of a lighting primitive):

    SvgDistantLight -- feDistantLight    float Azimuth, Elevation
    SvgPointLight   -- fePointLight      float X, Y, Z
    SvgSpotLight    -- feSpotLight       float X, Y, Z, PointsAtX, PointsAtY,
                                        PointsAtZ, SpecularExponent,
                                        LimitingConeAngle

Filter enums:

    SvgBlendMode            Normal, Multiply, Screen, Overlay, Darken, Lighten,
                            ColorDodge, ColorBurn, HardLight, SoftLight,
                            Difference, Exclusion, Hue, Saturation, Color,
                            Luminosity
    SvgColorMatrixType      Matrix, Saturate, HueRotate, LuminanceToAlpha
    SvgCompositeOperator    Over, In, Out, Atop, Xor, Arithmetic
    SvgEdgeMode             Duplicate, Wrap, None
    SvgChannelSelector      R, G, B, A
    SvgMorphologyOperator   Erode, Dilate
    SvgStitchType           Stitch, NoStitch
    SvgTurbulenceType       FractalNoise, Turbulence
    SvgComponentTransferType Identity, Table, Discrete, Linear, Gamma
    BlurType                Both, HorizontalOnly, VerticalOnly


SCRIPTING, LINKING, METADATA AND UNKNOWN CONTENT
------------------------------------------------
SvgAnchor -- [SvgElement("a")] : SvgElement
    string Href, Show, Title                // xlink:href, xlink:show, xlink:title
    string Target                           // target

SvgScript -- [SvgElement("script")] : SvgElement
    string Script                           // the inline script text
    string ScriptType                       // type
    string CrossOrigin                      // crossorigin
    string Href                             // xlink:href
    The library never executes script content.

SvgDocumentMetadata -- [SvgElement("metadata")] : SvgElement
    Preserves arbitrary metadata XML verbatim through load and save.

SvgUnknownElement : SvgElement
    new SvgUnknownElement()
    new SvgUnknownElement(string elementName)
    Produced for an element in the SVG namespace that the library does not
    model.

NonSvgElement : SvgElement
    new NonSvgElement()
    new NonSvgElement(string elementName, string elementNamespace)
    string Name { get; }                    // the element's local name
    Produced for elements in a FOREIGN namespace. Name is the only public
    way to read back an element's tag name in this library.

SvgContentNode : ISvgNode
    string Content { get; set; }
    ISvgNode DeepCopy()
    A text node inside SvgElement.Nodes.


DATA TYPES
----------
Every value type below is library-native. The library does NOT depend on
System.Drawing or on any other external geometry/color package.

SvgUnit (struct) -- a number plus a unit:
    float Value { get; set; }
    SvgUnitType Type { get; set; }
    bool IsEmpty { get; }
    bool IsNone { get; }
    SvgUnit ToPercentage()
    static readonly SvgUnit Empty           // User 0, flagged empty
    static readonly SvgUnit None            // SvgUnitType.None
    new SvgUnit(float value)                // SvgUnitType.User
    new SvgUnit(SvgUnitType type, float value)
    implicit operator SvgUnit(float value)
    == / != compare Value AND Type.

    enum SvgUnitType
        None, Pixel, Em, Ex, Percentage, User, Inch, Centimeter, Millimeter,
        Pica, Point

    Those eleven names, in that order, are the whole enum. There is no Px,
    In, Cm, Mm, Pt or Pc member -- the spelled-out names are the real ones,
    and SvgUnitType.Pixel is what "10px" parses to.

    enum UnitRenderingType -- internal-facing hint used while measuring;
    you will not normally set it.

SvgUnitCollection : ObservableCollection<SvgUnit>, ICloneable
    const string None = "none"
    const string Inherit = "inherit"
    string StringForEmptyValue { get; set; }
    void AddRange(IEnumerable<SvgUnit> collection)
    static bool IsNullOrEmpty(SvgUnitCollection collection)
    Used for stroke-dasharray and for text x/y/dx/dy lists. It is an
    OBSERVABLE collection, not a List<SvgUnit>.

SvgNumberCollection : List<float>, ICloneable
    Used for feGaussianBlur stdDeviation, keyTimes, kernel matrices, etc.

SvgPoint (struct) -- a unit-bearing 2D point:
    SvgUnit X, Y { get; set; }
    bool IsEmpty()
    new SvgPoint(SvgUnit x, SvgUnit y)
    new SvgPoint(string x, string y)

SvgPointCollection : List<SvgUnit>, ICloneable
    A FLAT list of SvgUnit values in x0, y0, x1, y1, ... order -- NOT a list
    of SvgPoint. polygon.Points[0] is the first x, polygon.Points[1] is the
    first y, and Points.Count is twice the number of vertices. ToString()
    re-emits "x,y x,y ..." pairs.

SvgPointF (struct) -- a raw float 2D point (used by path segments):
    float X, Y { get; set; }
    bool IsEmpty                            // X == 0 && Y == 0
    static readonly SvgPointF Empty         // (0, 0)
    static readonly SvgPointF NaN           // (NaN, NaN) -- the placeholder for
                                            //   an omitted control point in a
                                            //   smooth curve command
    new SvgPointF(float x, float y)

SvgRectangleF (struct) -- a raw float rectangle:
    float X, Y, Width, Height { get; set; }
    SvgPointF Location { get; set; }
    SvgSizeF Size { get; set; }
    float Left, Top, Right, Bottom { get; }
    bool IsEmpty                            // Width <= 0 || Height <= 0
    static readonly SvgRectangleF Empty
    new SvgRectangleF(float x, float y, float width, float height)
    new SvgRectangleF(SvgPointF location, SvgSizeF size)

SvgSizeF (struct) -- a raw float size:
    float Width, Height { get; set; }
    bool IsEmpty                            // both zero
    static readonly SvgSizeF Empty
    new SvgSizeF(float width, float height)

SvgViewBox (struct):
    float MinX, MinY, Width, Height { get; set; }
    static readonly SvgViewBox Empty
    new SvgViewBox(float minX, float minY, float width, float height)
    implicit conversions to and from SvgRectangleF.

SvgAspectRatio (CLASS, not a struct) : ICloneable
    SvgPreserveAspectRatio Align { get; set; }
    bool Slice { get; set; }                // "meet" (false) vs "slice" (true)
    bool Defer { get; set; }
    new SvgAspectRatio()
    new SvgAspectRatio(SvgPreserveAspectRatio align)
    new SvgAspectRatio(SvgPreserveAspectRatio align, bool slice)
    new SvgAspectRatio(SvgPreserveAspectRatio align, bool slice, bool defer)

    enum SvgPreserveAspectRatio -- lower-camel member names matching the SVG
    keywords: xMidYMid (the default), none, xMinYMin, xMidYMin, xMaxYMin,
    xMinYMid, xMaxYMid, xMinYMax, xMidYMax, xMaxYMax

SvgOrient (CLASS, not a struct)
    float Angle { get; set; }
    bool IsAuto { get; set; }
    bool IsAutoStartReverse { get; set; }
    new SvgOrient()
    new SvgOrient(float angle)
    new SvgOrient(bool isAuto)
    new SvgOrient(bool isAuto, bool isAutoStartReverse)
    implicit operator SvgOrient(float value)

SvgColor (readonly struct) : IEquatable<SvgColor> -- 8-bit-per-channel ARGB:
    byte A, R, G, B { get; }
    bool IsEmpty { get; }
    int ToArgb()
    static readonly SvgColor Empty

    Factories:
        static SvgColor FromRgb(byte r, byte g, byte b)          // alpha 255
        static SvgColor FromRgba(byte r, byte g, byte b, byte a)
        static SvgColor FromArgb(int a, int r, int g, int b)     // alpha first
        static SvgColor FromArgb(int r, int g, int b)            // alpha 255
        static SvgColor FromArgb(int argb)                       // packed
        static SvgColor FromArgb(int a, SvgColor baseColor)      // re-alpha

    Parsing:
        static SvgColor ParseHex(string hex)     // #rgb, #rgba, #rrggbb, #rrggbbaa
        static bool TryParseHex(string hex, out SvgColor result)
        static SvgColor Parse(string input)      // name OR hex
        static bool TryParse(string input, out SvgColor result)
        static bool TryFromName(string name, out SvgColor result)  // case-insensitive

    Serialization:
        string ToHex()                           // "#rrggbb" or "#rrggbbaa"
        string ToString()                        // same as ToHex()
        string GetKnownName()                    // "red" for #ff0000, else null

    Named colors: 142 static readonly fields spanning the W3C/CSS3 set,
    SvgColor.AliceBlue through SvgColor.YellowGreen (SvgColor.Black, Red,
    Green, Blue, White, Transparent and the rest are in there). Name lookup
    is case-insensitive; the British spellings (grey, darkgrey, ...) resolve
    to the same value as the American ones, aqua == cyan, and
    fuchsia == magenta.

    Notes:
      - Equality compares packed ARGB.
      - SvgColor.Empty and SvgColor.Transparent BOTH have packed ARGB 0, so
        they compare equal and both report IsEmpty. To distinguish "unset"
        from "fully transparent", use the SvgPaintServer sentinels
        (None / NotSet / Inherit) at the paint-server layer.
      - There is no SvgColor.FromName; use Parse / TryParse / TryFromName.


ENUMERATIONS AT A GLANCE
------------------------
Presentation and geometry (all in CodeBrix.SvgParse):

    SvgFillRule             NonZero, EvenOdd, Inherit
    SvgClipRule             NonZero, EvenOdd, Inherit
    SvgStrokeLineCap        Inherit, Butt, Round, Square
    SvgStrokeLineJoin       Inherit, Miter, MiterClip, Round, Bevel, Arcs
    SvgCoordinateUnits      ObjectBoundingBox, UserSpaceOnUse
    SvgGradientSpreadMethod Pad, Reflect, Repeat
    SvgMarkerUnits          StrokeWidth, UserSpaceOnUse   (in .Primitives)
    SvgOverflow             Hidden, Inherit, Auto, Visible, Scroll
    SvgVisibility           Visible, Hidden, Inherit
    XmlSpaceHandling        Default, Inherit, Preserve
    SvgPointerEvents        VisiblePainted, VisibleFill, VisibleStroke, Visible,
                            Painted, Fill, Stroke, All, None
    SvgShapeRendering       Inherit, Auto, OptimizeSpeed, CrispEdges,
                            GeometricPrecision
    SvgTextRendering        Inherit, Auto, OptimizeSpeed, OptimizeLegibility,
                            GeometricPrecision
    SvgImageRendering       Inherit, Auto, OptimizeSpeed, OptimizeQuality
    SvgColorInterpolation   Auto, SRGB, LinearRGB, Inherit   (in .Primitives)

Text and font:

    SvgTextAnchor           Inherit, Start, Middle, End
    SvgDominantBaseline     Auto, UseScript, NoChange, ResetSize, Ideographic,
                            Alphabetic, Hanging, Mathematical, Central, Middle,
                            TextAfterEdge, TextBeforeEdge, TextBottom, TextTop,
                            Inherit
    SvgTextDecoration       [Flags] Inherit=0, None=1, Underline=2, Overline=4,
                            LineThrough=8, Blink=16
    SvgTextTransformation   [Flags] Inherit=0, None=1, Capitalize=2,
                            Uppercase=4, Lowercase=8
    SvgTextLengthAdjust     Spacing, SpacingAndGlyphs
    SvgTextPathMethod       Align, Stretch
    SvgTextPathSpacing      Exact, Auto
    SvgFontStyle            [Flags] Inherit, Normal=1, Oblique=2, Italic=4, All
    SvgFontVariant          Normal, SmallCaps, Inherit
    SvgFontWeight           [Flags] Inherit, Normal=1, Bold=2, Bolder=4,
                            Lighter=8, W100..W900, All
    SvgFontStretch          Normal, Wider, Narrower, UltraCondensed,
                            ExtraCondensed, Condensed, SemiCondensed,
                            SemiExpanded, Expanded, ExtraExpanded,
                            UltraExpanded, Inherit

Paths, animation and filters are listed with their own sections above.
Note that most of these enums include an Inherit member: "inherit" is a
real, distinct value here, not a null.


INTERFACES (THE ISvg* CONTRACTS)
--------------------------------
    public interface ISvgNode
    {
        string Content { get; }
        ISvgNode DeepCopy();
    }
        Implemented by SvgElement and SvgContentNode; the element type of
        SvgElement.Nodes.

    public interface ISvgTransformable
    {
        SvgTransformCollection Transforms { get; set; }
    }
        Implemented by SvgElement, so every element is transformable.

    public interface ISvgStylable
    {
        SvgPaintServer Fill { get; set; }
        SvgPaintServer Stroke { get; set; }
        SvgFillRule FillRule { get; set; }
        float Opacity { get; set; }
        float FillOpacity { get; set; }
        float StrokeOpacity { get; set; }
        SvgUnit StrokeWidth { get; set; }
        SvgStrokeLineCap StrokeLineCap { get; set; }
        SvgStrokeLineJoin StrokeLineJoin { get; set; }
        float StrokeMiterLimit { get; set; }
        SvgUnitCollection StrokeDashArray { get; set; }
        SvgUnit StrokeDashOffset { get; set; }
    }
        Implemented by SvgVisualElement. Use it to write renderer code that
        does not care which shape it is painting.

    public interface ISvgViewPort
    {
        SvgViewBox ViewBox { get; set; }
        SvgAspectRatio AspectRatio { get; set; }
        SvgOverflow Overflow { get; set; }
    }
        Implemented by SvgFragment (and so SvgDocument), SvgMarker and
        SvgPatternServer.

    public interface ISvgPathElement          // CodeBrix.SvgParse.Pathing
    {
        void OnPathUpdated();
    }
        Implemented by SvgPath and SvgGlyph; SvgPathSegmentList.Owner is an
        ISvgPathElement and calls it when the segment list changes.

    public interface ISvgFilterable            // CodeBrix.SvgParse.FilterEffects
    {
        SvgFilter Filter { get; set; }
    }

    public interface ISvgDescriptiveElement { }
        Marker interface: the element is descriptive metadata, not something
        to draw. Implemented by SvgTitle and SvgDescription -- test for it to
        skip non-drawable content.

    public interface ISvgBoundable { }
        Marker interface for a bounding-box provider.

    public interface ISvgEventCaller
    {
        void RegisterAction(string rpcID, Action action);
        void RegisterAction<T1>(string rpcID, Action<T1> action);
        void RegisterAction<T1, T2>(string rpcID, Action<T1, T2> action);
        // ... the same shape up to eight generic parameters ...
        void UnregisterAction(string rpcID);
    }
        Only relevant if you are wiring SVG DOM events to a host; pass an
        implementation to SvgElement.RegisterEvents / UnregisterEvents.


ATTRIBUTES, ID MANAGEMENT AND EXTENSIBILITY
-------------------------------------------
SvgAttributeAttribute : Attribute -- marks a CLR property as an SVG attribute.

    public string Name { get; }
    public string NameSpace { get; }
    public const string XLinkNamespace       // http://www.w3.org/1999/xlink
    public const string XmlNamespace         // http://www.w3.org/XML/1998/namespace
    public SvgAttributeAttribute(string name, string nameSpace)

    ONLY the two-argument constructor is public. The one-argument
    [SvgAttribute("stroke-width")] form is internal, so from a consumer
    assembly you must write the namespace explicitly:

        [SvgAttribute("stroke-width", SvgNamespaces.SvgNamespace)]
        [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]

SvgElementAttribute : Attribute -- marks a class as an SVG element.

    public string ElementName { get; }
    public SvgElementAttribute(string elementName)

    Applying it in YOUR assembly does not make the parser produce your type:
    the element-name-to-type table is generated at build time from this
    package's own assembly and is internal. Elements the library does not
    know become SvgUnknownElement (SVG namespace) or NonSvgElement (foreign
    namespace), with their attributes preserved in CustomAttributes. Custom
    element types are useful as containers you build yourself, not as parse
    targets.

ElementFactoryAttribute : Attribute -- a build-time marker consumed by the
    package's own source generator. Nothing for a consumer to do with it.

SvgNamespaces (static)
    const string SvgNamespace    = "http://www.w3.org/2000/svg"
    const string XLinkPrefix     = "xlink"
    const string XLinkNamespace  = "http://www.w3.org/1999/xlink"
    const string XmlPrefix       = "xml"
    const string XmlNamespace    = "http://www.w3.org/XML/1998/namespace"

SvgAttributeCollection : Dictionary<string, object>
    TAttributeType GetAttribute<TAttributeType>(string attributeName,
                                    TAttributeType defaultValue = default)
    TAttributeType GetInheritedAttribute<TAttributeType>(string attributeName,
                                    bool inherited, TAttributeType defaultValue = default)
    new object this[string attributeName] { get; set; }
    event EventHandler<AttributeEventArgs> AttributeChanged
    The TYPE is public, but SvgElement's instance of it is protected
    internal -- see COMMON PITFALLS.

SvgCustomAttributeCollection : Dictionary<string, string>
    new string this[string attributeName] { get; set; }
    event EventHandler<AttributeEventArgs> AttributeChanged
    This one IS reachable as element.CustomAttributes. It holds every
    attribute the library has no typed property for; namespaced attributes
    are keyed "prefix:name".

SvgElementCollection : IList<SvgElement>
    The full IList surface plus:
    void AddAndForceUniqueID(SvgElement item, bool autoForceUniqueID = true,
                             bool autoFixChildrenID = true,
                             Action<SvgElement, string, string> logElementOldIDNewID = null)
    void InsertAndForceUniqueID(int index, SvgElement item,
                             bool autoForceUniqueID = true,
                             bool autoFixChildrenID = true,
                             Action<SvgElement, string, string> logElementOldIDNewID = null)
    IEnumerable<T> FindSvgElementsOf<T>() where T : SvgElement
    T FindSvgElementOf<T>() where T : SvgElement      // first match or null
    T GetSvgElementOf<T>() where T : SvgElement       // recursive search

SvgElementIdManager -- the id index behind GetElementById.
    SvgElementIdManager(SvgDocument document)
    SvgElement GetElementById(string id)              // virtual
    SvgElement GetElementById(Uri uri)                // virtual; url(#id) form
    void Add(SvgElement element)                      // virtual
    bool AddAndForceUniqueID(SvgElement element, SvgElement sibling,
                             bool autoForceUniqueID = true,
                             Action<SvgElement, string, string> logElementOldIDNewID = null)
    void Remove(SvgElement element)                   // virtual
    string EnsureValidId(string id, bool autoForceUniqueID = false)
    event EventHandler<SvgElementEventArgs> ElementAdded
    event EventHandler<SvgElementEventArgs> ElementRemoved

    Install a subclass with document.OverwriteIdManager(manager) -- but if
    elements are already in the document, the replacement must be told about
    them.


SERIALIZATION
-------------
Writing a whole document:

    void SvgDocument.Write(XmlWriter writer)
    void SvgDocument.Write(Stream stream, bool useBom = true)
    void SvgDocument.Write(string path, bool useBom = true)

Writing to a string:

    string SvgExtensions.GetXML(this SvgDocument doc)
    string SvgExtensions.GetXML(this SvgElement elem)

    GetXML() on an element serializes just that subtree -- handy for
    round-trip assertions and for extracting one icon out of a sprite sheet.

Writing a single element into an XmlWriter:

    void SvgElement.Write(XmlWriter writer)           // virtual
    bool SvgElement.ShouldWriteElement()              // virtual; false to skip

Named-color output is controlled by SvgDocument.EmitNamedColorsOnSerialization
(static default) and doc.EnableEmitNamedColorsOnSerialization (per document).
A url(#id) fill written back out is produced by SvgDeferredPaintServer /
SvgFallbackPaintServer, so a document that was loaded with an unresolved
reference re-serializes with that reference intact.


TYPE CONVERTERS AND STRING PARSING
----------------------------------
Roughly forty-five TypeConverter classes back attribute parsing. You rarely
name them directly -- the parser uses them -- but they are public and each
exposes the usual ConvertFrom/ConvertTo, and several expose a static Parse:

    static SvgPathSegmentList SvgPathBuilder.Parse(ReadOnlySpan<char> path)
    static SvgTransformCollection SvgTransformConverter.Parse(ReadOnlySpan<char> t)
    static SvgUnitCollection SvgUnitCollectionConverter.Parse(ReadOnlySpan<char> points)
    static SvgNumberCollection SvgNumberCollectionConverter.Parse(ReadOnlySpan<char> n)

Named converters worth knowing:

    SvgUnitConverter, SvgColorConverter, SvgUnitCollectionConverter,
    SvgNumberCollectionConverter, SvgSemicolonNumberCollectionConverter,
    SvgOrientConverter and SvgPreserveAspectRatioConverter (both in
    CodeBrix.SvgParse.Primitives), SvgTransformConverter (in
    CodeBrix.SvgParse.Transforms), and the generic enum converter base:

    public abstract class EnumBaseConverter<T> : TypeConverter where T : struct
    {
        public enum CaseHandling { CamelCase, PascalCase, LowerCase, KebabCase }
        public CaseHandling CaseHandlingMode { get; }
        public EnumBaseConverter(CaseHandling caseHandling = CaseHandling.CamelCase)
    }

    CaseHandling is NESTED inside EnumBaseConverter<T>; each concrete
    converter picks the casing its SVG keywords use (lower-case for
    fill-rule, kebab-case for dominant-baseline, camel-case by default).

    Every presentation enum has a sealed EnumBaseConverter<T> subclass
    named after it -- SvgFillRuleConverter, SvgStrokeLineCapConverter,
    SvgStrokeLineJoinConverter, SvgFontWeightConverter, SvgFontStyleConverter,
    SvgFontVariantConverter, SvgFontStretchConverter, SvgTextAnchorConverter,
    SvgTextDecorationConverter, SvgTextTransformationConverter,
    SvgTextLengthAdjustConverter, SvgTextPathMethodConverter,
    SvgTextPathSpacingConverter, SvgDominantBaselineConverter,
    SvgClipRuleConverter, SvgCoordinateUnitsConverter,
    SvgGradientSpreadMethodConverter, SvgMarkerUnitsConverter,
    SvgOverflowConverter, SvgPointerEventsConverter,
    SvgShapeRenderingConverter, SvgTextRenderingConverter,
    SvgImageRenderingConverter, SvgColorInterpolationConverter,
    XmlSpaceHandlingConverter, the seven animation converters, and the filter
    ones (SvgBlendModeConverter, SvgColorMatrixTypeConverter,
    SvgCompositeOperatorConverter, SvgEdgeModeConverter,
    SvgChannelSelectorConverter, SvgMorphologyOperatorConverter,
    SvgStitchTypeConverter, SvgTurbulenceTypeConverter,
    SvgComponentTransferTypeConverter).

    enum NumState is a helper enum used by CoordinateParser to track where
    it is inside a number while scanning a coordinate string.


EXCEPTIONS AND EVENTS
---------------------
Exceptions (all [Serializable], all with the standard
(), (string), (string, Exception) constructor set):

    SvgException : FormatException                 // CodeBrix.SvgParse
        A malformed SVG value.
    SvgIDException : FormatException               // CodeBrix.SvgParse
        Base for the id problems below. NOTE it derives from FormatException
        directly, NOT from SvgException.
    SvgIDExistsException : SvgIDException          // duplicate id
    SvgIDWrongFormatException : SvgIDException     // id fails the SVG id rules
    SvgGdiPlusCannotBeLoadedException : Exception  // legacy carry-over from the
                                                   //   upstream project
    SvgMemoryException : Exception                 // CodeBrix.SvgParse.Exceptions

    Loading also surfaces the ordinary BCL exceptions: ArgumentNullException
    for a null path/stream/string, FileNotFoundException from Open(path),
    ArgumentException from the BaseUri setter when the Uri is relative, and
    XmlException from the underlying reader for malformed XML.

Event-argument classes:

    SVGArg : EventArgs                    // base; public string SessionID field
    AttributeEventArgs : SVGArg           // string Attribute; object Value
    ContentEventArgs : SVGArg             // string Content
    ChildAddedEventArgs : SVGArg          // SvgElement NewChild, BeforeSibling
    StringArg : SVGArg                    // string s
    MouseArg : SVGArg                     // float x, y; int Button, ClickCount;
                                          //   bool AltKey, ShiftKey, CtrlKey
    MouseScrollArg : SVGArg               // int Scroll; bool AltKey, ShiftKey,
                                          //   CtrlKey
    SvgElementEventArgs : EventArgs       // SvgElement Element
                                          //   (raised by SvgElementIdManager)

    These carry PUBLIC FIELDS, not properties -- Attribute, Value, Content,
    NewChild, x, y and the rest are fields.


================================================================================

COMPLETE EXAMPLES
=================

Example 1: Load and traverse an SVG document
--------------------------------------------
    using System;
    using CodeBrix.SvgParse;

    var document = SvgDocument.Open("drawing.svg");

    Console.WriteLine($"Document size: {document.Width} x {document.Height}");
    Console.WriteLine($"ViewBox: {document.ViewBox}");

    foreach (var element in document.Descendants())
    {
        // There is no public element.ElementName; identify by CLR type.
        Console.WriteLine($"{element.GetType().Name} id={element.ID}");
    }


Example 2: Parse SVG from a string and query elements
-----------------------------------------------------
    using System;
    using System.Linq;
    using CodeBrix.SvgParse;

    var svg = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
        <rect id='bg' x='0' y='0' width='200' height='200' fill='white'/>
        <circle id='dot' cx='100' cy='100' r='50' fill='red'/>
        <text x='100' y='180' text-anchor='middle'>Hello</text>
    </svg>";

    var document = SvgDocument.FromSvg<SvgDocument>(svg);

    // Find by id
    var circle = document.GetElementById<SvgCircle>("dot");
    Console.WriteLine($"Circle radius: {circle.Radius}");

    // Find all drawable elements
    foreach (var shape in document.Descendants().OfType<SvgVisualElement>())
    {
        var fill = shape.Fill as SvgColorServer;
        var text = fill?.ColorValue.ToHex() ?? "(not a solid color)";
        Console.WriteLine($"{shape.GetType().Name}: fill={text}");
    }


Example 3: Deep copy an element
-------------------------------
    using CodeBrix.SvgParse;

    var document = SvgDocument.Open("image.svg");
    var original = document.GetElementById<SvgCircle>("myCircle");

    // Create an independent deep copy
    var copy = (SvgCircle)original.DeepCopy();
    copy.ID = "myCircle-copy";
    copy.CenterX = new SvgUnit(200f);
    copy.Fill = new SvgColorServer(SvgColor.Blue);

    document.Children.Add(copy);


Example 4: Load with options, and load the browser-compatible way
-----------------------------------------------------------------
    using System.IO;
    using CodeBrix.SvgParse;

    // Extra CSS applied on top of the document's own styles
    var options = new SvgOptions("circle { fill: blue; } rect { stroke: red; }");

    using var stream = File.OpenRead("image.svg");
    var document = SvgDocument.Open<SvgDocument>(stream, options);

    // The browser-compatibility loader: same tree, browser-aligned CSS and a
    // real document base URI for relative stylesheet references.
    var compat = SvgDocumentCompatibilityLoader.Open<SvgDocument>("image.svg", options);


Example 5: Inspect and rebuild path data
----------------------------------------
    using System;
    using System.Linq;
    using CodeBrix.SvgParse;
    using CodeBrix.SvgParse.Pathing;

    var document = SvgDocument.Open("icon.svg");

    foreach (var path in document.Descendants().OfType<SvgPath>())
    {
        Console.WriteLine($"{path.ID}: {path.PathData.Count} segments");
        foreach (var segment in path.PathData)
        {
            Console.WriteLine($"  {segment.GetType().Name} -> {segment.End.X},{segment.End.Y}");
        }
    }

    // Parse a "d" string into a segment list
    var segments = SvgPathBuilder.Parse("M 0 0 L 100 0 L 100 100 Z".AsSpan());

    // Or build one by hand
    var built = new SvgPathSegmentList();
    built.Add(new SvgMoveToSegment(new SvgPointF(0f, 0f)));
    built.Add(new SvgLineSegment(new SvgPointF(0f, 0f), new SvgPointF(100f, 0f)));
    built.Add(new SvgClosePathSegment());

    var newPath = new SvgPath { PathData = built };
    document.Children.Add(newPath);


Example 6: Inspect gradients and resolve a url(#id) fill
--------------------------------------------------------
    using System;
    using System.Linq;
    using CodeBrix.SvgParse;

    var document = SvgDocument.Open("gradient.svg");

    foreach (var gradient in document.Descendants().OfType<SvgLinearGradientServer>())
    {
        Console.WriteLine($"({gradient.X1},{gradient.Y1}) -> ({gradient.X2},{gradient.Y2})");
        foreach (var stop in gradient.Stops)
        {
            Console.WriteLine($"  stop {stop.Offset}: {stop.GetColor(gradient).ToHex()}");
        }
    }

    // A fill written as url(#grad) parses to an SvgDeferredPaintServer.
    // TryGet resolves it and returns null when it is not the type you want.
    foreach (var shape in document.Descendants().OfType<SvgVisualElement>())
    {
        var resolved = SvgDeferredPaintServer.TryGet<SvgLinearGradientServer>(
            shape.Fill, shape);
        if (resolved is not null)
        {
            Console.WriteLine($"{shape.ID} is filled with gradient {resolved.ID}");
        }
    }


Example 7: Build a document from scratch and write it out
---------------------------------------------------------
    using System.IO;
    using CodeBrix.SvgParse;

    var doc = new SvgDocument
    {
        Width = new SvgUnit(SvgUnitType.Pixel, 120f),
        Height = new SvgUnit(SvgUnitType.Pixel, 120f),
        ViewBox = new SvgViewBox(0f, 0f, 120f, 120f),
    };

    var group = new SvgGroup { ID = "content" };
    doc.Children.Add(group);

    group.Children.Add(new SvgRectangle
    {
        X = new SvgUnit(10f),
        Y = new SvgUnit(10f),
        Width = new SvgUnit(100f),
        Height = new SvgUnit(100f),
        CornerRadiusX = new SvgUnit(8f),
        CornerRadiusY = new SvgUnit(8f),
        Fill = new SvgColorServer(SvgColor.FromRgb(0x33, 0x66, 0xCC)),
        Stroke = new SvgColorServer(SvgColor.Black),
        StrokeWidth = new SvgUnit(2f),
    });

    var label = new SvgText("CodeBrix");
    label.X.Add(new SvgUnit(60f));      // x/y are SvgUnitCollection lists
    label.Y.Add(new SvgUnit(65f));
    label.TextAnchor = SvgTextAnchor.Middle;
    label.FontFamily = "sans-serif";
    label.FontSize = new SvgUnit(14f);
    group.Children.Add(label);

    doc.Write("out.svg");                    // to a file
    using var ms = new MemoryStream();
    doc.Write(ms, useBom: false);            // to a stream
    string xml = doc.GetXML();               // to a string


Example 8: Apply CSS-style declarations programmatically
--------------------------------------------------------
    using System.Linq;
    using CodeBrix.SvgParse;

    var document = SvgDocument.Open("chart.svg");

    foreach (var rect in document.Descendants().OfType<SvgRectangle>())
    {
        // specificity follows CSS rules: higher wins
        rect.AddStyle("fill", "#3366cc", 100);
        rect.AddStyle("stroke-width", "2", 100);
    }

    // Stage everything first, then flush ONCE for the whole subtree.
    document.FlushStyles(true);


Example 9: Named-color serialization
------------------------------------
    using System;
    using CodeBrix.SvgParse;

    // Default: colors are written as hex
    var doc = SvgDocument.FromSvg<SvgDocument>(
        "<svg xmlns='http://www.w3.org/2000/svg'><rect fill='red'/></svg>");
    Console.WriteLine(doc.GetXML());   // ... fill="#ff0000" ...

    // Opt in per document
    doc.EnableEmitNamedColorsOnSerialization = true;
    Console.WriteLine(doc.GetXML());   // ... fill="red" ...

    // Library-wide default for documents created from now on
    SvgDocument.EmitNamedColorsOnSerialization = true;
    var doc2 = SvgDocument.FromSvg<SvgDocument>(
        "<svg xmlns='http://www.w3.org/2000/svg'><rect fill='red'/></svg>");
    // doc2.EnableEmitNamedColorsOnSerialization == true (snapshotted).
    // Documents created BEFORE the static changed are unaffected.


Example 10: Read the animation elements without running them
------------------------------------------------------------
    using System;
    using System.Linq;
    using CodeBrix.SvgParse;

    var doc = SvgDocument.FromSvg<SvgDocument>(@"
        <svg xmlns='http://www.w3.org/2000/svg'>
          <circle id='c' cx='10' cy='10' r='5'>
            <animate attributeName='r' from='5' to='20' dur='2s'
                     repeatCount='indefinite' fill='freeze'/>
          </circle>
        </svg>");

    foreach (var anim in doc.Descendants().OfType<SvgAnimationElement>())
    {
        Console.WriteLine($"{anim.GetType().Name} begin={anim.Begin} dur={anim.Duration} " +
                          $"repeat={anim.RepeatCount} fill={anim.AnimationFill}");

        if (anim is SvgAnimationValueElement v)
        {
            Console.WriteLine($"  {v.AnimationAttributeName}: {v.From} -> {v.To}");
        }
    }

    // Nothing animates on its own. To drive a frame yourself, push a value
    // into the target element by attribute name:
    var circle = doc.GetElementById<SvgCircle>("c");
    circle.TrySetAnimationValue("r", new SvgUnit(12.5f));
    var current = circle.GetAnimationValue("r");
    circle.ClearAnimationValue("r");


================================================================================

MINIMUM VIABLE PROJECT
======================

MySvgTool.csproj
----------------
    <Project Sdk="Microsoft.NET.Sdk">

      <PropertyGroup>
        <OutputType>Exe</OutputType>
        <TargetFramework>net10.0</TargetFramework>
        <Nullable>disable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
      </PropertyGroup>

      <ItemGroup>
        <PackageReference Include="CodeBrix.SvgParse.MsplLicenseForever" Version="*" />
      </ItemGroup>

    </Project>

    (Replace Version="*" with the version you intend to pin.)

Program.cs
----------
    using System;
    using System.Linq;
    using CodeBrix.SvgParse;

    // Keep external entity and image resolution locked down for untrusted input.
    SvgDocument.ResolveExternalXmlEntities = ExternalType.None;
    SvgDocument.ResolveExternalImages = ExternalType.None;
    SvgDocument.ResolveExternalElements = ExternalType.None;

    if (args.Length == 0)
    {
        Console.Error.WriteLine("usage: MySvgTool <file.svg>");
        return 1;
    }

    var doc = SvgDocumentCompatibilityLoader.Open<SvgDocument>(args[0], new SvgOptions());

    Console.WriteLine($"size   : {doc.Width} x {doc.Height}");
    Console.WriteLine($"viewBox: {doc.ViewBox}");

    var counts = doc.Descendants()
                    .GroupBy(e => e.GetType().Name)
                    .OrderByDescending(g => g.Count());

    foreach (var group in counts)
    {
        Console.WriteLine($"{group.Count(),5}  {group.Key}");
    }

    return 0;


================================================================================

PERFORMANCE TIPS
================

1. Parsing is the expensive step. Load an SvgDocument once and query it many
   times; do not re-parse the same SVG text per query.

2. Use GetElementById() / GetElementById<T>() instead of scanning
   Descendants() when you know the id. The document keeps an id index
   (SvgElementIdManager); Descendants() walks the whole tree.

3. For large files, prefer Open<SvgDocument>(stream) over
   FromSvg<SvgDocument>(string) so the file never has to be materialized as
   one big string.

4. Leave ResolveExternalXmlEntities at ExternalType.None (the default). It
   both prevents XXE and removes a class of network/disk access from the
   parse path. Set ResolveExternalImages/ResolveExternalElements to None too
   when the input is untrusted.

5. DeepCopy() copies an entire subtree. Copy the smallest element that gives
   you what you need, and avoid copying inside a loop over a big document.

6. When applying styles programmatically, call AddStyle() for every
   declaration first and then FlushStyles(true) ONCE. Flushing per
   declaration re-resolves the cascade every time.

7. Descendants() is a depth-first enumerator, so chaining .OfType<T>() onto
   it costs one pass. Chaining several independent Descendants() queries
   costs one pass each -- materialize with ToList() if you need several
   views of the same tree.

8. The static Parse helpers (SvgPathBuilder.Parse, SvgTransformConverter.Parse,
   SvgUnitCollectionConverter.Parse, SvgNumberCollectionConverter.Parse)
   take ReadOnlySpan<char>, so slicing an existing string does not allocate
   a substring.


================================================================================

COMMON PITFALLS TO AVOID
========================

1. DO NOT confuse the package id with the namespace.
   Package : CodeBrix.SvgParse.MsplLicenseForever
   Namespace: CodeBrix.SvgParse

2. DO NOT use upstream "Svg." namespaces. Every namespace in this fork is
   CodeBrix.SvgParse[.Sub]. Several members that are public upstream are
   internal here.

3. DO NOT expect a public element.ElementName or element.Attributes.
   SvgElement.ElementName and SvgElement.Attributes are protected internal.
   From a consumer assembly use the CLR type (`is SvgRectangle`,
   `OfType<SvgPath>()`, `GetType().Name`), ContainsAttribute /
   TryGetAttribute for raw attribute strings, CustomAttributes for anything
   the library does not model, and NonSvgElement.Name for foreign-namespace
   tag names.

4. DO NOT write [SvgAttribute("x")] with one argument in your own code --
   that constructor is internal. Use the two-argument form:
   [SvgAttribute("x", SvgNamespaces.SvgNamespace)].

5. DO NOT expect your own [SvgElement("...")] classes to be produced by the
   parser. The element-name table is generated at build time inside this
   package. Unknown SVG-namespace elements become SvgUnknownElement; foreign
   ones become NonSvgElement.

6. DO NOT assume container elements are not visual elements. SvgGroup IS an
   SvgVisualElement (SvgGroup -> SvgMarkerElement -> SvgPathBasedElement ->
   SvgVisualElement). The elements that are NOT SvgVisualElement include
   SvgDefinitionList, SvgClipPath, SvgMask, SvgGradientStop, the paint
   servers, SvgFilter and the filter primitives, the font/glyph elements and
   the animation elements.

7. DO NOT assume SvgText.X and SvgText.Y are SvgUnit. On SvgTextBase, X, Y,
   Dx and Dy are SvgUnitCollection (per-glyph lists) and Rotate is a raw
   string. Use text.X[0] to read, text.X.Add(...) to write.

8. DO NOT treat SvgPointCollection as a list of points. It is a flat
   List<SvgUnit> of x, y, x, y ... values, so Count is twice the vertex
   count.

9. DO NOT look for SvgSkewX / SvgSkewY. The type is SvgSkew(float x, float y);
   skewX(a) is new SvgSkew(a, 0f), skewY(a) is new SvgSkew(0f, a). SvgShear
   also exists and has no SVG-standard equivalent.

10. DO NOT confuse SvgMarker with SvgMarkerElement. SvgMarker is the
    <marker> element and carries RefX/RefY/MarkerWidth/MarkerHeight/
    MarkerUnits/Orient/ViewBox. SvgMarkerElement is the abstract shape base
    that carries MarkerStart/MarkerMid/MarkerEnd.

11. DO NOT confuse the two SvgImage types. CodeBrix.SvgParse.SvgImage is the
    <image> element; CodeBrix.SvgParse.FilterEffects.SvgImage is the
    <feImage> filter primitive. If both usings are in scope you must qualify.

12. DO NOT mis-spell ResolveExternalXmlEntities. The property has the "i" in
    "Entities"; the older upstream spelling does not exist here.

13. DO NOT set Fill or Stroke to an SvgColor. They are SvgPaintServer; wrap
    the color: element.Fill = new SvgColorServer(SvgColor.Red).

14. DO NOT read a url(#id) fill as if it were the target paint server. It
    parses to an SvgDeferredPaintServer. Resolve it with
    SvgDeferredPaintServer.TryGet<T>(shape.Fill, shape) or by calling
    EnsureServer(styleOwner).

15. DO NOT forget SVG attribute inheritance. fill, stroke, font-family and
    most other presentation properties inherit from the parent chain, so a
    property that "looks unset" on a child may be resolved from an ancestor.
    Most of the presentation enums have an explicit Inherit member.

16. DO NOT modify element.Children while enumerating it (or while
    enumerating Descendants()). Snapshot with ToList() first.

17. DO NOT mix SvgUnit types carelessly. SvgUnit equality compares both
    Value AND Type, so new SvgUnit(SvgUnitType.Pixel, 10f) !=
    new SvgUnit(SvgUnitType.User, 10f). Check .Type before comparing or
    arithmetic.

18. DO NOT expect SvgDocument.EmitNamedColorsOnSerialization to affect
    documents that already exist. It is snapshotted into
    EnableEmitNamedColorsOnSerialization at construction time; set the
    instance property to change an already-loaded document.

19. DO NOT use System.Drawing types with this library. Use SvgColor,
    SvgPointF, SvgRectangleF and SvgSizeF; add your own conversion helpers
    at the boundary if your app needs System.Drawing.

20. DO NOT expect SvgColor.Empty and SvgColor.Transparent to be
    distinguishable -- both are packed ARGB 0. Use the SvgPaintServer
    sentinels (None / NotSet / Inherit) when "unset" and "transparent" must
    differ.

21. DO NOT assume `polyline is not SvgPolygon`. SvgPolyline derives from
    SvgPolygon, so a type test for SvgPolygon matches polylines too. Test
    for SvgPolyline first.

22. DO NOT set SvgDocument.BaseUri to a relative Uri. The setter throws
    ArgumentException; it must be absolute.

23. DO NOT enable ResolveExternalImages = Remote (or ResolveExternalElements
    = Remote) for untrusted documents. That permits the parser to reach out
    over the network.

24. DO NOT expect the animation elements to animate. They are parsed and
    re-serialized; the timeline is yours to run, via
    TrySetAnimationValue / GetAnimationValue / ClearAnimationValue.


================================================================================

WHAT THIS PACKAGE DOES NOT DO
=============================

Do NOT reach for this package to:

  - Render or rasterize SVG. Nothing is drawn. (CodeBrix.SkiaSvg is one
    rendering backend built on top of this DOM; other backends can be
    written against it.)
  - Export to PNG, JPEG, PDF, EPS or any other format.
  - Run SVG animations. Animation elements are modeled, never played.
  - Handle interaction. The mouse events on SvgElement are plumbing for a
    host that raises them; there is no hit testing here.
  - Measure text or resolve real fonts. The <font> element family is
    modeled as data; no typeface is loaded and no glyph is shaped.
  - Compute geometry: no bounding boxes, no path flattening, no
    intersection, no transform composition into a matrix.
  - Optimize or minify SVG.
  - Offer a fluent drawing API. You can construct elements programmatically
    (see Example 7), but there is no Canvas/DrawLine-style front end.
  - Let a consumer assembly register new element types with the parser (see
    pitfall 5).
  - Execute <script> content.


================================================================================

WORKING EXAMPLES ON GITHUB
==========================

The CodeBrix.SvgParse.Tests project is the largest body of working,
compiling usage of this package. Browse it here:

    https://github.com/ellisnet/CodeBrix.SvgParse/tree/main/tests/CodeBrix.SvgParse.Tests

Feature-to-test-file map:

  Document parsing and loading (both loaders, SvgOptions, entities)
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgDocumentParsingTests.cs

  Deep copy and cloning of elements and subtrees
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgDeepCopyTests.cs

  The element-name-to-type registration table (uses internal API, but it is
  the authoritative list of element names the parser recognizes)
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgElementFactoryTests.cs

  Element id handling, uniqueness and the id manager
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgElementIdTests.cs

  Generated attribute properties across the element families
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgGeneratedPropertyTests.cs

  Gradients: linear, radial, stops, spread methods, inheritance
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgGradientTests.cs

  Serialization / round-tripping back to SVG text
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgSerializationTests.cs

  Shape elements: rect, circle, ellipse, line, path, polygon, polyline
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgShapeElementTests.cs

  CSS styling, the cascade and specificity
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgStylingTests.cs

  Text elements, tspan and font properties
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgTextTests.cs

  Clipping, masking and filter effects
    https://github.com/ellisnet/CodeBrix.SvgParse/blob/main/tests/CodeBrix.SvgParse.Tests/SvgClippingAndFilterTests.cs

To read one as plain text, swap the host for raw.githubusercontent.com:

    https://raw.githubusercontent.com/ellisnet/CodeBrix.SvgParse/main/tests/CodeBrix.SvgParse.Tests/SvgDocumentParsingTests.cs


================================================================================

QUICK REFERENCE CARD
====================

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
Browser-compatible: SvgDocumentCompatibilityLoader.Open<SvgDocument>(path, options)
                    SvgDocumentCompatibilityLoader.FromSvg<SvgDocument>(svgString)

--- Save ---
To file:            doc.Write("out.svg")
To stream:          doc.Write(stream, useBom: false)
To XmlWriter:       doc.Write(xmlWriter)
To string:          doc.GetXML()      /   element.GetXML()

--- Query ---
By id:              document.GetElementById("id")
By id (typed):      document.GetElementById<SvgCircle>("id")
All descendants:    document.Descendants()
Typed descendants:  document.Descendants().OfType<SvgPath>()
In a child list:    element.Children.FindSvgElementsOf<SvgRectangle>()
Children:           element.Children
Parent:             element.Parent
Parent chain:       element.Parents  /  element.ParentsAndSelf

--- Element facts ---
Type name:          element.GetType().Name    (there is no public ElementName)
Id:                 element.ID
Text content:       element.Content
Raw attribute:      element.TryGetAttribute("data-x", out var v)
Custom attributes:  element.CustomAttributes["mask"]
Mixed nodes:        element.Nodes

--- Presentation (on any SvgElement) ---
Fill / Stroke:      element.Fill, element.Stroke      (SvgPaintServer)
Opacity:            element.Opacity, FillOpacity, StrokeOpacity
Stroke shape:       StrokeWidth, StrokeLineCap, StrokeLineJoin,
                    StrokeMiterLimit, StrokeDashArray, StrokeDashOffset
Font:               FontFamily, FontSize, FontWeight, FontStyle, FontStretch
Text:               TextAnchor, DominantBaseline, TextDecoration,
                    TextTransformation

--- Visual-element only ---
Clip path:          element.ClipPath (Uri)   / ClipRule / Clip
Filter:             element.Filter (Uri)
Visibility:         element.Visible

--- Shapes ---
Rectangle:          X, Y, Width, Height, CornerRadiusX, CornerRadiusY, Location
Circle:             CenterX, CenterY, Radius, Center
Ellipse:            CenterX, CenterY, RadiusX, RadiusY
Line:               StartX, StartY, EndX, EndY
Polygon/Polyline:   Points  (flat SvgUnit list: x, y, x, y, ...)
Path:               PathData (SvgPathSegmentList), PathLength
Markers on shapes:  MarkerStart, MarkerMid, MarkerEnd  (Uri)

--- Text ---
Text/Tspan:         Text, X, Y, Dx, Dy (SvgUnitCollection), Rotate (string),
                    TextLength, LengthAdjust, LetterSpacing, WordSpacing
TextPath:           ReferencedPath, StartOffset, Method, Spacing
TextRef:            ReferencedElement

--- Paint ---
Solid:              new SvgColorServer(SvgColor.Red)
Sentinels:          SvgPaintServer.None / .Inherit / .NotSet
Gradient stops:     gradient.Stops  ->  stop.Offset, stop.GetColor(gradient)
url(#id) fill:      SvgDeferredPaintServer.TryGet<SvgLinearGradientServer>(
                        shape.Fill, shape)

--- Transforms ---
Translate:          new SvgTranslate(x, y)
Rotate:             new SvgRotate(angle) / new SvgRotate(angle, cx, cy)
Scale:              new SvgScale(x) / new SvgScale(x, y)
Skew:               new SvgSkew(angleX, angleY)     // no SvgSkewX/SvgSkewY
Shear:              new SvgShear(x, y)
Matrix:             new SvgMatrix(new List<float> { a, b, c, d, e, f })
Parse:              SvgTransformConverter.Parse("translate(10,20) rotate(45)")

--- Manipulation ---
Deep copy:          element.DeepCopy()  /  element.DeepCopy<T>()
Add child:          element.Children.Add(child)
Add unique-id child: element.Children.AddAndForceUniqueID(child)
Add style:          element.AddStyle(name, value, specificity)
Flush styles:       document.FlushStyles(true)
Walk and mutate:    element.ApplyRecursive(e => { ... })

--- Data types ---
Unit:               new SvgUnit(SvgUnitType.Pixel, 10f)  /  new SvgUnit(10f)
Unit types:         None, Pixel, Em, Ex, Percentage, User, Inch, Centimeter,
                    Millimeter, Pica, Point
Point (units):      new SvgPoint(x, y)
Point (floats):     new SvgPointF(x, y)     (SvgPointF.NaN = omitted control pt)
Rect (floats):      new SvgRectangleF(x, y, width, height)
Size (floats):      new SvgSizeF(width, height)
ViewBox:            new SvgViewBox(minX, minY, width, height)
AspectRatio:        new SvgAspectRatio(SvgPreserveAspectRatio.xMidYMid, slice)
Orient:             new SvgOrient(45f)  /  new SvgOrient(isAuto: true)
Color (named):      SvgColor.Red
Color (hex):        SvgColor.ParseHex("#ff0000")
Color (parse):      SvgColor.Parse("red")  /  SvgColor.TryParse(s, out c)
Color (construct):  SvgColor.FromRgb(r, g, b) / FromRgba / FromArgb

--- Parsing helpers ---
Path data:          SvgPathBuilder.Parse(span)
Transform list:     SvgTransformConverter.Parse(span)
Unit list:          SvgUnitCollectionConverter.Parse(span)
Number list:        SvgNumberCollectionConverter.Parse(span)

--- Security (static, library-wide) ---
XXE prevention:     SvgDocument.ResolveExternalXmlEntities = ExternalType.None
Image loading:      SvgDocument.ResolveExternalImages = ExternalType.Local
Element loading:    SvgDocument.ResolveExternalElements = ExternalType.None
DTD:                SvgDocument.DisableDtdProcessing = true

--- Serialization options ---
Named colors:       SvgDocument.EmitNamedColorsOnSerialization = true  // static
                    doc.EnableEmitNamedColorsOnSerialization = true    // instance
                    // Default false (hex output). The static is snapshotted
                    // into each new document at construction.

Target: .NET 10 or later
License: MS-PL


================================================================================

END OF AGENT-README
