namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgUnknownElement.</summary>
/// <summary>Represents the <see cref="SvgUnknownElement"/> class.</summary>
public partial class SvgUnknownElement : SvgElement
{
    /// <summary>Gets or sets the SvgUnknownElement().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgUnknownElement"/> class.</summary>
    public SvgUnknownElement()
    {
    }

    /// <summary>Gets or sets the SvgUnknownElement(string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgUnknownElement"/> class with the specified parameters.</summary>
    public SvgUnknownElement(string elementName)
    {
        ElementName = elementName;
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgUnknownElement>();
    }
}
