using System.ComponentModel;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgAnimationAttributeType.</summary>
/// <summary>Defines the SvgAnimationAttributeType enumeration.</summary>
[TypeConverter(typeof(SvgAnimationAttributeTypeConverter))]
public enum SvgAnimationAttributeType
{
    /// <summary>Gets or sets the Auto.</summary>
    /// <summary>The Auto value.</summary>
    Auto,
    /// <summary>Gets or sets the Css.</summary>
    /// <summary>The Css value.</summary>
    Css,
    /// <summary>Gets or sets the Xml.</summary>
    /// <summary>The Xml value.</summary>
    Xml
}

/// <summary>Gets or sets the SvgAnimationRestart.</summary>
/// <summary>Defines the SvgAnimationRestart enumeration.</summary>
[TypeConverter(typeof(SvgAnimationRestartConverter))]
public enum SvgAnimationRestart
{
    /// <summary>Gets or sets the Always.</summary>
    /// <summary>The Always value.</summary>
    Always,
    /// <summary>Gets or sets the Never.</summary>
    /// <summary>The Never value.</summary>
    Never,
    /// <summary>Gets or sets the WhenNotActive.</summary>
    /// <summary>The WhenNotActive value.</summary>
    WhenNotActive
}

/// <summary>Gets or sets the SvgAnimationFill.</summary>
/// <summary>Defines the SvgAnimationFill enumeration.</summary>
[TypeConverter(typeof(SvgAnimationFillConverter))]
public enum SvgAnimationFill
{
    /// <summary>Gets or sets the Remove.</summary>
    /// <summary>The Remove value.</summary>
    Remove,
    /// <summary>Gets or sets the Freeze.</summary>
    /// <summary>The Freeze value.</summary>
    Freeze
}

/// <summary>Gets or sets the SvgAnimationCalcMode.</summary>
/// <summary>Defines the SvgAnimationCalcMode enumeration.</summary>
[TypeConverter(typeof(SvgAnimationCalcModeConverter))]
public enum SvgAnimationCalcMode
{
    /// <summary>Gets or sets the Discrete.</summary>
    /// <summary>The Discrete value.</summary>
    Discrete,
    /// <summary>Gets or sets the Linear.</summary>
    /// <summary>The Linear value.</summary>
    Linear,
    /// <summary>Gets or sets the Paced.</summary>
    /// <summary>The Paced value.</summary>
    Paced,
    /// <summary>Gets or sets the Spline.</summary>
    /// <summary>The Spline value.</summary>
    Spline
}

/// <summary>Gets or sets the SvgAnimationAdditive.</summary>
/// <summary>Defines the SvgAnimationAdditive enumeration.</summary>
[TypeConverter(typeof(SvgAnimationAdditiveConverter))]
public enum SvgAnimationAdditive
{
    /// <summary>Gets or sets the Replace.</summary>
    /// <summary>The Replace value.</summary>
    Replace,
    /// <summary>Gets or sets the Sum.</summary>
    /// <summary>The Sum value.</summary>
    Sum
}

/// <summary>Gets or sets the SvgAnimationAccumulate.</summary>
/// <summary>Defines the SvgAnimationAccumulate enumeration.</summary>
[TypeConverter(typeof(SvgAnimationAccumulateConverter))]
public enum SvgAnimationAccumulate
{
    /// <summary>Gets or sets the None.</summary>
    /// <summary>The None value.</summary>
    None,
    /// <summary>Gets or sets the Sum.</summary>
    /// <summary>The Sum value.</summary>
    Sum
}

/// <summary>Gets or sets the SvgAnimateTransformType.</summary>
/// <summary>Defines the SvgAnimateTransformType enumeration.</summary>
[TypeConverter(typeof(SvgAnimateTransformTypeConverter))]
public enum SvgAnimateTransformType
{
    /// <summary>Gets or sets the Translate.</summary>
    /// <summary>The Translate value.</summary>
    Translate,
    /// <summary>Gets or sets the Scale.</summary>
    /// <summary>The Scale value.</summary>
    Scale,
    /// <summary>Gets or sets the Rotate.</summary>
    /// <summary>The Rotate value.</summary>
    Rotate,
    /// <summary>Gets or sets the SkewX.</summary>
    /// <summary>The SkewX value.</summary>
    SkewX,
    /// <summary>Gets or sets the SkewY.</summary>
    /// <summary>The SkewY value.</summary>
    SkewY
}

/// <summary>Gets or sets the SvgAnimationAttributeTypeConverter.</summary>
/// <summary>Represents the <see cref="SvgAnimationAttributeTypeConverter"/> class.</summary>
public sealed class SvgAnimationAttributeTypeConverter : EnumBaseConverter<SvgAnimationAttributeType>
{
}

/// <summary>Gets or sets the SvgAnimationRestartConverter.</summary>
/// <summary>Represents the <see cref="SvgAnimationRestartConverter"/> class.</summary>
public sealed class SvgAnimationRestartConverter : EnumBaseConverter<SvgAnimationRestart>
{
}

/// <summary>Gets or sets the SvgAnimationFillConverter.</summary>
/// <summary>Represents the <see cref="SvgAnimationFillConverter"/> class.</summary>
public sealed class SvgAnimationFillConverter : EnumBaseConverter<SvgAnimationFill>
{
}

/// <summary>Gets or sets the SvgAnimationCalcModeConverter.</summary>
/// <summary>Represents the <see cref="SvgAnimationCalcModeConverter"/> class.</summary>
public sealed class SvgAnimationCalcModeConverter : EnumBaseConverter<SvgAnimationCalcMode>
{
}

/// <summary>Gets or sets the SvgAnimationAdditiveConverter.</summary>
/// <summary>Represents the <see cref="SvgAnimationAdditiveConverter"/> class.</summary>
public sealed class SvgAnimationAdditiveConverter : EnumBaseConverter<SvgAnimationAdditive>
{
}

/// <summary>Gets or sets the SvgAnimationAccumulateConverter.</summary>
/// <summary>Represents the <see cref="SvgAnimationAccumulateConverter"/> class.</summary>
public sealed class SvgAnimationAccumulateConverter : EnumBaseConverter<SvgAnimationAccumulate>
{
}

/// <summary>Gets or sets the SvgAnimateTransformTypeConverter.</summary>
/// <summary>Represents the <see cref="SvgAnimateTransformTypeConverter"/> class.</summary>
public sealed class SvgAnimateTransformTypeConverter : EnumBaseConverter<SvgAnimateTransformType>
{
}
