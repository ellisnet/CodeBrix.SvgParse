using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

public abstract partial class SvgVisualElement
{
    /// <summary>Gets or sets the Visible.</summary>
    public virtual bool Visible
    {
        get { return string.Equals(Visibility.Trim(), "visible", StringComparison.OrdinalIgnoreCase); }
    }

    // Displayable - false if attribute display="none", true otherwise
    /// <summary>Gets or sets the Displayable.</summary>
    protected virtual bool Displayable
    {
        get { return !string.Equals(Display.Trim(), "none", StringComparison.OrdinalIgnoreCase); }
    }

    /// <summary>
    /// Gets or sets the fill <see cref="SvgPaintServer"/> of this element.
    /// </summary>
    [SvgAttribute("enable-background")]
    public virtual string EnableBackground
    {
        get { return GetAttribute("enable-background", false, "accumulate"); }
        set { Attributes["enable-background"] = value; }
    }
}
