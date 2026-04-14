namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgContentNode.</summary>
/// <summary>Represents the <see cref="SvgContentNode"/> class.</summary>
public class SvgContentNode : ISvgNode
{
    /// <summary>Gets or sets the Content.</summary>
    public string Content { get; set; }

    /// <summary>
    /// Create a deep copy of this <see cref="ISvgNode"/>.
    /// </summary>
    /// <returns>A deep copy of this <see cref="ISvgNode"/></returns>
    public ISvgNode DeepCopy()
    {
        // Since strings are immutable in C#, we can just use the same reference here.
        return new SvgContentNode { Content = this.Content };
    }
}
