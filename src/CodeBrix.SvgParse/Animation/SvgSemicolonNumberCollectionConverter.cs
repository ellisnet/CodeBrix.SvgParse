using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using CodeBrix.SvgParse.Helpers;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgSemicolonNumberCollectionConverter.</summary>
/// <summary>Represents the <see cref="SvgSemicolonNumberCollectionConverter"/> class.</summary>
public sealed class SvgSemicolonNumberCollectionConverter : TypeConverter
{
    /// <summary>Gets or sets the CanConvertFrom(ITypeDescriptorContext, Type).</summary>
    /// <inheritdoc />
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        if (sourceType == typeof(string))
        {
            return true;
        }

        return base.CanConvertFrom(context, sourceType);
    }

    /// <summary>Gets or sets the CanConvertTo(ITypeDescriptorContext, Type).</summary>
    /// <inheritdoc />
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            return true;
        }

        return base.CanConvertTo(context, destinationType);
    }

    /// <summary>Gets or sets the ConvertFrom(ITypeDescriptorContext, CultureInfo, object).</summary>
    /// <inheritdoc />
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string str)
        {
            var collection = new SvgNumberCollection();

            if (string.IsNullOrWhiteSpace(str))
            {
                return collection;
            }

            var items = str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                var trimmed = item.Trim();
                if (trimmed.Length == 0)
                {
                    continue;
                }

                collection.Add(StringParser.ToFloatAny(trimmed.AsSpan()));
            }

            return collection;
        }

        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>Gets or sets the ConvertTo(ITypeDescriptorContext, CultureInfo, object, Type).</summary>
    /// <inheritdoc />
    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is SvgNumberCollection collection)
        {
            return string.Join(";", collection.Select(number => number.ToSvgString()).ToArray());
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}
