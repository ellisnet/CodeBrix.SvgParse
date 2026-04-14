using CodeBrix.SvgParse.Transforms;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// Represents and element that may be transformed.
/// </summary>
public interface ISvgTransformable
{
    /// <summary>
    /// Gets or sets an <see cref="SvgTransformCollection"/> of element transforms.
    /// </summary>
    SvgTransformCollection Transforms { get; set; }
}
