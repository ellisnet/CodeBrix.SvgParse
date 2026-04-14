using System.ComponentModel;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgPointerEvents.</summary>
/// <summary>Defines the SvgPointerEvents enumeration.</summary>
[TypeConverter(typeof(SvgPointerEventsConverter))]
public enum SvgPointerEvents
{
    /// <summary>Gets or sets the VisiblePainted.</summary>
    /// <summary>The VisiblePainted value.</summary>
    VisiblePainted,
    /// <summary>Gets or sets the VisibleFill.</summary>
    /// <summary>The VisibleFill value.</summary>
    VisibleFill,
    /// <summary>Gets or sets the VisibleStroke.</summary>
    /// <summary>The VisibleStroke value.</summary>
    VisibleStroke,
    /// <summary>Gets or sets the Visible.</summary>
    /// <summary>The Visible value.</summary>
    Visible,
    /// <summary>Gets or sets the Painted.</summary>
    /// <summary>The Painted value.</summary>
    Painted,
    /// <summary>Gets or sets the Fill.</summary>
    /// <summary>The Fill value.</summary>
    Fill,
    /// <summary>Gets or sets the Stroke.</summary>
    /// <summary>The Stroke value.</summary>
    Stroke,
    /// <summary>Gets or sets the All.</summary>
    /// <summary>The All value.</summary>
    All,
    /// <summary>Gets or sets the None.</summary>
    /// <summary>The None value.</summary>
    None
}

/// <summary>Gets or sets the SvgPointerEventsConverter.</summary>
/// <summary>Represents the <see cref="SvgPointerEventsConverter"/> class.</summary>
public sealed class SvgPointerEventsConverter : EnumBaseConverter<SvgPointerEvents>
{
}

public abstract partial class SvgVisualElement
{
    /// <summary>Gets or sets the PointerEvents.</summary>
    [SvgAttribute("pointer-events")]
    public virtual SvgPointerEvents PointerEvents
    {
        get { return GetAttribute("pointer-events", true, SvgPointerEvents.VisiblePainted); }
        set { Attributes["pointer-events"] = value; }
    }
}
