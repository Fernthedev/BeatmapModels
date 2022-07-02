using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2Waypoint : V2BeatmapObject<V2WaypointCustomData>, IWaypoint
{
    public V2Waypoint(IDictionary<string, JToken>? unserializedData, float time, V2WaypointCustomData? typedCustomData, int lineIndex, int lineLayer, int offsetDirection) : base(unserializedData, time, typedCustomData, lineIndex)
    {
        LineLayer = lineLayer;
        OffsetDirection = offsetDirection;
    }

    public override IBeatmapJSON Clone()
    {
        return new V2Waypoint(new Dictionary<string, JToken>(UnserializedData), Time,
            new V2WaypointCustomData(TypedCustomData), LineIndex, LineLayer, OffsetDirection);
    }


    [JsonProperty("_lineLayer")]
    public int LineLayer
    {
        get;
        set;
    }

    [JsonProperty("_offsetDirection")]
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

    protected override V2WaypointCustomData Internal_CustomDataWrap(ICustomData data)
    {
        return new V2WaypointCustomData(data);
    }
}