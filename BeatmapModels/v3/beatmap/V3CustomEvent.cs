using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3CustomEvent : V3CustomBeatmapItem<V3CustomEventCustomData>, ICustomEvent
{
    public V3CustomEvent(IDictionary<string, JToken>? unserializedData, float time,
        V3CustomEventCustomData? typedCustomData, string type) : base(unserializedData, time, typedCustomData)
    {
        Type = type;
    }

    public override IBeatmapJSON Clone()
    {
        return new V3CustomEvent(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V3CustomEventCustomData, Type);
    }

    [JsonProperty("_type")]
    public string Type { get; set; }

    [JsonIgnore]
    public ICustomEventCustomData? CustomData
    {
        get => TypedCustomData;
        set => CustomDataWrap(value);
    }
}