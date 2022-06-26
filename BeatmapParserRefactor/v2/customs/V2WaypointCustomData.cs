
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2WaypointCustomData : V2ObjectCustomData
{
    public V2WaypointCustomData(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }

    public override IBeatmapJSON Clone() => new V2WaypointCustomData(new Dictionary<string, JToken>(UnserializedData));
}

