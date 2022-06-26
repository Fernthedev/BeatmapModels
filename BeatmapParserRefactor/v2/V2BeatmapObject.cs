
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public abstract class V2BeatmapObject<T> : V2CustomBeatmapItem<T>, IBeatmapObject where T: class, IObjectCustomData
{
    public V2BeatmapObject(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }



    public int LineIndex { get => UnserializedData["_lineIndex"].ToObject<int>(); set => UnserializedData["_lineLayer"] = JToken.FromObject(value); } 

}

