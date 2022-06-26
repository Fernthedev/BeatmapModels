
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2CustomEvent : V2CustomBeatmapItem<V2CustomEventCustomData>, ICustomEvent
{

    public V2CustomEvent(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }
    
    public override IBeatmapJSON Clone() => new V2CustomEvent(new Dictionary<string, JToken>(UnserializedData));

    public string Type
    {
        get => UnserializedData["_type"].ToObject<string>();
        set => UnserializedData["_type"] = value;
    }

    public ICustomEventCustomData CustomData
    {
        get => TypedCustomData;
        set => SetCustomData(value);
    }


}

