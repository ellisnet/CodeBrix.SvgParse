using System;
using System.ComponentModel;
using System.Globalization;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

public abstract partial class SvgElement
{
    /// <summary>Gets or sets the GetAnimationValue(string).</summary>
    /// <summary>Gets the AnimationValue(string).</summary>
    public virtual object GetAnimationValue(string attributeName)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return GetValue(attributeName);
    }

    /// <summary>Gets or sets the TrySetAnimationValue(string, object).</summary>
    /// <summary>Attempts to perform the TrySetAnimationValue(string, object) operation.</summary>
    public virtual bool TrySetAnimationValue(string attributeName, object value)
    {
        return TrySetAnimationValue(attributeName, OwnerDocument, CultureInfo.InvariantCulture, value);
    }

    /// <summary>Gets or sets the TrySetAnimationValue(string, ITypeDescriptorContext, CultureInfo, object).</summary>
    /// <summary>Attempts to perform the TrySetAnimationValue(string, ITypeDescriptorContext, CultureInfo, object) operation.</summary>
    public virtual bool TrySetAnimationValue(string attributeName, ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        context ??= OwnerDocument;
        culture ??= CultureInfo.InvariantCulture;

        return SetValue(attributeName, context, culture, value);
    }

    /// <summary>Gets or sets the ClearAnimationValue(string).</summary>
    /// <summary>Performs the ClearAnimationValue(string) operation.</summary>
    public virtual bool ClearAnimationValue(string attributeName)
    {
        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return Attributes.Remove(attributeName);
    }
}
