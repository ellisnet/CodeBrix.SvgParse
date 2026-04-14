using System;

namespace CodeBrix.SvgParse.ExtensionMethods; //Was previously: namespace Svg.ExtensionMethods;

/// <summary>Gets or sets the UriExtensions.</summary>
/// <summary>Represents the <see cref="UriExtensions"/> class.</summary>
public static class UriExtensions
{
    /// <summary>Gets or sets the ReplaceWithNullIfNone(Uri).</summary>
    /// <summary>Performs the ReplaceWithNullIfNone(Uri) operation.</summary>
    public static Uri ReplaceWithNullIfNone(this Uri uri)
    {
        return string.Equals(uri?.ToString().Trim(), "none", StringComparison.OrdinalIgnoreCase) ? null : uri;
    }
}
