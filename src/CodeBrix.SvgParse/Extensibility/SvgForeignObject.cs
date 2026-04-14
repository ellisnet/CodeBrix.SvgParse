namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// The 'foreignObject' element allows for inclusion of a foreign namespace which has its graphical content drawn by a different user agent
/// </summary>
[SvgElement("foreignObject")]
public partial class SvgForeignObject : SvgVisualElement
{
    /// <summary>Gets or sets the Renderable.</summary>
    protected override bool Renderable { get { return false; } }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgForeignObject>();
    }
}
