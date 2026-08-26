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
                if (TryParseRgbFunction(color, out var rgb))
                    return rgb;
                throw new SvgException("Color is in an invalid format: '" + color + "'");
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
    /// Parses the argument list of an <c>rgb()</c> / <c>rgba()</c> function into an
    /// <see cref="SvgColor"/>.
    /// </summary>
    /// <remarks>
    /// Accepts both the CSS Color Level 3 comma form and the CSS Color Level 4 space form
    /// (<c>rgb(r g b / a)</c>). Each channel may be a number (0-255, fractions allowed) or a
    /// percentage; channels may mix the two. The alpha may be a percentage, a 0-1 number, or
    /// (for tolerance of legacy content) a 0-255 number when it is greater than 1. Every value
    /// is clamped to its range rather than rejected, as CSS requires. Percentage alpha is what
    /// LilyPond's SVG backend writes (<c>rgba(0.0000%, 0.0000%, 0.0000%, 100.0000%)</c>), and
    /// before this parser accepted it every such color threw and fell back to black.
    /// </remarks>
    private static bool TryParseRgbFunction(string color, out SvgColor result)
    {
        result = default;
        int open = color.IndexOf('(');
        int close = color.LastIndexOf(')');
        if (open < 0 || close < open)
            return false;

        string[] values = color
            .Substring(open + 1, close - open - 1)
            .Split(new char[] { ',', ' ', '/', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (values.Length != 3 && values.Length != 4)
            return false;

        if (!TryParseChannel(values[0], out int r)
            || !TryParseChannel(values[1], out int g)
            || !TryParseChannel(values[2], out int b))
        {
            return false;
        }

        int a = 255;
        if (values.Length == 4 && !TryParseAlpha(values[3], out a))
            return false;

        result = SvgColor.FromArgb(a, r, g, b);
        return true;
    }

    /// <summary>Parses one rgb() channel: a number on the 0-255 scale or a percentage.</summary>
    private static bool TryParseChannel(string token, out int channel)
    {
        channel = 0;
        if (token.EndsWith("%", StringComparison.InvariantCulture))
        {
            if (!TryParseFloat(token.Substring(0, token.Length - 1), out float percent))
                return false;
            channel = ClampByte(255f * percent / 100f);
            return true;
        }

        if (!TryParseFloat(token, out float number))
            return false;
        channel = ClampByte(number);
        return true;
    }

    /// <summary>
    /// Parses an rgba() alpha: a percentage, a 0-1 number, or a legacy 0-255 number when it
    /// is greater than 1.
    /// </summary>
    private static bool TryParseAlpha(string token, out int alpha)
    {
        alpha = 255;
        if (token.EndsWith("%", StringComparison.InvariantCulture))
        {
            if (!TryParseFloat(token.Substring(0, token.Length - 1), out float percent))
                return false;
            alpha = ClampByte(255f * percent / 100f);
            return true;
        }

        if (!TryParseFloat(token, out float number))
            return false;
        alpha = number <= 1f ? ClampByte(number * 255f) : ClampByte(number);
        return true;
    }

    private static bool TryParseFloat(string token, out float value)
    {
        if (token.StartsWith(".", StringComparison.InvariantCulture))
            token = "0" + token;
        else if (token.StartsWith("-.", StringComparison.InvariantCulture))
            token = "-0" + token.Substring(1);
        return float.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }

    private static int ClampByte(float value)
    {
        if (float.IsNaN(value)) return 0;
        return (int)Math.Round(Math.Min(255f, Math.Max(0f, value)));
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
