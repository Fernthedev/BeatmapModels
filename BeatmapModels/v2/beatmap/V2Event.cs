using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2BasicEvent : V2CustomBeatmapItem<V2EventCustomData>, IBasicEvent
{
    public V2BasicEvent(IDictionary<string, JToken>? unserializedData, float time, V2EventCustomData? typedCustomData,
        BeatmapEventType type, int value, float? floatValue) : base(unserializedData, time, typedCustomData)
    {
        Type = type;
        Value = value;
        FloatValue = floatValue;
    }

    public override IBeatmapJSON Clone()
    {
        return new V2BasicEvent(new Dictionary<string, JToken>(UnserializedData), Time,
            CustomData?.Clone() as V2EventCustomData, Type, Value, FloatValue);
    }

    [JsonProperty("_type")] 
    public BeatmapEventType Type { get; set; }

    [JsonProperty("_value")] 
    public int Value { get; set; }

    [JsonProperty("_floatValue")] 
    public float? FloatValue { get; set; }

    [JsonIgnore]
    public IEventCustomData? CustomData
    {
        get => TypedCustomData;
        set => CustomDataWrap(value);
    }
}