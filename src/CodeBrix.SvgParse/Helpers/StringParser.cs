using System;
using System.Globalization;

namespace CodeBrix.SvgParse.Helpers; //Was previously: namespace Svg.Helpers;

internal static class StringParser
{
    private static readonly CultureInfo Format = CultureInfo.InvariantCulture;

    public static float ToFloat(ReadOnlySpan<char> value)
    {
        return float.Parse(value, NumberStyles.Float, Format);
    }

    public static float ToFloatAny(ReadOnlySpan<char> value)
    {
        return float.Parse(value, NumberStyles.Any, Format);
    }

    public static double ToDouble(ReadOnlySpan<char> value)
    {
        return double.Parse(value, NumberStyles.Any, Format);
    }

    public static int ToInt(ReadOnlySpan<char> value)
    {
        return int.Parse(value, NumberStyles.Integer, Format);
    }
}
