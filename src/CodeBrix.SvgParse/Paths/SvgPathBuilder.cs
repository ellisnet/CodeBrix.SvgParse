using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using CodeBrix.SvgParse.Pathing;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the PointFExtensions.</summary>
/// <summary>Represents the <see cref="PointFExtensions"/> class.</summary>
public static class PointFExtensions
{
    /// <summary>Gets or sets the ToSvgString(float).</summary>
    /// <summary>Performs the ToSvgString(float) operation.</summary>
    public static string ToSvgString(this float value)
    {
        // Use G7 format specifier to be compatible across all target frameworks.
        return value.ToString("G7", CultureInfo.InvariantCulture);
    }

    /// <summary>Gets or sets the ToSvgString(SvgPointF).</summary>
    /// <summary>Performs the ToSvgString(SvgPointF) operation.</summary>
    public static string ToSvgString(this SvgPointF p)
    {
        return $"{p.X.ToSvgString()} {p.Y.ToSvgString()}";
    }
}

/// <summary>Gets or sets the SvgPathBuilder.</summary>
/// <summary>Represents the <see cref="SvgPathBuilder"/> class.</summary>
public class SvgPathBuilder : TypeConverter
{
    /// <summary>
    /// Parses the specified string into a collection of path segments.
    /// </summary>
    /// <param name="path">A <see cref="string"/> containing path data.</param>
    public static SvgPathSegmentList Parse(ReadOnlySpan<char> path)
    {
        var segments = new SvgPathSegmentList();

        try
        {
            var pathTrimmed = path.TrimEnd();
            var commandStart = 0;
            var pathLength = pathTrimmed.Length;

            for (var i = 0; i < pathLength; ++i)
            {
                var currentChar = pathTrimmed[i];
                if (char.IsLetter(currentChar) && currentChar != 'e' && currentChar != 'E') // e is used in scientific notiation. but not svg path
                {
                    var start = commandStart;
                    var length = i - commandStart;
                    var command = pathTrimmed.Slice(start, length).Trim();
                    commandStart = i;

                    if (command.Length > 0)
                    {
                        var commandSetTrimmed = pathTrimmed.Slice(start, length).Trim();
                        var state = new CoordinateParserState(ref commandSetTrimmed);
                        CreatePathSegment(commandSetTrimmed[0], segments, ref state, commandSetTrimmed);
                    }

                    if (pathLength == i + 1)
                    {
                        var commandSetTrimmed = pathTrimmed.Slice(i, 1).Trim();
                        var state = new CoordinateParserState(ref commandSetTrimmed);
                        CreatePathSegment(commandSetTrimmed[0], segments, ref state, commandSetTrimmed);
                    }
                }
                else if (pathLength == i + 1)
                {
                    var start = commandStart;
                    var length = i - commandStart + 1;
                    var command = pathTrimmed.Slice(start, length).Trim();

                    if (command.Length > 0)
                    {
                        var commandSetTrimmed = pathTrimmed.Slice(start, length).Trim();
                        var state = new CoordinateParserState(ref commandSetTrimmed);
                        CreatePathSegment(commandSetTrimmed[0], segments, ref state, commandSetTrimmed);
                    }
                }
            }
        }
        catch (Exception exc)
        {
            Trace.TraceError("Error parsing path \"{0}\": {1}", path.ToString(), exc.Message);
        }

        return segments;
    }

