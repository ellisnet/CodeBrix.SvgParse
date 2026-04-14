using System;
using System.ComponentModel;
using CodeBrix.SvgParse.Pathing;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgAnimationElement.</summary>
/// <summary>Represents the <see cref="SvgAnimationElement"/> class.</summary>
public abstract partial class SvgAnimationElement : SvgElement
{
    /// <summary>Gets or sets the ReferencedElement.</summary>
    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public virtual Uri ReferencedElement
    {
        get { return GetAttribute<Uri>("href", false); }
        set { Attributes["href"] = value; }
    }

    /// <summary>Gets or sets the TargetElement.</summary>
    public virtual SvgElement TargetElement
    {
        get
        {
            if (ReferencedElement != null)
            {
                return OwnerDocument?.IdManager.GetElementById(ReferencedElement);
            }

            return Parent;
        }
    }

    /// <summary>Gets or sets the RequiredFeatures.</summary>
    [SvgAttribute("requiredFeatures")]
    public virtual string RequiredFeatures
    {
        get { return GetAttribute<string>("requiredFeatures", false); }
        set { Attributes["requiredFeatures"] = value; }
    }

    /// <summary>Gets or sets the RequiredExtensions.</summary>
    [SvgAttribute("requiredExtensions")]
    public virtual string RequiredExtensions
    {
        get { return GetAttribute<string>("requiredExtensions", false); }
        set { Attributes["requiredExtensions"] = value; }
    }

    /// <summary>Gets or sets the SystemLanguage.</summary>
    [SvgAttribute("systemLanguage")]
    public virtual string SystemLanguage
    {
        get { return GetAttribute<string>("systemLanguage", false); }
        set { Attributes["systemLanguage"] = value; }
    }

    /// <summary>Gets or sets the ExternalResourcesRequired.</summary>
    [SvgAttribute("externalResourcesRequired")]
    public virtual bool ExternalResourcesRequired
    {
        get { return GetAttribute("externalResourcesRequired", false, defaultValue: false); }
        set { Attributes["externalResourcesRequired"] = value; }
    }

    /// <summary>Gets or sets the Begin.</summary>
    [SvgAttribute("begin")]
    public virtual string Begin
    {
        get { return GetAttribute<string>("begin", false); }
        set { Attributes["begin"] = value; }
    }

    /// <summary>Gets or sets the Duration.</summary>
    [SvgAttribute("dur")]
    public virtual string Duration
    {
        get { return GetAttribute<string>("dur", false); }
        set { Attributes["dur"] = value; }
    }

    /// <summary>Gets or sets the End.</summary>
    [SvgAttribute("end")]
    public virtual string End
    {
        get { return GetAttribute<string>("end", false); }
        set { Attributes["end"] = value; }
    }

    /// <summary>Gets or sets the Minimum.</summary>
    [SvgAttribute("min")]
    public virtual string Minimum
    {
        get { return GetAttribute<string>("min", false); }
        set { Attributes["min"] = value; }
    }

    /// <summary>Gets or sets the Maximum.</summary>
    [SvgAttribute("max")]
    public virtual string Maximum
    {
        get { return GetAttribute<string>("max", false); }
        set { Attributes["max"] = value; }
    }

    /// <summary>Gets or sets the Restart.</summary>
    [SvgAttribute("restart")]
    public virtual SvgAnimationRestart Restart
    {
        get { return GetAttribute("restart", false, SvgAnimationRestart.Always); }
        set { Attributes["restart"] = value; }
    }

    /// <summary>Gets or sets the RepeatCount.</summary>
    [SvgAttribute("repeatCount")]
    public virtual string RepeatCount
    {
        get { return GetAttribute<string>("repeatCount", false); }
        set { Attributes["repeatCount"] = value; }
    }

    /// <summary>Gets or sets the RepeatDuration.</summary>
    [SvgAttribute("repeatDur")]
    public virtual string RepeatDuration
    {
        get { return GetAttribute<string>("repeatDur", false); }
        set { Attributes["repeatDur"] = value; }
    }

