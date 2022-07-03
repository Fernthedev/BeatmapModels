using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class V2BeatmapItem : IBeatmapItem
{
    protected V2BeatmapItem(IDictionary<string, JToken>? unserializedData, float time)
    {
        UnserializedData = unserializedData ?? new Dictionary<string, JToken>();
        Time = time;
    }

    [JsonIgnore] public bool isV3 => false;

    public abstract IBeatmapJSON Clone();

    [JsonExtensionData] public IDictionary<string, JToken> UnserializedData { get; }

    [JsonProperty("_time")] public float Time { get; set; }

    public int CompareTo(IBeatmapItem? other)
    {
        return other == null ? 1 : Time.CompareTo(other.Time);
    }
}

public abstract class V2CustomBeatmapItem<T> : V2BeatmapItem, ICustomBeatmapItem where T : class, ICustomData
{
    protected V2CustomBeatmapItem(IDictionary<string, JToken>? unserializedData, float time, T? typedCustomData) : base(
        unserializedData, time)
    {
        TypedCustomData = typedCustomData;
    }

    [JsonProperty("_customData")] 
    protected T? TypedCustomData { get; set; }

    [JsonIgnore]
    public ICustomData? UntypedCustomData
    {
        get => TypedCustomData;
        set => TypedCustomData = CustomDataWrap(value); // TODO: Make this initialize T with the data
    }

    protected T? CustomDataWrap(ICustomData? data)
    {
        return data switch
        {
            null => null,
            T customData => customData,
            _ => throw new InvalidCastException($"Expected type {typeof(T)}, got {data.GetType()}")
        };
    }
}