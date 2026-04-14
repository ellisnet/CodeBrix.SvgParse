namespace CodeBrix.SvgParse;

/// <summary>Gets or sets the SvgColorServer.</summary>
/// <summary>Represents the <see cref="SvgColorServer"/> class.</summary>
public partial class SvgColorServer : SvgPaintServer
{
    /// <summary>Gets or sets the SvgColorServer().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgColorServer"/> class.</summary>
    public SvgColorServer()
        : this(SvgColor.Black)
    {
    }

    /// <summary>Gets or sets the SvgColorServer(SvgColor).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgColorServer"/> class with the specified parameters.</summary>
    public SvgColorServer(SvgColor color)
    {
        this._color = color;
    }

    private SvgColor _color;

    /// <summary>Gets or sets the ColorValue.</summary>
    public SvgColor ColorValue
    {
        get { return this._color; }
        set { this._color = value; }
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        if (this == None)
            return "none";
        else if (this == NotSet)
            return string.Empty;
        else if (this == Inherit)
            return "inherit";

        // Use the document-level setting when we have an owner; otherwise fall back to
        // the library-wide default.
        var useNamed = OwnerDocument?.EnableEmitNamedColorsOnSerialization
                       ?? SvgDocument.EmitNamedColorsOnSerialization;
        return SvgColorConverter.ToHtml(this._color, useNamed);
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgColorServer>();
    }

    /// <summary>Gets or sets the DeepCopy.</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy<T>()
    {
        if (this == None || this == Inherit || this == NotSet)
            return this;

        var newObj = base.DeepCopy<T>() as SvgColorServer;

        newObj.ColorValue = ColorValue;
        return newObj;
    }

    /// <summary>Gets or sets the Equals(object).</summary>
    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        var objColor = obj as SvgColorServer;
        if (objColor == null)
            return false;

        if ((this == None && obj != None) || (this != None && obj == None) ||
            (this == NotSet && obj != NotSet) || (this != NotSet && obj == NotSet) ||
            (this == Inherit && obj != Inherit) || (this != Inherit && obj == Inherit))
            return false;

        return this.GetHashCode() == objColor.GetHashCode();
    }

    /// <summary>Gets or sets the GetHashCode().</summary>
    /// <inheritdoc />
    public override int GetHashCode()
    {
        return _color.GetHashCode();
    }
}
