using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3Waypoint : V3BeatmapObject<V3WaypointCustomData>, IWaypoint
{
    public V3Waypoint(IDictionary<string, JToken>? unserializedData, float time, V3WaypointCustomData? typedCustomData, int lineIndex, int lineLayer, int offsetDirection) : base(unserializedData, time, typedCustomData, lineIndex, lineLayer)
    {
        LineLayer = lineLayer;
        OffsetDirection = offsetDirection;
    }

    public override IBeatmapJSON Clone()
    {
        return new V3Waypoint(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V3WaypointCustomData, LineIndex, LineLayer, OffsetDirection);
    }


    [JsonProperty("d")]
    public int OffsetDirection
    {
        get;
        set;
    }

    [JsonIgnore]
    public IObjectCustomData? CustomData
    {
        get => TypedCustomData;
        set => CustomDataWrap(value);
    }
}