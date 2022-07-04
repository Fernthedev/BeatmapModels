using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class V3BeatmapItem : IBeatmapItem
{
    protected V3BeatmapItem(IDictionary<string, JToken>? unserializedData, float time)
    {
        UnserializedData = unserializedData ?? new Dictionary<string, JToken>();
        Time = time;
    }

    [JsonIgnore] public bool isV3 => true;

    public abstract IBeatmapJSON Clone();

    [JsonExtensionData] public IDictionary<string, JToken> UnserializedData { get; }

    [JsonProperty("b")]
    public float Time { get; set; }

    public int CompareTo(IBeatmapItem? other)
    {
        return other == null ? 1 : Time.CompareTo(other.Time);
    }
}

public abstract class V3CustomBeatmapItem : V3BeatmapItem, ICustomBeatmapItem
{
    protected V3CustomBeatmapItem(IDictionary<string, JToken>? unserializedData, float time, ICustomData? untypedCustomData) : base(
        unserializedData, time)
    {
        UntypedCustomData = untypedCustomData;
    }

    [JsonProperty("customData")]
    public ICustomData? UntypedCustomData { get; set; }
}

public abstract class V3CustomBeatmapItem<T> : V3BeatmapItem, ICustomBeatmapItem where T : class, ICustomData
{
    protected V3CustomBeatmapItem(IDictionary<string, JToken>? unserializedData, float time, T? typedCustomData) : base(
        unserializedData, time)
    {
        TypedCustomData = typedCustomData;
    }

    [JsonProperty("customData")] 
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