    private static void CreatePathSegment(char command, SvgPathSegmentList segments, ref CoordinateParserState state, ReadOnlySpan<char> chars)
    {
        var isRelative = char.IsLower(command);
        // http://www.w3.org/TR/SVG11/paths.html#PathDataGeneralInformation

        switch (command)
        {
            case 'M': // moveto
            case 'm': // relative moveto
                {
                    if (CoordinateParser.TryGetFloat(out var coords0, chars, ref state)
                     && CoordinateParser.TryGetFloat(out var coords1, chars, ref state))
                    {
                        segments.Add(
                            new SvgMoveToSegment(
                                isRelative, new SvgPointF(coords0, coords1)));
                    }
                    while (CoordinateParser.TryGetFloat(out coords0, chars, ref state)
                        && CoordinateParser.TryGetFloat(out coords1, chars, ref state))
                    {
                        segments.Add(
                            new SvgLineSegment(
                                isRelative, new SvgPointF(coords0, coords1)));
                    }
                }
                break;
            case 'A': // elliptical arc
            case 'a': // relative elliptical arc
                {
                    while (CoordinateParser.TryGetFloat(out var coords0, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords1, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords2, chars, ref state)
                        && CoordinateParser.TryGetBool(out var size, chars, ref state)
                        && CoordinateParser.TryGetBool(out var sweep, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords3, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords4, chars, ref state))
                    {
                        // A|a rx ry x-axis-rotation large-arc-flag sweep-flag x y
                        segments.Add(
                            new SvgArcSegment(
                                coords0,
                                coords1,
                                coords2,
                                size ? SvgArcSize.Large : SvgArcSize.Small,
                                sweep ? SvgArcSweep.Positive : SvgArcSweep.Negative,
                                isRelative, new SvgPointF(coords3, coords4)));
                    }
                }
                break;
            case 'L': // lineto
            case 'l': // relative lineto
                {
                    while (CoordinateParser.TryGetFloat(out var coords0, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords1, chars, ref state))
                    {
                        segments.Add(
                            new SvgLineSegment(
                                isRelative, new SvgPointF(coords0, coords1)));
                    }
                }
                break;
            case 'H': // horizontal lineto
            case 'h': // relative horizontal lineto
                {
                    while (CoordinateParser.TryGetFloat(out var coords0, chars, ref state))
                    {
                        segments.Add(
                            new SvgLineSegment(
                                isRelative, new SvgPointF(coords0, float.NaN)));
                    }
                }
                break;
            case 'V': // vertical lineto
            case 'v': // relative vertical lineto
                {
                    while (CoordinateParser.TryGetFloat(out var coords0, chars, ref state))
                    {
                        segments.Add(
                            new SvgLineSegment(
                                isRelative, new SvgPointF(float.NaN, coords0)));
                    }
                }
                break;
            case 'Q': // quadratic bézier curveto
            case 'q': // relative quadratic bézier curveto
                {
                    while (CoordinateParser.TryGetFloat(out var coords0, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords1, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords2, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords3, chars, ref state))
                    {
                        segments.Add(
                            new SvgQuadraticCurveSegment(
                                isRelative,
                                new SvgPointF(coords0, coords1),
                                new SvgPointF(coords2, coords3)));
                    }
                }
                break;
            case 'T': // shorthand/smooth quadratic bézier curveto
            case 't': // relative shorthand/smooth quadratic bézier curveto
                {
                    while (CoordinateParser.TryGetFloat(out var coords0, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords1, chars, ref state))
                    {
                        segments.Add(
                            new SvgQuadraticCurveSegment(
                                isRelative, new SvgPointF(coords0, coords1)));
                    }
                }
                break;
            case 'C': // curveto
            case 'c': // relative curveto
                {
                while (CoordinateParser.TryGetFloat(out var coords0, chars, ref state)
                    && CoordinateParser.TryGetFloat(out var coords1, chars, ref state)
                    && CoordinateParser.TryGetFloat(out var coords2, chars, ref state)
                    && CoordinateParser.TryGetFloat(out var coords3, chars, ref state)
                    && CoordinateParser.TryGetFloat(out var coords4, chars, ref state)
                    && CoordinateParser.TryGetFloat(out var coords5, chars, ref state))
                {
                    segments.Add(
                        new SvgCubicCurveSegment(
                            isRelative,
                            new SvgPointF(coords0, coords1),
                            new SvgPointF(coords2, coords3),
                            new SvgPointF(coords4, coords5)));
                }
                }
                break;
            case 'S': // shorthand/smooth curveto
            case 's': // relative shorthand/smooth curveto
                {
                    while (CoordinateParser.TryGetFloat(out var coords0, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords1, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords2, chars, ref state)
                        && CoordinateParser.TryGetFloat(out var coords3, chars, ref state))
                    {
                        segments.Add(
                            new SvgCubicCurveSegment(
                                isRelative,
                                new SvgPointF(coords0, coords1),
                                new SvgPointF(coords2, coords3)));
                    }
                }
                break;
            case 'Z': // closepath
            case 'z': // relative closepath
                {
                    segments.Add(new SvgClosePathSegment(isRelative));
                }
                break;
        }
    }

    /// <summary>Gets or sets the ConvertFrom(ITypeDescriptorContext, CultureInfo, object).</summary>
    /// <inheritdoc />
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string s)
            return Parse(s.AsSpan());

        return base.ConvertFrom(context, culture, value);
    }
}