    /// <summary>Gets or sets the AnimationFill.</summary>
    [SvgAttribute("fill")]
    public virtual SvgAnimationFill AnimationFill
    {
        get { return GetAttribute("fill", false, SvgAnimationFill.Remove); }
        set { Attributes["fill"] = value; }
    }

    /// <summary>Gets or sets the OnBeginScript.</summary>
    [SvgAttribute("onbegin")]
    public virtual string OnBeginScript
    {
        get { return GetAttribute<string>("onbegin", false); }
        set { Attributes["onbegin"] = value; }
    }

    /// <summary>Gets or sets the OnEndScript.</summary>
    [SvgAttribute("onend")]
    public virtual string OnEndScript
    {
        get { return GetAttribute<string>("onend", false); }
        set { Attributes["onend"] = value; }
    }

    /// <summary>Gets or sets the OnRepeatScript.</summary>
    [SvgAttribute("onrepeat")]
    public virtual string OnRepeatScript
    {
        get { return GetAttribute<string>("onrepeat", false); }
        set { Attributes["onrepeat"] = value; }
    }

    /// <summary>Gets or sets the OnLoadScript.</summary>
    [SvgAttribute("onload")]
    public virtual string OnLoadScript
    {
        get { return GetAttribute<string>("onload", false); }
        set { Attributes["onload"] = value; }
    }
}

/// <summary>Gets or sets the SvgAnimationAttributeElement.</summary>
/// <summary>Represents the <see cref="SvgAnimationAttributeElement"/> class.</summary>
public abstract partial class SvgAnimationAttributeElement : SvgAnimationElement
{
    /// <summary>Gets or sets the AnimationAttributeName.</summary>
    [SvgAttribute("attributeName")]
    public virtual string AnimationAttributeName
    {
        get { return GetAttribute<string>("attributeName", false); }
        set { Attributes["attributeName"] = value; }
    }

    /// <summary>Gets or sets the AttributeType.</summary>
    [SvgAttribute("attributeType")]
    public virtual SvgAnimationAttributeType AttributeType
    {
        get { return GetAttribute("attributeType", false, SvgAnimationAttributeType.Auto); }
        set { Attributes["attributeType"] = value; }
    }
}

/// <summary>Gets or sets the SvgAnimationValueElement.</summary>
/// <summary>Represents the <see cref="SvgAnimationValueElement"/> class.</summary>
public abstract partial class SvgAnimationValueElement : SvgAnimationAttributeElement
{
    /// <summary>Gets or sets the CalcMode.</summary>
    [SvgAttribute("calcMode")]
    public virtual SvgAnimationCalcMode CalcMode
    {
        get { return GetAttribute("calcMode", false, SvgAnimationCalcMode.Linear); }
        set { Attributes["calcMode"] = value; }
    }

    /// <summary>Gets or sets the Values.</summary>
    [SvgAttribute("values")]
    public virtual string Values
    {
        get { return GetAttribute<string>("values", false); }
        set { Attributes["values"] = value; }
    }

    /// <summary>Gets or sets the KeyTimes.</summary>
    [TypeConverter(typeof(SvgSemicolonNumberCollectionConverter))]
    [SvgAttribute("keyTimes")]
    public virtual SvgNumberCollection KeyTimes
    {
        get { return GetAttribute<SvgNumberCollection>("keyTimes", false); }
        set { Attributes["keyTimes"] = value; }
    }

    /// <summary>Gets or sets the KeySplines.</summary>
    [SvgAttribute("keySplines")]
    public virtual string KeySplines
    {
        get { return GetAttribute<string>("keySplines", false); }
        set { Attributes["keySplines"] = value; }
    }

    /// <summary>Gets or sets the From.</summary>
    [SvgAttribute("from")]
    public virtual string From
    {
        get { return GetAttribute<string>("from", false); }
        set { Attributes["from"] = value; }
    }

