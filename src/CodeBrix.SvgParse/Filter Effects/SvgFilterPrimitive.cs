using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBrix.SvgParse.FilterEffects; //Was previously: namespace Svg.FilterEffects;

/// <summary>Gets or sets the SvgFilterPrimitive.</summary>
/// <summary>Represents the <see cref="SvgFilterPrimitive"/> class.</summary>
public abstract partial class SvgFilterPrimitive : SvgElement
{
    /// <summary>Gets or sets the SourceGraphic.</summary>
    /// <summary>The SourceGraphic constant value.</summary>
    public const string SourceGraphic = "SourceGraphic";
    /// <summary>Gets or sets the SourceAlpha.</summary>
    /// <summary>The SourceAlpha constant value.</summary>
    public const string SourceAlpha = "SourceAlpha";
    /// <summary>Gets or sets the BackgroundImage.</summary>
    /// <summary>The BackgroundImage constant value.</summary>
    public const string BackgroundImage = "BackgroundImage";
    /// <summary>Gets or sets the BackgroundAlpha.</summary>
    /// <summary>The BackgroundAlpha constant value.</summary>
    public const string BackgroundAlpha = "BackgroundAlpha";
    /// <summary>Gets or sets the FillPaint.</summary>
    /// <summary>The FillPaint constant value.</summary>
    public const string FillPaint = "FillPaint";
    /// <summary>Gets or sets the StrokePaint.</summary>
    /// <summary>The StrokePaint constant value.</summary>
    public const string StrokePaint = "StrokePaint";

    /// <summary>Gets or sets the X.</summary>
    [SvgAttribute("x")]
    public SvgUnit X
    {
        get { return GetAttribute("x", false, new SvgUnit(SvgUnitType.Percentage, 0f)); }
        set { Attributes["x"] = value; }
    }

    /// <summary>Gets or sets the Y.</summary>
    [SvgAttribute("y")]
    public SvgUnit Y
    {
        get { return GetAttribute("y", false, new SvgUnit(SvgUnitType.Percentage, 0f)); }
        set { Attributes["y"] = value; }
    }

    /// <summary>Gets or sets the Width.</summary>
    [SvgAttribute("width")]
    public SvgUnit Width
    {
        get { return GetAttribute("width", false, new SvgUnit(SvgUnitType.Percentage, 100f)); }
        set { Attributes["width"] = value; }
    }

    /// <summary>Gets or sets the Height.</summary>
    [SvgAttribute("height")]
    public SvgUnit Height
    {
        get { return GetAttribute("height", false, new SvgUnit(SvgUnitType.Percentage, 100f)); }
        set { Attributes["height"] = value; }
    }

    /// <summary>Gets or sets the Input.</summary>
    [SvgAttribute("in")]
    public string Input
    {
        get { return GetAttribute<string>("in", false); }
        set { Attributes["in"] = value; }
    }

    /// <summary>Gets or sets the Result.</summary>
    [SvgAttribute("result")]
    public string Result
    {
        get { return GetAttribute<string>("result", false); }
        set { Attributes["result"] = value; }
    }

    /// <summary>Gets or sets the Owner.</summary>
    protected SvgFilter Owner
    {
        get { return (SvgFilter)this.Parent; }
    }

}
