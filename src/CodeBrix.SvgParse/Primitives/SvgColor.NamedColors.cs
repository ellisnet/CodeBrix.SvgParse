using System;
using System.Collections.Generic;

namespace CodeBrix.SvgParse;

/// <content>
/// W3C / CSS3 named colors (see https://www.w3.org/TR/css-color-3/).
/// Names are matched case-insensitively.
/// Alias pairs (aqua/cyan, fuchsia/magenta, and *gray/*grey variants) both resolve to
/// the same color value. Reverse lookup (<see cref="SvgColor.GetKnownName"/>) uses a
/// single canonical name per color.
/// </content>
public readonly partial struct SvgColor
{
    /// <summary>Gets or sets the AliceBlue.</summary>
    /// <summary>Gets the AliceBlue value.</summary>
    public static readonly SvgColor AliceBlue            = FromRgb(0xF0, 0xF8, 0xFF);
    /// <summary>Gets or sets the AntiqueWhite.</summary>
    /// <summary>Gets the AntiqueWhite value.</summary>
    public static readonly SvgColor AntiqueWhite         = FromRgb(0xFA, 0xEB, 0xD7);
    /// <summary>Gets or sets the Aqua.</summary>
    /// <summary>Gets the Aqua value.</summary>
    public static readonly SvgColor Aqua                 = FromRgb(0x00, 0xFF, 0xFF);
    /// <summary>Gets or sets the Aquamarine.</summary>
    /// <summary>Gets the Aquamarine value.</summary>
    public static readonly SvgColor Aquamarine           = FromRgb(0x7F, 0xFF, 0xD4);
    /// <summary>Gets or sets the Azure.</summary>
    /// <summary>Gets the Azure value.</summary>
    public static readonly SvgColor Azure                = FromRgb(0xF0, 0xFF, 0xFF);
    /// <summary>Gets or sets the Beige.</summary>
    /// <summary>Gets the Beige value.</summary>
    public static readonly SvgColor Beige                = FromRgb(0xF5, 0xF5, 0xDC);
    /// <summary>Gets or sets the Bisque.</summary>
    /// <summary>Gets the Bisque value.</summary>
    public static readonly SvgColor Bisque               = FromRgb(0xFF, 0xE4, 0xC4);
    /// <summary>Gets or sets the Black.</summary>
    /// <summary>Gets the Black value.</summary>
    public static readonly SvgColor Black                = FromRgb(0x00, 0x00, 0x00);
    /// <summary>Gets or sets the BlanchedAlmond.</summary>
    /// <summary>Gets the BlanchedAlmond value.</summary>
    public static readonly SvgColor BlanchedAlmond       = FromRgb(0xFF, 0xEB, 0xCD);
    /// <summary>Gets or sets the Blue.</summary>
    /// <summary>Gets the Blue value.</summary>
    public static readonly SvgColor Blue                 = FromRgb(0x00, 0x00, 0xFF);
    /// <summary>Gets or sets the BlueViolet.</summary>
    /// <summary>Gets the BlueViolet value.</summary>
    public static readonly SvgColor BlueViolet           = FromRgb(0x8A, 0x2B, 0xE2);
    /// <summary>Gets or sets the Brown.</summary>
    /// <summary>Gets the Brown value.</summary>
    public static readonly SvgColor Brown                = FromRgb(0xA5, 0x2A, 0x2A);
    /// <summary>Gets or sets the BurlyWood.</summary>
    /// <summary>Gets the BurlyWood value.</summary>
    public static readonly SvgColor BurlyWood            = FromRgb(0xDE, 0xB8, 0x87);
    /// <summary>Gets or sets the CadetBlue.</summary>
    /// <summary>Gets the CadetBlue value.</summary>
    public static readonly SvgColor CadetBlue            = FromRgb(0x5F, 0x9E, 0xA0);
    /// <summary>Gets or sets the Chartreuse.</summary>
    /// <summary>Gets the Chartreuse value.</summary>
    public static readonly SvgColor Chartreuse           = FromRgb(0x7F, 0xFF, 0x00);
    /// <summary>Gets or sets the Chocolate.</summary>
    /// <summary>Gets the Chocolate value.</summary>
    public static readonly SvgColor Chocolate            = FromRgb(0xD2, 0x69, 0x1E);
    /// <summary>Gets or sets the Coral.</summary>
    /// <summary>Gets the Coral value.</summary>
    public static readonly SvgColor Coral                = FromRgb(0xFF, 0x7F, 0x50);
    /// <summary>Gets or sets the CornflowerBlue.</summary>
    /// <summary>Gets the CornflowerBlue value.</summary>
    public static readonly SvgColor CornflowerBlue       = FromRgb(0x64, 0x95, 0xED);
    /// <summary>Gets or sets the Cornsilk.</summary>
    /// <summary>Gets the Cornsilk value.</summary>
    public static readonly SvgColor Cornsilk             = FromRgb(0xFF, 0xF8, 0xDC);
    /// <summary>Gets or sets the Crimson.</summary>
    /// <summary>Gets the Crimson value.</summary>
    public static readonly SvgColor Crimson              = FromRgb(0xDC, 0x14, 0x3C);
    /// <summary>Gets or sets the Cyan.</summary>
    /// <summary>Gets the Cyan value.</summary>
    public static readonly SvgColor Cyan                 = FromRgb(0x00, 0xFF, 0xFF);
    /// <summary>Gets or sets the DarkBlue.</summary>
    /// <summary>Gets the DarkBlue value.</summary>
    public static readonly SvgColor DarkBlue             = FromRgb(0x00, 0x00, 0x8B);
    /// <summary>Gets or sets the DarkCyan.</summary>
    /// <summary>Gets the DarkCyan value.</summary>
    public static readonly SvgColor DarkCyan             = FromRgb(0x00, 0x8B, 0x8B);
    /// <summary>Gets or sets the DarkGoldenrod.</summary>
    /// <summary>Gets the DarkGoldenrod value.</summary>
    public static readonly SvgColor DarkGoldenrod        = FromRgb(0xB8, 0x86, 0x0B);
    /// <summary>Gets or sets the DarkGray.</summary>
    /// <summary>Gets the DarkGray value.</summary>
    public static readonly SvgColor DarkGray             = FromRgb(0xA9, 0xA9, 0xA9);
    /// <summary>Gets or sets the DarkGreen.</summary>
    /// <summary>Gets the DarkGreen value.</summary>
    public static readonly SvgColor DarkGreen            = FromRgb(0x00, 0x64, 0x00);
    /// <summary>Gets or sets the DarkKhaki.</summary>
    /// <summary>Gets the DarkKhaki value.</summary>
    public static readonly SvgColor DarkKhaki            = FromRgb(0xBD, 0xB7, 0x6B);
    /// <summary>Gets or sets the DarkMagenta.</summary>
    /// <summary>Gets the DarkMagenta value.</summary>
    public static readonly SvgColor DarkMagenta          = FromRgb(0x8B, 0x00, 0x8B);
    /// <summary>Gets or sets the DarkOliveGreen.</summary>
    /// <summary>Gets the DarkOliveGreen value.</summary>
    public static readonly SvgColor DarkOliveGreen       = FromRgb(0x55, 0x6B, 0x2F);
    /// <summary>Gets or sets the DarkOrange.</summary>
    /// <summary>Gets the DarkOrange value.</summary>
    public static readonly SvgColor DarkOrange           = FromRgb(0xFF, 0x8C, 0x00);
    /// <summary>Gets or sets the DarkOrchid.</summary>
    /// <summary>Gets the DarkOrchid value.</summary>
    public static readonly SvgColor DarkOrchid           = FromRgb(0x99, 0x32, 0xCC);
    /// <summary>Gets or sets the DarkRed.</summary>
    /// <summary>Gets the DarkRed value.</summary>
    public static readonly SvgColor DarkRed              = FromRgb(0x8B, 0x00, 0x00);
    /// <summary>Gets or sets the DarkSalmon.</summary>
    /// <summary>Gets the DarkSalmon value.</summary>
    public static readonly SvgColor DarkSalmon           = FromRgb(0xE9, 0x96, 0x7A);
    /// <summary>Gets or sets the DarkSeaGreen.</summary>
    /// <summary>Gets the DarkSeaGreen value.</summary>
    public static readonly SvgColor DarkSeaGreen         = FromRgb(0x8F, 0xBC, 0x8F);
    /// <summary>Gets or sets the DarkSlateBlue.</summary>
    /// <summary>Gets the DarkSlateBlue value.</summary>
    public static readonly SvgColor DarkSlateBlue        = FromRgb(0x48, 0x3D, 0x8B);
    /// <summary>Gets or sets the DarkSlateGray.</summary>
    /// <summary>Gets the DarkSlateGray value.</summary>
    public static readonly SvgColor DarkSlateGray        = FromRgb(0x2F, 0x4F, 0x4F);
    /// <summary>Gets or sets the DarkTurquoise.</summary>
    /// <summary>Gets the DarkTurquoise value.</summary>
    public static readonly SvgColor DarkTurquoise        = FromRgb(0x00, 0xCE, 0xD1);
    /// <summary>Gets or sets the DarkViolet.</summary>
    /// <summary>Gets the DarkViolet value.</summary>
    public static readonly SvgColor DarkViolet           = FromRgb(0x94, 0x00, 0xD3);
    /// <summary>Gets or sets the DeepPink.</summary>
    /// <summary>Gets the DeepPink value.</summary>
    public static readonly SvgColor DeepPink             = FromRgb(0xFF, 0x14, 0x93);
    /// <summary>Gets or sets the DeepSkyBlue.</summary>
    /// <summary>Gets the DeepSkyBlue value.</summary>
    public static readonly SvgColor DeepSkyBlue          = FromRgb(0x00, 0xBF, 0xFF);
    /// <summary>Gets or sets the DimGray.</summary>
    /// <summary>Gets the DimGray value.</summary>
    public static readonly SvgColor DimGray              = FromRgb(0x69, 0x69, 0x69);
    /// <summary>Gets or sets the DodgerBlue.</summary>
    /// <summary>Gets the DodgerBlue value.</summary>
    public static readonly SvgColor DodgerBlue           = FromRgb(0x1E, 0x90, 0xFF);
    /// <summary>Gets or sets the Firebrick.</summary>
    /// <summary>Gets the Firebrick value.</summary>
    public static readonly SvgColor Firebrick            = FromRgb(0xB2, 0x22, 0x22);
    /// <summary>Gets or sets the FloralWhite.</summary>
    /// <summary>Gets the FloralWhite value.</summary>
    public static readonly SvgColor FloralWhite          = FromRgb(0xFF, 0xFA, 0xF0);
    /// <summary>Gets or sets the ForestGreen.</summary>
    /// <summary>Gets the ForestGreen value.</summary>
    public static readonly SvgColor ForestGreen          = FromRgb(0x22, 0x8B, 0x22);
    /// <summary>Gets or sets the Fuchsia.</summary>
    /// <summary>Gets the Fuchsia value.</summary>
    public static readonly SvgColor Fuchsia              = FromRgb(0xFF, 0x00, 0xFF);
    /// <summary>Gets or sets the Gainsboro.</summary>
    /// <summary>Gets the Gainsboro value.</summary>
    public static readonly SvgColor Gainsboro            = FromRgb(0xDC, 0xDC, 0xDC);
    /// <summary>Gets or sets the GhostWhite.</summary>
    /// <summary>Gets the GhostWhite value.</summary>
    public static readonly SvgColor GhostWhite           = FromRgb(0xF8, 0xF8, 0xFF);
    /// <summary>Gets or sets the Gold.</summary>
    /// <summary>Gets the Gold value.</summary>
    public static readonly SvgColor Gold                 = FromRgb(0xFF, 0xD7, 0x00);
    /// <summary>Gets or sets the Goldenrod.</summary>
    /// <summary>Gets the Goldenrod value.</summary>
    public static readonly SvgColor Goldenrod            = FromRgb(0xDA, 0xA5, 0x20);
    /// <summary>Gets or sets the Gray.</summary>
    /// <summary>Gets the Gray value.</summary>
    public static readonly SvgColor Gray                 = FromRgb(0x80, 0x80, 0x80);
    /// <summary>Gets or sets the Green.</summary>
    /// <summary>Gets the Green value.</summary>
    public static readonly SvgColor Green                = FromRgb(0x00, 0x80, 0x00);
    /// <summary>Gets or sets the GreenYellow.</summary>
    /// <summary>Gets the GreenYellow value.</summary>
    public static readonly SvgColor GreenYellow          = FromRgb(0xAD, 0xFF, 0x2F);
    /// <summary>Gets or sets the Honeydew.</summary>
    /// <summary>Gets the Honeydew value.</summary>
    public static readonly SvgColor Honeydew             = FromRgb(0xF0, 0xFF, 0xF0);
    /// <summary>Gets or sets the HotPink.</summary>
    /// <summary>Gets the HotPink value.</summary>
    public static readonly SvgColor HotPink              = FromRgb(0xFF, 0x69, 0xB4);
    /// <summary>Gets or sets the IndianRed.</summary>
    /// <summary>Gets the IndianRed value.</summary>
    public static readonly SvgColor IndianRed            = FromRgb(0xCD, 0x5C, 0x5C);
    /// <summary>Gets or sets the Indigo.</summary>
    /// <summary>Gets the Indigo value.</summary>
    public static readonly SvgColor Indigo               = FromRgb(0x4B, 0x00, 0x82);
    /// <summary>Gets or sets the Ivory.</summary>
    /// <summary>Gets the Ivory value.</summary>
    public static readonly SvgColor Ivory                = FromRgb(0xFF, 0xFF, 0xF0);
    /// <summary>Gets or sets the Khaki.</summary>
    /// <summary>Gets the Khaki value.</summary>
    public static readonly SvgColor Khaki                = FromRgb(0xF0, 0xE6, 0x8C);
    /// <summary>Gets or sets the Lavender.</summary>
    /// <summary>Gets the Lavender value.</summary>
    public static readonly SvgColor Lavender             = FromRgb(0xE6, 0xE6, 0xFA);
    /// <summary>Gets or sets the LavenderBlush.</summary>
    /// <summary>Gets the LavenderBlush value.</summary>
    public static readonly SvgColor LavenderBlush        = FromRgb(0xFF, 0xF0, 0xF5);
    /// <summary>Gets or sets the LawnGreen.</summary>
    /// <summary>Gets the LawnGreen value.</summary>
    public static readonly SvgColor LawnGreen            = FromRgb(0x7C, 0xFC, 0x00);
    /// <summary>Gets or sets the LemonChiffon.</summary>
    /// <summary>Gets the LemonChiffon value.</summary>
    public static readonly SvgColor LemonChiffon         = FromRgb(0xFF, 0xFA, 0xCD);
    /// <summary>Gets or sets the LightBlue.</summary>
    /// <summary>Gets the LightBlue value.</summary>
    public static readonly SvgColor LightBlue            = FromRgb(0xAD, 0xD8, 0xE6);
    /// <summary>Gets or sets the LightCoral.</summary>
    /// <summary>Gets the LightCoral value.</summary>
    public static readonly SvgColor LightCoral           = FromRgb(0xF0, 0x80, 0x80);
    /// <summary>Gets or sets the LightCyan.</summary>
    /// <summary>Gets the LightCyan value.</summary>
    public static readonly SvgColor LightCyan            = FromRgb(0xE0, 0xFF, 0xFF);
    /// <summary>Gets or sets the LightGoldenrodYellow.</summary>
    /// <summary>Gets the LightGoldenrodYellow value.</summary>
    public static readonly SvgColor LightGoldenrodYellow = FromRgb(0xFA, 0xFA, 0xD2);
    /// <summary>Gets or sets the LightGray.</summary>
    /// <summary>Gets the LightGray value.</summary>
    public static readonly SvgColor LightGray            = FromRgb(0xD3, 0xD3, 0xD3);
    /// <summary>Gets or sets the LightGreen.</summary>
    /// <summary>Gets the LightGreen value.</summary>
    public static readonly SvgColor LightGreen           = FromRgb(0x90, 0xEE, 0x90);
    /// <summary>Gets or sets the LightPink.</summary>
    /// <summary>Gets the LightPink value.</summary>
    public static readonly SvgColor LightPink            = FromRgb(0xFF, 0xB6, 0xC1);
    /// <summary>Gets or sets the LightSalmon.</summary>
    /// <summary>Gets the LightSalmon value.</summary>
    public static readonly SvgColor LightSalmon          = FromRgb(0xFF, 0xA0, 0x7A);
    /// <summary>Gets or sets the LightSeaGreen.</summary>
    /// <summary>Gets the LightSeaGreen value.</summary>
    public static readonly SvgColor LightSeaGreen        = FromRgb(0x20, 0xB2, 0xAA);
    /// <summary>Gets or sets the LightSkyBlue.</summary>
    /// <summary>Gets the LightSkyBlue value.</summary>
    public static readonly SvgColor LightSkyBlue         = FromRgb(0x87, 0xCE, 0xFA);
    /// <summary>Gets or sets the LightSlateGray.</summary>
    /// <summary>Gets the LightSlateGray value.</summary>
    public static readonly SvgColor LightSlateGray       = FromRgb(0x77, 0x88, 0x99);
    /// <summary>Gets or sets the LightSteelBlue.</summary>
    /// <summary>Gets the LightSteelBlue value.</summary>
    public static readonly SvgColor LightSteelBlue       = FromRgb(0xB0, 0xC4, 0xDE);
    /// <summary>Gets or sets the LightYellow.</summary>
    /// <summary>Gets the LightYellow value.</summary>
    public static readonly SvgColor LightYellow          = FromRgb(0xFF, 0xFF, 0xE0);
    /// <summary>Gets or sets the Lime.</summary>
    /// <summary>Gets the Lime value.</summary>
    public static readonly SvgColor Lime                 = FromRgb(0x00, 0xFF, 0x00);
    /// <summary>Gets or sets the LimeGreen.</summary>
    /// <summary>Gets the LimeGreen value.</summary>
    public static readonly SvgColor LimeGreen            = FromRgb(0x32, 0xCD, 0x32);
    /// <summary>Gets or sets the Linen.</summary>
    /// <summary>Gets the Linen value.</summary>
    public static readonly SvgColor Linen                = FromRgb(0xFA, 0xF0, 0xE6);
    /// <summary>Gets or sets the Magenta.</summary>
    /// <summary>Gets the Magenta value.</summary>
    public static readonly SvgColor Magenta              = FromRgb(0xFF, 0x00, 0xFF);
    /// <summary>Gets or sets the Maroon.</summary>
    /// <summary>Gets the Maroon value.</summary>
    public static readonly SvgColor Maroon               = FromRgb(0x80, 0x00, 0x00);
    /// <summary>Gets or sets the MediumAquamarine.</summary>
    /// <summary>Gets the MediumAquamarine value.</summary>
    public static readonly SvgColor MediumAquamarine     = FromRgb(0x66, 0xCD, 0xAA);
    /// <summary>Gets or sets the MediumBlue.</summary>
    /// <summary>Gets the MediumBlue value.</summary>
    public static readonly SvgColor MediumBlue           = FromRgb(0x00, 0x00, 0xCD);
    /// <summary>Gets or sets the MediumOrchid.</summary>
    /// <summary>Gets the MediumOrchid value.</summary>
    public static readonly SvgColor MediumOrchid         = FromRgb(0xBA, 0x55, 0xD3);
    /// <summary>Gets or sets the MediumPurple.</summary>
    /// <summary>Gets the MediumPurple value.</summary>
    public static readonly SvgColor MediumPurple         = FromRgb(0x93, 0x70, 0xDB);
    /// <summary>Gets or sets the MediumSeaGreen.</summary>
    /// <summary>Gets the MediumSeaGreen value.</summary>
    public static readonly SvgColor MediumSeaGreen       = FromRgb(0x3C, 0xB3, 0x71);
    /// <summary>Gets or sets the MediumSlateBlue.</summary>
    /// <summary>Gets the MediumSlateBlue value.</summary>
    public static readonly SvgColor MediumSlateBlue      = FromRgb(0x7B, 0x68, 0xEE);
    /// <summary>Gets or sets the MediumSpringGreen.</summary>
    /// <summary>Gets the MediumSpringGreen value.</summary>
    public static readonly SvgColor MediumSpringGreen    = FromRgb(0x00, 0xFA, 0x9A);
    /// <summary>Gets or sets the MediumTurquoise.</summary>
    /// <summary>Gets the MediumTurquoise value.</summary>
    public static readonly SvgColor MediumTurquoise      = FromRgb(0x48, 0xD1, 0xCC);
    /// <summary>Gets or sets the MediumVioletRed.</summary>
    /// <summary>Gets the MediumVioletRed value.</summary>
    public static readonly SvgColor MediumVioletRed      = FromRgb(0xC7, 0x15, 0x85);
    /// <summary>Gets or sets the MidnightBlue.</summary>
    /// <summary>Gets the MidnightBlue value.</summary>
    public static readonly SvgColor MidnightBlue         = FromRgb(0x19, 0x19, 0x70);
    /// <summary>Gets or sets the MintCream.</summary>
    /// <summary>Gets the MintCream value.</summary>
    public static readonly SvgColor MintCream            = FromRgb(0xF5, 0xFF, 0xFA);
    /// <summary>Gets or sets the MistyRose.</summary>
    /// <summary>Gets the MistyRose value.</summary>
    public static readonly SvgColor MistyRose            = FromRgb(0xFF, 0xE4, 0xE1);
    /// <summary>Gets or sets the Moccasin.</summary>
    /// <summary>Gets the Moccasin value.</summary>
    public static readonly SvgColor Moccasin             = FromRgb(0xFF, 0xE4, 0xB5);
    /// <summary>Gets or sets the NavajoWhite.</summary>
    /// <summary>Gets the NavajoWhite value.</summary>
    public static readonly SvgColor NavajoWhite          = FromRgb(0xFF, 0xDE, 0xAD);
    /// <summary>Gets or sets the Navy.</summary>
    /// <summary>Gets the Navy value.</summary>
    public static readonly SvgColor Navy                 = FromRgb(0x00, 0x00, 0x80);
    /// <summary>Gets or sets the OldLace.</summary>
    /// <summary>Gets the OldLace value.</summary>
    public static readonly SvgColor OldLace              = FromRgb(0xFD, 0xF5, 0xE6);
    /// <summary>Gets or sets the Olive.</summary>
    /// <summary>Gets the Olive value.</summary>
    public static readonly SvgColor Olive                = FromRgb(0x80, 0x80, 0x00);
    /// <summary>Gets or sets the OliveDrab.</summary>
    /// <summary>Gets the OliveDrab value.</summary>
    public static readonly SvgColor OliveDrab            = FromRgb(0x6B, 0x8E, 0x23);
    /// <summary>Gets or sets the Orange.</summary>
    /// <summary>Gets the Orange value.</summary>
    public static readonly SvgColor Orange               = FromRgb(0xFF, 0xA5, 0x00);
    /// <summary>Gets or sets the OrangeRed.</summary>
    /// <summary>Gets the OrangeRed value.</summary>
    public static readonly SvgColor OrangeRed            = FromRgb(0xFF, 0x45, 0x00);
    /// <summary>Gets or sets the Orchid.</summary>
    /// <summary>Gets the Orchid value.</summary>
    public static readonly SvgColor Orchid               = FromRgb(0xDA, 0x70, 0xD6);
    /// <summary>Gets or sets the PaleGoldenrod.</summary>
    /// <summary>Gets the PaleGoldenrod value.</summary>
    public static readonly SvgColor PaleGoldenrod        = FromRgb(0xEE, 0xE8, 0xAA);
    /// <summary>Gets or sets the PaleGreen.</summary>
    /// <summary>Gets the PaleGreen value.</summary>
    public static readonly SvgColor PaleGreen            = FromRgb(0x98, 0xFB, 0x98);
    /// <summary>Gets or sets the PaleTurquoise.</summary>
    /// <summary>Gets the PaleTurquoise value.</summary>
    public static readonly SvgColor PaleTurquoise        = FromRgb(0xAF, 0xEE, 0xEE);
    /// <summary>Gets or sets the PaleVioletRed.</summary>
    /// <summary>Gets the PaleVioletRed value.</summary>
    public static readonly SvgColor PaleVioletRed        = FromRgb(0xDB, 0x70, 0x93);
    /// <summary>Gets or sets the PapayaWhip.</summary>
    /// <summary>Gets the PapayaWhip value.</summary>
    public static readonly SvgColor PapayaWhip           = FromRgb(0xFF, 0xEF, 0xD5);
    /// <summary>Gets or sets the PeachPuff.</summary>
    /// <summary>Gets the PeachPuff value.</summary>
    public static readonly SvgColor PeachPuff            = FromRgb(0xFF, 0xDA, 0xB9);
    /// <summary>Gets or sets the Peru.</summary>
    /// <summary>Gets the Peru value.</summary>
    public static readonly SvgColor Peru                 = FromRgb(0xCD, 0x85, 0x3F);
    /// <summary>Gets or sets the Pink.</summary>
    /// <summary>Gets the Pink value.</summary>
    public static readonly SvgColor Pink                 = FromRgb(0xFF, 0xC0, 0xCB);
    /// <summary>Gets or sets the Plum.</summary>
    /// <summary>Gets the Plum value.</summary>
    public static readonly SvgColor Plum                 = FromRgb(0xDD, 0xA0, 0xDD);
    /// <summary>Gets or sets the PowderBlue.</summary>
    /// <summary>Gets the PowderBlue value.</summary>
    public static readonly SvgColor PowderBlue           = FromRgb(0xB0, 0xE0, 0xE6);
    /// <summary>Gets or sets the Purple.</summary>
    /// <summary>Gets the Purple value.</summary>
    public static readonly SvgColor Purple               = FromRgb(0x80, 0x00, 0x80);
    /// <summary>Gets or sets the RebeccaPurple.</summary>
    /// <summary>Gets the RebeccaPurple value.</summary>
    public static readonly SvgColor RebeccaPurple        = FromRgb(0x66, 0x33, 0x99);
    /// <summary>Gets or sets the Red.</summary>
    /// <summary>Gets the Red value.</summary>
    public static readonly SvgColor Red                  = FromRgb(0xFF, 0x00, 0x00);
    /// <summary>Gets or sets the RosyBrown.</summary>
    /// <summary>Gets the RosyBrown value.</summary>
    public static readonly SvgColor RosyBrown            = FromRgb(0xBC, 0x8F, 0x8F);
    /// <summary>Gets or sets the RoyalBlue.</summary>
    /// <summary>Gets the RoyalBlue value.</summary>
    public static readonly SvgColor RoyalBlue            = FromRgb(0x41, 0x69, 0xE1);
    /// <summary>Gets or sets the SaddleBrown.</summary>
    /// <summary>Gets the SaddleBrown value.</summary>
    public static readonly SvgColor SaddleBrown          = FromRgb(0x8B, 0x45, 0x13);
    /// <summary>Gets or sets the Salmon.</summary>
    /// <summary>Gets the Salmon value.</summary>
    public static readonly SvgColor Salmon               = FromRgb(0xFA, 0x80, 0x72);
    /// <summary>Gets or sets the SandyBrown.</summary>
    /// <summary>Gets the SandyBrown value.</summary>
    public static readonly SvgColor SandyBrown           = FromRgb(0xF4, 0xA4, 0x60);
    /// <summary>Gets or sets the SeaGreen.</summary>
    /// <summary>Gets the SeaGreen value.</summary>
    public static readonly SvgColor SeaGreen             = FromRgb(0x2E, 0x8B, 0x57);
    /// <summary>Gets or sets the SeaShell.</summary>
    /// <summary>Gets the SeaShell value.</summary>
    public static readonly SvgColor SeaShell             = FromRgb(0xFF, 0xF5, 0xEE);
    /// <summary>Gets or sets the Sienna.</summary>
    /// <summary>Gets the Sienna value.</summary>
    public static readonly SvgColor Sienna               = FromRgb(0xA0, 0x52, 0x2D);
    /// <summary>Gets or sets the Silver.</summary>
    /// <summary>Gets the Silver value.</summary>
    public static readonly SvgColor Silver               = FromRgb(0xC0, 0xC0, 0xC0);
    /// <summary>Gets or sets the SkyBlue.</summary>
    /// <summary>Gets the SkyBlue value.</summary>
    public static readonly SvgColor SkyBlue              = FromRgb(0x87, 0xCE, 0xEB);
    /// <summary>Gets or sets the SlateBlue.</summary>
    /// <summary>Gets the SlateBlue value.</summary>
    public static readonly SvgColor SlateBlue            = FromRgb(0x6A, 0x5A, 0xCD);
    /// <summary>Gets or sets the SlateGray.</summary>
    /// <summary>Gets the SlateGray value.</summary>
    public static readonly SvgColor SlateGray            = FromRgb(0x70, 0x80, 0x90);
    /// <summary>Gets or sets the Snow.</summary>
    /// <summary>Gets the Snow value.</summary>
    public static readonly SvgColor Snow                 = FromRgb(0xFF, 0xFA, 0xFA);
    /// <summary>Gets or sets the SpringGreen.</summary>
    /// <summary>Gets the SpringGreen value.</summary>
    public static readonly SvgColor SpringGreen          = FromRgb(0x00, 0xFF, 0x7F);
    /// <summary>Gets or sets the SteelBlue.</summary>
    /// <summary>Gets the SteelBlue value.</summary>
    public static readonly SvgColor SteelBlue            = FromRgb(0x46, 0x82, 0xB4);
    /// <summary>Gets or sets the Tan.</summary>
    /// <summary>Gets the Tan value.</summary>
    public static readonly SvgColor Tan                  = FromRgb(0xD2, 0xB4, 0x8C);
    /// <summary>Gets or sets the Teal.</summary>
    /// <summary>Gets the Teal value.</summary>
    public static readonly SvgColor Teal                 = FromRgb(0x00, 0x80, 0x80);
    /// <summary>Gets or sets the Thistle.</summary>
    /// <summary>Gets the Thistle value.</summary>
    public static readonly SvgColor Thistle              = FromRgb(0xD8, 0xBF, 0xD8);
    /// <summary>Gets or sets the Tomato.</summary>
    /// <summary>Gets the Tomato value.</summary>
    public static readonly SvgColor Tomato               = FromRgb(0xFF, 0x63, 0x47);
    /// <summary>Gets or sets the Transparent.</summary>
    /// <summary>Gets the Transparent value.</summary>
    public static readonly SvgColor Transparent          = FromRgba(0x00, 0x00, 0x00, 0x00);
    /// <summary>Gets or sets the Turquoise.</summary>
    /// <summary>Gets the Turquoise value.</summary>
    public static readonly SvgColor Turquoise            = FromRgb(0x40, 0xE0, 0xD0);
    /// <summary>Gets or sets the Violet.</summary>
    /// <summary>Gets the Violet value.</summary>
    public static readonly SvgColor Violet               = FromRgb(0xEE, 0x82, 0xEE);
    /// <summary>Gets or sets the Wheat.</summary>
    /// <summary>Gets the Wheat value.</summary>
    public static readonly SvgColor Wheat                = FromRgb(0xF5, 0xDE, 0xB3);
    /// <summary>Gets or sets the White.</summary>
    /// <summary>Gets the White value.</summary>
    public static readonly SvgColor White                = FromRgb(0xFF, 0xFF, 0xFF);
    /// <summary>Gets or sets the WhiteSmoke.</summary>
    /// <summary>Gets the WhiteSmoke value.</summary>
    public static readonly SvgColor WhiteSmoke           = FromRgb(0xF5, 0xF5, 0xF5);
    /// <summary>Gets or sets the Yellow.</summary>
    /// <summary>Gets the Yellow value.</summary>
    public static readonly SvgColor Yellow               = FromRgb(0xFF, 0xFF, 0x00);
    /// <summary>Gets or sets the YellowGreen.</summary>
    /// <summary>Gets the YellowGreen value.</summary>
    public static readonly SvgColor YellowGreen          = FromRgb(0x9A, 0xCD, 0x32);

    /// <summary>
    /// Case-insensitive name → <see cref="SvgColor"/> lookup. Includes both
    /// American and British spellings of the gray/grey variants, plus the
    /// aqua/cyan and fuchsia/magenta aliases.
    /// </summary>
    private static readonly IReadOnlyDictionary<string, SvgColor> NamedColorLookup
        = BuildNamedColorLookup();

    /// <summary>
    /// Reverse lookup: packed ARGB → canonical lowercase name. Used by
    /// <see cref="SvgColor.GetKnownName"/> and the named-color serialization path.
    /// </summary>
    private static readonly IReadOnlyDictionary<uint, string> NameLookup
        = BuildNameLookup();

    private static Dictionary<string, SvgColor> BuildNamedColorLookup()
    {
        var d = new Dictionary<string, SvgColor>(StringComparer.OrdinalIgnoreCase)
        {
            ["aliceblue"] = AliceBlue,
            ["antiquewhite"] = AntiqueWhite,
            ["aqua"] = Aqua,
            ["aquamarine"] = Aquamarine,
            ["azure"] = Azure,
            ["beige"] = Beige,
            ["bisque"] = Bisque,
            ["black"] = Black,
            ["blanchedalmond"] = BlanchedAlmond,
            ["blue"] = Blue,
            ["blueviolet"] = BlueViolet,
            ["brown"] = Brown,
            ["burlywood"] = BurlyWood,
            ["cadetblue"] = CadetBlue,
            ["chartreuse"] = Chartreuse,
            ["chocolate"] = Chocolate,
            ["coral"] = Coral,
            ["cornflowerblue"] = CornflowerBlue,
            ["cornsilk"] = Cornsilk,
            ["crimson"] = Crimson,
            ["cyan"] = Cyan,
            ["darkblue"] = DarkBlue,
            ["darkcyan"] = DarkCyan,
            ["darkgoldenrod"] = DarkGoldenrod,
            ["darkgray"] = DarkGray,
            ["darkgrey"] = DarkGray,
            ["darkgreen"] = DarkGreen,
            ["darkkhaki"] = DarkKhaki,
            ["darkmagenta"] = DarkMagenta,
            ["darkolivegreen"] = DarkOliveGreen,
            ["darkorange"] = DarkOrange,
            ["darkorchid"] = DarkOrchid,
            ["darkred"] = DarkRed,
            ["darksalmon"] = DarkSalmon,
            ["darkseagreen"] = DarkSeaGreen,
            ["darkslateblue"] = DarkSlateBlue,
            ["darkslategray"] = DarkSlateGray,
            ["darkslategrey"] = DarkSlateGray,
            ["darkturquoise"] = DarkTurquoise,
            ["darkviolet"] = DarkViolet,
            ["deeppink"] = DeepPink,
            ["deepskyblue"] = DeepSkyBlue,
            ["dimgray"] = DimGray,
            ["dimgrey"] = DimGray,
            ["dodgerblue"] = DodgerBlue,
            ["firebrick"] = Firebrick,
            ["floralwhite"] = FloralWhite,
            ["forestgreen"] = ForestGreen,
            ["fuchsia"] = Fuchsia,
            ["gainsboro"] = Gainsboro,
            ["ghostwhite"] = GhostWhite,
            ["gold"] = Gold,
            ["goldenrod"] = Goldenrod,
            ["gray"] = Gray,
            ["grey"] = Gray,
            ["green"] = Green,
            ["greenyellow"] = GreenYellow,
            ["honeydew"] = Honeydew,
            ["hotpink"] = HotPink,
            ["indianred"] = IndianRed,
            ["indigo"] = Indigo,
            ["ivory"] = Ivory,
            ["khaki"] = Khaki,
            ["lavender"] = Lavender,
            ["lavenderblush"] = LavenderBlush,
            ["lawngreen"] = LawnGreen,
            ["lemonchiffon"] = LemonChiffon,
            ["lightblue"] = LightBlue,
            ["lightcoral"] = LightCoral,
            ["lightcyan"] = LightCyan,
            ["lightgoldenrodyellow"] = LightGoldenrodYellow,
            ["lightgray"] = LightGray,
            ["lightgrey"] = LightGray,
            ["lightgreen"] = LightGreen,
            ["lightpink"] = LightPink,
            ["lightsalmon"] = LightSalmon,
            ["lightseagreen"] = LightSeaGreen,
            ["lightskyblue"] = LightSkyBlue,
            ["lightslategray"] = LightSlateGray,
            ["lightslategrey"] = LightSlateGray,
            ["lightsteelblue"] = LightSteelBlue,
            ["lightyellow"] = LightYellow,
            ["lime"] = Lime,
            ["limegreen"] = LimeGreen,
            ["linen"] = Linen,
            ["magenta"] = Magenta,
            ["maroon"] = Maroon,
            ["mediumaquamarine"] = MediumAquamarine,
            ["mediumblue"] = MediumBlue,
            ["mediumorchid"] = MediumOrchid,
            ["mediumpurple"] = MediumPurple,
            ["mediumseagreen"] = MediumSeaGreen,
            ["mediumslateblue"] = MediumSlateBlue,
            ["mediumspringgreen"] = MediumSpringGreen,
            ["mediumturquoise"] = MediumTurquoise,
            ["mediumvioletred"] = MediumVioletRed,
            ["midnightblue"] = MidnightBlue,
            ["mintcream"] = MintCream,
            ["mistyrose"] = MistyRose,
            ["moccasin"] = Moccasin,
            ["navajowhite"] = NavajoWhite,
            ["navy"] = Navy,
            ["oldlace"] = OldLace,
            ["olive"] = Olive,
            ["olivedrab"] = OliveDrab,
            ["orange"] = Orange,
            ["orangered"] = OrangeRed,
            ["orchid"] = Orchid,
            ["palegoldenrod"] = PaleGoldenrod,
            ["palegreen"] = PaleGreen,
            ["paleturquoise"] = PaleTurquoise,
            ["palevioletred"] = PaleVioletRed,
            ["papayawhip"] = PapayaWhip,
            ["peachpuff"] = PeachPuff,
            ["peru"] = Peru,
            ["pink"] = Pink,
            ["plum"] = Plum,
            ["powderblue"] = PowderBlue,
            ["purple"] = Purple,
            ["rebeccapurple"] = RebeccaPurple,
            ["red"] = Red,
            ["rosybrown"] = RosyBrown,
            ["royalblue"] = RoyalBlue,
            ["saddlebrown"] = SaddleBrown,
            ["salmon"] = Salmon,
            ["sandybrown"] = SandyBrown,
            ["seagreen"] = SeaGreen,
            ["seashell"] = SeaShell,
            ["sienna"] = Sienna,
            ["silver"] = Silver,
            ["skyblue"] = SkyBlue,
            ["slateblue"] = SlateBlue,
            ["slategray"] = SlateGray,
            ["slategrey"] = SlateGray,
            ["snow"] = Snow,
            ["springgreen"] = SpringGreen,
            ["steelblue"] = SteelBlue,
            ["tan"] = Tan,
            ["teal"] = Teal,
            ["thistle"] = Thistle,
            ["tomato"] = Tomato,
            ["transparent"] = Transparent,
            ["turquoise"] = Turquoise,
            ["violet"] = Violet,
            ["wheat"] = Wheat,
            ["white"] = White,
            ["whitesmoke"] = WhiteSmoke,
            ["yellow"] = Yellow,
            ["yellowgreen"] = YellowGreen,
        };
        return d;
    }

    private static Dictionary<uint, string> BuildNameLookup()
    {
        // Canonical names for the reverse lookup. We pick one name per ARGB value:
        // - "cyan" for #00FFFF (also known as aqua)
        // - "magenta" for #FF00FF (also known as fuchsia)
        // - American "gray" forms, not "grey"
        return new Dictionary<uint, string>
        {
            [(uint)AliceBlue.ToArgb()] = "aliceblue",
            [(uint)AntiqueWhite.ToArgb()] = "antiquewhite",
            [(uint)Aquamarine.ToArgb()] = "aquamarine",
            [(uint)Azure.ToArgb()] = "azure",
            [(uint)Beige.ToArgb()] = "beige",
            [(uint)Bisque.ToArgb()] = "bisque",
            [(uint)Black.ToArgb()] = "black",
            [(uint)BlanchedAlmond.ToArgb()] = "blanchedalmond",
            [(uint)Blue.ToArgb()] = "blue",
            [(uint)BlueViolet.ToArgb()] = "blueviolet",
            [(uint)Brown.ToArgb()] = "brown",
            [(uint)BurlyWood.ToArgb()] = "burlywood",
            [(uint)CadetBlue.ToArgb()] = "cadetblue",
            [(uint)Chartreuse.ToArgb()] = "chartreuse",
            [(uint)Chocolate.ToArgb()] = "chocolate",
            [(uint)Coral.ToArgb()] = "coral",
            [(uint)CornflowerBlue.ToArgb()] = "cornflowerblue",
            [(uint)Cornsilk.ToArgb()] = "cornsilk",
            [(uint)Crimson.ToArgb()] = "crimson",
            [(uint)Cyan.ToArgb()] = "cyan", // also aqua
            [(uint)DarkBlue.ToArgb()] = "darkblue",
            [(uint)DarkCyan.ToArgb()] = "darkcyan",
            [(uint)DarkGoldenrod.ToArgb()] = "darkgoldenrod",
            [(uint)DarkGray.ToArgb()] = "darkgray",
            [(uint)DarkGreen.ToArgb()] = "darkgreen",
            [(uint)DarkKhaki.ToArgb()] = "darkkhaki",
            [(uint)DarkMagenta.ToArgb()] = "darkmagenta",
            [(uint)DarkOliveGreen.ToArgb()] = "darkolivegreen",
            [(uint)DarkOrange.ToArgb()] = "darkorange",
            [(uint)DarkOrchid.ToArgb()] = "darkorchid",
            [(uint)DarkRed.ToArgb()] = "darkred",
            [(uint)DarkSalmon.ToArgb()] = "darksalmon",
            [(uint)DarkSeaGreen.ToArgb()] = "darkseagreen",
            [(uint)DarkSlateBlue.ToArgb()] = "darkslateblue",
            [(uint)DarkSlateGray.ToArgb()] = "darkslategray",
            [(uint)DarkTurquoise.ToArgb()] = "darkturquoise",
            [(uint)DarkViolet.ToArgb()] = "darkviolet",
            [(uint)DeepPink.ToArgb()] = "deeppink",
            [(uint)DeepSkyBlue.ToArgb()] = "deepskyblue",
            [(uint)DimGray.ToArgb()] = "dimgray",
            [(uint)DodgerBlue.ToArgb()] = "dodgerblue",
            [(uint)Firebrick.ToArgb()] = "firebrick",
            [(uint)FloralWhite.ToArgb()] = "floralwhite",
            [(uint)ForestGreen.ToArgb()] = "forestgreen",
            [(uint)Fuchsia.ToArgb()] = "fuchsia", // also magenta
            [(uint)Gainsboro.ToArgb()] = "gainsboro",
            [(uint)GhostWhite.ToArgb()] = "ghostwhite",
            [(uint)Gold.ToArgb()] = "gold",
            [(uint)Goldenrod.ToArgb()] = "goldenrod",
            [(uint)Gray.ToArgb()] = "gray",
            [(uint)Green.ToArgb()] = "green",
            [(uint)GreenYellow.ToArgb()] = "greenyellow",
            [(uint)Honeydew.ToArgb()] = "honeydew",
            [(uint)HotPink.ToArgb()] = "hotpink",
            [(uint)IndianRed.ToArgb()] = "indianred",
            [(uint)Indigo.ToArgb()] = "indigo",
            [(uint)Ivory.ToArgb()] = "ivory",
            [(uint)Khaki.ToArgb()] = "khaki",
            [(uint)Lavender.ToArgb()] = "lavender",
            [(uint)LavenderBlush.ToArgb()] = "lavenderblush",
            [(uint)LawnGreen.ToArgb()] = "lawngreen",
            [(uint)LemonChiffon.ToArgb()] = "lemonchiffon",
            [(uint)LightBlue.ToArgb()] = "lightblue",
            [(uint)LightCoral.ToArgb()] = "lightcoral",
            [(uint)LightCyan.ToArgb()] = "lightcyan",
            [(uint)LightGoldenrodYellow.ToArgb()] = "lightgoldenrodyellow",
            [(uint)LightGray.ToArgb()] = "lightgray",
            [(uint)LightGreen.ToArgb()] = "lightgreen",
            [(uint)LightPink.ToArgb()] = "lightpink",
            [(uint)LightSalmon.ToArgb()] = "lightsalmon",
            [(uint)LightSeaGreen.ToArgb()] = "lightseagreen",
            [(uint)LightSkyBlue.ToArgb()] = "lightskyblue",
            [(uint)LightSlateGray.ToArgb()] = "lightslategray",
            [(uint)LightSteelBlue.ToArgb()] = "lightsteelblue",
            [(uint)LightYellow.ToArgb()] = "lightyellow",
            [(uint)Lime.ToArgb()] = "lime",
            [(uint)LimeGreen.ToArgb()] = "limegreen",
            [(uint)Linen.ToArgb()] = "linen",
            [(uint)Maroon.ToArgb()] = "maroon",
            [(uint)MediumAquamarine.ToArgb()] = "mediumaquamarine",
            [(uint)MediumBlue.ToArgb()] = "mediumblue",
            [(uint)MediumOrchid.ToArgb()] = "mediumorchid",
            [(uint)MediumPurple.ToArgb()] = "mediumpurple",
            [(uint)MediumSeaGreen.ToArgb()] = "mediumseagreen",
            [(uint)MediumSlateBlue.ToArgb()] = "mediumslateblue",
            [(uint)MediumSpringGreen.ToArgb()] = "mediumspringgreen",
            [(uint)MediumTurquoise.ToArgb()] = "mediumturquoise",
            [(uint)MediumVioletRed.ToArgb()] = "mediumvioletred",
            [(uint)MidnightBlue.ToArgb()] = "midnightblue",
            [(uint)MintCream.ToArgb()] = "mintcream",
            [(uint)MistyRose.ToArgb()] = "mistyrose",
            [(uint)Moccasin.ToArgb()] = "moccasin",
            [(uint)NavajoWhite.ToArgb()] = "navajowhite",
            [(uint)Navy.ToArgb()] = "navy",
            [(uint)OldLace.ToArgb()] = "oldlace",
            [(uint)Olive.ToArgb()] = "olive",
            [(uint)OliveDrab.ToArgb()] = "olivedrab",
            [(uint)Orange.ToArgb()] = "orange",
            [(uint)OrangeRed.ToArgb()] = "orangered",
            [(uint)Orchid.ToArgb()] = "orchid",
            [(uint)PaleGoldenrod.ToArgb()] = "palegoldenrod",
            [(uint)PaleGreen.ToArgb()] = "palegreen",
            [(uint)PaleTurquoise.ToArgb()] = "paleturquoise",
            [(uint)PaleVioletRed.ToArgb()] = "palevioletred",
            [(uint)PapayaWhip.ToArgb()] = "papayawhip",
            [(uint)PeachPuff.ToArgb()] = "peachpuff",
            [(uint)Peru.ToArgb()] = "peru",
            [(uint)Pink.ToArgb()] = "pink",
            [(uint)Plum.ToArgb()] = "plum",
            [(uint)PowderBlue.ToArgb()] = "powderblue",
            [(uint)Purple.ToArgb()] = "purple",
            [(uint)RebeccaPurple.ToArgb()] = "rebeccapurple",
            [(uint)Red.ToArgb()] = "red",
            [(uint)RosyBrown.ToArgb()] = "rosybrown",
            [(uint)RoyalBlue.ToArgb()] = "royalblue",
            [(uint)SaddleBrown.ToArgb()] = "saddlebrown",
            [(uint)Salmon.ToArgb()] = "salmon",
            [(uint)SandyBrown.ToArgb()] = "sandybrown",
            [(uint)SeaGreen.ToArgb()] = "seagreen",
            [(uint)SeaShell.ToArgb()] = "seashell",
            [(uint)Sienna.ToArgb()] = "sienna",
            [(uint)Silver.ToArgb()] = "silver",
            [(uint)SkyBlue.ToArgb()] = "skyblue",
            [(uint)SlateBlue.ToArgb()] = "slateblue",
            [(uint)SlateGray.ToArgb()] = "slategray",
            [(uint)Snow.ToArgb()] = "snow",
            [(uint)SpringGreen.ToArgb()] = "springgreen",
            [(uint)SteelBlue.ToArgb()] = "steelblue",
            [(uint)Tan.ToArgb()] = "tan",
            [(uint)Teal.ToArgb()] = "teal",
            [(uint)Thistle.ToArgb()] = "thistle",
            [(uint)Tomato.ToArgb()] = "tomato",
            [(uint)Transparent.ToArgb()] = "transparent",
            [(uint)Turquoise.ToArgb()] = "turquoise",
            [(uint)Violet.ToArgb()] = "violet",
            [(uint)Wheat.ToArgb()] = "wheat",
            [(uint)White.ToArgb()] = "white",
            [(uint)WhiteSmoke.ToArgb()] = "whitesmoke",
            [(uint)Yellow.ToArgb()] = "yellow",
            [(uint)YellowGreen.ToArgb()] = "yellowgreen",
        };
    }
}
