using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class V2BeatmapItem : IBeatmapItem
{
    [Newtonsoft.Json.JsonIgnore]
    public bool isV3 => false;
    public abstract IBeatmapJSON Clone();

    protected V2BeatmapItem(IDictionary<string, JToken>? unserializedData, float time)
    {
        UnserializedData = unserializedData ?? new Dictionary<string, JToken>();
        Time = time;
    }
    
    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, JToken> UnserializedData { get; }
    
    [JsonProperty("_time")]
    public float Time
    {
        get;
        set;
    }
}

public abstract class V2CustomBeatmapItem<T> : V2BeatmapItem, ICustomBeatmapItem where T: class, ICustomData
{
    protected V2CustomBeatmapItem(IDictionary<string, JToken>? unserializedData, float time, T? typedCustomData) : base(unserializedData, time)
    {
        TypedCustomData = typedCustomData;
    }

    [Newtonsoft.Json.JsonIgnore]
    public ICustomData? UntypedCustomData
    {
        get => TypedCustomData;
        set => TypedCustomData = CustomDataWrap(value); // TODO: Make this initialize T with the data
    }

    [JsonProperty("_customData")]
    protected T? TypedCustomData
    {
        get;
        set;
    }

    protected T? CustomDataWrap(ICustomData? data)
    {
        return data switch
        {
            null => null,
            T customData => customData,
            _ => Internal_CustomDataWrap(data)
        };
    }

    protected abstract T Internal_CustomDataWrap(ICustomData data);
}
