using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class AbstractCustomData : Dictionary<string, JToken?>, ICustomData
{
    protected AbstractCustomData(IDictionary<string, JToken?> dictionary) : base(dictionary)
    {
    }

    protected AbstractCustomData()
    {
    }

    protected AbstractCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }

    [JsonIgnore] public abstract bool isV3 { get; }

    public abstract IBeatmapJSON Clone();

    [JsonIgnore]
    public IDictionary<string, JToken> UnserializedData
    {
        get => this;
        set
        {
            Clear();
            // Fallback path for IEnumerable that isn't a non-subclassed Dictionary<TKey,TValue>.
            foreach (var pair in value) Add(pair.Key, pair.Value);
        }
    }

    // Sadly can't override :(
    public new JToken? this[string key]
    {
        get => Get(key);
        set => base[key] = value;
    }

    public abstract ICustomData ShallowClone();

    public abstract ICustomData DeepCopy();

    protected JToken? Get(string key)
    {
        return TryGetValue(key, out var val) ? val : null;
    }

    protected T? Get<T>(string key) where T : JToken
    {
        return TryGetValue(key, out var val) ? (T)val! : null;
    }

    protected T? GetObject<T>(string key) where T : class
    {
        return TryGetValue(key, out var val) ? val.ToObject<T>() : null;
    }

    protected JToken? GetOrAssign<T>(string key, Func<T?, JToken?> assignDefault, T? t = default)
    {
        if (TryGetValue(key, out var val))
            return val;
        return this[key] = assignDefault(t);
    }
    //
    // public IEnumerator<KeyValuePair<string, JToken>> GetEnumerator() => UnserializedData.GetEnumerator();
    //
    // IEnumerator IEnumerable.GetEnumerator() => UnserializedData.GetEnumerator();
    //
    // public void Add(string key, JToken value) => UnserializedData.Add(key, value);
    //
    // public bool ContainsKey(string key) => UnserializedData.ContainsKey(key);
    // public bool Remove(string key) => UnserializedData.Remove(key);
    //
    // public bool TryGetValue(string key, out JToken value) => UnserializedData.TryGetValue(key, out value);
    //
    // public JToken this[string key]
    // {
    //     get => UnserializedData[key];
    //     set => UnserializedData[key] = value;
    // }
    //
    // public ICollection<string> Keys => UnserializedData.Keys;
    // public ICollection<JToken> Values => UnserializedData.Values;
    //
    // public void Add(KeyValuePair<string, JToken> item) => UnserializedData.Add(item);
    //
    // public void Clear() => UnserializedData.Clear();
    //
    // public bool Contains(KeyValuePair<string, JToken> item) => UnserializedData.Contains(item);
    //
    // public void CopyTo(KeyValuePair<string, JToken>[] array, int arrayIndex) =>
    //     UnserializedData.CopyTo(array, arrayIndex);
    //
    // public bool Remove(KeyValuePair<string, JToken> item) => UnserializedData.Remove(item);
    //
    // public int Count => UnserializedData.Count;
    // public bool IsReadOnly => UnserializedData.IsReadOnly;
}