using System;
using System.Collections.Generic;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>
/// A wrapper for a paint server has a fallback if the primary server doesn't work.
/// </summary>
[Obsolete("Will be removed.Use SvgDeferredPaintServer class instead.")]
public partial class SvgFallbackPaintServer : SvgPaintServer
{
    private IEnumerable<SvgPaintServer> _fallbacks;
    private SvgPaintServer _primary;

    /// <summary>Gets or sets the SvgFallbackPaintServer().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgFallbackPaintServer"/> class with the specified parameters.</summary>
    public SvgFallbackPaintServer() : base() { }
    /// <summary>Gets or sets the SvgFallbackPaintServer(SvgPaintServer, IEnumerable.</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgFallbackPaintServer"/> class with the specified parameters.</summary>
    public SvgFallbackPaintServer(SvgPaintServer primary, IEnumerable<SvgPaintServer> fallbacks) : this()
    {
        _fallbacks = fallbacks;
        _primary = primary;
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return base.DeepCopy<SvgFallbackPaintServer>();
    }

    /// <summary>Gets or sets the DeepCopy.</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy<T>()
    {
        var newObj = base.DeepCopy<T>() as SvgFallbackPaintServer;

        newObj._primary = _primary?.DeepCopy() as SvgPaintServer;
        if (_fallbacks != null)
        {
            var fallbacks = new List<SvgPaintServer>();
            foreach (var server in _fallbacks)
                fallbacks.Add(server.DeepCopy() as SvgPaintServer);
            newObj._fallbacks = fallbacks;
        }
        return newObj;
    }
}
