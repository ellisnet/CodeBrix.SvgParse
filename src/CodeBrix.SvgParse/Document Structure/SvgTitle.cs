namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgTitle.</summary>
/// <summary>Represents the <see cref="SvgTitle"/> class.</summary>
[SvgElement("title")]
public partial class SvgTitle : SvgElement, ISvgDescriptiveElement
{
    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        return this.Content;
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgTitle>();
    }
}
