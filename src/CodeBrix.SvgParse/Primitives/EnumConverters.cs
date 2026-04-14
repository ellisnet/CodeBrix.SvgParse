using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using CodeBrix.SvgParse.Primitives;
using CodeBrix.SvgParse.FilterEffects;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Represents the <see cref="EnumBaseConverter{T}"/> class.</summary>
public abstract class EnumBaseConverter<T> : TypeConverter
    where T : struct
{
    /// <summary>Gets or sets the CaseHandling.</summary>
    /// <summary>Defines the CaseHandling enumeration.</summary>
    public enum CaseHandling
    {
        /// <summary>Gets or sets the CamelCase.</summary>
        /// <summary>The CamelCase value.</summary>
        CamelCase,
        /// <summary>Gets or sets the PascalCase.</summary>
        /// <summary>The PascalCase value.</summary>
        PascalCase,
        /// <summary>Gets or sets the LowerCase.</summary>
        /// <summary>The LowerCase value.</summary>
        LowerCase,
        /// <summary>Gets or sets the KebabCase.</summary>
        /// <summary>The KebabCase value.</summary>
        KebabCase,
    }

    /// <summary>Defines if the enum literal shall be converted to camelCase, PascalCase or kebab-case.</summary>
    public CaseHandling CaseHandlingMode { get; }

    /// <summary>Creates a new instance.</summary>
    /// <param name="caseHandling">Defines if the value shall be converted to camelCase, PascalCase, lowercase or kebab-case.</param>
    public EnumBaseConverter(CaseHandling caseHandling = CaseHandling.CamelCase)
    {
        CaseHandlingMode = caseHandling;
    }

    /// <summary>Gets or sets the CanConvertFrom(ITypeDescriptorContext, Type).</summary>
    /// <inheritdoc />
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        if (sourceType == typeof(string))
            return true;

        return base.CanConvertFrom(context, sourceType);
    }

    /// <summary>Attempts to convert the provided value to <typeparamref name="T"/>.</summary>
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string stringValue)
        {
            if (CaseHandlingMode == CaseHandling.KebabCase)
                stringValue = stringValue.Replace("-", string.Empty);

            if (Enum.TryParse<T>(stringValue, true, out T result))
                return result;
        }

        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>Attempts to convert the value to the destination type.</summary>
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is T)
        {
            var stringValue = ((T)value).ToString();
            if (CaseHandlingMode == CaseHandling.CamelCase)
                return string.Format("{0}{1}", stringValue[0].ToString().ToLower(), stringValue.Substring(1));

            if (CaseHandlingMode == CaseHandling.PascalCase)
                return stringValue;

            if (CaseHandlingMode == CaseHandling.KebabCase)
                stringValue = Regex.Replace(stringValue, @"(\w)([A-Z])", "$1-$2", RegexOptions.CultureInvariant);

            return stringValue.ToLower();
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

/// <summary>Gets or sets the XmlSpaceHandlingConverter.</summary>
/// <summary>Represents the <see cref="XmlSpaceHandlingConverter"/> class.</summary>
public sealed class XmlSpaceHandlingConverter : EnumBaseConverter<XmlSpaceHandling>
{
    /// <summary>Gets or sets the XmlSpaceHandlingConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="XmlSpaceHandlingConverter"/> class with the specified parameters.</summary>
    public XmlSpaceHandlingConverter() : base(CaseHandling.LowerCase) { }
}

/// <summary>Gets or sets the SvgFillRuleConverter.</summary>
/// <summary>Represents the <see cref="SvgFillRuleConverter"/> class.</summary>
public sealed class SvgFillRuleConverter : EnumBaseConverter<SvgFillRule>
{
    /// <summary>Gets or sets the SvgFillRuleConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgFillRuleConverter"/> class with the specified parameters.</summary>
    public SvgFillRuleConverter() : base(CaseHandling.LowerCase) { }
}

/// <summary>Gets or sets the SvgColorInterpolationConverter.</summary>
/// <summary>Represents the <see cref="SvgColorInterpolationConverter"/> class.</summary>
public sealed class SvgColorInterpolationConverter : EnumBaseConverter<SvgColorInterpolation> { }

/// <summary>Gets or sets the SvgClipRuleConverter.</summary>
/// <summary>Represents the <see cref="SvgClipRuleConverter"/> class.</summary>
public sealed class SvgClipRuleConverter : EnumBaseConverter<SvgClipRule>
{
    /// <summary>Gets or sets the SvgClipRuleConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgClipRuleConverter"/> class with the specified parameters.</summary>
    public SvgClipRuleConverter() : base(CaseHandling.LowerCase) { }
}

/// <summary>Gets or sets the SvgTextAnchorConverter.</summary>
/// <summary>Represents the <see cref="SvgTextAnchorConverter"/> class.</summary>
public sealed class SvgTextAnchorConverter : EnumBaseConverter<SvgTextAnchor> { }

/// <summary>Gets or sets the SvgDominantBaselineConverter.</summary>
/// <summary>Represents the <see cref="SvgDominantBaselineConverter"/> class.</summary>
public sealed class SvgDominantBaselineConverter : EnumBaseConverter<SvgDominantBaseline>
{
    /// <summary>Gets or sets the SvgDominantBaselineConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgDominantBaselineConverter"/> class with the specified parameters.</summary>
    public SvgDominantBaselineConverter() : base(CaseHandling.KebabCase) { }
}

/// <summary>Gets or sets the SvgStrokeLineCapConverter.</summary>
/// <summary>Represents the <see cref="SvgStrokeLineCapConverter"/> class.</summary>
public sealed class SvgStrokeLineCapConverter : EnumBaseConverter<SvgStrokeLineCap> { }

/// <summary>Gets or sets the SvgStrokeLineJoinConverter.</summary>
/// <summary>Represents the <see cref="SvgStrokeLineJoinConverter"/> class.</summary>
public sealed class SvgStrokeLineJoinConverter : EnumBaseConverter<SvgStrokeLineJoin> { }

/// <summary>Gets or sets the SvgMarkerUnitsConverter.</summary>
/// <summary>Represents the <see cref="SvgMarkerUnitsConverter"/> class.</summary>
public sealed class SvgMarkerUnitsConverter : EnumBaseConverter<SvgMarkerUnits> { }

/// <summary>Gets or sets the SvgFontStyleConverter.</summary>
/// <summary>Represents the <see cref="SvgFontStyleConverter"/> class.</summary>
public sealed class SvgFontStyleConverter : EnumBaseConverter<SvgFontStyle> { }

/// <summary>Gets or sets the SvgOverflowConverter.</summary>
/// <summary>Represents the <see cref="SvgOverflowConverter"/> class.</summary>
public sealed class SvgOverflowConverter : EnumBaseConverter<SvgOverflow> { }

/// <summary>Gets or sets the SvgTextLengthAdjustConverter.</summary>
/// <summary>Represents the <see cref="SvgTextLengthAdjustConverter"/> class.</summary>
public sealed class SvgTextLengthAdjustConverter : EnumBaseConverter<SvgTextLengthAdjust> { }

/// <summary>Gets or sets the SvgTextPathMethodConverter.</summary>
/// <summary>Represents the <see cref="SvgTextPathMethodConverter"/> class.</summary>
public sealed class SvgTextPathMethodConverter : EnumBaseConverter<SvgTextPathMethod> { }

/// <summary>Gets or sets the SvgTextPathSpacingConverter.</summary>
/// <summary>Represents the <see cref="SvgTextPathSpacingConverter"/> class.</summary>
public sealed class SvgTextPathSpacingConverter : EnumBaseConverter<SvgTextPathSpacing> { }

/// <summary>Gets or sets the SvgShapeRenderingConverter.</summary>
/// <summary>Represents the <see cref="SvgShapeRenderingConverter"/> class.</summary>
public sealed class SvgShapeRenderingConverter : EnumBaseConverter<SvgShapeRendering> { }

/// <summary>Gets or sets the SvgTextRenderingConverter.</summary>
/// <summary>Represents the <see cref="SvgTextRenderingConverter"/> class.</summary>
public sealed class SvgTextRenderingConverter : EnumBaseConverter<SvgTextRendering> { }

/// <summary>Gets or sets the SvgImageRenderingConverter.</summary>
/// <summary>Represents the <see cref="SvgImageRenderingConverter"/> class.</summary>
public sealed class SvgImageRenderingConverter : EnumBaseConverter<SvgImageRendering> { }

/// <summary>Gets or sets the SvgFontVariantConverter.</summary>
/// <summary>Represents the <see cref="SvgFontVariantConverter"/> class.</summary>
public sealed class SvgFontVariantConverter : EnumBaseConverter<SvgFontVariant>
{
    /// <summary>Gets or sets the SvgFontVariantConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgFontVariantConverter"/> class with the specified parameters.</summary>
    public SvgFontVariantConverter() : base(CaseHandling.KebabCase) { }
}

/// <summary>Gets or sets the SvgCoordinateUnitsConverter.</summary>
/// <summary>Represents the <see cref="SvgCoordinateUnitsConverter"/> class.</summary>
public sealed class SvgCoordinateUnitsConverter : EnumBaseConverter<SvgCoordinateUnits> { }

/// <summary>Gets or sets the SvgGradientSpreadMethodConverter.</summary>
/// <summary>Represents the <see cref="SvgGradientSpreadMethodConverter"/> class.</summary>
public sealed class SvgGradientSpreadMethodConverter : EnumBaseConverter<SvgGradientSpreadMethod> { }

/// <summary>Gets or sets the SvgTextDecorationConverter.</summary>
/// <summary>Represents the <see cref="SvgTextDecorationConverter"/> class.</summary>
public sealed class SvgTextDecorationConverter : EnumBaseConverter<SvgTextDecoration>
{
    /// <summary>Gets or sets the SvgTextDecorationConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgTextDecorationConverter"/> class with the specified parameters.</summary>
    public SvgTextDecorationConverter() : base(CaseHandling.KebabCase) { }

    /// <summary>Gets or sets the ConvertFrom(ITypeDescriptorContext, CultureInfo, object).</summary>
    /// <inheritdoc />
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string)
            value = ((string)value).Replace(" ", ", ");

        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>Gets or sets the ConvertTo(ITypeDescriptorContext, CultureInfo, object, Type).</summary>
    /// <inheritdoc />
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        var destination = base.ConvertTo(context, culture, value, destinationType);

        if (destination is string && value is SvgTextDecoration)
            destination = ((string)destination).Replace(",", string.Empty);

        return destination;
    }
}

