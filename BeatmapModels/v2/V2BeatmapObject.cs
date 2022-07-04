using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class V2BeatmapObject<T> : V2CustomBeatmapItem<T>, IBeatmapObject where T : class, IObjectCustomData
{
    protected V2BeatmapObject(IDictionary<string, JToken>? unserializedData, float time, T? typedCustomData,
        int lineIndex) : base(unserializedData, time, typedCustomData)
    {
        LineIndex = lineIndex;
    }


    [JsonProperty("_lineIndex")]
    public int LineIndex { get; set; }
}