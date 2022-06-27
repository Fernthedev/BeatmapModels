
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2Waypoint : V2BeatmapObject<V2WaypointCustomData>, IWaypoint
{
    public V2Waypoint(IDictionary<string, JToken>? unserializedData, float time, V2WaypointCustomData? typedCustomData) : base(unserializedData, time, typedCustomData)
    {
    }

    public override IBeatmapJSON Clone() => new V2Waypoint(new Dictionary<string, JToken>(UnserializedData), Time, new V2WaypointCustomData(TypedCustomData));


    public int LineLayer
    {
        get => UnserializedData["_lineLayer"].ToObject<int>();
        set => UnserializedData["_lineLayer"] = value;
    }
    public int OffsetDirection {         
        get => UnserializedData["_offsetDirection"].ToObject<int>();
        set => UnserializedData["_offsetDirection"] = value; 
    }

    public IObjectCustomData? CustomData { get => TypedCustomData; set => CustomDataWrap(value); }
    protected override V2WaypointCustomData Internal_CustomDataWrap(ICustomData data)
    {
        return new V2WaypointCustomData(data);
    }
}

