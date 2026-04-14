namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the NonSvgElement.</summary>
/// <summary>Represents the <see cref="NonSvgElement"/> class.</summary>
public partial class NonSvgElement : SvgElement
{
    /// <summary>Gets or sets the NonSvgElement().</summary>
    /// <summary>Initializes a new instance of the <see cref="NonSvgElement"/> class.</summary>
    public NonSvgElement()
    {
    }

    /// <summary>Gets or sets the NonSvgElement(string, string).</summary>
    /// <summary>Initializes a new instance of the <see cref="NonSvgElement"/> class with the specified parameters.</summary>
    public NonSvgElement(string elementName, string elementNamespace)
    {
        ElementName = elementName;
        ElementNamespace = elementNamespace;
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<NonSvgElement>();
    }

    /// <summary>
    /// Publish the element name to be able to differentiate non-svg elements.
    /// </summary>
    public string Name
    {
        get { return ElementName; }
    }
}
