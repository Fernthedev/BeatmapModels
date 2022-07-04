using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3Obstacle : V3BeatmapObject<V3ObstacleCustomData>, IObstacle
{
    public V3Obstacle(IDictionary<string, JToken>? unserializedData, float time, V3ObstacleCustomData? typedCustomData,
        int lineIndex, int lineLayer, float duration, int width, int height) : base(unserializedData, time,
        typedCustomData, lineIndex, lineLayer)
    {
        Duration = duration;
        Width = width;
        Height = height;
    }

    [JsonProperty("h")]
    public int Height { get; set; }

    public override IBeatmapJSON Clone()
    {
        return new V3Obstacle(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V3ObstacleCustomData, LineIndex, LineLayer, Duration, Width, Height);
    }


    [JsonIgnore]
    public int Type
    {
        get => Height;
        set => Height = value;
    }

    [JsonProperty("d")]
    public float Duration { get; set; }


    [JsonProperty("w")]
    public int Width { get; set; }

    [JsonIgnore]
    public IObstacleCustomData? CustomData
    {
        get => TypedCustomData;
        set => CustomDataWrap(value);
    }
}