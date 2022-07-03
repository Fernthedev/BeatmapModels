using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2CustomEvent : V2CustomBeatmapItem<V2CustomEventCustomData>, ICustomEvent
{
    public V2CustomEvent(IDictionary<string, JToken>? unserializedData, float time, V2CustomEventCustomData? typedCustomData, string type) : base(unserializedData, time, typedCustomData)
    {
        Type = type;
    }

    public override IBeatmapJSON Clone()
    {
        return new V2CustomEvent(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V2CustomEventCustomData, Type);
    }

    [JsonProperty("_type")]
    public string Type
    {
        get;
        set;
    }

    [JsonIgnore]
    public ICustomEventCustomData? CustomData
    {
        get => TypedCustomData;
        set => CustomDataWrap(value);
    }
}