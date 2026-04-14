using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CodeBrix.SvgParse.Pathing; //Was previously: namespace Svg.Pathing;

/// <summary>Gets or sets the SvgPathSegmentList.</summary>
/// <summary>Represents the <see cref="SvgPathSegmentList"/> class.</summary>
[TypeConverter(typeof(SvgPathBuilder))]
public sealed class SvgPathSegmentList : IList<SvgPathSegment>, ICloneable
{
    private readonly List<SvgPathSegment> _segments = new List<SvgPathSegment>();

    /// <summary>Gets or sets the Owner.</summary>
    public ISvgPathElement Owner { get; set; }

    /// <summary>Gets or sets the First.</summary>
    public SvgPathSegment First
    {
        get { return _segments[0]; }
    }

    /// <summary>Gets or sets the Last.</summary>
    public SvgPathSegment Last
    {
        get { return _segments[_segments.Count - 1]; }
    }

    /// <summary>Gets or sets the IndexOf(SvgPathSegment).</summary>
    /// <summary>Performs the IndexOf(SvgPathSegment) operation.</summary>
    public int IndexOf(SvgPathSegment item)
    {
        return _segments.IndexOf(item);
    }

    /// <summary>Gets or sets the Insert(int, SvgPathSegment).</summary>
    /// <summary>Performs the Insert(int, SvgPathSegment) operation.</summary>
    public void Insert(int index, SvgPathSegment item)
    {
        _segments.Insert(index, item);
        Owner?.OnPathUpdated();
    }

    /// <summary>Gets or sets the RemoveAt(int).</summary>
    /// <summary>Removes the specified item.</summary>
    public void RemoveAt(int index)
    {
        _segments.RemoveAt(index);
        Owner?.OnPathUpdated();
    }

    /// <summary>Gets or sets the this[int].</summary>
    /// <summary>Gets or sets the element at the specified index.</summary>
    public SvgPathSegment this[int index]
    {
        get { return _segments[index]; }
        set
        {
            _segments[index] = value;
            Owner?.OnPathUpdated();
        }
    }

    /// <summary>Gets or sets the Add(SvgPathSegment).</summary>
    /// <summary>Adds the specified item.</summary>
    public void Add(SvgPathSegment item)
    {
        _segments.Add(item);
        Owner?.OnPathUpdated();
    }

    /// <summary>Gets or sets the Clear().</summary>
    /// <summary>Performs the Clear() operation.</summary>
    public void Clear()
    {
        _segments.Clear();
    }

    /// <summary>Gets or sets the Contains(SvgPathSegment).</summary>
    /// <summary>Determines whether the collection contains the specified item.</summary>
    public bool Contains(SvgPathSegment item)
    {
        return _segments.Contains(item);
    }

    /// <summary>Gets or sets the CopyTo(SvgPathSegment[], int).</summary>
    /// <summary>Performs the CopyTo(SvgPathSegment[], int) operation.</summary>
    public void CopyTo(SvgPathSegment[] array, int arrayIndex)
    {
        _segments.CopyTo(array, arrayIndex);
    }

    /// <summary>Gets or sets the Count.</summary>
    public int Count
    {
        get { return _segments.Count; }
    }

    /// <summary>Gets or sets the IsReadOnly.</summary>
    public bool IsReadOnly
    {
        get { return false; }
    }

    /// <summary>Gets or sets the Remove(SvgPathSegment).</summary>
    /// <summary>Removes the specified item.</summary>
    public bool Remove(SvgPathSegment item)
    {
        var removed = _segments.Remove(item);

        if (removed)
            Owner?.OnPathUpdated();

        return removed;
    }

    /// <summary>Gets or sets the GetEnumerator().</summary>
    /// <summary>Gets the Enumerator().</summary>
    public IEnumerator<SvgPathSegment> GetEnumerator()
    {
        return _segments.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _segments.GetEnumerator();
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <summary>Performs the Clone() operation.</summary>
    public object Clone()
    {
        var segments = new SvgPathSegmentList();
        foreach (var segment in this)
            segments.Add(segment.Clone());
        return segments;
    }

    /// <summary>Gets or sets the ToString().</summary>
    /// <inheritdoc />
    public override string ToString()
    {
        return string.Join(" ", this.Select(p => p.ToString()));
    }
}

/// <summary>Gets or sets the ISvgPathElement.</summary>
/// <summary>Defines the <see cref="ISvgPathElement"/> interface.</summary>
public interface ISvgPathElement
{
    /// <summary>Gets or sets the OnPathUpdated().</summary>
    void OnPathUpdated();
}
