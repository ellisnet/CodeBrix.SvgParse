using System;
using System.Collections.Generic;
using System.Globalization;

namespace CodeBrix.SvgParse;

/// <summary>
/// Represents an 8-bit-per-channel ARGB color. Values are stored as a packed
/// 32-bit integer in <c>0xAARRGGBB</c> form.
/// </summary>
public readonly partial struct SvgColor : IEquatable<SvgColor>
{
    private readonly uint _argb;

    /// <summary>
    /// Represents an <see cref="SvgColor"/> whose packed ARGB value is zero.
    /// This is the sentinel "unset" color, distinct from a transparent color.
    /// </summary>
    public static readonly SvgColor Empty = default;

    private SvgColor(uint argb)
    {
        _argb = argb;
    }

    /// <summary>Gets the alpha component (0-255).</summary>
    public byte A => (byte)((_argb >> 24) & 0xFF);

    /// <summary>Gets the red component (0-255).</summary>
    public byte R => (byte)((_argb >> 16) & 0xFF);

    /// <summary>Gets the green component (0-255).</summary>
    public byte G => (byte)((_argb >> 8) & 0xFF);

    /// <summary>Gets the blue component (0-255).</summary>
    public byte B => (byte)(_argb & 0xFF);

    /// <summary>
    /// Returns <c>true</c> when this color is the default (unset) sentinel value.
    /// </summary>
    public bool IsEmpty => _argb == 0u && Equals(Empty);

    /// <summary>Returns the packed ARGB value as a 32-bit signed integer (for interop).</summary>
    public int ToArgb() => unchecked((int)_argb);

    // ---------- Factory methods ----------

    /// <summary>Gets or sets the FromRgba(byte, byte, byte, byte).</summary>
    /// <summary>Performs the FromRgba(byte, byte, byte, byte) operation.</summary>
    public static SvgColor FromRgba(byte r, byte g, byte b, byte a) =>
        new SvgColor(((uint)a << 24) | ((uint)r << 16) | ((uint)g << 8) | b);

    /// <summary>Gets or sets the FromRgb(byte, byte, byte).</summary>
    /// <summary>Performs the FromRgb(byte, byte, byte) operation.</summary>
    public static SvgColor FromRgb(byte r, byte g, byte b) => FromRgba(r, g, b, 255);

    /// <summary>Gets or sets the FromArgb(int, int, int, int).</summary>
    /// <summary>Performs the FromArgb(int, int, int, int) operation.</summary>
    public static SvgColor FromArgb(int a, int r, int g, int b)
    {
        CheckByte(a, nameof(a));
        CheckByte(r, nameof(r));
        CheckByte(g, nameof(g));
        CheckByte(b, nameof(b));
        return FromRgba((byte)r, (byte)g, (byte)b, (byte)a);
    }

    /// <summary>Gets or sets the FromArgb(int, int, int).</summary>
    /// <summary>Performs the FromArgb(int, int, int) operation.</summary>
    public static SvgColor FromArgb(int r, int g, int b) => FromArgb(255, r, g, b);

    /// <summary>Gets or sets the FromArgb(int).</summary>
    /// <summary>Performs the FromArgb(int) operation.</summary>
    public static SvgColor FromArgb(int argb) => new SvgColor(unchecked((uint)argb));

    /// <summary>Gets or sets the FromArgb(int, SvgColor).</summary>
    /// <summary>Performs the FromArgb(int, SvgColor) operation.</summary>
    public static SvgColor FromArgb(int a, SvgColor baseColor)
    {
        CheckByte(a, nameof(a));
        return FromRgba(baseColor.R, baseColor.G, baseColor.B, (byte)a);
    }

    // ---------- Parsing ----------

    /// <summary>
    /// Parses a hex color string. Accepts <c>#rgb</c>, <c>#rgba</c>, <c>#rrggbb</c>,
    /// and <c>#rrggbbaa</c> forms (with or without leading <c>#</c>).
    /// </summary>
    public static SvgColor ParseHex(string hex)
    {
        if (!TryParseHex(hex, out var color))
            throw new FormatException($"'{hex}' is not a recognized hex color.");
        return color;
    }

    /// <summary>Gets or sets the TryParseHex(string, out SvgColor).</summary>
    /// <summary>Attempts to perform the TryParseHex(string, out SvgColor) operation.</summary>
    public static bool TryParseHex(string hex, out SvgColor result)
    {
        result = default;
        if (string.IsNullOrWhiteSpace(hex)) return false;

        ReadOnlySpan<char> s = hex.AsSpan();
        if (s[0] == '#') s = s.Slice(1);

        byte r, g, b, a = 255;
        switch (s.Length)
        {
            case 3: // #rgb
                if (!TryHexNibble(s[0], out r) || !TryHexNibble(s[1], out g) || !TryHexNibble(s[2], out b))
                    return false;
                r = (byte)(r | (r << 4)); g = (byte)(g | (g << 4)); b = (byte)(b | (b << 4));
                break;
            case 4: // #rgba
                if (!TryHexNibble(s[0], out r) || !TryHexNibble(s[1], out g) ||
                    !TryHexNibble(s[2], out b) || !TryHexNibble(s[3], out a))
                    return false;
                r = (byte)(r | (r << 4)); g = (byte)(g | (g << 4));
                b = (byte)(b | (b << 4)); a = (byte)(a | (a << 4));
                break;
            case 6: // #rrggbb
                if (!TryHexByte(s[0], s[1], out r) || !TryHexByte(s[2], s[3], out g) ||
                    !TryHexByte(s[4], s[5], out b))
                    return false;
                break;
            case 8: // #rrggbbaa
                if (!TryHexByte(s[0], s[1], out r) || !TryHexByte(s[2], s[3], out g) ||
                    !TryHexByte(s[4], s[5], out b) || !TryHexByte(s[6], s[7], out a))
                    return false;
                break;
            default:
                return false;
        }

        result = FromRgba(r, g, b, a);
        return true;
    }

    /// <summary>
    /// Parses a color from either a named color (case-insensitive) or a hex string.
    /// </summary>
    public static SvgColor Parse(string input)
    {
        if (!TryParse(input, out var color))
            throw new FormatException($"'{input}' is not a recognized color.");
        return color;
    }

    /// <summary>Gets or sets the TryParse(string, out SvgColor).</summary>
    /// <summary>Attempts to perform the TryParse(string, out SvgColor) operation.</summary>
    public static bool TryParse(string input, out SvgColor result)
    {
        result = default;
        if (string.IsNullOrWhiteSpace(input)) return false;

        if (NamedColorLookup.TryGetValue(input.Trim(), out result))
            return true;

        return TryParseHex(input, out result);
    }

    /// <summary>
    /// Attempts to look up a color by its case-insensitive W3C/CSS name.
    /// </summary>
    public static bool TryFromName(string name, out SvgColor result)
    {
        if (name == null) { result = default; return false; }
        return NamedColorLookup.TryGetValue(name.Trim(), out result);
    }

    /// <summary>
    /// Returns the W3C/CSS named color matching this color's RGBA value,
    /// or <c>null</c> if no named color matches.
    /// </summary>
    public string GetKnownName()
    {
        NameLookup.TryGetValue(_argb, out var name);
        return name;
    }

    // ---------- Serialization ----------

    /// <summary>
    /// Returns a hex string representation. Alpha is included (as <c>#rrggbbaa</c>)
    /// only when it is less than 255; otherwise returns <c>#rrggbb</c>.
    /// </summary>
    public string ToHex()
    {
        if (A == 255)
            return string.Format(CultureInfo.InvariantCulture, "#{0:x2}{1:x2}{2:x2}", R, G, B);
        return string.Format(CultureInfo.InvariantCulture, "#{0:x2}{1:x2}{2:x2}{3:x2}", R, G, B, A);
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString() => ToHex();

    // ---------- Equality ----------

    /// <summary>Gets or sets the Equals(SvgColor).</summary>
    /// <summary>Performs the Equals(SvgColor) operation.</summary>
    public bool Equals(SvgColor other) => _argb == other._argb;

    /// <summary>Gets or sets the Equals(object).</summary>
    /// <inheritdoc />
    public override bool Equals(object obj) => obj is SvgColor other && Equals(other);

    /// <summary>Gets or sets the GetHashCode().</summary>
    /// <inheritdoc />
    public override int GetHashCode() => _argb.GetHashCode();

    /// <summary>Gets or sets the operator ==(SvgColor, SvgColor).</summary>
    /// <summary>Determines whether two instances are equal.</summary>
    public static bool operator ==(SvgColor left, SvgColor right) => left._argb == right._argb;

    /// <summary>Gets or sets the operator !=(SvgColor, SvgColor).</summary>
    /// <summary>Determines whether two instances are not equal.</summary>
    public static bool operator !=(SvgColor left, SvgColor right) => left._argb != right._argb;

    // ---------- Helpers ----------

    private static void CheckByte(int value, string name)
    {
        if (unchecked((uint)value) > 255)
        {
            throw new ArgumentException(
                $"Value of '{value}' is not valid for '{name}'. '{name}' should be between 0 and 255 inclusive.");
        }
    }

    private static bool TryHexNibble(char c, out byte value)
    {
        if (c >= '0' && c <= '9') { value = (byte)(c - '0'); return true; }
        if (c >= 'a' && c <= 'f') { value = (byte)(c - 'a' + 10); return true; }
        if (c >= 'A' && c <= 'F') { value = (byte)(c - 'A' + 10); return true; }
        value = 0;
        return false;
    }

    private static bool TryHexByte(char hi, char lo, out byte value)
    {
        if (TryHexNibble(hi, out var h) && TryHexNibble(lo, out var l))
        {
            value = (byte)((h << 4) | l);
            return true;
        }
        value = 0;
        return false;
    }
}
