using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3BpmChangeEventData : V3CustomBeatmapItem
{
    public V3BpmChangeEventData(IDictionary<string, JToken>? unserializedData, float time, ICustomData? untypedCustomData, float bpm) : base(unserializedData, time, untypedCustomData)
    {
        Bpm = bpm;
    }


    [JsonProperty("m")] 
    public float Bpm { get; set; }

    public override IBeatmapJSON Clone()
    {
        return new V3BpmChangeEventData(UnserializedData, Time, UntypedCustomData, Bpm);
    }
}