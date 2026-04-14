using System.ComponentModel;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgDescription.</summary>
/// <summary>Represents the <see cref="SvgDescription"/> class.</summary>
[DefaultProperty("Text")]
[SvgElement("desc")]
public partial class SvgDescription : SvgElement, ISvgDescriptiveElement
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
        return DeepCopy<SvgDescription>();
    }
}
