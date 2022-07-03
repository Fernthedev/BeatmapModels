using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2Obstacle : V2BeatmapObject<V2ObstacleCustomData>, IObstacle
{
    public V2Obstacle(IDictionary<string, JToken>? unserializedData, float time, V2ObstacleCustomData? typedCustomData, int lineIndex, int type, float duration, int width) : base(unserializedData, time, typedCustomData, lineIndex)
    {
        Type = type;
        Duration = duration;
        Width = width;
    }

    public override IBeatmapJSON Clone()
    {
        return new V2Obstacle(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V2ObstacleCustomData, LineIndex, Type, Duration, Width);
    }

    [JsonProperty("_type")]
    public int Type
    {
        get;
        set;
    }

    [JsonProperty("_duration")]
    public float Duration
    {
        get;
        set;
    }


    [JsonProperty("_width")]
    public int Width
    {
        get;
        set;
    }

    [JsonIgnore]
    public IObstacleCustomData? CustomData
    {
        get => TypedCustomData;
        set => CustomDataWrap(value);
    }
}