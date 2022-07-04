using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3RotationEventData : V3CustomBeatmapItem
{
    public V3RotationEventData(IDictionary<string, JToken>? unserializedData, float time, ICustomData? untypedCustomData, int executionTime, float rotation) : base(unserializedData, time, untypedCustomData)
    {
        ExecutionTime = executionTime;
        Rotation = rotation;
    }


    // TODO: USE ENUM
    [JsonProperty("e")] 
    public int ExecutionTime  { get; set; }
    
    [JsonProperty("r")]

    public float Rotation { get; set; }
    
    public override IBeatmapJSON Clone()
    {
        return new V3RotationEventData(UnserializedData, Time, UntypedCustomData, ExecutionTime, Rotation);
    }

}