    /// <summary>Gets or sets the To.</summary>
    [SvgAttribute("to")]
    public virtual string To
    {
        get { return GetAttribute<string>("to", false); }
        set { Attributes["to"] = value; }
    }

    /// <summary>Gets or sets the By.</summary>
    [SvgAttribute("by")]
    public virtual string By
    {
        get { return GetAttribute<string>("by", false); }
        set { Attributes["by"] = value; }
    }

    /// <summary>Gets or sets the Additive.</summary>
    [SvgAttribute("additive")]
    public virtual SvgAnimationAdditive Additive
    {
        get { return GetAttribute("additive", false, SvgAnimationAdditive.Replace); }
        set { Attributes["additive"] = value; }
    }

    /// <summary>Gets or sets the Accumulate.</summary>
    [SvgAttribute("accumulate")]
    public virtual SvgAnimationAccumulate Accumulate
    {
        get { return GetAttribute("accumulate", false, SvgAnimationAccumulate.None); }
        set { Attributes["accumulate"] = value; }
    }
}

/// <summary>Gets or sets the SvgAnimate.</summary>
/// <summary>Represents the <see cref="SvgAnimate"/> class.</summary>
[SvgElement("animate")]
public partial class SvgAnimate : SvgAnimationValueElement
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgAnimate>();
    }
}

