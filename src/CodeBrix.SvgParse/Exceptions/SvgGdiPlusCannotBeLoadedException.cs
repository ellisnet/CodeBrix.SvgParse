using System;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgGdiPlusCannotBeLoadedException.</summary>
/// <summary>Represents the <see cref="SvgGdiPlusCannotBeLoadedException"/> class.</summary>
[Serializable]
public class SvgGdiPlusCannotBeLoadedException : Exception
{
    const string gdiErrorMsg = "Cannot initialize gdi+ libraries. This is likely to be caused by running on a non-Windows OS without proper gdi+ replacement. Please refer to the documentation for more details.";

    /// <summary>Gets or sets the SvgGdiPlusCannotBeLoadedException().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgGdiPlusCannotBeLoadedException"/> class with the specified parameters.</summary>
    public SvgGdiPlusCannotBeLoadedException() : base(gdiErrorMsg) { }
    /// <summary>Gets or sets the SvgGdiPlusCannotBeLoadedException(string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgGdiPlusCannotBeLoadedException"/> class with the specified parameters.</summary>
    public SvgGdiPlusCannotBeLoadedException(string message) : base(message) { }
    /// <summary>Gets or sets the SvgGdiPlusCannotBeLoadedException(Exception).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgGdiPlusCannotBeLoadedException"/> class with the specified parameters.</summary>
    public SvgGdiPlusCannotBeLoadedException(Exception inner) : base(gdiErrorMsg, inner) {}
    /// <summary>Gets or sets the SvgGdiPlusCannotBeLoadedException(string, Exception).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgGdiPlusCannotBeLoadedException"/> class with the specified parameters.</summary>
    public SvgGdiPlusCannotBeLoadedException(string message, Exception inner) : base(message, inner) { }

}
