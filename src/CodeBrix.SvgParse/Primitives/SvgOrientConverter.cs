using System;
using System.ComponentModel;
using System.Globalization;

namespace CodeBrix.SvgParse.Primitives; //Was previously: namespace Svg.DataTypes;

/// <summary>Gets or sets the SvgOrientConverter.</summary>
/// <summary>Represents the <see cref="SvgOrientConverter"/> class.</summary>
public sealed class SvgOrientConverter : TypeConverter
{
    /// <summary>Gets or sets the ConvertFrom(ITypeDescriptorContext, CultureInfo, object).</summary>
    /// <inheritdoc />
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value == null)
            return new SvgOrient();

        if (!(value is string))
            throw new ArgumentOutOfRangeException("value must be a string.");

        switch (value.ToString())
        {
            case "auto":
                return new SvgOrient(true);
            case "auto-start-reverse":
                return new SvgOrient(true, true);
            default:
                float fTmp;
                if (!float.TryParse(value.ToString(), out fTmp))
                    throw new ArgumentOutOfRangeException("value must be a valid float.");
                return new SvgOrient(fTmp);
        }
    }

    /// <summary>Gets or sets the CanConvertFrom(ITypeDescriptorContext, Type).</summary>
    /// <inheritdoc />
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        if (sourceType == typeof(string))
            return true;

        return base.CanConvertFrom(context, sourceType);
    }

    /// <summary>Gets or sets the CanConvertTo(ITypeDescriptorContext, Type).</summary>
    /// <inheritdoc />
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        if (destinationType == typeof(string))
            return true;

        return base.CanConvertTo(context, destinationType);
    }

    /// <summary>Gets or sets the ConvertTo(ITypeDescriptorContext, CultureInfo, object, Type).</summary>
    /// <inheritdoc />
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        return base.ConvertTo(context, culture, value, destinationType);
    }
}