/// <summary>Gets or sets the SvgSet.</summary>
/// <summary>Represents the <see cref="SvgSet"/> class.</summary>
[SvgElement("set")]
public partial class SvgSet : SvgAnimationAttributeElement
{
    /// <summary>Gets or sets the To.</summary>
    [SvgAttribute("to")]
    public virtual string To
    {
        get { return GetAttribute<string>("to", false); }
        set { Attributes["to"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgSet>();
    }
}

/// <summary>Gets or sets the SvgAnimateMotion.</summary>
/// <summary>Represents the <see cref="SvgAnimateMotion"/> class.</summary>
[SvgElement("animateMotion")]
public partial class SvgAnimateMotion : SvgAnimationElement
{
    /// <summary>Gets or sets the CalcMode.</summary>
    [SvgAttribute("calcMode")]
    public virtual SvgAnimationCalcMode CalcMode
    {
        get { return GetAttribute("calcMode", false, SvgAnimationCalcMode.Paced); }
        set { Attributes["calcMode"] = value; }
    }

    /// <summary>Gets or sets the Values.</summary>
    [SvgAttribute("values")]
    public virtual string Values
    {
        get { return GetAttribute<string>("values", false); }
        set { Attributes["values"] = value; }
    }

    /// <summary>Gets or sets the KeyTimes.</summary>
    [TypeConverter(typeof(SvgSemicolonNumberCollectionConverter))]
    [SvgAttribute("keyTimes")]
    public virtual SvgNumberCollection KeyTimes
    {
        get { return GetAttribute<SvgNumberCollection>("keyTimes", false); }
        set { Attributes["keyTimes"] = value; }
    }

    /// <summary>Gets or sets the KeySplines.</summary>
    [SvgAttribute("keySplines")]
    public virtual string KeySplines
    {
        get { return GetAttribute<string>("keySplines", false); }
        set { Attributes["keySplines"] = value; }
    }

    /// <summary>Gets or sets the From.</summary>
    [SvgAttribute("from")]
    public virtual string From
    {
        get { return GetAttribute<string>("from", false); }
        set { Attributes["from"] = value; }
    }

    /// <summary>Gets or sets the To.</summary>
    [SvgAttribute("to")]
    public virtual string To
    {
        get { return GetAttribute<string>("to", false); }
        set { Attributes["to"] = value; }
    }

    /// <summary>Gets or sets the By.</summary>
    [SvgAttribute("by")]
    public virtual string By
    {
        get { return GetAttribute<string>("by", false); }
        set { Attributes["by"] = value; }
    }

    /// <summary>Gets or sets the Additive.</summary>
    [SvgAttribute("additive")]
    public virtual SvgAnimationAdditive Additive
    {
        get { return GetAttribute("additive", false, SvgAnimationAdditive.Replace); }
        set { Attributes["additive"] = value; }
    }

    /// <summary>Gets or sets the Accumulate.</summary>
    [SvgAttribute("accumulate")]
    public virtual SvgAnimationAccumulate Accumulate
    {
        get { return GetAttribute("accumulate", false, SvgAnimationAccumulate.None); }
        set { Attributes["accumulate"] = value; }
    }

    /// <summary>Gets or sets the PathData.</summary>
    [SvgAttribute("path")]
    public virtual SvgPathSegmentList PathData
    {
        get { return GetAttribute<SvgPathSegmentList>("path", false); }
        set { Attributes["path"] = value; }
    }

    /// <summary>Gets or sets the KeyPoints.</summary>
    [TypeConverter(typeof(SvgSemicolonNumberCollectionConverter))]
    [SvgAttribute("keyPoints")]
    public virtual SvgNumberCollection KeyPoints
    {
        get { return GetAttribute<SvgNumberCollection>("keyPoints", false); }
        set { Attributes["keyPoints"] = value; }
    }

    /// <summary>Gets or sets the Rotate.</summary>
    [SvgAttribute("rotate")]
    public virtual string Rotate
    {
        get { return GetAttribute("rotate", false, "0"); }
        set { Attributes["rotate"] = value; }
    }

    /// <summary>Gets or sets the Origin.</summary>
    [SvgAttribute("origin")]
    public virtual string Origin
    {
        get { return GetAttribute<string>("origin", false); }
        set { Attributes["origin"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgAnimateMotion>();
    }
}

/// <summary>Gets or sets the SvgAnimateColor.</summary>
/// <summary>Represents the <see cref="SvgAnimateColor"/> class.</summary>
[SvgElement("animateColor")]
public partial class SvgAnimateColor : SvgAnimationValueElement
{
    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgAnimateColor>();
    }
}

/// <summary>Gets or sets the SvgAnimateTransform.</summary>
/// <summary>Represents the <see cref="SvgAnimateTransform"/> class.</summary>
[SvgElement("animateTransform")]
public partial class SvgAnimateTransform : SvgAnimationValueElement
{
    /// <summary>Gets or sets the TransformType.</summary>
    [SvgAttribute("type")]
    public virtual SvgAnimateTransformType TransformType
    {
        get { return GetAttribute("type", false, SvgAnimateTransformType.Translate); }
        set { Attributes["type"] = value; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgAnimateTransform>();
    }
}

/// <summary>Gets or sets the SvgMPath.</summary>
/// <summary>Represents the <see cref="SvgMPath"/> class.</summary>
[SvgElement("mpath")]
public partial class SvgMPath : SvgElement
{
    /// <summary>Gets or sets the ReferencedPath.</summary>
    [SvgAttribute("href", SvgAttributeAttribute.XLinkNamespace)]
    public virtual Uri ReferencedPath
    {
        get { return GetAttribute<Uri>("href", false); }
        set { Attributes["href"] = value; }
    }

    /// <summary>Gets or sets the ExternalResourcesRequired.</summary>
    [SvgAttribute("externalResourcesRequired")]
    public virtual bool ExternalResourcesRequired
    {
        get { return GetAttribute("externalResourcesRequired", false, defaultValue: false); }
        set { Attributes["externalResourcesRequired"] = value; }
    }

    /// <summary>Gets or sets the TargetPath.</summary>
    public virtual SvgPath TargetPath
    {
        get { return OwnerDocument?.IdManager.GetElementById(ReferencedPath) as SvgPath; }
    }

    /// <summary>Gets or sets the DeepCopy().</summary>
    /// <inheritdoc />
    public override SvgElement DeepCopy()
    {
        return DeepCopy<SvgMPath>();
    }
}
