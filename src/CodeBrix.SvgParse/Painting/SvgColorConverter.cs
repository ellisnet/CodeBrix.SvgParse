using System;
using System.ComponentModel;
using System.Globalization;

namespace CodeBrix.SvgParse;

/// <summary>
/// Converts string representations of colors (hex, rgb(), rgba(), hsl(), named) into
/// <see cref="SvgColor"/> values, and back to string form for serialization.
/// </summary>
public class SvgColorConverter : TypeConverter
{
    /// <summary>Gets or sets the CanConvertFrom(ITypeDescriptorContext, Type).</summary>
    /// <inheritdoc />
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        if (sourceType == typeof(string)) return true;
        return base.CanConvertFrom(context, sourceType);
    }

    /// <summary>Gets or sets the CanConvertTo(ITypeDescriptorContext, Type).</summary>
    /// <inheritdoc />
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        if (destinationType == typeof(string)) return true;
        return base.CanConvertTo(context, destinationType);
    }

    /// <summary>Gets or sets the ConvertFrom(ITypeDescriptorContext, CultureInfo, object).</summary>
    /// <inheritdoc />
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string color)
        {
            color = color.Trim();

            // rgb(...) / rgba(...)
            if (color.StartsWith("rgb", StringComparison.InvariantCulture))
            {
                try
                {
                    int start = color.IndexOf("(", StringComparison.InvariantCulture) + 1;
                    string[] values = color
                        .Substring(start, color.IndexOf(")", StringComparison.InvariantCulture) - start)
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // alpha defaults to 255 but may be present as the 4th value (0-1 float)
                    int alphaValue = 255;
                    if (values.Length > 3)
                    {
                        var alphastring = values[3];
                        if (alphastring.StartsWith(".", StringComparison.InvariantCulture))
                            alphastring = "0" + alphastring;

                        var alphaDecimal = decimal.Parse(alphastring, CultureInfo.InvariantCulture);
                        alphaValue = alphaDecimal <= 1
                            ? (int)Math.Round(alphaDecimal * 255)
                            : (int)Math.Round(alphaDecimal);
                    }

                    if (values[0].Trim().EndsWith("%", StringComparison.InvariantCulture))
                    {
                        return SvgColor.FromArgb(
                            alphaValue,
                            (int)Math.Round(255 * float.Parse(values[0].Trim().TrimEnd('%'), NumberStyles.Any, CultureInfo.InvariantCulture) / 100f),
                            (int)Math.Round(255 * float.Parse(values[1].Trim().TrimEnd('%'), NumberStyles.Any, CultureInfo.InvariantCulture) / 100f),
                            (int)Math.Round(255 * float.Parse(values[2].Trim().TrimEnd('%'), NumberStyles.Any, CultureInfo.InvariantCulture) / 100f));
                    }
                    else
                    {
                        return SvgColor.FromArgb(
                            alphaValue,
                            int.Parse(values[0], CultureInfo.InvariantCulture),
                            int.Parse(values[1], CultureInfo.InvariantCulture),
                            int.Parse(values[2], CultureInfo.InvariantCulture));
                    }
                }
                catch
                {
                    throw new SvgException("Color is in an invalid format: '" + color + "'");
                }
            }
            // hsl(...)
            else if (color.StartsWith("hsl", StringComparison.InvariantCulture))
            {
                try
                {
                    int start = color.IndexOf("(", StringComparison.InvariantCulture) + 1;
                    string[] values = color
                        .Substring(start, color.IndexOf(")", StringComparison.InvariantCulture) - start)
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (values[1].EndsWith("%", StringComparison.InvariantCulture))
                        values[1] = values[1].TrimEnd('%');
                    if (values[2].EndsWith("%", StringComparison.InvariantCulture))
                        values[2] = values[2].TrimEnd('%');

                    double h = double.Parse(values[0], CultureInfo.InvariantCulture) / 360.0;
                    double s = double.Parse(values[1], CultureInfo.InvariantCulture) / 100.0;
                    double l = double.Parse(values[2], CultureInfo.InvariantCulture) / 100.0;
                    return Hsl2Rgb(h, s, l);
                }
                catch
                {
                    throw new SvgException("Color is in an invalid format: '" + color + "'");
                }
            }
            // #hex
            else if (color.StartsWith("#", StringComparison.InvariantCulture))
            {
                if (SvgColor.TryParseHex(color, out var hex))
                    return hex;
                return SvgPaintServer.NotSet;
            }

            // Integers are rejected (SVG integer syntax is not supported as a color).
            if (int.TryParse(color, NumberStyles.Integer, CultureInfo.InvariantCulture, out _))
                return SvgPaintServer.NotSet;

            // Named color (case-insensitive). British "grey" variants resolve via the
            // alias entries in SvgColor.NamedColorLookup.
            if (SvgColor.TryFromName(color, out var named))
                return named;

            throw new SvgException("Color is in an invalid format: '" + color + "'");
        }

        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>Gets or sets the ConvertTo(ITypeDescriptorContext, CultureInfo, object, Type).</summary>
    /// <inheritdoc />
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is SvgColor svgColor)
        {
            return ToHtml(svgColor, SvgDocument.EmitNamedColorsOnSerialization);
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }

    /// <summary>
    /// Produces an HTML/CSS color string for the given <see cref="SvgColor"/>.
    /// When <paramref name="useNamedColor"/> is true and the color matches a
    /// W3C/CSS3 named color, the name is returned; otherwise a hex string is returned.
    /// </summary>
    internal static string ToHtml(SvgColor c, bool useNamedColor)
    {
        if (c.IsEmpty) return string.Empty;
        if (useNamedColor)
        {
            var name = c.GetKnownName();
            if (name != null) return name;
        }
        return c.ToHex();
    }

    /// <summary>
    /// Converts HSL color (each component 0..1) to an <see cref="SvgColor"/>.
    /// Based on http://www.geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
    /// </summary>
    private static SvgColor Hsl2Rgb(double h, double sl, double l)
    {
        double r = l, g = l, b = l; // default to gray
        double v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
        if (v > 0)
        {
            double m = l + l - v;
            double sv = (v - m) / v;
            h *= 6.0;
            int sextant = (int)h;
            double fract = h - sextant;
            double vsf = v * sv * fract;
            double mid1 = m + vsf;
            double mid2 = v - vsf;
            switch (sextant)
            {
                case 0: r = v;    g = mid1; b = m;    break;
                case 1: r = mid2; g = v;    b = m;    break;
                case 2: r = m;    g = v;    b = mid1; break;
                case 3: r = m;    g = mid2; b = v;    break;
                case 4: r = mid1; g = m;    b = v;    break;
                case 5: r = v;    g = m;    b = mid2; break;
            }
        }
        return SvgColor.FromArgb(
            (int)Math.Round(r * 255.0),
            (int)Math.Round(g * 255.0),
            (int)Math.Round(b * 255.0));
    }
}
