using System;
using CodeBrix.SvgParse.Helpers;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the NumState.</summary>
/// <summary>Defines the NumState enumeration.</summary>
public enum NumState
{
    /// <summary>Gets or sets the Invalid.</summary>
    /// <summary>The Invalid value.</summary>
    Invalid,
    /// <summary>Gets or sets the Separator.</summary>
    /// <summary>The Separator value.</summary>
    Separator,
    /// <summary>Gets or sets the Prefix.</summary>
    /// <summary>The Prefix value.</summary>
    Prefix,
    /// <summary>Gets or sets the Integer.</summary>
    /// <summary>The Integer value.</summary>
    Integer,
    /// <summary>Gets or sets the DecPlace.</summary>
    /// <summary>The DecPlace value.</summary>
    DecPlace,
    /// <summary>Gets or sets the Fraction.</summary>
    /// <summary>The Fraction value.</summary>
    Fraction,
    /// <summary>Gets or sets the Exponent.</summary>
    /// <summary>The Exponent value.</summary>
    Exponent,
    /// <summary>Gets or sets the ExpPrefix.</summary>
    /// <summary>The ExpPrefix value.</summary>
    ExpPrefix,
    /// <summary>Gets or sets the ExpValue.</summary>
    /// <summary>The ExpValue value.</summary>
    ExpValue
}

/// <summary>Gets or sets the CoordinateParserState.</summary>
/// <summary>Represents the <see cref="CoordinateParserState"/> structure.</summary>
public ref struct CoordinateParserState
{
    /// <summary>Gets or sets the CurrNumState.</summary>
    public NumState CurrNumState;
    /// <summary>Gets or sets the NewNumState.</summary>
    public NumState NewNumState;
    /// <summary>Gets or sets the CharsPosition.</summary>
    public int CharsPosition;
    /// <summary>Gets or sets the Position.</summary>
    public int Position;
    /// <summary>Gets or sets the HasMore.</summary>
    public bool HasMore;

    /// <summary>Gets or sets the CoordinateParserState(ref ReadOnlySpan.</summary>
    /// <summary>Initializes a new instance of the <see cref="CoordinateParserState"/> class with the specified parameters.</summary>
    public CoordinateParserState(ref ReadOnlySpan<char> chars)
    {
        CurrNumState = NumState.Separator;
        NewNumState = NumState.Separator;
        CharsPosition = 0;
        Position = 0;
        HasMore = chars.Length > 0;
        if (char.IsLetter(chars[0])) ++CharsPosition;
    }
}

/// <summary>Gets or sets the CoordinateParser.</summary>
/// <summary>Represents the <see cref="CoordinateParser"/> class.</summary>
public static class CoordinateParser
{
    private static bool MarkState(bool hasMode, ref CoordinateParserState state)
    {
        state.HasMore = hasMode;
        ++state.CharsPosition;
        return hasMode;
    }

    /// <summary>Gets or sets the TryGetBool(out bool, ReadOnlySpan.</summary>
    /// <summary>Attempts to perform the TryGetBool(out bool, ReadOnlySpan operation.</summary>
    public static bool TryGetBool(out bool result, ReadOnlySpan<char> chars, ref CoordinateParserState state)
    {
        var charsLength = chars.Length;

        while (state.CharsPosition < charsLength && state.HasMore)
        {
            switch (state.CurrNumState)
            {
                case NumState.Separator:
                    var currentChar = chars[state.CharsPosition];
                    if (IsCoordSeparator(currentChar))
                    {
                        state.NewNumState = NumState.Separator;
                    }
                    else if (currentChar == '0')
                    {
                        result = false;
                        state.NewNumState = NumState.Separator;
                        state.Position = state.CharsPosition + 1;
                        return MarkState(true, ref state);
                    }
                    else if (currentChar == '1')
                    {
                        result = true;
                        state.NewNumState = NumState.Separator;
                        state.Position = state.CharsPosition + 1;
                        return MarkState(true, ref state);
                    }
                    else
                    {
                        result = false;
                        return MarkState(false, ref state);
                    }
                    break;
                default:
                    result = false;
                    return MarkState(false, ref state);
            }
            ++state.CharsPosition;
        }
        result = false;
        return MarkState(false, ref state);
    }