/// <summary>Gets or sets the SvgFontStretchConverter.</summary>
/// <summary>Represents the <see cref="SvgFontStretchConverter"/> class.</summary>
public sealed class SvgFontStretchConverter : EnumBaseConverter<SvgFontStretch>
{
    /// <summary>Gets or sets the SvgFontStretchConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgFontStretchConverter"/> class with the specified parameters.</summary>
    public SvgFontStretchConverter() : base(CaseHandling.KebabCase) { }
}

/// <summary>Gets or sets the SvgFontWeightConverter.</summary>
/// <summary>Represents the <see cref="SvgFontWeightConverter"/> class.</summary>
public sealed class SvgFontWeightConverter : EnumBaseConverter<SvgFontWeight>
{
    /// <summary>Gets or sets the ConvertFrom(ITypeDescriptorContext, CultureInfo, object).</summary>
    /// <inheritdoc />
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string)
        {
            switch ((string)value)
            {
                case "100": return SvgFontWeight.W100;
                case "200": return SvgFontWeight.W200;
                case "300": return SvgFontWeight.W300;
                case "400": return SvgFontWeight.W400;
                case "500": return SvgFontWeight.W500;
                case "600": return SvgFontWeight.W600;
                case "700": return SvgFontWeight.W700;
                case "800": return SvgFontWeight.W800;
                case "900": return SvgFontWeight.W900;
            }
        }
        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>Gets or sets the ConvertTo(ITypeDescriptorContext, CultureInfo, object, Type).</summary>
    /// <inheritdoc />
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is SvgFontWeight)
        {
            switch ((SvgFontWeight)value)
            {
                case SvgFontWeight.W100: return "100";
                case SvgFontWeight.W200: return "200";
                case SvgFontWeight.W300: return "300";
                case SvgFontWeight.W400: return "400";
                case SvgFontWeight.W500: return "500";
                case SvgFontWeight.W600: return "600";
                case SvgFontWeight.W700: return "700";
                case SvgFontWeight.W800: return "800";
                case SvgFontWeight.W900: return "900";
            }
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}

