
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2Obstacle : V2BeatmapObject<V2ObstacleCustomData>, IObstacle
{
    public V2Obstacle(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }
    public override IBeatmapJSON Clone() => new V2Obstacle(new Dictionary<string, JToken>(UnserializedData));

    public int Type
    {
        get => UnserializedData["_type"].ToObject<int>();
        set => UnserializedData["_type"] = JToken.FromObject(value);
    }
    
    public float Duration
    {
        get => UnserializedData["_duration"].ToObject<float>();
        set => UnserializedData["_duration"] = JToken.FromObject(value);
    }


    public int Width
    {
        get => UnserializedData["_width"].ToObject<int>();
        set => UnserializedData["_width"] = JToken.FromObject(value);
    }

    public IObstacleCustomData CustomData { get => TypedCustomData; set => SetCustomData(value); }
}

