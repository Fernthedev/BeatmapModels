using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class V3BeatmapObject<T> : V3CustomBeatmapItem<T>, IBeatmapObject where T : class, IObjectCustomData
{
    protected V3BeatmapObject(IDictionary<string, JToken>? unserializedData, float time, T? typedCustomData, int lineIndex, int lineLayer) : base(unserializedData, time, typedCustomData)
    {
        LineIndex = lineIndex;
        LineLayer = lineLayer;
    }


    [JsonProperty("x")]
    public int LineIndex
    {
        get;
        set;
    }


    [JsonProperty("y")] 
    public int LineLayer
    {
        get;
        set;
    }
}