/// <summary>Gets or sets the SvgTextTransformationConverter.</summary>
/// <summary>Represents the <see cref="SvgTextTransformationConverter"/> class.</summary>
public sealed class SvgTextTransformationConverter : EnumBaseConverter<SvgTextTransformation> { }

/// <summary>Gets or sets the SvgBlendModeConverter.</summary>
/// <summary>Represents the <see cref="SvgBlendModeConverter"/> class.</summary>
public sealed class SvgBlendModeConverter : EnumBaseConverter<SvgBlendMode>
{
    /// <summary>Gets or sets the SvgBlendModeConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgBlendModeConverter"/> class with the specified parameters.</summary>
    public SvgBlendModeConverter() : base(CaseHandling.KebabCase) { }
}

/// <summary>Gets or sets the SvgColorMatrixTypeConverter.</summary>
/// <summary>Represents the <see cref="SvgColorMatrixTypeConverter"/> class.</summary>
public sealed class SvgColorMatrixTypeConverter : EnumBaseConverter<SvgColorMatrixType> { }

/// <summary>Gets or sets the SvgComponentTransferTypeConverter.</summary>
/// <summary>Represents the <see cref="SvgComponentTransferTypeConverter"/> class.</summary>
public sealed class SvgComponentTransferTypeConverter : EnumBaseConverter<SvgComponentTransferType> { }

