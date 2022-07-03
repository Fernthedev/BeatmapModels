using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3BasicEvent : V3CustomBeatmapItem<V3EventCustomData>, IBasicEvent
{
    public V3BasicEvent(IDictionary<string, JToken>? unserializedData, float time, V3EventCustomData? typedCustomData,
        BeatmapEventType type, int value, float? floatValue) : base(unserializedData, time, typedCustomData)
    {
        Type = type;
        Value = value;
        FloatValue = floatValue;
    }

    public override IBeatmapJSON Clone()
    {
        return new V3BasicEvent(new Dictionary<string, JToken>(UnserializedData), Time,
            CustomData?.Clone() as V3EventCustomData, Type, Value, FloatValue);
    }

    [JsonProperty("et")] 
    public BeatmapEventType Type { get; set; }

    [JsonProperty("i")] 
    public int Value { get; set; }

    [JsonProperty("f")] 
    public float? FloatValue { get; set; }

    [JsonIgnore]
    public IEventCustomData? CustomData
    {
        get => TypedCustomData;
        set => CustomDataWrap(value);
    }
}