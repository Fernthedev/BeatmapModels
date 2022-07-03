using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2Event : V2CustomBeatmapItem<V2EventCustomData>, IEvent
{
    public V2Event(IDictionary<string, JToken>? unserializedData, float time, V2EventCustomData? typedCustomData,
        int type, int value, float? floatValue) : base(unserializedData, time, typedCustomData)
    {
        Type = type;
        Value = value;
        FloatValue = floatValue;
    }

    public override IBeatmapJSON Clone()
    {
        return new V2Event(new Dictionary<string, JToken>(UnserializedData), Time,
            CustomData?.Clone() as V2EventCustomData, Type, Value, FloatValue);
    }

    [JsonProperty("_type")] 
    public int Type { get; set; }

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