/// <summary>Gets or sets the SvgCompositeOperatorConverter.</summary>
/// <summary>Represents the <see cref="SvgCompositeOperatorConverter"/> class.</summary>
public sealed class SvgCompositeOperatorConverter : EnumBaseConverter<SvgCompositeOperator> { }

/// <summary>Gets or sets the SvgEdgeModeConverter.</summary>
/// <summary>Represents the <see cref="SvgEdgeModeConverter"/> class.</summary>
public sealed class SvgEdgeModeConverter : EnumBaseConverter<SvgEdgeMode> { }

/// <summary>Gets or sets the SvgChannelSelectorConverter.</summary>
/// <summary>Represents the <see cref="SvgChannelSelectorConverter"/> class.</summary>
public sealed class SvgChannelSelectorConverter : EnumBaseConverter<SvgChannelSelector>
{
    /// <summary>Gets or sets the SvgChannelSelectorConverter().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgChannelSelectorConverter"/> class with the specified parameters.</summary>
    public SvgChannelSelectorConverter() : base(CaseHandling.PascalCase) { }
}

/// <summary>Gets or sets the SvgMorphologyOperatorConverter.</summary>
/// <summary>Represents the <see cref="SvgMorphologyOperatorConverter"/> class.</summary>
public sealed class SvgMorphologyOperatorConverter : EnumBaseConverter<SvgMorphologyOperator> { }

/// <summary>Gets or sets the SvgStitchTypeConverter.</summary>
/// <summary>Represents the <see cref="SvgStitchTypeConverter"/> class.</summary>
public sealed class SvgStitchTypeConverter : EnumBaseConverter<SvgStitchType> { }

/// <summary>Gets or sets the SvgTurbulenceTypeConverter.</summary>
/// <summary>Represents the <see cref="SvgTurbulenceTypeConverter"/> class.</summary>
public sealed class SvgTurbulenceTypeConverter : EnumBaseConverter<SvgTurbulenceType> { }
