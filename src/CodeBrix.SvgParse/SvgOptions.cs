using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CodeBrix.SvgParse; //Was previously: namespace Svg;

/// <summary>Gets or sets the SvgOptions.</summary>
/// <summary>Represents the <see cref="SvgOptions"/> class.</summary>
public class SvgOptions : IDictionary<string, string>, ICloneable
{
    private readonly IDictionary<string, string> _properties;
    private Dictionary<string, string> _entities;

    /// <summary>Gets or sets the SvgOptions().</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgOptions"/> class.</summary>
    public SvgOptions()
    {
        _properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>Gets or sets the SvgOptions(Dictionary.</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgOptions"/> class with the specified parameters.</summary>
    public SvgOptions(Dictionary<string, string> entities)
        : this()
    {
        _entities = entities;
    }

    /// <summary>Gets or sets the SvgOptions(Dictionary.</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgOptions"/> class with the specified parameters.</summary>
    public SvgOptions(Dictionary<string, string> entities, string css)
        : this()
    {
        _entities = entities;
        this.SetValue(nameof(Css), css);
    }

    /// <summary>Gets or sets the SvgOptions(string).</summary>
    /// <summary>Initializes a new instance of the <see cref="SvgOptions"/> class with the specified parameters.</summary>
    public SvgOptions(string css)
        : this()
    {
        this.SetValue(nameof(Css), css);
    }

    /// <summary>Gets or sets the Entities.</summary>
    public Dictionary<string, string> Entities {
        get => _entities;
        set => _entities = value;
    }

    /// <summary>Gets or sets the Css.</summary>
    public string Css {
        get => this.GetValue(nameof(Css));
        set => this.SetValue(nameof(Css), value);
    }

    /// <summary>Gets or sets the this[string].</summary>
    /// <summary>Gets or sets the element at the specified index.</summary>
    public string this[string key]
    {
        get => this.GetValue(key, string.Empty);
        set => this.SetValue(key, value);
    }

    /// <summary>Gets or sets the Keys.</summary>
    public ICollection<string> Keys => _properties.Keys;

    /// <summary>Gets or sets the Values.</summary>
    public ICollection<string> Values => _properties.Values;

    /// <summary>Gets or sets the Count.</summary>
    public int Count => _properties.Count;

    /// <summary>Gets or sets the IsReadOnly.</summary>
    public bool IsReadOnly => _properties.IsReadOnly;

    /// <summary>Gets or sets the Add(string, string).</summary>
    /// <summary>Adds the specified item.</summary>
    public void Add(string key, string value)
    {
        if (key != null)
        {
            _properties.Add(key, value);
        }
    }

    /// <summary>Gets or sets the Add(KeyValuePair.</summary>
    /// <summary>Adds the specified item.</summary>
    public void Add(KeyValuePair<string, string> item)
    {
        this.Add(item.Key, item.Value);
    }

    /// <summary>Gets or sets the Clear().</summary>
    /// <summary>Performs the Clear() operation.</summary>
    public void Clear()
    {
        _properties.Clear();
    }

    /// <summary>Gets or sets the Contains(KeyValuePair.</summary>
    /// <summary>Determines whether the collection contains the specified item.</summary>
    public bool Contains(KeyValuePair<string, string> item)
    {
        return _properties.Contains(item);
    }

    /// <summary>Gets or sets the ContainsKey(string).</summary>
    /// <summary>Determines whether the collection contains the specified item.</summary>
    public bool ContainsKey(string key)
    {
        return _properties.ContainsKey(key);
    }

    /// <summary>Gets or sets the CopyTo(KeyValuePair.</summary>
    /// <summary>Performs the CopyTo(KeyValuePair operation.</summary>
    public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
    {
        _properties.CopyTo(array, arrayIndex);
    }

    /// <summary>Gets or sets the GetEnumerator().</summary>
    /// <summary>Gets the Enumerator().</summary>
    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return _properties.GetEnumerator();
    }

    /// <summary>Gets or sets the Remove(string).</summary>
    /// <summary>Removes the specified item.</summary>
    public bool Remove(string key)
    {
        return _properties.Remove(key);
    }

    /// <summary>Gets or sets the Remove(KeyValuePair.</summary>
    /// <summary>Removes the specified item.</summary>
    public bool Remove(KeyValuePair<string, string> item)
    {
        return _properties.Remove(item);
    }

    /// <summary>Gets or sets the TryGetValue(string, out string).</summary>
    /// <summary>Attempts to perform the TryGetValue(string, out string) operation.</summary>
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
    {
        return _properties.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_properties).GetEnumerator();
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }

    /// <summary>Gets or sets the Clone().</summary>
    /// <summary>Performs the Clone() operation.</summary>
    public SvgOptions Clone()
    {
        SvgOptions options = new SvgOptions();
        foreach (KeyValuePair<string, string> item in _properties)
        {
            options.Add(item);
        }
        if (_entities != null)
        {
            Dictionary<string, string> entities = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in _entities)
            {
                entities.Add(item.Key, item.Value);
            }
            options._entities = entities;
        }

        return options;
    }

    /// <summary>Gets or sets the GetValue(string, string).</summary>
    protected string GetValue(string key, string defaultVal = null)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return defaultVal;
        }
        if (_properties.TryGetValue(key, out string value))
        {
            return value;
        }

        return defaultVal;
    }

    /// <summary>Gets or sets the SetValue(string, string).</summary>
    protected void SetValue(string key, string value)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return;
        }
        _properties[key] = value;
    }
}
