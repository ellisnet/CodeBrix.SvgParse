using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;

/// <summary>Gets or sets the SvgTransformCollection.</summary>
/// <summary>Represents the <see cref="SvgTransformCollection"/> class.</summary>
[TypeConverter(typeof(SvgTransformConverter))]
public partial class SvgTransformCollection : List<SvgTransform>, ICloneable
{
    private void AddItem(SvgTransform item)
    {
        base.Add(item);
    }

    /// <summary>Gets or sets the Add(SvgTransform).</summary>
    /// <summary>Adds the specified item.</summary>
    public new void Add(SvgTransform item)
    {
        AddItem(item);
        OnTransformChanged();
    }

    /// <summary>Gets or sets the AddRange(IEnumerable.</summary>
    /// <summary>Adds the specified item.</summary>
    public new void AddRange(IEnumerable<SvgTransform> collection)
    {
        base.AddRange(collection);
        OnTransformChanged();
    }

    /// <summary>Gets or sets the Remove(SvgTransform).</summary>
    /// <summary>Removes the specified item.</summary>
    public new void Remove(SvgTransform item)
    {
        base.Remove(item);
        OnTransformChanged();
    }

    /// <summary>Gets or sets the RemoveAt(int).</summary>
    /// <summary>Removes the specified item.</summary>
    public new void RemoveAt(int index)
    {
        base.RemoveAt(index);
        OnTransformChanged();
    }

    /// <summary>Gets or sets the Equals(object).</summary>
    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (Count == 0 && Count == base.Count) // default will be an empty list
            return true;
        return base.Equals(obj);
    }

    /// <summary>Gets or sets the GetHashCode().</summary>
    /// <inheritdoc />
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    /// <summary>Gets or sets the this[int].</summary>
    /// <summary>Gets or sets the element at the specified index.</summary>
    public new SvgTransform this[int i]
    {
        get { return base[i]; }
        set
        {
            var oldVal = base[i];
            base[i] = value;
            if (oldVal != value)
                OnTransformChanged();
        }
    }

    /// <summary>
    /// Fired when an SvgTransform has changed
    /// </summary>
    public event EventHandler<AttributeEventArgs> TransformChanged;

    /// <summary>Gets or sets the OnTransformChanged().</summary>
    protected void OnTransformChanged()
    {
        var handler = TransformChanged;
        if (handler != null)
            // make a copy of the current value to avoid collection changed exceptions
            handler(this, new AttributeEventArgs { Attribute = "transform", Value = Clone() });
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <summary>Performs the Clone() operation.</summary>
    public object Clone()
    {
        var result = new SvgTransformCollection();
        foreach (var transform in this)
             result.AddItem(transform.Clone() as SvgTransform);
         return result;
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        if (Count < 1)
            return string.Empty;
        return string.Join(" ", (from t in this select t.ToString()).ToArray());
    }
}
