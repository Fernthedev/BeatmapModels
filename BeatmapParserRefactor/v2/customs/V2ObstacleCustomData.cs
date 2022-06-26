
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2ObstacleCustomData : V2ObjectCustomData, IObstacleCustomData
{
    public V2ObstacleCustomData(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }

    public override IBeatmapJSON Clone() => new V2ObstacleCustomData(new Dictionary<string, JToken>(UnserializedData));
}

