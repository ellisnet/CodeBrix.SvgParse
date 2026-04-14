using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the ExternalType.</summary>
/// <summary>Defines the ExternalType enumeration.</summary>
[Flags]
public enum ExternalType
{
    /// <summary>Gets or sets the None.</summary>
    /// <summary>The None value.</summary>
    None = 0x0,
    /// <summary>Gets or sets the Local.</summary>
    /// <summary>The Local value.</summary>
    Local = 0x1,
    /// <summary>Gets or sets the Remote.</summary>
    /// <summary>The Remote value.</summary>
    Remote = 0x2,
}

/// <summary>Gets or sets the ExternalTypeExtensions.</summary>
/// <summary>Represents the <see cref="ExternalTypeExtensions"/> class.</summary>
public static class ExternalTypeExtensions
{
    /// <summary>Gets or sets the AllowsResolving(ExternalType, Uri).</summary>
    /// <summary>Performs the AllowsResolving(ExternalType, Uri) operation.</summary>
    public static bool AllowsResolving(this ExternalType externalType, Uri uri)
    {
        return uri.IsAbsoluteUri &&
            (externalType.HasFlag(ExternalType.Local) && uri.IsFile ||
            externalType.HasFlag(ExternalType.Remote) && !uri.IsFile);
    }
}
