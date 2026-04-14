using System;

namespace CodeBrix.SvgParse.Exceptions; //Was previously: namespace Svg.Exceptions;

/// <summary>Gets or sets the SvgMemoryException.</summary>
/// <summary>Represents the <see cref="SvgMemoryException"/> class.</summary>
[Serializable]
public class SvgMemoryException : Exception
{
    /// <summary>Gets or sets the SvgMemoryException().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgMemoryException"/> class with the specified parameters.</summary>
    public SvgMemoryException() { }
    /// <summary>Gets or sets the SvgMemoryException(string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgMemoryException"/> class with the specified parameters.</summary>
    public SvgMemoryException(string message) : base(message) { }
    /// <summary>Gets or sets the SvgMemoryException(string, Exception).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgMemoryException"/> class with the specified parameters.</summary>
    public SvgMemoryException(string message, Exception inner) : base(message, inner) { }

}
