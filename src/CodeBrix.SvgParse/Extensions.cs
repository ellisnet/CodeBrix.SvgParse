using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the Extensions.</summary>
/// <summary>Represents the <see cref="Extensions"/> class.</summary>
public static class Extensions
{
    /// <summary>Gets or sets the Descendants.</summary>
    /// <summary>Performs the Descendants operation.</summary>
    public static IEnumerable<SvgElement> Descendants<T>(this IEnumerable<T> source) where T : SvgElement
    {
        if (source == null) throw new ArgumentNullException("source");

        return GetDescendants<T>(source, false);
    }

    private static IEnumerable<SvgElement> GetAncestors<T>(IEnumerable<T> source, bool self) where T : SvgElement
    {
        foreach (var start in source)
        {
            if (start != null)
            {
                for (var elem = (self ? start : start.Parent) as SvgElement; elem != null; elem = (elem.Parent as SvgElement))
                {
                    yield return elem;
                }
            }
        }
        yield break;
    }

    private static IEnumerable<SvgElement> GetDescendants<T>(IEnumerable<T> source, bool self) where T : SvgElement
    {
        foreach (var top in source)
        {
            if (top == null)
                continue;

            if (self)
                yield return top;

            var elements = new Stack<SvgElement>(top.Children.Reverse());
            while (elements.Count > 0)
            {
                var element = elements.Pop();
                yield return element;
                foreach (var e in element.Children.Reverse())
                    elements.Push(e);
            }
        }
        yield break;
    }
}