    /// <summary>Gets or sets the TryGetFloat(out float, ReadOnlySpan.</summary>
    /// <summary>Attempts to perform the TryGetFloat(out float, ReadOnlySpan operation.</summary>
    public static bool TryGetFloat(out float result, ReadOnlySpan<char> chars, ref CoordinateParserState state)
    {
        var charsLength = chars.Length;

        while (state.CharsPosition < charsLength && state.HasMore)
        {
            var currentChar = chars[state.CharsPosition];

            switch (state.CurrNumState)
            {
                case NumState.Separator:
                    if (char.IsNumber(currentChar))
                    {
                        state.NewNumState = NumState.Integer;
                    }
                    else if (IsCoordSeparator(currentChar))
                    {
                        state.NewNumState = NumState.Separator;
                    }
                    else
                    {
                        switch (currentChar)
                        {
                            case '.':
                                state.NewNumState = NumState.DecPlace;
                                break;
                            case '+':
                            case '-':
                                state.NewNumState = NumState.Prefix;
                                break;
                            default:
                                state.NewNumState = NumState.Invalid;
                                break;
                        }
                    }
                    break;
                case NumState.Prefix:
                    if (char.IsNumber(currentChar))
                    {
                        state.NewNumState = NumState.Integer;
                    }
                    else if (currentChar == '.')
                    {
                        state.NewNumState = NumState.DecPlace;
                    }
                    else
                    {
                        state.NewNumState = NumState.Invalid;
                    }
                    break;
                case NumState.Integer:
                    if (char.IsNumber(currentChar))
                    {
                        state.NewNumState = NumState.Integer;
                    }
                    else if (IsCoordSeparator(currentChar))
                    {
                        state.NewNumState = NumState.Separator;
                    }
                    else
                    {
                        switch (currentChar)
                        {
                            case '.':
                                state.NewNumState = NumState.DecPlace;
                                break;
                            case 'E':
                            case 'e':
                                state.NewNumState = NumState.Exponent;
                                break;
                            case '+':
                            case '-':
                                state.NewNumState = NumState.Prefix;
                                break;
                            default:
                                state.NewNumState = NumState.Invalid;
                                break;
                        }
                    }
                    break;
                case NumState.DecPlace:
                    if (char.IsNumber(currentChar))
                    {
                        state.NewNumState = NumState.Fraction;
                    }
                    else if (IsCoordSeparator(currentChar))
                    {
                        state.NewNumState = NumState.Separator;
                    }
                    else
                    {
                        switch (currentChar)
                        {
                            case 'E':
                            case 'e':
                                state.NewNumState = NumState.Exponent;
                                break;
                            case '+':
                            case '-':
                                state.NewNumState = NumState.Prefix;
                                break;
                            default:
                                state.NewNumState = NumState.Invalid;
                                break;
                        }
                    }
                    break;
                case NumState.Fraction:
                    if (char.IsNumber(currentChar))
                    {
                        state.NewNumState = NumState.Fraction;
                    }
                    else if (IsCoordSeparator(currentChar))
                    {
                        state.NewNumState = NumState.Separator;
                    }
                    else
                    {
                        switch (currentChar)
                        {
                            case '.':
                                state.NewNumState = NumState.DecPlace;
                                break;
                            case 'E':
                            case 'e':
                                state.NewNumState = NumState.Exponent;
                                break;
                            case '+':
                            case '-':
                                state.NewNumState = NumState.Prefix;
                                break;
                            default:
                                state.NewNumState = NumState.Invalid;
                                break;
                        }
                    }
                    break;
                case NumState.Exponent:
                    if (char.IsNumber(currentChar))
                    {
                        state.NewNumState = NumState.ExpValue;
                    }
                    else if (IsCoordSeparator(currentChar))
                    {
                        state.NewNumState = NumState.Invalid;
                    }
                    else
                    {
                        switch (currentChar)
                        {
                            case '+':
                            case '-':
                                state.NewNumState = NumState.ExpPrefix;
                                break;
                            default:
                                state.NewNumState = NumState.Invalid;
                                break;
                        }
                    }
                    break;
                case NumState.ExpPrefix:
                    if (char.IsNumber(currentChar))
                    {
                        state.NewNumState = NumState.ExpValue;
                    }
                    else
                    {
                        state.NewNumState = NumState.Invalid;
                    }
                    break;
                case NumState.ExpValue:
                    if (char.IsNumber(currentChar))
                    {
                        state.NewNumState = NumState.ExpValue;
                    }
                    else if (IsCoordSeparator(currentChar))
                    {
                        state.NewNumState = NumState.Separator;
                    }
                    else
                    {
                        switch (currentChar)
                        {
                            case '.':
                                state.NewNumState = NumState.DecPlace;
                                break;
                            case '+':
                            case '-':
                                state.NewNumState = NumState.Prefix;
                                break;
                            default:
                                state.NewNumState = NumState.Invalid;
                                break;
                        }
                    }
                    break;
            }

            if (state.CurrNumState != NumState.Separator && state.NewNumState < state.CurrNumState)
            {
                var value = chars.Slice(state.Position, state.CharsPosition - state.Position);
                result = StringParser.ToFloat(value);
                state.Position = state.CharsPosition;
                state.CurrNumState = state.NewNumState;
                return MarkState(true, ref state);
            }
            else if (state.NewNumState != state.CurrNumState && state.CurrNumState == NumState.Separator)
            {
                state.Position = state.CharsPosition;
            }

            if (state.NewNumState == NumState.Invalid)
            {
                result = float.MinValue;
                return MarkState(false, ref state);
            }
            state.CurrNumState = state.NewNumState;
            ++state.CharsPosition;
        }

        if (state.CurrNumState == NumState.Separator || !state.HasMore || state.Position >= charsLength)
        {
            result = float.MinValue;
            return MarkState(false, ref state);
        }
        else
        {
            var value = chars.Slice(state.Position, charsLength - state.Position);
            result = StringParser.ToFloat(value);
            state.Position = charsLength;
            return MarkState(true, ref state);
        }
    }

    private static bool IsCoordSeparator(char value)
    {
        switch (value)
        {
            case ' ':
            case '\t':
            case '\n':
            case '\r':
            case ',':
                return true;
        }
        return false;
    }
}
