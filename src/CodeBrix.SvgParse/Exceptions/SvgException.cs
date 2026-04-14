using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgException.</summary>
/// <summary>Represents the <see cref="SvgException"/> class.</summary>
[Serializable]
public class SvgException : FormatException
{
    /// <summary>Gets or sets the SvgException().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgException"/> class with the specified parameters.</summary>
    public SvgException() { }
    /// <summary>Gets or sets the SvgException(string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgException"/> class with the specified parameters.</summary>
    public SvgException(string message) : base(message) { }
    /// <summary>Gets or sets the SvgException(string, Exception).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgException"/> class with the specified parameters.</summary>
    public SvgException(string message, Exception inner) : base(message, inner) { }

}

/// <summary>Gets or sets the SvgIDException.</summary>
/// <summary>Represents the <see cref="SvgIDException"/> class.</summary>
[Serializable]
public class SvgIDException : FormatException
{
    /// <summary>Gets or sets the SvgIDException().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDException"/> class with the specified parameters.</summary>
    public SvgIDException() { }
    /// <summary>Gets or sets the SvgIDException(string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDException"/> class with the specified parameters.</summary>
    public SvgIDException(string message) : base(message) { }
    /// <summary>Gets or sets the SvgIDException(string, Exception).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDException"/> class with the specified parameters.</summary>
    public SvgIDException(string message, Exception inner) : base(message, inner) { }

}

/// <summary>Gets or sets the SvgIDExistsException.</summary>
/// <summary>Represents the <see cref="SvgIDExistsException"/> class.</summary>
[Serializable]
public class SvgIDExistsException : SvgIDException
{
    /// <summary>Gets or sets the SvgIDExistsException().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDExistsException"/> class with the specified parameters.</summary>
    public SvgIDExistsException() { }
    /// <summary>Gets or sets the SvgIDExistsException(string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDExistsException"/> class with the specified parameters.</summary>
    public SvgIDExistsException(string message) : base(message) { }
    /// <summary>Gets or sets the SvgIDExistsException(string, Exception).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDExistsException"/> class with the specified parameters.</summary>
    public SvgIDExistsException(string message, Exception inner) : base(message, inner) { }

}

/// <summary>Gets or sets the SvgIDWrongFormatException.</summary>
/// <summary>Represents the <see cref="SvgIDWrongFormatException"/> class.</summary>
[Serializable]
public class SvgIDWrongFormatException : SvgIDException
{
    /// <summary>Gets or sets the SvgIDWrongFormatException().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDWrongFormatException"/> class with the specified parameters.</summary>
    public SvgIDWrongFormatException() { }
    /// <summary>Gets or sets the SvgIDWrongFormatException(string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDWrongFormatException"/> class with the specified parameters.</summary>
    public SvgIDWrongFormatException(string message) : base(message) { }
    /// <summary>Gets or sets the SvgIDWrongFormatException(string, Exception).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgIDWrongFormatException"/> class with the specified parameters.</summary>
    public SvgIDWrongFormatException(string message, Exception inner) : base(message, inner) { }

}
