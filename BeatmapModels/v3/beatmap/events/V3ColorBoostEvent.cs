using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3ColorBoostEvent : V3CustomBeatmapItem
{
    public V3ColorBoostEvent(IDictionary<string, JToken>? unserializedData, float time, ICustomData? untypedCustomData,
        bool boost) : base(unserializedData, time, untypedCustomData)
    {
        Boost = boost;
    }


    [JsonProperty("o")]
    public bool Boost { get; set; }

    public override IBeatmapJSON Clone()
    {
        return new V3ColorBoostEvent(UnserializedData, Time, UntypedCustomData, Boost);
    }
}